using OpenProtocolInterpreter.MIDs;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Helpers
{
    internal static class DictionaryHelper
    {
        public static DataField getDataField(this List<DataField> datafields, int field)
        {
            var dtField = datafields.SingleOrDefault(x => x.Field == field);
            if (dtField == null)
                dtField = new DataField(field, string.Empty, 0, null);
            return dtField;
        }
    }
}
