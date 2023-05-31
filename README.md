<img src="https://github.com/Rickedb/OpenProtocolInterpreter/blob/master/media/logo.png?raw=true" width="550" alt="Open Protocol Interpreter" />

<h1>
   <a href="https://www.buymeacoffee.com/openprotocolitp">
    <img height="40" alt="Buy me a coffee" src="https://img.buymeacoffee.com/button-api/?text=Buy me a coffee&emoji=&slug=openprotocolitp&button_colour=FFDD00&font_colour=000000&font_family=Cookie&outline_colour=000000&coffee_colour=ffffff" />
   </a>
  <a href="https://opencollective.com/open-protocol-interpreter" alt="Financial Contributors on Open Collective">
    <img src="https://opencollective.com/open-protocol-interpreter/all/badge.svg?label=financial+contributors" />
  </a>
  <a href="https://github.com/Rickedb/OpenProtocolInterpreter/">
    <img src="https://github.com/rickedb/openprotocolinterpreter/workflows/master/badge.svg" />
  </a>
  <a href="https://raw.githubusercontent.com/Rickedb/OpenProtocolIntepreter/master/LICENSE">
    <img src= "https://img.shields.io/badge/license-MIT-blue.svg" alt="MIT">
  </a>
</h1>

  
> OpenProtocol communication utility

 1. [What is Open Protocol at all?](#what-is-open-protocol-at-all) 
 2. [What is OpenProtocolInterpreter?](#what-is-openprotocolinterpreter)
 3. [How does it work?](#how-does-it-work)
 4. [Usage examples](#lets-see-some-examples-of-usage)
 5. [Available on package managers](#get-it-on-nuget)
 6. [Advanced section](#advanced-section)
    * [How it was built?](#how-it-was-built)
    * [Customization](#mids-identifying-customization)
    * [Advanced example](#advanced-example)
7. [Tips](#tips)
8. [Contribute to the project](#contribute-to-the-project)
9. [Still unavailable mids](#list-of-still-unavailable-mids)


## What is Open Protocol at all?

Open Protocol, as the name says, it's a protocol to communicate with Atlas Copco Tightening Controllers or whatever that implement that protocol.
Most common Tightening Controllers from Atlas Copco company are **PowerFocus4000** and **PowerMacs**.

*Although, some other companies adhered to use the same protocol.*

## What is OpenProtocolInterpreter?

OpenProtocolInterpreter is a **library that converts the ugly string** that came from Open Protocol packages, which is commonly called **MID**, to an **object**.
*"Substringing"* packages is such a boring thing to do, so let OpenProtocolIntepreter do it for you!

**[If you're curious, just take a look at their documentation.](https://github.com/Rickedb/OpenProtocolIntepreter/blob/master/docs/OpenProtocol_Specification.pdf)**

## How does it work?

It's simple, you give us your byte[] or string package and we deliver you an object, simple as that!

For example, let's imagine you received the following string package: 
``` csharp
string package = "00240005001         0018";
```
It's **MID 5**, so OpenProtocolIntepreter will return a **Mid0005** class for you with all his datafields and the package entire translated to an object.

## Let's see some examples of usage

A simple usage:

``` csharp
var interpreter = new MidInterpreter();
var midPackage = @"00260004001         001802";
var myMid04 = interpreter.Parse<Mid0004>(midPackage);
//MID 0004 is an error mid which contains which MID Failed and its error code
//Int value of the Failed Mid
int myFailedMid = myMid04.FailedMid;
//An enum with Error Code
Error errorCode = myMid04.ErrorCode;
```   

It can generate an object from a string, but can it make it to the other way?? FOR SURE!
``` csharp
var jobUploadRequest = new Mid0032(1, 2); //Job id 1, revision 2
var package = jobUploadRequest.Pack();
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

It used to rely on **Chain Of Responsabilities** design pattern, but since we had some problems with instance references, it changed!
For now, instead of iterating through all Mids of the same category, it relies on a Dictionary, which every category knows which mid it attends, once it found it creates a new Instance via System.Reflection and parse it.

#### MIDs Identifying Customization

We have several MIDs inside Open Protocol documentation, but do you really need all of them? 
The answer is... **NO!**

You will probably need only to use a range of MIDs, with this in mind, we did something to make things faster. You can tell us which MIDs we should considerate!

> *NOTE: You can register only mids you need to call "Parse" method 

Here is an example:
``` csharp
string package = "00260004001         001802";
var myCustomInterpreter = new MidInterpreter()
								.UseAllMessages(new Type[]
		                        {
		                            typeof(Mid0001),
		                            typeof(Mid0002),
		                            typeof(Mid0003),
		                            typeof(Mid0004),
		                            typeof(Mid0106)
		                        });
//Will work:
var myMid04 = myCustomInterpreter.Parse<Mid0004>(package);
//Won't work, will throw NotImplementedException:
var myMid30 = myCustomInterpreter.Parse<Mid0030>(package);        
//Won't work, will throw InvalidCastException:
var myMid01 = myCustomInterpreter.Parse<Mid0001>(package);
```
When you don't know which package will come, use ``` Parse ``` overload, not ``` Parse<DesiredMid> ```. If you want, take a look at the sample on this repository.
> If necessary, there is a new overload where you can define if you're the controller or the integrator, which will automatically handle implemented mids

#### MIDs Overriding

Maybe you have a totally crazy controller that does not implement the Mid as the documentation says or you might want to inject your own Mid inheriting another Mid, 
so you can customize it and add more properties to handle some conversions. Anyway, if you need that, it's possible to override!

Here is an example:
``` csharp
//This will override Mid 81 with my custom Mid
var _midInterpreter new MidInterpreter().UseAllMessages()
                                        .UseTimeMessages(new Dictionary<int, Type>() { { 81, typeof(OverridedMid0081) } });


public class OverridedMid0081 : Mid0081
{
    public string FormattedDate
    {
        get => Time.ToString("dd/MM/yyyy HH:mm:ss");
        set => Time = DateTime.Parse(value);
    }

    public OverridedMid0081()
    {
        
    }

    public override string Pack()
    {
        Time = TestCustomMid.Now;
        return base.Pack();
    }
}
```

#### Adding MIDs that are not in documentation

Maybe your controller is weird and have unknown MID numbers, MIDs that are not in the documentation and you want to inject into MidInterpreter, there is a way:

``` csharp
var _midInterpreter new MidInterpreter().UseAllMessages()
                                        .UseCustomMessage(new Dictionary<int, Type>() { { 83, typeof(NewMid0083) } });

public class NewMid0083 : Mid
{
    private readonly IValueConverter<DateTime> _dateConverter;
    private const int LAST_REVISION = 1;
    public const int MID = 83;

    public DateTime Time
    {
        get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
        set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
    }
    public string TimeZone
    {
        get => GetField(1, (int)DataFields.TIMEZONE).Value;
        set => GetField(1, (int)DataFields.TIMEZONE).SetValue(value);
    }

    public NewMid0083() : base(MID, LAST_REVISION)
    {
        _dateConverter = new DateConverter();
    }

    protected override Dictionary<int, List<DataField>> RegisterDatafields()
    {
        return new Dictionary<int, List<DataField>>()
        {
            {
                1, new List<DataField>()
                        {
                            new DataField((int)DataFields.TIME, 20, 19),
                            new DataField((int)DataFields.TIMEZONE, 41, 2)
                        }
            }
        };
    }

    public enum DataFields
    {
        TIME,
        TIMEZONE
    }
}
```

> **NOTE:** Custom messages might not perform as fast as other MIDs because they don't have optimizations for finding it

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

> Instantiate the **MIDIdentifier** class just once and keep working with it!

> **Controller Implementation Tip:** Always **TRY** to register used MIDs, not all Tightening Controllers use every available MID.

> **Integrator Implementation Tip:** Always **DO** register used MIDs, I'm pretty sure you won't need all of them to your application.

### Contribute to the project

Lot's of effort were given to this project and by seen people using it motivated me a lot to improve it more and more.

Does it help you a lot? That's awesome and very rewarding!
But if you wish, you can support and help to motivate the constant improving of this library by contributing in [OpenCollective](https://opencollective.com/open-protocol-interpreter).

### List of still unavailable Mids

 - Mid 0700;
 - Mid 0900;
 - Mid 0901;
 - Mid 1000;
 - Mid 1001;
 - Mid 1601;
 - Mid 1602;
 - Mid 1900;
 - Mid 1901;
 - Mid 2100;
 - Mid 2500;
 - Mid 2501;
 - Mid 2600;
 - Mid 2601;
 - Mid 2602;
 - Mid 2603;
 - Mid 2604;
 - Mid 2605;
 - Mid 2606.

Feel free to fork and contribute to add any of those mids.
