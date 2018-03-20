using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal class MessageTemplateFactory
    {
        public static IMID BuildChainOfMids(IEnumerable<MID> selectedMids)
        {
            if (!selectedMids.Any())
                return null;

            List<MID> midList = selectedMids.ToList();
            for(int i = 1; i < selectedMids.Count(); i++)
                midList[i - 1].SetNextTemplate(midList[i]);
                
            return (IMID)midList.FirstOrDefault();
        }
    }
}
