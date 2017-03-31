using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs
{
    public interface IMID
    {
        MID.Header HeaderData { get; set; }
        List<DataField> RegisteredDataFields { get; set; }
        MID processPackage(string package);
        ExpectedMid processPackage<ExpectedMid>(string package) where ExpectedMid : MID;
        string buildPackage();
    }
}
