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

        public static void ArrayTask1(int size)
        {
            Console.WriteLine($"Input {size} elements in the array: ");
            int[] array = Input(size);
            Console.Write("Elements in array are: ");
            WriteOutput(array);
        }

        public static void ArrayTask5()
        {
            Console.WriteLine("Input the number of elements to be stored in the array : ");
            int size = int.Parse(Console.ReadLine());

            if (size < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {size} elements in the array : ");
            int[] array = Input(size);
            List<int> list = new(); 
            Array.Sort(array);
            
            for (int i = 0; i < size - 1; i++)
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
            int size = int.Parse(Console.ReadLine());

            if (size < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {size} elements in the array : ");

            int[] array = Input(size);

            int evenCount = 0;

            for (int i = 0; i < size; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenCount++;
                }
            }

            int[] even = new int[evenCount];
            int[] odd = new int[size - evenCount];
            int evenIndex = 0;
            int oddIndex = 0;

            for (int i = 0; i < size; i++)
            {
                if (array[i] % 2 == 0)
                {
                    even[evenIndex] = array[i];
                    evenIndex++;
                }
                else
                {
                    odd[oddIndex] = array[i];
                    oddIndex++;
                }
            }

            Console.WriteLine("The Even elements are: ");
            WriteOutput(even);
            Console.WriteLine();
            Console.WriteLine("The Odds elements are: ");
            WriteOutput(odd);
        }

        public static void ArrayTask15()
        {
            Console.Write("Input the size of array : ");
            int size = int.Parse(Console.ReadLine());

            if (size < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input {size} elements in the array: ");
            int[] array = Input(size);
            Console.WriteLine("Input the position where to delete: ");
            int deletePosition = int.Parse(Console.ReadLine()) - 1;

            if (deletePosition < 0 || deletePosition >= array.Length)
            {
                Console.WriteLine("Incorrectly entered position of element");
                return;
            }

            int[] resultArray = new int[size - 1];

            for (int i = 0; i < deletePosition; i++)
            {
                resultArray[i] = array[i];
            }

            for (int i = deletePosition + 1; i < array.Length; i++)
            {
                resultArray[i - 1] = array[i];
            }

            Console.Write("The new list is : ");
            WriteOutput(resultArray);
        }

        public static void ArrayTask20()
        {
            Console.Write("Input the size of the square matrix: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 1)
            {
                Console.WriteLine("Incorrectly entered array size");
                return;
            }

            Console.WriteLine($"Input elements in the first matrix : ");
            int[,] array1 = Input2D(size, size);
            Console.WriteLine($"Input elements in the second matrix : ");
            int[,] array2 = Input2D(size, size);
            Console.WriteLine("The First matrix is :");
            WriteOutput2D(array1, size);
            Console.WriteLine("The Second matrix is :");
            WriteOutput2D(array2, size);
            int[,] resultArray = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    resultArray[i, j] = array1[i, j] - array2[i, j];
                }
            }

            Console.WriteLine("The Subtraction of two matrix is : ");
            WriteOutput2D(resultArray, size);
        }

        public static int[] Input(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"element - {i} : ");
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }

        public static void WriteOutput(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        public static int[,] Input2D(int size1, int size2)
        {
            int[,] array = new int[size1, size2];

            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    Console.Write($"element - [{i}],[{j}] : ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return array;
        }

        public static void WriteOutput2D(int[,] array, int size2)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < size2; j++)
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
            int wordsNumber = str.Split(' ').Length;
            Console.WriteLine($"Total number of words in the string is : {wordsNumber}");
        }

        public static void StringTask10()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"\s+", "");
            char[] charList = str.Distinct().ToArray();
            int[] count = new int[charList.Length];

            for (int i = 0; i < str.Length; i++)
            {
                for (int k = 0; k < charList.Length; k++)
                {
                    if (str[i] == charList[k])
                    {
                        count[k]++;
                    }
                } 
            }

            int index = Array.IndexOf(count, count.Max());
            Console.WriteLine($"The Highest frequency of character '{charList[index]}' appears number of times: {count.Max()} ");
        }

        public static void StringTask15()
        {
            Console.WriteLine("Input the string : ");
            string str = Console.ReadLine().Trim();
            char[] charList =str.ToCharArray();

            for (int i = 0; i < charList.Length; i++)
            {
                if (char.IsUpper(charList[i]))
                {
                    charList[i] =char.ToLower(charList[i]);
                }
                else
                {
                   charList[i] = char.ToUpper(charList[i]);
                }
            }

            Console.Write("After conversion, the string is : ");

            for (int i = 0; i < charList.Length; i++)
            {
                Console.Write($"{charList[i]}");
            }
        }

        public static void StringTask20()
        {
            Console.WriteLine("Input the original string : ");
            string str = Console.ReadLine().Trim();
            Console.WriteLine("Input the string to be searched for : ");
            string searchStr = Console.ReadLine().Trim();
            Console.WriteLine("Input the string to be inserted : ");
            string insertStr = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"\s+", " ");
            string[] words = str.Split(' ');
            string[] newStr = new string[words.Length + 1];

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != searchStr)
                {
                    newStr[i] = words[i];
                }
                else
                {
                    newStr[i] = insertStr;

                    for (int k = i + 1; k < words.Length + 1; k++)
                    {
                        newStr[k] = words[k - 1];
                    }
                    i = str.Length;
                }
            }

            Console.WriteLine("The modified string is: ");

            for (int i = 0; i < newStr.Length; i++)
            {
                Console.Write($"{newStr[i]} ");
            }
        }
    }
}
