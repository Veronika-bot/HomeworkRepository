using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1(10);
            //Task5();
            //Task10();
            //Task15();
            //Task20();
        }

        public static void Task1(int dimension)
        {
            Console.WriteLine($"Input {dimension} elements in the array: ");
            int[] array = Input(dimension);
            Console.Write("Elements in array are: ");
            Output(array);
        }

        public static void Task5()
        {
            Console.WriteLine("Input the number of elements to be stored in the array : ");
            int dimension = int.Parse(Console.ReadLine());

            if (dimension < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {dimension} elements in the array : ");
            int[] array = Input(dimension);
            List<int> list = new(); 
            Array.Sort(array);

            for (int i = 0; i < dimension - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    list.Add(array[i]);
                }
            }

            list = list.Distinct().ToList();
            Console.WriteLine($"Total number of duplicate elements found in the array is : {list.Count}");
        }

        public static void Task10()
        {
            Console.Write("Input the number of elements to be stored in the array : ");
            int dimension = int.Parse(Console.ReadLine());

            if (dimension < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {dimension} elements in the array : ");

            int[] array = Input(dimension);

            int evencount = 0;

            for (int i = 0; i < dimension; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evencount++;
                }
            }

            int[] even = new int[evencount];
            int[] odd = new int[dimension - evencount];
            int evenindex = 0;
            int oddindex = 0;

            for (int i = 0; i < dimension; i++)
            {
                if (array[i] % 2 == 0)
                {
                    even[evenindex] = array[i];
                    evenindex++;
                }
                else
                {
                    odd[oddindex] = array[i];
                    oddindex++;
                }
            }

            Console.WriteLine("The Even elements are: ");
            Output(even);
            Console.WriteLine();
            Console.WriteLine("The Odds elements are: ");
            Output(odd);
        }
        public static void Task15()
        {
            Console.Write("Input the size of array : ");
            int dimension = int.Parse(Console.ReadLine());

            if (dimension < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {dimension} elements in the array: ");
            int[] array = Input(dimension);
            Console.WriteLine("Input the position where to delete: ");
            int deleteposition = int.Parse(Console.ReadLine()) - 1;

            if (deleteposition < 0 || deleteposition >= array.Length)
            {
                Console.WriteLine("Incorrectly entered position of element");
                return;
            }

            int[] resultarray = new int[dimension - 1];

            for (int i = 0; i < deleteposition; i++)
            {
                resultarray[i] = array[i];
            }

            for (int i = deleteposition + 1; i < array.Length; i++)
            {
                resultarray[i - 1] = array[i];
            }

            Console.Write("The new list is : ");
            Output(resultarray);
        }
        public static void Task20()
        {
            Console.Write("Input the size of the square matrix: ");
            int dimension = int.Parse(Console.ReadLine());

            if (dimension < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input elements in the first matrix : ");
            int[,] array1 = Input2D(dimension, dimension);
            Console.WriteLine($"Input elements in the second matrix : ");
            int[,] array2 = Input2D(dimension, dimension);
            Console.WriteLine("The First matrix is :");
            Output2D(array1, dimension);
            Console.WriteLine("The Second matrix is :");
            Output2D(array2, dimension);
            int[,] resultarray = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    resultarray[i, j] = array1[i, j] - array2[i, j];
                }
            }

            Console.WriteLine("The Subtraction of two matrix is : ");
            Output2D(resultarray, dimension);
        }

        public static int[] Input(int dimension)
        {
            int[] array = new int[dimension];

            for (int i = 0; i < dimension; i++)
            {
                Console.Write($"element - {i} : ");
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }

        public static void Output(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        public static int[,] Input2D(int dimension1, int dimension2)
        {
            int[,] array = new int[dimension1, dimension2];

            for (int i = 0; i < dimension1; i++)
            {
                for (int j = 0; j < dimension2; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return array;
        }

        public static void Output2D(int[,] array, int dimension2)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < dimension2; j++)
                {
                    Console.Write($"{array[i, j]}  ");
                }

                Console.WriteLine();
            }
        }
    }
}
