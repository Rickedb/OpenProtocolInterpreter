using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OpenProtocolInterpreter.Messages
{
    internal class MidCompiledInstance
    {
        public Type Type { get; set; }
        public Func<Mid> CompiledConstructor { get; set; }

        public MidCompiledInstance(Type type)
        {
            Type = type;
            var ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            CompiledConstructor = Expression.Lambda<Func<Mid>>(Expression.New(ctor)).Compile();
        }
    }
}
