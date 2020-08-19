using System;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };

            Assert.AreEqual(2, Searching.BinarySearch(input, 4));
            Assert.AreEqual(4, Searching.BinarySearch(input, 8));
            Assert.AreEqual(6, Searching.BinarySearch(input, 15));
            Assert.AreEqual(7, Searching.BinarySearch(input, 22));

            Assert.AreEqual(2, Searching.RecursiveBinarySearch(input, 4));
            Assert.AreEqual(4, Searching.RecursiveBinarySearch(input, 8));
            Assert.AreEqual(6, Searching.RecursiveBinarySearch(input, 15));
            Assert.AreEqual(7, Searching.RecursiveBinarySearch(input, 22));
        }
    }
}
