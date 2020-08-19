using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Algorithms_DataStruct_Lib;
using Algorithms_DataStruct_Lib.Stacks;
using Algorithms_DataStruct_Lib.SymbolTables;
using ThreeSum;

namespace Algorithms_CSharp_Course
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchSt<char, int> bsst = new BinarySearchSt<char, int>(5);

            //char ch = 'b';
            //int num = 1;

            //for (int i = 0; i < bsst.Capacity; i++)
            //{
            //    Console.WriteLine(ch + " " + num);
            //    bsst.Add(ch++, num++);

            //}

            bsst.Add('c', 2);
            bsst.Add('f', 5);
            bsst.Add('b', 1);
            bsst.Add('d', 3);
            bsst.Add('e', 4);

            Console.WriteLine(bsst.Count);
            Console.WriteLine("Min, should be b: " + bsst.Min());
            Console.WriteLine("Max, should be f: " + bsst.Max());

            bsst.RemoveMin();
            bsst.RemoveMax();

            Console.WriteLine("Min, should be c: " + bsst.Min());
            Console.WriteLine("Max, should be e: " + bsst.Max());

            bsst.Add('b', 1);
            bsst.Add('f', 5);

            Console.WriteLine("Select index 2, should be d: " + bsst.Select(2));
            Console.WriteLine("Select index 4, should be f: " + bsst.Select(4));

            Console.WriteLine("Ceiling b, should be b: " + bsst.Ceiling('b'));
            Console.WriteLine("Ceiling a, should be b: " + bsst.Ceiling('a'));
            Console.WriteLine("Ceiling g, should be null: " + bsst.Ceiling('g'));
            Console.WriteLine("Ceiling d, should be d: " + bsst.Ceiling('d'));

            Console.WriteLine("Floor e, should be e: " + bsst.Floor('e'));
            Console.WriteLine("Floor a, should be null: " + bsst.Floor('a'));
            Console.WriteLine("Floor g, should be f: " + bsst.Floor('g'));

            Console.WriteLine("Range b & f: ");
            var range = bsst.Range('b', 'f');

            //Console.WriteLine("Range a & f: ");
            //array = bsst.Range('a', 'f');

            //Console.WriteLine("Range e & h: ");
            //array = bsst.Range('e', 'h');

            //Console.WriteLine("Range b & c: ");
            //array = bsst.Range('b', 'c');

            //Console.WriteLine("Range g & h: ");
            //array = bsst.Range('g', 'h');

            Console.WriteLine("Range a & g: ");
            range = bsst.Range('a', 'g');

            foreach (var item in range)
            {
                Console.Write(item + " ");
            }


            //Console.Read();

            //   TestThreeSum();

            //try
            //{
            //    var ss = new SortedSet<int>();
            //    ss.Add(1);
            //    ss.Add(2);
            //    ss.Add(1);


            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //}

            //var sl = new SortedList<int, string>();
            //try
            //{

            //    sl.Add(1, "1");
            //    sl.Add(2, "2");
            //    sl.Add(1, "3");
            //}
            ////sl.Capacity
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //try
            //{
            //    var sd = new SortedDictionary<int, string>();
            //    sd.Add(1, "1");
            //    sd.Add(2, "2");
            //    sd.Add(1, "3");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //try
            //{
            //    var dic = new Dictionary<int, string>();
            //    dic.Add(1, "1");
            //    dic.Add(2, "2");
            //    dic.Add(1, "3");

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //}

            //int[] keys = {3, 0, 7, 2, 4};
            //int[] values = {9, 8, 12, 14, 15};

            //Array.Sort(keys, values);

            //Console.Read();

        }

        public static void LinearSearchDemo()
        {
            var customerList = new List<Customer>()
            {
                new Customer {Age = 3, Name = "Ann"},
                new Customer {Age = 16, Name = "Bill"},
                new Customer {Age = 20, Name = "Rose"},
                new Customer {Age = 14, Name = "Rob"},
                new Customer {Age = 28, Name = "Bill"},
                new Customer {Age = 14, Name = "John" }
            };

            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

            bool contains = intList.Contains(3);
            bool contains2 = customerList.Contains(new Customer { Age = 14, Name = "Rob" }, new CustomerComparer());

            bool exists = customerList.Exists(customer => customer.Age == 28);

            int min = intList.Min();
            int max = intList.Max();

            int youngestCustomerAge = customerList.Min(customer => customer.Age);

            Customer bill = customerList.Find(customer => customer.Name == "Bill");
            Customer lastBill = customerList.FindLast(customer => customer.Name == "Bill");
            Customer lastBill2 = customerList.Last(customer => customer.Name == "Bill");

            List<Customer> customers = customerList.FindAll(customer => customer.Age > 18);
            IEnumerable<Customer> whereAge = customerList.Where(customer => customer.Age > 18);

            int index1 = customerList.FindIndex(customer => customer.Age == 14);
            int lastIndex = customerList.FindLastIndex(customer => customer.Age > 18);

            int indexOf = intList.IndexOf(2);
            int lastIndexOf = intList.LastIndexOf(2);

            // from List
            bool isTrueForAll = customerList.TrueForAll(customer => customer.Age > 10);

            // from LINQ
            bool all = customerList.All(customer => customer.Age > 18);
            bool areThereAny = customerList.Any(customer => customer.Age == 3);
            int count = customers.Count(customer => customer.Age > 18);

            Customer firstBill = customerList.First(c => c.Name == "Bill");
            Customer singleAnn = customerList.Single(c => c.Name == "Ann");
        }

        public static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return true;
            }
            return false;
        }

        public static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return i;
            }
            return -1;
        }

        public static void LinkedStackDemo()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print 4: {stack.Peek()}");

            stack.Pop();

            Console.WriteLine($"Should print 4: {stack.Peek()}");

            Console.WriteLine("Iterate over stack:");

            foreach (var cur in stack)
            {
                Console.WriteLine(cur);
            }
        }

        public static void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write("{0,8}", obj);
            }
            Console.WriteLine();
        }

        private static void DemoWithNodes()
        {
            //Node first = new Node() {Value = 5};
            //Node second = new Node() {Value = 1};

            //first.Next = second;

            //Node third = new Node() {Value = 3};
            //second.Next = third;

            //PrintOutLinkedList(first);
        }

        //private static void PrintOutLinkedList(Node node)
        //{
        //    while (node != null)
        //    {
        //        Console.WriteLine(node.Value);
        //        node = node.Next;
        //    }
        //}

        //1! = 1 * 0! = 1
        //2! = 2 * 1 = 2 * 1!
        //3! = 3 * 2 * 1 = 3 * 2!
        //4! = 4 * 3 * 2 * 1 = 4 * 3!
        //n! = n * (n-1)!

        //1*Calculate(1-1) = 1 ->
        //2*Calculate(2-1) = 2 * 1 = 2 ->
        //3*Calculate(3-2)=3*2 = 6

        private static int Calculate(int n)
        {
            if (n == 0)
                return 1;

            return n * Calculate(n - 1);
        }

        private static int IterativeFactorial(int number)
        {
            if (number == 0)
                return 1;

            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private static void TestThreeSum()
        {
            //300 millisecons for 1k
            //14 second for 4k
            ////1 min 36 seconds for 8k
            //var ints = In.ReadInts("16kints.txt").ToArray();

            //var watch = new Stopwatch();
            //watch.Start();

            //var triplets = ThreeSum.Count(ints);

            //watch.Stop();

            //Console.WriteLine($"The number of \"zero-sum\" triplets:{triplets}");
            //Console.WriteLine($"Time taken:{watch.Elapsed:g}");
        }

        #region Info

        static void ArrayTimeComplexity(object[] array)
        {
            //access by index O(1)
            Console.WriteLine(array[0]);

            int length = array.Length;
            object elementINeedToFind = new object();

            //searching for an element O(N)
            for (int i = 0; i < length; i++)
            {
                if (array[i] == elementINeedToFind)
                {
                    Console.WriteLine("Exists/Found");
                }
            }

            //add to a full array
            var bigArray = new int[length * 2];
            Array.Copy(array, bigArray, length);
            bigArray[length + 1] = 10;

            //add to the end when there's some space
            //O(1)
            array[length - 1] = 10;

            //O(1)
            array[6] = null;
        }

        private static void RemoveAt(object[] array, int index)
        {
            var newArray = new object[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - 1 - index);

        }

        //private static unsafe void IterateOver(int[] array)
        //{
        //    fixed (int* b = array)
        //    {
        //        int* p = b;
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            Console.WriteLine(*p);
        //            p++;
        //        }
        //    }
        //}

        private static void MultiDimArrays()
        {
            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.WriteLine($"{r2[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void JaggedArraysDemo()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the numbers for a jagged arary.");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Printing the Elements:");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]);
                    Console.Write("\0");
                }

                Console.WriteLine("");
            }
        }

        private static void ArraysDemo()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            //System.Array

            //for (int i = 0; i < a3.Length; i++)
            for (int i = 0; i <= a3.Length - 1; i++)
            {
                Console.Write($"{a3[i] }");
            }

            Console.WriteLine();

            foreach (var el in a4)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine();

            Array myArray = new int[5];

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);

            Console.Read();
        }
    }

    internal class CustomerComparer : IEqualityComparer<Customer>
    {
        public bool Equals([AllowNull] Customer x, [AllowNull] Customer y) => x.Age == y.Age && x.Name == y.Name;
        
        public int GetHashCode(Customer obj) => obj.GetHashCode();
    }
}
#endregion