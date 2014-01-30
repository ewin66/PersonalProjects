using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public class Combinatorics
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Combinations with repetition:");
            CombinationsRepetRecursive(0, 0);
            Console.WriteLine(counter);
            counter = 0;

            Console.WriteLine("Combinations without repetition:");
            CombinationsNoRepetRecursive(0, 0);
            Console.WriteLine(counter);
            counter = 0;

            Console.WriteLine("Permutations with repetition:");
            var arr = new string[] { "banana", "apple", "orange", "strawberry", "raspberry" };
            Array.Sort(arr);
            PermutationsRepetRecursive(arr, 0, arr.Length);
            Console.WriteLine(counter);
            counter = 0;

            Console.WriteLine("Permutations without repetition:");
            //var arr = new string[] { "banana", "apple", "orange", "strawberry", "raspberry" };
            PermutationsNoRepetRecursive(arr, 0);
            Console.WriteLine(counter);
            counter = 0;

            Console.WriteLine("Variations with repetitions:");
            VariationsRepetRecursive(0);
            Console.WriteLine(counter);
            counter = 0;

            Console.WriteLine("Variations without repetitions:");
            VariationsNoRepetRecursive(0);
            Console.WriteLine(counter);
            counter = 0;
        }
        #region Permutations with repetition recursive
        static void PermutationsRepetRecursive(string[] arr, int start, int n)
        {
            PrintSingle(arr);
            counter++;

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermutationsRepetRecursive(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static void PrintSingle<T>(T[] arr)
        {
            Console.WriteLine(String.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
        #endregion
        #region Permutations without repetition recursive
        static void PermutationsNoRepetRecursive<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                PrintSingle(arr);
                counter++;
            }
            else
            {
                PermutationsNoRepetRecursive(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    PermutationsNoRepetRecursive(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }
        #endregion

        const int n = 5;
        const int k = 5;
        static string[] objects = new string[n] { "banana", "apple", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[k];
        static BigInteger counter = 0;

        #region Combinations with repetition recursive


        public static void CombinationsRepetRecursive(int index, int start)
        {
            if (index >= k)
            {
                PrintSingle(); //put here some other logic about the current combination
                counter++;
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    CombinationsRepetRecursive(index + 1, i);
                }
            }
        }
        static void PrintSingle()
        {
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }

        #endregion
        #region Combinations without repetition recursive
        static void CombinationsNoRepetRecursive(int index, int start)
        {
            if (index >= k)
            {
                PrintSingle();
                counter++;
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    CombinationsNoRepetRecursive(index + 1, i + 1);
                }
            }
        }
        #endregion
        #region Variations with repetition recursive
        static void VariationsRepetRecursive(int index)
        {
            if (index >= k)
            {
                PrintSingle();
                counter++;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    VariationsRepetRecursive(index + 1);
                }
            }
        }
        #endregion
        #region Variations without repetition recursive
        static bool[] used = new bool[n];
        static void VariationsNoRepetRecursive(int index)
        {
            if (index >= k)
            {
                PrintSingle();
                counter++;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        VariationsNoRepetRecursive(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
        #endregion
    }
}
