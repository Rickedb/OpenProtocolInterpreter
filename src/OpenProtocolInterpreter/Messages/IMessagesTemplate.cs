namespace OpenProtocolInterpreter.Messages
{
    internal interface IMessagesTemplate
    {
        MIDs.MID processPackage(string package);
    }
}
