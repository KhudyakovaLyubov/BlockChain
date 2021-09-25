using BlockChainLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlockChainTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void BlockTestNullData()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Block(string.Empty, new Block()));
        }

        [TestMethod]
        public void BlockTestNullBlock()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Block("hello world", null));
        }
    }
}
