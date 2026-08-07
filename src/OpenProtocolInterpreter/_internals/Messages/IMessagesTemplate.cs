using System;
using System.Collections.Generic;
using System.Text;

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
        Mid ProcessPackage(int mid, byte[] package, Encoding encoding);
        bool IsAssignableTo(int mid);
        CompiledInstance<Mid> GetInstance(int mid);
        CompiledInstance<ExtraData> GetExtraDataInstance(int mid, Type kind);
    }
}
