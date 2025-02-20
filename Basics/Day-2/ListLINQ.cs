using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Write a program that creates a list of integers and uses LINQ to filter out odd numbers, sort them in
// ascending order, and group them by even and odd numbers.

namespace Day_2
{
    public class ListLINQ
    {
        public List<int> list;

        public bool MakeList()
        {
            Console.WriteLine("Enter nums:");
            string? nums = Console.ReadLine();

            try
            {
                list = nums.Split(" ").Select(int.Parse).ToList();
                return true;

            }
            catch(FormatException) {
                Console.WriteLine("Please enter numbers only seprated by spaces");
                return false;
            }
        }

        public void FilterAndOrder()
        {
            Console.WriteLine("Displaying Elements after filtering out odd numbers and ordering them in ascending order:");

            // x=>x represents sort by the value of x itself
            var evenNums = list.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            foreach (var evenitem in evenNums)
            {
                Console.WriteLine(evenitem);
            }
        }


        public void GroupedNums()
        {
            Console.WriteLine("Displaying Elements of Grouped list");
            var groupedNums = list.OrderBy(x => x).GroupBy(x => x % 2 == 0 ? "even" : "odd");
            foreach (var group in groupedNums)
            {
                Console.WriteLine($"{group.Key} Numbers : {string.Join(",", group)}");
            }
        }


    }
}


