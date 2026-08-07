using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace MIDTesters
{
    public abstract class MidTester
    {
        private const int MaxComparisonDepth = 4;

        protected readonly MidInterpreter _midInterpreter;

        public MidTester()
        {
            _midInterpreter = new MidInterpreter().UseAllMessages();
        }

        protected byte[] GetAsciiBytes(string package) => Encoding.ASCII.GetBytes(package);
        protected byte[] GetAsciiBytes(byte[] package, int byteLength)
        {
            var asciiInt = (byteLength > 8 ? BitConverter.ToInt64(package, 0) : BitConverter.ToInt32(package, 0)).ToString().PadLeft(byteLength, '0');
            return Encoding.ASCII.GetBytes(asciiInt);
        }

        protected void AssertEqualPackages(string expected, Mid mid, bool useEmptyRevision = false)
        {
            if(useEmptyRevision)
            {
                mid.Header.Revision = 0;
            }

            mid.Header.StationId = mid.Header.SpindleId = null;
            Assert.AreEqual(expected, mid.Pack());
        }

        protected void AssertEqualPackages(IReadOnlyCollection<byte> expected, Mid mid, bool useEmptyRevision = false)
        {
            if (useEmptyRevision)
            {
                mid.Header.Revision = 0;
            }

            mid.Header.StationId = mid.Header.SpindleId = null;
            CollectionAssert.AreEqual(expected.ToArray(), mid.PackBytes());
        }

        /// <summary>
        /// Packs a mid built from its properties (instead of parsed from a package) and asserts both
        /// the string and the byte array representations match <paramref name="expected"/>.
        /// </summary>
        protected void AssertPackedFromProperties(string expected, Mid built, bool useEmptyRevision = false)
        {
            if (useEmptyRevision)
            {
                built.Header.Revision = 0;
            }

            built.Header.StationId = built.Header.SpindleId = null;
            Assert.AreEqual(expected, built.Pack());
            CollectionAssert.AreEqual(GetAsciiBytes(expected), built.PackBytes());
        }

        /// <summary>
        /// Reverse of the usual parse/re-pack test: packs a mid built from its properties, asserts the
        /// package matches, then parses that package back and asserts every data field bound property
        /// of the parsed mid holds the same value as the built one.
        /// </summary>
        protected TMid AssertBuildAndParse<TMid>(string expected, TMid built, bool useEmptyRevision = false) where TMid : Mid
        {
            AssertPackedFromProperties(expected, built, useEmptyRevision);

            var parsed = _midInterpreter.Parse<TMid>(expected);
            AssertEqualDataFieldProperties(built, parsed, built.Header.StandardizedRevision);
            return parsed;
        }

        /// <summary>
        /// Compares every public property decorated with a <see cref="DataFieldDefinitionAttribute"/> up to
        /// <paramref name="revision"/> between two instances, recursing into the collections a mid may hold.
        /// </summary>
        protected static void AssertEqualDataFieldProperties(object expected, object actual, int revision)
        {
            Assert.IsNotNull(actual, $"Expected an instance of {expected.GetType().Name} but got null");

            foreach (var property in GetDataFieldProperties(expected.GetType(), revision))
            {
                AssertEqualValues(property.GetValue(expected),
                                  property.GetValue(actual),
                                  $"{expected.GetType().Name}.{property.Name}",
                                  0);
            }
        }

        private static IEnumerable<PropertyInfo> GetDataFieldProperties(Type type, int revision)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.GetCustomAttributes<DataFieldDefinitionAttribute>()
                                    .Any(a => a.Revision <= revision));
        }

        private static void AssertEqualValues(object expected, object actual, string path, int depth)
        {
            if (expected is string || actual is string)
            {
                // Setting a property keeps the value as given while parsing hands back the padded field,
                // so only the content is compared here. The padding itself is already covered by the
                // exact package assertion made before the parse leg runs.
                Assert.AreEqual((expected as string)?.Trim() ?? string.Empty,
                                (actual as string)?.Trim() ?? string.Empty,
                                $"{path} does not match");
                return;
            }

            if (expected == null && actual == null)
                return;

            Assert.IsNotNull(expected, $"{path}: built value is null but parsed value is '{actual}'");
            Assert.IsNotNull(actual, $"{path}: parsed value is null but built value is '{expected}'");

            if (IsComparableValue(expected.GetType()))
            {
                Assert.AreEqual(expected, actual, $"{path} does not match");
                return;
            }

            if (expected is IEnumerable expectedItems && actual is IEnumerable actualItems)
            {
                AssertEqualCollections(expectedItems, actualItems, path, depth);
                return;
            }

            if (depth >= MaxComparisonDepth)
                return;

            foreach (var property in expected.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetIndexParameters().Length > 0)
                    continue;

                AssertEqualValues(property.GetValue(expected),
                                  property.GetValue(actual),
                                  $"{path}.{property.Name}",
                                  depth + 1);
            }
        }

        private static void AssertEqualCollections(IEnumerable expected, IEnumerable actual, string path, int depth)
        {
            var expectedList = expected.Cast<object>().ToList();
            var actualList = actual.Cast<object>().ToList();

            Assert.AreEqual(expectedList.Count, actualList.Count, $"{path} has a different number of entries");

            for (int i = 0; i < expectedList.Count; i++)
            {
                AssertEqualValues(expectedList[i], actualList[i], $"{path}[{i}]", depth + 1);
            }
        }

        private static bool IsComparableValue(Type type)
            => type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime);
    }
}
