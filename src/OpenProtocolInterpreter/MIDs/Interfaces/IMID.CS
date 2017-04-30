using System.Collections.Generic;

namespace DCX.ITLC.UMI.AtlasCopco.OpenProtocol.MIDs.Interfaces
{
    public interface IMID
    {
        MID.Header HeaderData { get; set; }
        List<DataField> RegisteredDataFields { get; set; }
        MID processPackage(string package);
        string buildPackage();
    }
}
