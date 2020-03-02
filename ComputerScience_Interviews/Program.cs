 
using System;
 using System.Collections.Generic; //Added 2/18/2020 td 

namespace ComputerScience_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //string strListOfNumbersToSort = "";
            List<int> list_of_nums = new List<int>();
            //var tupleOfNums = new Tuple<List<int>, string>() { list_of_nums, "" }; 
            Tuple<List<int>, string> tupleOfNums; 

            Console.WriteLine("_____________________________________________");
            Console.WriteLine("____                                  _______");
            Console.WriteLine("____    Sorting Arrays of Integers    _______");
            Console.WriteLine("____                                  _______");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("__");
            Console.WriteLine("__Generate integer array via random-number functionality (Y/N):");
            bool boolUseRandom = (Console.ReadLine().ToUpper().StartsWith("Y"));

            if (boolUseRandom)
            {
                tupleOfNums = CreateRandomListOfIntegers();
            }
            else
            {
                tupleOfNums = UserDefinedListOfIntegers();
            }
                //Console.WriteLine("__");
                //Console.WriteLine("__Enter huge decimal number #2:");
                //listOfNumbers.Add(Console.ReadLine());

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
