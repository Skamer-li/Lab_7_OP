using System;

namespace linked_list
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedListMod list = [1f, 7f, 9f, 3f, 5f];
            float n;

            Console.WriteLine("Initial list:");
            PrintList(list);

            Console.WriteLine("\n1-st task");

            Console.WriteLine("Enter the value to find the first value in the list 2 times bigger:");
            EnterFloat(out n);

            FindX2Value(n, list);

            Console.WriteLine($"\n2-nd task\nThere are {AmountOfBiggerElements(3.14f, list)} elements in the list bigger than 3.14");

            Console.WriteLine("\n3-rd task\nEnter the value to get a list of elements bigger than that value:");
            EnterFloat(out n);

            LinkedListMod bigList = GetArrayOfBiggerElements(n, list);

            Console.WriteLine($"List of elements bigger than {n}:");
            PrintList(bigList);

            Console.WriteLine("\n4-th task\nElements bigger than average removed:");
            RemoveElementsMoreThanAverage(list);
            PrintList(list);
        }

        static void EnterFloat(out float value)
        {
            while (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        static void PrintList(LinkedListMod linkedList)
        {
            foreach (var item in linkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void FindX2Value(float value, LinkedListMod linkedList)
        {
            foreach (float item in linkedList)
            {
                if (item >= 2f * value)
                {
                    Console.WriteLine($"Value {item} inside the list is more than 2 times bigger than {value}.");
                    return;
                }  
            }

            Console.WriteLine($"There is no value 2 times bigger than {value} inside the list");
        }

        static int AmountOfBiggerElements(float value, LinkedListMod linkedList)
        {
            int count = 0;

            foreach (float item in linkedList)
                if (item > value)
                    count++;

            return count;
        }

        static LinkedListMod GetArrayOfBiggerElements(float value, LinkedListMod linkedList)
        {
            LinkedListMod newList = new LinkedListMod();

            foreach (float item in linkedList)
                if (item > value)
                    newList.Add(item);

            return newList;
        }

        static void RemoveElementsMoreThanAverage(LinkedListMod linkedList)
        {
            if (linkedList.isEmpty())
                return;

            float average = 0;

            foreach (float item in linkedList)
                average += item;

            average /= linkedList.Count();

            foreach (float item in linkedList)
                if (item > average)
                    linkedList.Remove(item);
        }
    }
}
