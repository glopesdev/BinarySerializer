﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySerialization.Test.Issues.Issue27
{
    [TestClass]
    public class Issue27Tests
    {
        [TestMethod]
        [ExpectedException(typeof(EndOfStreamException))]
        public void TestPrematureStreamTermination()
        {
            var serializer = new BinarySerializer { Endianness = BinarySerialization.Endianness.Little };
            var inBytes = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x40, 0x34 };

            using (var stream = new MemoryStream(inBytes))
            {
                var actualObj = serializer.Deserialize<LoadCarrierData>(stream);
                Assert.AreEqual(null, actualObj, "Deserialization done with invalid Stream.");
            }
        }
    }
}