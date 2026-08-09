using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MIDTesters
{
    /// <summary>
    /// Every <see cref="Mid"/> and <see cref="ExtraData"/> holding a collection must hand it back already
    /// initialized, so callers may add items to a freshly built instance and packing never dereferences null.
    /// </summary>
    [TestClass]
    [TestCategory("Default")]
    public class TestCollectionInitialization
    {
        [TestMethod]
        public void EveryMidInitializesItsCollections()
            => AssertCollectionsAreInitialized(typeof(Mid));

        [TestMethod]
        public void EveryExtraDataInitializesItsCollections()
            => AssertCollectionsAreInitialized(typeof(ExtraData));

        private static void AssertCollectionsAreInitialized(Type baseType)
        {
            var failures = new List<string>();
            var types = baseType.Assembly.GetTypes()
                                .Where(x => x.IsPublic && x.IsClass && !x.IsAbstract && baseType.IsAssignableFrom(x))
                                .OrderBy(x => x.FullName);

            foreach (var type in types)
            {
                var collections = GetCollectionProperties(type).ToList();
                if (collections.Count == 0)
                    continue;

                foreach (var constructor in type.GetConstructors())
                {
                    if (!TryBuildArguments(constructor, out var arguments))
                        continue;

                    var instance = constructor.Invoke(arguments);
                    foreach (var property in collections.Where(x => x.GetValue(instance) == null))
                    {
                        failures.Add($"{type.Name}.{property.Name} is null when built by {Describe(constructor)}");
                    }
                }
            }

            Assert.AreEqual(0, failures.Count, $"{failures.Count} collection(s) are left uninitialized:{Environment.NewLine}{string.Join(Environment.NewLine, failures)}");
        }

        private static IEnumerable<PropertyInfo> GetCollectionProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.CanRead && x.CanWrite
                                   && x.PropertyType != typeof(string)
                                   && typeof(IEnumerable).IsAssignableFrom(x.PropertyType));
        }

        /// <summary>
        /// Mids and extra datas are built either with no arguments, from a <see cref="Header"/> or from a
        /// revision number. Any other constructor is skipped instead of guessing a value for it.
        /// </summary>
        private static bool TryBuildArguments(ConstructorInfo constructor, out object[] arguments)
        {
            var parameters = constructor.GetParameters();
            arguments = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType == typeof(Header))
                    arguments[i] = new Header();
                else if (parameters[i].ParameterType == typeof(int))
                    arguments[i] = 1;
                else
                    return false;
            }

            return true;
        }

        private static string Describe(ConstructorInfo constructor)
        {
            var parameters = constructor.GetParameters().Select(x => x.ParameterType.Name);
            return $"{constructor.DeclaringType.Name}({string.Join(", ", parameters)})";
        }
    }
}
