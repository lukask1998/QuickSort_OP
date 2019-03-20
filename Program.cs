using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace QuickSort_OP
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 10;
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            MyDataArray myArray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            myArray.Print(n);
            QuickSort(myArray, 0, n - 1);
            myArray.Print(n);

            MyDataList myList = new MyDataList(n, seed);
            Console.WriteLine("\n LIST \n");
            myList.Print(n);
            QuickSort(myList, 0, n - 1);
            myList.Print(n);

            //SpeedTest();
        }

        //private static void SpeedTest()
        //{
        //    Stopwatch stopWatch = new Stopwatch();

        //    MyDataArray myArray;
        //    MyDataList myList;

        //    int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

        //    int[] numbers = { 1000, 2000, 4000, 8000, 16000, 32000, 64000 };

        //    Console.WriteLine("MEMORY ARRAY MERGE SORT");
        //    Console.WriteLine("|---------------------------|");
        //    Console.WriteLine("|  N          |  Run time   |");
        //    Console.WriteLine("|---------------------------|");
        //    foreach (int number in numbers)
        //    {
        //        //speed test for array
        //        myArray = new MyDataArray(number, seed);
        //        stopWatch.Start();
        //        QuickSort(myArray, 0, number - 1);
        //        stopWatch.Stop();

        //        Console.WriteLine("|  {0,-9}  |  {1,2}:{2,2}:{3,3}  |", number,
        //            stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);

        //        //reseting stop watch
        //        stopWatch.Reset();
        //    }
        //    Console.WriteLine("|---------------------------|\n");

        //    Console.WriteLine("MEMORY LIST MERGE SORT");
        //    Console.WriteLine("|---------------------------|");
        //    Console.WriteLine("|  N          |  Run time   |");
        //    Console.WriteLine("|---------------------------|");
        //    foreach (int number in numbers)
        //    {
        //        //speed test for list
        //        myList = new MyDataList(number, seed);
        //        stopWatch.Start();
        //        QuickSort(myList, 0, number - 1);
        //        stopWatch.Stop();

        //        Console.WriteLine("|  {0,-9}  |  {1,2}:{2,2}:{3,3}  |", number,
        //            stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);

        //        //reseting stop watch
        //        stopWatch.Reset();
        //    }
        //    Console.WriteLine("|---------------------------|");
        //}

        /* The main function that implements QuickSort() 
         * arr[] --> Array to be sorted, 
         * low --> Starting index, 
         * high --> Ending index */
        static void QuickSort(DataArray arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        } 

        /* This function takes last element as pivot, 
         * places the pivot element at its correct 
         * position in sorted array, and places all 
         * smaller (smaller than pivot) to left of 
         * pivot and all greater elements to right 
         * of pivot */
        static int partition(DataArray arr, int low, int high)
        {
            double pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than or equal to pivot 
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            double temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        /* The main function that implements QuickSort() 
         * arr[] --> Array to be sorted, 
         * low --> Starting index, 
         * high --> Ending index */
        static void QuickSort(DataList arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        /* This function takes last element as pivot, 
         * places the pivot element at its correct 
         * position in sorted array, and places all 
         * smaller (smaller than pivot) to left of 
         * pivot and all greater elements to right 
         * of pivot */
        static int partition(DataList arr, int low, int high)
        {
            double pivot = arr.Value(high);

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than or equal to pivot 
                if (arr.Value(j) <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    arr.Swap(i, j);
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            arr.Swap(i + 1, high);

            return i + 1;
        }

    }
}
