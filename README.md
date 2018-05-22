
  
# OpenProtocolInterpreter  
[![Build status](https://ci.appveyor.com/api/projects/status/op72gr1k1vi04o35/branch/master?svg=true)](https://ci.appveyor.com/project/Rickedb/openprotocolintepreter/branch/master) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Rickedb/OpenProtocolIntepreter/master/LICENSE)
> OpenProtocol communication utility

## Work in progress:

* Testing up Version 2.0.0

> Missing version OpenProtocolInterpreter v1.0.0 ? [It's here!](https://github.com/Rickedb/OpenProtocolInterpreter/releases/tag/1.0.0)

## What is Open Protocol at all?

Open Protocol, as the name says, it's a protocol to communicate with Atlas Copco Tightening Controllers or whatever that implement that protocol.
Most common Tightening Controllers from Atlas Copco company are **PowerFocus4000** and **PowerMacs**.

*Although, some other companies adhered to use the same protocol.*

## What is OpenProtocolInterpreter?

OpenProtocolInterpreter is a **library that converts the ugly string** that came from Open Protocol packages, which is commonly called **MID**, to an **object**.
*"Substringing"* packages is such a boring thing to do, so let OpenProtocolIntepreter do it for you!

**[If you're curious, just take a look at their documentation.](https://github.com/Rickedb/OpenProtocolIntepreter/blob/master/docs/OpenProtocol_Specification.pdf)**

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
MIDIdentifier identifier = new MIDIdentifier();
string midPackage = @"00260004001         001802";
var myMid04 = identifier.IdentifyMid<MID_0004>(midPackage);
//MID 0004 is an error mid which contains which MID Failed and its error code
//Int value of the Failed Mid
int myFailedMid = myMid04.FailedMid; 
//An enum with Error Code
MID_0004.ErrorCode errorCode = myMid04.ErrorCode;
```   

It can generate an object from a string, but can it make it to the other way?? FOR SURE!
``` csharp
MID_0032 jobUploadRequest = new MID_0032();
jobUploadRequest.JobID = 1;

string package = jobUploadRequest.buildPackage();
//Generated package => 00220032001         01
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
var myMidIdentifier = new MIDIdentifier(new MID[]
                        {
                            new MID_0001(),
                            new MID_0002(),
                            new MID_0003(),
                            new MID_0004(),
                            new MID_0106()
                        });
//Will work:
MID_0004 myMid04 = myMidIdentifier.IdentifyMid<MID_0004>(package);  
//Won't work:
MID_0030 myMid30 = myMidIdentifier.IdentifyMid<MID_0030>(package);          
```

> In my conception you should always register used MIDs when you are the **Integrator**

#### Advanced Example

Declared a delegate:

``` csharp
protected delegate void ReceivedCommandActionDelegate(ReceivedMIDEventArgs e);
```
**ReceivedMIDEventArgs class**:
``` csharp
public class ReceivedMIDEventArgs : EventArgs
{
    public MID ReceivedMID { get; set; }
}
```
Created a method to register all those MID types by delegates:

``` csharp
protected Dictionary<Type, ReceivedCommandActionDelegate> RegisterOnAsyncReceivedMIDs()
{
    var receivedMids = new Dictionary<Type, ReceivedCommandActionDelegate>();
    receivedMids.Add(typeof(MID_0005), new ReceivedCommandActionDelegate(this.onCommandAcceptedReceived));
    receivedMids.Add(typeof(MID_0004), new ReceivedCommandActionDelegate(this.onErrorReceived));
    receivedMids.Add(typeof(MID_0071), new ReceivedCommandActionDelegate(this.onAlarmReceived));
    receivedMids.Add(typeof(MID_0061), new ReceivedCommandActionDelegate(this.onTighteningReceived));
    receivedMids.Add(typeof(MID_0035), new ReceivedCommandActionDelegate(this.onJobInfoReceived));
    return receivedMids;
}
```
What was done is registering in a dictionary the correspondent delegate for a determinated MID, once done that we just need to invoke the delegate everytime you face a desired MID.

When a package income:

``` csharp
protected void onPackageReceived(string message)
{
    try
    {
        var mid = this.DriverManager.IdentifyMidFromPackage(message);

        //Get Registered delegate for the MID that was identified
        var action = this.onReceivedMID.FirstOrDefault(x => x.Key == mid.GetType());
        
        if (action.Equals(default(KeyValuePair<Type, ReceivedCommandActionDelegate>)))
           return; //Stop if there is no delegate registered for the message that arrived

         action.Value(new ReceivedMIDEventArgs() { ReceivedMID = mid }); //Call delegate
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
protected void onTighteningReceived(ReceivedMIDEventArgs e)
{
    try
    {
        
        MID_0061 tighteningMid = e.ReceivedMID as MID_0061; //Converting to the right mid

        //This method just send the ack from tightening mid
        this.buildAndSendAcknowledge(tighteningMid); 
        Console.log("TIGHTENING ARRIVED")
     }
     catch (Exception ex)
     {
         Console.log(ex.Message);
     }
}

protected void buildAndSendAcknowledge(MID mid)
{
     this.tcpClient.GetStream().Write(new MID_0062().buildPackage()); //Send acknowledge to controller
}
```

### Tips

> Instantiate the **MIDIdentifier** class just once, it takes some time to build all the "chain thing", and you don't want to lose time instantiating it everytime a package arrives.

> **Controller Implementation Tip:** Always **TRY** to register used MIDs, not all Tightening Controllers use every available MID.

> **Integrator Implementation Tip:** Always **DO** register used MIDs, I'm pretty sure you won't need all of them to your application.