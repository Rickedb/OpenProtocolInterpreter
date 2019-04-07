using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal class MessageTemplateFactory
    {
        public static IMid BuildChainOfMids(IEnumerable<Mid> selectedMids)
        {
            if (!selectedMids.Any())
                return null;

            List<Mid> midList = selectedMids.ToList();
            for(int i = 1; i < midList.Count; i++)
                midList[i - 1].SetNextTemplate(midList[i]);
                
            return midList.FirstOrDefault();
        }
    }
}
