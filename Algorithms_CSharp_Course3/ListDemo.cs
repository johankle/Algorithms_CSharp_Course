using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Algorithms_CSharp_Course
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class ListDemo
    {
        public static void Run()
        {
            List<int> list = new List<int>();
            LogCountAndCapacity(list);

            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i - 1);
                LogCountAndCapacity(list);
            }

            list.TrimExcess();
            LogCountAndCapacity(list);

            list.Add(1);
            LogCountAndCapacity(list);
        }

        public static void ApiMembers()
        {
            var list = new List<int>() { 1, 0, 5, 4, 3 };
            list.Sort();

            int indexBinSort = list.BinarySearch(3);

            list.Reverse();

            ReadOnlyCollection<int> readOnlyList = list.AsReadOnly();

            int[] array = list.ToArray();

            var listCustomers = new List<Customer>
            {
                new Customer{BirthDate = new DateTime(1988, 08, 12), Name = "Elias" },
                new Customer{BirthDate = new DateTime(1990, 06, 09), Name = "Marina" },
                new Customer{BirthDate = new DateTime(2015, 06, 09), Name = "Ann" }
            };
            listCustomers.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate)
                {
                    return 1;
                }
                else if (left.BirthDate < right.BirthDate)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });
        }

        private static void LogCountAndCapacity(List<int> list)
        {
            Console.WriteLine($"Count = {list.Count}. Capacity = {list.Capacity}");
        }
    }
}
