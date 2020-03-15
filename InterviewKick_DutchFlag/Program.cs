using System;
using System.Collections.Generic;  

namespace InterviewKick_DutchFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void dutch_flag_sort(List<char> balls)
        {
            //
            //
            //
            int intIndexStart = 0;
            int intIndexEnd = -1 + balls.Count;
            int intIndexFinal = 0;

            //private static void dutch_flag_sort_helper(List<char> balls, int intIndexStart, int intIndexEnd, 
            //                                       char pchar1_R, char pchar2a, char pchar2b,
            //                                       ref int pref_intIndexFinal)

            dutch_flag_sort_helper(balls, intIndexStart, intIndexEnd, 'R', 'G', 'B', ref intIndexFinal);

            if (balls[intIndexFinal] == 'R') intIndexFinal++; //We need it to point to a G or B color. 

            dutch_flag_sort_helper(balls, intIndexFinal, intIndexEnd, 'G', 'B', '_', ref intIndexFinal);


        }

        /***  private static void dutch_dont_use(List<char> balls)
          {
              //
              //
              //
              int intPointerR= -1;
              int intPointerGorB = 0 + balls.Count; 
              int intPointerG = 0 + balls.Count; 
              int intPointerB = 0 + balls.Count;
              bool bKeepLooping = true; 
              char charBorG = ' ';
              char tempChar = ' ';
              bool boolBlueOrGreen = false;

              do
              {
                  intPointerR++;
                  //intPointerGorB--;

                  //boolRed = ('R' == balls[intPointerGorB]);
                  charBorG =  balls[intPointerR];
                  boolBlueOrGreen = ('G' == charBorG ||
                                     'B' == charBorG );

                  do
                  {
                      intPointerGorB--; 
                     boolRed = ('R' == balls[intPointerGorB]);
              bool boolBlueOrGreen = false;
                  } while (!boolRed);


                  if (boolRed && boolBlueOrGreen)
                  {
                      //tempChar = charBorG;
                      balls[intPointerBorG] = charBorG;
                      balls[intPointerR] = 'R'; 
                  }

                  bKeepLooping = (intPointerR < intPointerBorG);

              } while (bKeepLooping);

          }
          ***/


        private static void dutch_flag_sort_helper(List<char> balls, int intIndexStart, int intIndexEnd,
                                                   char pchar1_R, char pchar2a, char pchar2b,
                                                   ref int pref_intIndexFinal)
        {
            //
            //
            //

            int intPointer1R = -1 + intIndexStart;
            int intPointer2_BorG = 1 + intIndexEnd;    // 0 + balls.Count; 
                                                       //int intPointerG = 0 + balls.Count; 
                                                       //int intPointerB = 0 + balls.Count;
            bool bKeepLooping = true;
            char char2_BorG = ' ';
            char tempChar = ' ';
            bool bLefthandColor = false;
            bool boolBlueOrGreen = false;

            do
            {
                intPointer1R++;
                //intPointerGorB--;

                //boolRed = ('R' == balls[intPointerGorB]);
                char2_BorG = balls[intPointer1R];
                //boolBlueOrGreen = ('G' == char2_BorG ||
                //                   'B' == char2_BorG );
                boolBlueOrGreen = (pchar2a == char2_BorG ||
                                   pchar2b == char2_BorG);

                if (boolBlueOrGreen)
                {
                    do
                    {
                        intPointer2_BorG--;
                        //boolRed = ('R' == balls[intPointerGorB]);
                        bLefthandColor = (pchar1_R == balls[intPointer2_BorG]);

                    } while (!bLefthandColor);

                    //if (boolRed && boolBlueOrGreen)
                    if (bLefthandColor && boolBlueOrGreen)
                    {
                        //tempChar = charBorG;
                        balls[intPointer2_BorG] = char2_BorG;
                        //balls[intPointerR] = 'R';
                        balls[intPointer1R] = pChar1_R;
                    }
                }

                bKeepLooping = (intPointer1R < intPointer2_BorG);

            } while (bKeepLooping);

            pref_intIndexFinal = intPointer1R;

            return;

        }





    }
}
