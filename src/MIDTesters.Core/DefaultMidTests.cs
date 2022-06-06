using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;

namespace MIDTesters
{
    public class DefaultMidTests<TMid> : MidTester where TMid : Mid
    {
        [TestMethod]
        [TestCategory("Defaults")]
        public void HasHeaderParameterConstructor()
        {
            var constructor = typeof(TMid).GetConstructor(new Type[] { typeof(Header) });
            Assert.IsTrue(constructor != null);
        }
    }
}
