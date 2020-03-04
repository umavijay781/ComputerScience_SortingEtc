 
using System;
 using System.Collections.Generic; //Added 2/18/2020 td 
using ComputerScience_Sorting_Lib; //Added 3/4/2020 thomas downes

namespace ComputerScience_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Added 3/4/2020 td
            //
            //int[] array_integers = new int[] { 56, 23, 90 };
            //int[] sub_array = new int[2];  
            //array_integers.CopyTo(sub_array, 0);

            var objSorting_BubbleSort = new ComputerScience_Sorting_Lib.SortingByBubbleSort();
            var objSorting_Selection = new ComputerScience_Sorting_Lib.SortingBySelectionSort();
            var objSorting_MergeSort = new ComputerScience_Sorting_Lib.SortingByMergeSort();

            //Console.WriteLine("Hello World!");
            //string strListOfNumbersToSort = "";
            List<int> list_of_nums = new List<int>();
            //var tupleOfNums = new Tuple<List<int>, string>() { list_of_nums, "" }; 
            Tuple<List<int>, string> tupleOfNums = null;

            Console.WriteLine("__");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("____                                  _______");
            Console.WriteLine("____    Sorting Arrays of Integers    _______");
            Console.WriteLine("____                                  _______");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("__");
            Console.WriteLine("__Generate integer array via random-number functionality? (Y/N):");

            bool boolUseRandom = (Console.ReadLine().ToUpper().StartsWith("Y"));

            if (boolUseRandom)
            {
                tupleOfNums = CreateRandomListOfIntegers();
            }
            else
            {
                Console.WriteLine("__");
                Console.WriteLine("__Use a pre-defined list of 100 integers? (Y/N):");
                
                bool boolUsePredefined = (Console.ReadLine().ToUpper().StartsWith("Y"));
                if (boolUsePredefined)
                {
                    //var objSorting_BubbleSort = new ComputerScience_Sorting_Lib.SortingByBubbleSort();
                    tupleOfNums = objSorting_BubbleSort.DataSetToTest_Tuple(Enum_DataSetSize.N_is100);
                }
                else
                {
                    Console.WriteLine("__");
                    Console.WriteLine("__Compose your own list of 100 integers? (Y/N):");

                    bool boolUserDefinesHisList = (Console.ReadLine().ToUpper().StartsWith("Y"));
                    if (boolUserDefinesHisList)
                    {
                        tupleOfNums = UserDefinedListOfIntegers();
                    }
                    else
                    {
                        //Program.Main("Run program again");
                        //Program.Main(new string[] { "Run program again" });
                        Console.WriteLine("__");
                        Console.WriteLine("__Press the Enter key, to exit the program.");
                        Console.ReadLine();
                    }
                }
            }
            //Console.WriteLine("__");
            //Console.WriteLine("__Enter huge decimal number #2:");
            //listOfNumbers.Add(Console.ReadLine());

            //
            //Processing of the list. 
            //
            if (tupleOfNums != null)
            {
                Console.WriteLine("__");
                Console.WriteLine("__Here is the list of numbers to be sorted:");
                Console.WriteLine("__");
                Console.WriteLine(tupleOfNums.Item2.ToString());
                Console.WriteLine("__");
                //int[] objSortedArray_Bubble = objSorting_BubbleSort.Sort_ReturnMilliseconds();
                int[] array_ofNums;
                
                array_ofNums = tupleOfNums.Item1.ToArray();  // Refresh / initialize. 
                double time_millisecondsBubble = objSorting_BubbleSort.Sort_ReturnMilliseconds(array_ofNums);
                string strSortedList_Bubble = array_ofNums.ToString(); 

                array_ofNums = tupleOfNums.Item1.ToArray(); // Refresh. 
                double time_millisecondsSelect = objSorting_Selection.Sort_ReturnMilliseconds(array_ofNums);
                array_ofNums = tupleOfNums.Item1.ToArray();  // Refresh. 
                double time_millisecondsMerge = objSorting_MergeSort.Sort_ReturnMilliseconds(array_ofNums);

                Console.WriteLine("__");
                Console.WriteLine("__Here are the list(s) of sorted numbers:");
                Console.WriteLine("__");



            }

        }

        private static Tuple<List<int>, string> CreateRandomListOfIntegers()
        {
            Console.WriteLine("__");
            Console.WriteLine("__Do you want the length of the array to be random? (Y/N):");
            bool boolRandomLength = (Console.ReadLine().ToUpper().StartsWith("Y"));
            int intLengthOfArray = 0;
            var listOfNums = new List<int>();
            string strListOfNums = "";

            if (boolRandomLength)
            {
                intLengthOfArray = (new System.Random()).Next(3, 20);
            }
            else
            {
                Console.WriteLine("__");
                intLengthOfArray = int.Parse(Console.ReadLine().Trim());
            }

            System.Random randomNums = new System.Random();
            //listOfNums.Add(randomNums.Next(1, 100));
            //strListOfNums = (" " + listOfNums.FindLast(i => true));
            int intNewRandomNum = randomNums.Next(1, 100);
            listOfNums.Add(intNewRandomNum);
            strListOfNums = "{ " + intNewRandomNum.ToString();

            for (int intIndex = 2; intIndex <= intLengthOfArray; intIndex++)
            {
                //listOfNums.Add(randomNums.Next(1, 100));
                //strListOfNums += ", " + listOfNums.FindLast(i => true);
                intNewRandomNum = randomNums.Next(1, 100);
                listOfNums.Add(intNewRandomNum);
                strListOfNums += ", " + intNewRandomNum.ToString();
            }

            return Tuple.Create(listOfNums, strListOfNums);

        }

        private static Tuple<List<int>, string> UserDefinedListOfIntegers()
        {
            List<string> list_inputLines = new List<string>();
            bool boolContinue = false;
            var listOfNums = new List<int>();
            string strListOfNums = "";

            Console.WriteLine("__");
            Console.WriteLine("__Please enter a list of integers, separated by spaces only:");
            Console.WriteLine("__");
            list_inputLines.Add(Console.ReadLine().Trim());

            do
            {
                Console.WriteLine("__");
                Console.WriteLine("__Do you want to continue adding integers? (Y/N):");
                boolContinue = (Console.ReadLine().ToUpper().StartsWith("Y"));
                Console.WriteLine("__Please continue with your list:");
                Console.WriteLine("__");
                list_inputLines.Add(Console.ReadLine().Trim());

            } while (boolContinue);

            //
            //Processing.....
            //

            return Tuple.Create(listOfNums, strListOfNums);

        }

    }
    }
