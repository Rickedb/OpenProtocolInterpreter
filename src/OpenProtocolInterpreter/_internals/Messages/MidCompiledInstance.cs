using System;
using System.Linq.Expressions;

namespace OpenProtocolInterpreter.Messages
{
    internal class MidCompiledInstance
    {
        public Type Type { get; set; }
        public Func<Mid> CompiledConstructor { get; set; }

        public MidCompiledInstance(Type type)
        {
            Type = type;
            CompiledConstructor = Expression.Lambda<Func<Mid>>(Expression.New(type.GetConstructor(Type.EmptyTypes))).Compile();
        }
    }
}
