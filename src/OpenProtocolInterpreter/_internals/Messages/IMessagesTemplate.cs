namespace OpenProtocolInterpreter.Messages
{
    internal interface IMessagesTemplate
    {
        Mid ProcessPackage(int mid, string package);
        Mid ProcessPackage(int mid, byte[] package);
        bool IsAssignableTo(int mid);
    }
}
