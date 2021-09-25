using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainLib;

namespace BlockChain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("hello world", "Admin");

            Assert.AreEqual(2, chain.Blocks.Count);
            Assert.AreEqual("hello world", chain.Last.Data);
        }
    }
}