using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingGame
    {
        public Frame[] Frames;

        public BowlingGame()
        {
            Frames = new Frame[] { };
        }
        public BowlingGame(Frame[] inputFrames)
        {
            Frames = new Frame[10];
            for ( int i = 0; i < inputFrames.Length; i++)
            {
                Frames[i] = inputFrames[i];
            }
            for ( int i = inputFrames.Length; i < 10; i++)
            {
                Frames[i] = new Frame();
            }

        }

        public int GetScore()
        {
            int returnVal = 0;
            ProcessClosedFrames();
            returnVal = AddScore();
            return returnVal;
        }

        internal void ProcessClosedFrames()
        {
            for (int i = 0; i < 8; i++)
            {
                Frames[i].Score = Frames[i].R1 + Frames[i].R2;
                // Strike
                if (Frames[i].R1 == 10)
                {
                    // Next frame strike
                    if (Frames[i + 1].R1 == 10)
                    {
                        Frames[i].Score += Frames[i + 1].R1 + Frames[i + 2].R1;
                    }
                    // Next frame spare or open
                    else if (Frames[i + 1].R1 < 10)
                    {
                        Frames[i].Score += Frames[i + 1].R1 + Frames[i + 1].R2;
                    }
                }
                // Spare
                else if (Frames[i].R1 + Frames[i].R2 == 10)
                {
                    Frames[i].Score += Frames[i + 1].R1;
                }
            }
            // Ninth frame
            // Strike
            Frames[8].Score = Frames[8].R1 + Frames[8].R2;
            if (Frames[8].R1 == 10)
            {
                Frames[8].Score = 10 + Frames[9].R1 + Frames[9].R2;
            }
            // Spare
            else if (Frames[8].R1 + Frames[8].R2 == 10)
            {
                Frames[8].Score = 10 + Frames[9].R1;
            }
            // Tenth Frame
            Frames[9].Score = Frames[9].R1 + Frames[9].R2 + Frames[9].R3;
        }

        internal int AddScore()
        {
            int returnVal = -1;
            int sum = 0;
            if (Frames.Length == 10 )
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += Frames[i].GetScore();
                }
            }
            if (sum >= 0 && sum <= 300)
            {
                returnVal = sum;
            }
            return returnVal;
        }
    }

    public class Frame
    {
        internal int R1;
        internal int R2;
        internal int R3;
        internal int Score;
        internal bool isFinalFrame = false;

        public Frame()
        {
            R1 = 0;
            R2 = 0;
            R3 = 0;
            Score = 0;
        }

        public Frame(int roll1)
        {
            SetRollOne(roll1);
            SetRollTwo(0);
            R3 = 0;
            Score = 0;
        }
        public Frame(int roll1, int roll2)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
            Score = 0;
        }

        public Frame(int roll1, int roll2, int roll3)
        {
            isFinalFrame = true;
            SetRollOne(roll1);
            SetRollTwo(roll2);
            SetRollThree(roll3);
            Score = 0;
        }
        public Frame(string roll1, string roll2)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
            R3 = 0;
            Score = 0;
        }

        public Frame(string roll1, string roll2, string roll3)
        {
            isFinalFrame = true;
            SetRollOne(roll1);
            SetRollTwo(roll2);
            SetRollThree(roll3);
            Score = 0;
        }

        public void SetRollOne(string roll)
        {
            int value;
            roll.Trim();
            if (int.TryParse(roll, out value) && value >= 0 && value <= 10)
            {
                R1 = value;
            }
            else if (roll.ToUpper().Equals("X"))
            {
                R1 = 10;
            }
        }
        public void SetRollOne(int roll)
        {
            if (roll >= 0 && roll <= 10)
            {
                R1 = roll;
            }
        }
        public void SetRollTwo(string roll)
        {
            int value;
            roll.Trim();
            if (int.TryParse(roll, out value) && value >= 0 && value <= 10) {
                if (!isFinalFrame)
                {
                    if (R1 + value <= 10)
                    {
                        R2 = value;
                    }
                    else R2 = 10 - R1;
                }
                else
                {
                    if (R1 == 10 || (R1 + value <= 10))
                    {
                        R2 = value;
                    }
                    else R2 = 10 - value;
                }

            }
            else if (roll.Equals("/"))
            {
                R2 = 10 - R1;
            }
            else if (isFinalFrame && roll.ToUpper().Equals("X"))
            {
                // set roll 2 to ten only if roll 1 was a strike
                if (R1 == 10) R2 = 10;
                else R2 = 10 - R1;
            }
        }
        public void SetRollTwo(int roll)
        {
            if (roll >= 0 && roll <= 10)
            {
                if (!isFinalFrame)
                {
                    if (R1 + roll <= 10)
                    {
                        R2 = roll;
                    }
                    // error handling
                    else R2 = 10 - R1;
                }
                else
                {
                    if (R1 == 10 || (R1 + roll <= 10))
                    {
                        R2 = roll;
                    }
                    // roll 1 + roll2 add up to more than ten, error handling
                    else R2 = 10 - R1;
                }
            }
        }

        public void SetRollThree(string roll)
        {
            int value;
            if (Int32.TryParse(roll, out value) && value >= 0 && value <= 10)
            {
                R3 = value;
            }
            else if (roll.Equals("/")){
                R3 = 10 - R2;
            }
            else if (roll.ToUpper().Equals("X")){
                R3 = 10;
            }
        }
        public void SetRollThree(int roll)
        {
            if (roll >= 0 && roll <= 10)
            {
                R3 = roll;
            }
        }
        public int GetScore()
        {
            return Score;
        }

    }
}
