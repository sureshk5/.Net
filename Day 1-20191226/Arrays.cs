using System;
/*
 * All Arrays are reference types in .NET
 * All arrays are implicitly objects of a class System.Array.
 * Array class has methods and properties to get the info about the array like its size, dimensions, length of each dimension, cloning , copying and many more...
 * There are static methods in the Array class to create Arrays dynamically..
 * Arrays are fixed in size, once created, its immutable. 
 */
namespace SampleConApp
{
    class Arrays
    {
        static void Main(string[] args)
        {
            //simpleArrayExample();
            //string[] fruits = { "Apple", "Mango", "Orange", "Papaya" };//new syntax for array literals...
            //iterations could be done using foreach as they are within the bounds of the array and it will be forward only and readonly...
            //for assignments use the for loop and for reading use the foreach loop.
            //twoDArrayExample();
            //jaggedArray();
            //dynamicArrayExample();
            
        }

        private static void dynamicArrayExample()
        {
            //requirements: type, size, values, iteration...
            Console.WriteLine("What Type of Array U want to create\nPS: Enter the CTS typename");
            string input = Console.ReadLine();//ReadLine is the only method to take inputs from the console. 
            Type dataType = Type.GetType(input);//Similar to ClassName for...
            int size = MyConsole.GetNumber("Enter the size of the array");
            Array array = Array.CreateInstance(dataType, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the location {0} of the data type {1}", i, dataType.Name);
                input = Console.ReadLine();
                object inputValue = Convert.ChangeType(input, dataType);
                array.SetValue(inputValue, i);
            }
            Console.WriteLine("All the values are set\nReading the values");
            foreach (object value in array) Console.WriteLine(value);
        }

        private static void jaggedArray()
        {
            int[][] classRooms = new int[3][];
            classRooms[0] = new int[] { 345,45,456,456,456,345,345};
            classRooms[1] = new int[] { 56, 345, 3, 44, 5, 345, 5 };
            classRooms[2] = new int[] { 56, 67, 35, 67 };
            for (int i = 0; i < classRooms.Length; i++)
            {
                foreach(int val in classRooms[i])
                    Console.Write(val + "\t");
                Console.WriteLine();
            }
        }

        private static void twoDArrayExample()
        {
            //Length vs. GetLength vs. Rank of the Array class.
            //GetLength method is used to get the length of the specified dimension in a multi dimensional array. dimension index starts with 0...
            int[,] rooms = new int[3, 2];
            Console.WriteLine("The no of dimensions:" + rooms.Rank);
            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                for (int j = 0; j < rooms.GetLength(1); j++)
                {
                    rooms[i, j] = MyConsole.GetNumber($"Enter the value for {i},{j} location");
                }
            }

            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                for (int j = 0; j < rooms.GetLength(1); j++)
                {
                    Console.Write(rooms[i, j] + "\t");//Difference b/w Write vs WriteLine
                }
                Console.WriteLine();
            }


        }

        private static void simpleArrayExample()
        {
            int[] elements = new int[5];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = i;
            }

            foreach (int element in elements) Console.WriteLine(element);
        }
    }
}
