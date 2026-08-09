using System;
using System.Linq.Expressions;
using System.Reflection;

namespace OpenProtocolInterpreter.Messages
{
    internal class CompiledInstance<T>
    {
        public Type Type { get; set; }
        public Func<T> CompiledConstructor { get; set; }

        public CompiledInstance(Type type)
        {
            Type = type;
            var ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            CompiledConstructor = Expression.Lambda<Func<T>>(Expression.New(ctor)).Compile();
        }
    }
}
