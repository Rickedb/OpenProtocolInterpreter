using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Messages
{
    /// <summary>
    /// Templates for parsing packages and validating Mid assignability
    /// </summary>
    internal interface IMessagesTemplate
    {
        void AddOrUpdateTemplate(IDictionary<int, Type> types);
        Mid ProcessPackage(int mid, string package);
        Mid ProcessPackage(int mid, byte[] package);
        bool IsAssignableTo(int mid);
    }
}
