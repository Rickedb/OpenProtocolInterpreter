using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    public interface IMID
    {
        MID.Header HeaderData { get; set; }
        Dictionary<int, List<DataField>> RevisionsByFields { get; set; }
        MID ProcessPackage(string package);
        
        string BuildPackage();
    }
}
