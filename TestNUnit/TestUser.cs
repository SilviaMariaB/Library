namespace TestNUnit
{
    using System;
    using Library2Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    [TestFixture]
    public class TestUser
    {
        [Test]
        public void TestMethod1()
        {
            Program dode = new Program();
            Assert.AreEqual(dode.Silvia("D"), 2);
        }


    }
}
