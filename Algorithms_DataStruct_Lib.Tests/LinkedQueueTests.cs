using System;
using NUnit.Framework;
using Algorithms_DataStruct_Lib.Queues;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class linkedQueueTests
    {
        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new LinkedQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Pop_EmptyQueue_ThrowsException()
        {
            var queue = new LinkedQueue<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }

        [Test]
        public void Peek_EnqueueTwoItems_ReturnsHeadItem()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_EnqueTwoItemsAndDequeue_ReturnsHeadItem()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }


    }
}
