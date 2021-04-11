using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayTask1(10);
            //StringTask1();
            //ArrayTask5();
            //StringTask5();
            //ArrayTask10();
            //StringTask10();
            //ArrayTask15();
            //StringTask15();
            //ArrayTask20();
            StringTask20();
        }

        public static void ArrayTask1(int dimension)
        {
            Console.WriteLine($"Input {dimension} elements in the array: ");
            int[] array = Input(dimension);
            Console.Write("Elements in array are: ");
            Output(array);
        }

        public static void ArrayTask5()
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

        public static void ArrayTask10()
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
        public static void ArrayTask15()
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
        public static void ArrayTask20()
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
        public static void StringTask1()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine(); ;
            Console.Write($"The string you entered is : {str}");
        }
        public static void StringTask5()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"[^0-9a-zA-Z]", " ");
            str = Regex.Replace(str, @"\s+", " ");
            int wordsnumber = str.Split(' ').Length;
            Console.WriteLine($"Total number of words in the string is : {wordsnumber}");
        }
        public static void StringTask10()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"\s+", "");
            char[] charlist = str.Distinct().ToArray();
            int[] count = new int[charlist.Length];

            for (int i = 0; i < str.Length; i++)
            {
                for (int k = 0; k < charlist.Length; k++)
                {
                    if (str[i] == charlist[k])
                    {
                        count[k]++;
                    }
                } 
            }

            int index = Array.IndexOf(count, count.Max());
            Console.WriteLine($"The Highest frequency of character '{charlist[index]}' appears number of times: {count.Max()} ");
        }
        public static void StringTask15()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine().Trim();
            char[] charlist =str.ToCharArray();

            for (int i = 0; i < charlist.Length; i++)
            {
                if (char.IsUpper(charlist[i]))
                {
                    charlist[i] =char.ToLower(charlist[i]);
                }
                else
                {
                   charlist[i] = char.ToUpper(charlist[i]);
                }
            }

            Console.Write("After conversion, the string is : ");

            for (int i = 0; i < charlist.Length; i++)
            {
                Console.Write($"{charlist[i]}");
            }
        }
        public static void StringTask20()
        {
            Console.WriteLine("Input the original string : ");
            string str = Console.ReadLine().Trim();
            Console.WriteLine("Input the string to be searched for : ");
            string searchstr = Console.ReadLine().Trim();
            Console.WriteLine("Input the string to be inserted : ");
            string insertstr = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"\s+", " ");
            string[] words = str.Split(' ');
            string[] newstr = new string[words.Length + 1];

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != searchstr)
                {
                    newstr[i] = words[i];
                }
                else
                {
                    newstr[i] = insertstr;

                    for (int k = i + 1; k < words.Length + 1; k++)
                    {
                        newstr[k] = words[k - 1];
                    }
                    i = str.Length;
                }
            }

            Console.WriteLine("The modified string is: ");

            for (int i = 0; i < newstr.Length; i++)
            {
                Console.Write($"{newstr[i]} ");
            }
        }
    }
}
