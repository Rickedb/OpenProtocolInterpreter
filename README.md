

  
# OpenProtocolInterpreter  
[![Build status](https://ci.appveyor.com/api/projects/status/op72gr1k1vi04o35/branch/master?svg=true)](https://ci.appveyor.com/project/Rickedb/openprotocolintepreter/branch/master) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Rickedb/OpenProtocolIntepreter/master/LICENSE)
> OpenProtocol communication utility

> Missing OpenProtocolInterpreter v1.0.0 ? [>It's here!<](https://github.com/Rickedb/OpenProtocolInterpreter/releases/tag/1.0.0)

## What is Open Protocol at all?

Open Protocol, as the name says, it's a protocol to communicate with Atlas Copco Tightening Controllers or whatever that implement that protocol.
Most common Tightening Controllers from Atlas Copco company are **PowerFocus4000** and **PowerMacs**.

*Although, some other companies adhered to use the same protocol.*

## What is OpenProtocolInterpreter?

OpenProtocolInterpreter is a **library that converts the ugly string** that came from Open Protocol packages, which is commonly called **MID**, to an **object**.
*"Substringing"* packages is such a boring thing to do, so let OpenProtocolIntepreter do it for you!

**[If you're curious, just take a look at their documentation.](https://github.com/Rickedb/OpenProtocolIntepreter/blob/master/docs/OpenProtocol_Specification.pdf)**

## Changelog for version 2.0.0

 1. Namespace "MIDs" removed, for more clean usings;
 2. Classes, methods and properties names changed (For example: MidIdentifier => MidInterpreter);
 3. All revisions added to all current Mids;
 4. Mid classes names changed from "MID_{number}" to "Mid{number}";
 5. All interfaces from Mids were made public, so now anyone can inject a custom mid to MidInterpreter;
 6. Enums moved to root namespace instead of each class having his own enum correspondent to their values;
 7. Converting does not work as before, it will convert it's value only when you trigger get, parsing became faster;
 8. DataValues cache get values for better performance;
 9. Parsing almost 50% faster than version 1.0.0.

## How does it work?

It's simple, you give us your string package and we deliver you an object, simple as that!

For example, let's imagine you received the following string package: 
``` csharp
string package = "00240005001         0018";
```

It's **MID 5**, so OpenProtocolIntepreter will return a **MID_0005** class for you with all his datafields and the package entire translated to an object.

## Let's see some examples of usage

A simple usage:

``` csharp
MidInterpreter interpreter = new MidInterpreter();
string midPackage = @"00260004001         001802";
var myMid04 = interpreter.Parse<Mid0004>(midPackage);
//MID 0004 is an error mid which contains which MID Failed and its error code
//Int value of the Failed Mid
int myFailedMid = myMid04.FailedMid;
//An enum with Error Code
Error errorCode = myMid04.ErrorCode;
```   

It can generate an object from a string, but can it make it to the other way?? FOR SURE!
``` csharp
Mid0032 jobUploadRequest = new Mid0032(1, 2); //Job id 1, revision 2
string package = jobUploadRequest.Pack();
//Generated package => 00240032002         0001
```  

## Get it on [NuGet](https://www.nuget.org/packages/OpenProtocolInterpreter)!
```
Install-Package OpenProtocolInterpreter
```

## Advanced Section!

Now we will get real!
Put one thing in mind, in real world we will always need to build something more complex than the dummies examples we give to you.
**With this in mind, this section is for you:**

#### How it was built?

Well, FYI it was all built accordingly with **Chain Of Responsabilities** design pattern, so we iterate among the **COMMON** and **ONLY COMMON MIDs.**
<dl>
    <dt>What do I mean by Common mid?</dt>
    <dd>The docs separate mids by categories, such as "Job MIDs", there will be, Job Info, Ack, Upload Request, etc.</dd>
    <dd>So we iterate only inside "Job Messages", not in all of available MIDs.</dd>
</dl>

#### MIDs Identifying Customization

We have several MIDs inside Open Protocol documentation, but do you really need all of them? 
The answer is... **NO!**

You will probably need only to use a range of MIDs, with this in mind, we did something to make things faster. You can tell us which MIDs we should considerate!

> *NOTE: You can register only mids you need to call "processPackage" method 

Here is an example:
``` csharp
string package = "00260004001         001802";
var myCustomInterpreter = new MidInterpreter(new Mid[]
                        {
                            new Mid0001(),
                            new Mid0002(),
                            new Mid0003(),
                            new Mid0004(),
                            new Mid0106()
                        });
//Will work:
Mid0004 myMid04 = myCustomInterpreter.Parse<Mid0004>(package);
//Won't work, will throw NotImplementedException:
Mid0030 myMid30 = myCustomInterpreter.Parse<Mid0030>(package);        
//Won't work, will throw InvalidCastException:
Mid0001 myMid01 = myCustomInterpreter.Parse<Mid0001>(package);
```
When you don't know which package will come, use ``` Parse ``` overload, not ``` Parse<DesiredMid> ```. If you want, take a look at the sample on this repository.
> In my conception you should always register used MIDs when you are the **Integrator**

#### Advanced Example

Declared a delegate:

``` csharp
protected delegate void ReceivedCommandActionDelegate(ReceivedMIDEventArgs e);
```
**ReceivedMIDEventArgs class**:
``` csharp
public class ReceivedMidEventArgs : EventArgs
{
    public Mid ReceivedMid { get; set; }
}
```
Created a method to register all those MID types by delegates:

``` csharp
protected Dictionary<Type, ReceivedCommandActionDelegate> RegisterOnAsyncReceivedMids()
{
    var receivedMids = new Dictionary<Type, ReceivedCommandActionDelegate>();
    receivedMids.Add(typeof(Mid0005), new ReceivedCommandActionDelegate(OnCommandAcceptedReceived));
    receivedMids.Add(typeof(Mid0004), new ReceivedCommandActionDelegate(OnErrorReceived));
    receivedMids.Add(typeof(Mid0071), new ReceivedCommandActionDelegate(OnAlarmReceived));
    receivedMids.Add(typeof(Mid0061), new ReceivedCommandActionDelegate(OnTighteningReceived));
    receivedMids.Add(typeof(Mid0035), new ReceivedCommandActionDelegate(OnJobInfoReceived));
    return receivedMids;
}
```
What was done is registering in a dictionary the correspondent delegate for a determinated MID, once done that we just need to invoke the delegate everytime you face a desired MID.

When a package income:

``` csharp
protected void OnPackageReceived(string message)
{
    try
    {
        //Parse to mid class
        var mid = Interpreter.Parse(message);

        //Get Registered delegate for the MID that was identified
        var action = OnReceivedMid.FirstOrDefault(x => x.Key == mid.GetType());
        
        if (action.Equals(default(KeyValuePair<Type, ReceivedCommandActionDelegate>)))
           return; //Stop if there is no delegate registered for the message that arrived

         action.Value(new ReceivedMidEventArgs() { ReceivedMid = mid }); //Call delegate
     }
     catch (Exception ex)
     {
        Console.log(ex.Message);
     }
}
```
This would call the registered delegate which you're sure what mid it is. 
For example when a **MID_0061** (last tightening) pop up, the  **onTighteningReceived** delegate will be called:

``` csharp
protected void OnTighteningReceived(ReceivedMidEventArgs e)
{
    try
    {
        Mid0061 tighteningMid = e.ReceivedMID as Mid0061; //Casting to the right mid

        //This method just send the ack from tightening mid
        BuildAndSendAcknowledge(tighteningMid); 
        Console.log("TIGHTENING ARRIVED")
     }
     catch (Exception ex)
     {
         Console.log(ex.Message);
     }
}

protected void BuildAndSendAcknowledge(Mid mid)
{
     TcpClient.GetStream().Write(new Mid0062().Pack()); //Send acknowledge to controller
}
```

### Tips

> Instantiate the **MIDIdentifier** class just once, it takes some time to build all the "chain thing", and you don't want to lose time instantiating it everytime a package arrives.

> **Controller Implementation Tip:** Always **TRY** to register used MIDs, not all Tightening Controllers use every available MID.

> **Integrator Implementation Tip:** Always **DO** register used MIDs, I'm pretty sure you won't need all of them to your application.


### List of still unavailable Mids

 - Mid 0006;
 - Mid 0008;
 - Mid 0009;
 - Mid 0700;
 - Mid 0900;
 - Mid 0901;
 - Mid 1201;
 - Mid 1202;
 - Mid 1203;
 - Mid 2500;
 - Mid 2501;
 - Mid 2504;
 - Mid 2505;
 - Mid 2600;
 - Mid 2601;
 - Mid 2602;
 - Mid 2603;
 - Mid 2604;
 - Mid 2605;
 - Mid 2606;
 - Mid 9997;
 - Mid 9998.

Feel free to fork and contribute to add any of those mids.

### Next Steps

 1. Add overload method to parse that uses byte[] instead of string;
 2. Add missing mids;
 3. Create wiki.
