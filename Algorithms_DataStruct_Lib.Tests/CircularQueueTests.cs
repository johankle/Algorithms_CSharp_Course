using System;
using System.Collections.Generic;
using NUnit.Framework;
using Algorithms_DataStruct_Lib.Queues;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class CircularQueueTests
    {
        [Test]
        public void Capacity_EnqueueManyItems_DoubledCapacity()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Dequeue();

            queue.Enqueue(2);
            queue.Dequeue();

            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Assert.AreEqual(8, queue.Capacity);
        }

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var stack = new CircularQueue<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Enque_EmptyQueue_ThrowsException()
        {
            var queue = new CircularQueue<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }

        [Test]
        public void Peek_EnqueueTwoItems_ReturnsHeadItem()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_EnqueueTwoItemsAndDequeue_ReturnsHeadItem()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }


    }
}
