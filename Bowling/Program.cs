using System;
using System.Collections.Generic;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var frameList = new List<Frame>();
            GetFrames(frameList);
            var frames = frameList.ToArray();
            var game = new BowlingGame(frames);
            var score = game.GetScore();
            Console.WriteLine("The score is {0:N}", score);
        }

        static void GetFrames(List<Frame> frameList)
        {
            for ( int i = 0; i < 9; i++)
            {
                var frameObj = new Frame();
                if (!ReadFrame(frameObj))
                {
                    Console.WriteLine("Invalid input, input frame again.");
                    i++;
                }
                else
                {
                    frameList.Add(frameObj);
                }
            }

        }

        static bool ReadFrame(Frame frameObj)
        {
            bool validInput = false;
            Console.Write("Enter roll 1: ");
            string roll1Str = Console.ReadLine();
            int roll1;
            int roll2;

            if (Int32.TryParse(roll1Str, out roll1))
            {
                if (roll1 >= 0 && roll1 <= 10 )
                {
                    if (roll1 < 10)
                    {
                        Console.Write("Enter roll 2: ");
                        string roll2Str = Console.ReadLine();
                        if (Int32.TryParse(roll2Str, out roll2))
                        {
                            if (roll2 >= 0 && roll2 <= 10 - roll1)
                            {
                                frameObj.SetRollOne(roll1);
                                frameObj.SetRollTwo(roll2);
                                validInput = true;
                            }
                        }
                    }
                    else if (roll1 == 10)
                    {
                        frameObj.SetRollOne(roll1);
                        frameObj.SetRollTwo(0);
                        validInput = true;
                    }
                }
            }
            if (validInput == false)
            {
                Console.WriteLine("Invalid Input");
            }
            return validInput;
        }
    }

}
