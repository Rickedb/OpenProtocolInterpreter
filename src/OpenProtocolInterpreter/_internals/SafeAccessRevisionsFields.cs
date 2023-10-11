using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenProtocolInterpreter
{
    internal class SafeAccessRevisionsFields : Dictionary<int, List<DataField>>
    {
        public new List<DataField> this[int index]
        {
            get
            {
                if (!ContainsKey(index))
                {
                    Add(index, []);
                }

                return this[index];
            }
        }

        public SafeAccessRevisionsFields()
        {

        }

        public SafeAccessRevisionsFields(IDictionary<int, List<DataField>> dictionary) : base(dictionary)
        {
        }

        public SafeAccessRevisionsFields(IDictionary<int, List<DataField>> dictionary, IEqualityComparer<int> comparer) : base(dictionary, comparer)
        {
        }

        public SafeAccessRevisionsFields(IEqualityComparer<int> comparer) : base(comparer)
        {
        }

        public SafeAccessRevisionsFields(int capacity) : base(capacity)
        {
        }

        public SafeAccessRevisionsFields(int capacity, IEqualityComparer<int> comparer) : base(capacity, comparer)
        {
        }

        protected SafeAccessRevisionsFields(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
