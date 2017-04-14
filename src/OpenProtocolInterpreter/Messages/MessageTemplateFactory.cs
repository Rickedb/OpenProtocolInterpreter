using OpenProtocolInterpreter.MIDs;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal class MessageTemplateFactory
    {
        internal static IMID buildChainOfMids(IEnumerable<MID> selectedMids)
        {
            if (selectedMids.Count() == 0)
                return null;

            List<MID> midList = selectedMids.ToList();
            for(int i = 1; i < selectedMids.Count(); i++)
                midList[i - 1].setNextTemplate(midList[i]);
                
            return (IMID)midList.First();
        }
    }
}
