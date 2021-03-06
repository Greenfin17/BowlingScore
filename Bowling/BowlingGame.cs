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
        public BowlingGame(Frame[] frames)
        {
            Frames = frames;
        }

        private bool _isProcessed = false;
        public int GetScore()
        {
            int returnVal = 0;
            if (Frames.Length < 10)
            {
                returnVal = -1;
            }
            else if (Frames.Length == 10)
            {
                if (_isProcessed == false)
                {
                    ProcessClosedFrames();
                }
                if (_isProcessed == true)
                {
                    returnVal = AddScore();
                }
            }
            return returnVal;
        }

        internal bool ProcessClosedFrames()
        {
            if (!_isProcessed && Frames.Length == 10)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Frames[i].R1 == 10)
                    {
                        if (Frames[i + 1].R1 < 10)
                        {
                            Frames[i].R2 = Frames[i + 1].R1;
                            Frames[i].R3 = Frames[i + 1].R2;
                        }
                        else if (Frames[i + 1].R1 == 10)
                        {
                            Frames[i].R2 = Frames[i + 1].R1;
                            Frames[i].R3 = Frames[i + 2].R1;
                        }
                    }
                    else if (Frames[i].R1 + Frames[i].R2 == 10)
                    {
                        Frames[i].R3 = Frames[i + 1].R1;
                    }
                }
                if (Frames[8].R1 == 10)
                {
                    Frames[8].R2 = Frames[9].R1;
                    Frames[8].R3 = Frames[9].R2;
                }
                else if (Frames[8].R1 + Frames[8].R2 == 10)
                {
                    Frames[8].R3 = Frames[9].R1;
                }
                // Frame 10 depends on correct input for number of rolls, 3 for a spare or strike
                _isProcessed = true;
            }
            return _isProcessed;
        }

        internal int AddScore()
        {
            int returnVal = -1;
            int sum = 0;
            if (Frames.Length == 10 && _isProcessed)
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += Frames[i].GetSum();
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
        internal int R1 { get; set; }
        internal int R2 { get; set; }
        internal int R3 { get; set; }


        public Frame()
        {
            R1 = 0;
            R2 = 0;
            R3 = 0;
        }

        public Frame(int roll1)
        {
            SetRollOne(roll1);
            SetRollTwo(0);
            R3 = 0;
        }
        public Frame(string roll1, string roll2)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
            R3 = 0;
        }

        public Frame(int roll1, int roll2)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
        }

        public Frame(int roll1, int roll2, int roll3)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
            SetRollThree(roll3);
        }

        public Frame(string roll1, string roll2, string roll3)
        {
            SetRollOne(roll1);
            SetRollTwo(roll2);
            SetRollThree(roll3);
        }

        public void SetRollOne(string roll)
        {
            int value;
            roll.Trim();
            if (int.TryParse(roll, out value) && value >= 0 && value <= 10)
            {
                R1 = value;
                if (R1 == 10)
                {
                    R2 = 0;
                    R3 = 0;
                }
            }
            else if (roll.Equals("X"))
            {
                R1 = 10;
                R2 = 0;
                R3 = 0;
            }
        }
        public void SetRollOne(int roll)
        {
            if (roll >= 0 && roll < 10)
            {
                R1 = roll;
            }
            else if (roll == 10)
            {
                R1 = roll;
                R2 = 0;
                R3 = 0;
            }
        }
        public void SetRollTwo(string roll)
        {
            int value;
            roll.Trim();
            if (R1 < 10 && int.TryParse(roll, out value) && value >= 0 && value <= 10 && (R1 + value) <= 10)
            {
                R2 = value;
            }
            else if (R1 == 10)
            {
                R2 = 0;
                R3 = 0;
            }
            else if (roll.Equals("\\"))
            {
                R2 = 10 - R1;
                R3 = 0;
            }
        }
        public void SetRollTwo(int roll)
        {
            if (R1 < 10 && roll >= 0 && roll <= 10 && (R1 + roll) <= 10)
            {
                R2 = roll;
            }
        }

        public void SetRollThree(int roll)
        {
            if (roll >= 0 && roll <= 10)
            {
                R3 = roll;
            }
        }

        public void SetRollThree(string roll)
        {
            int value;
            if (Int32.TryParse(roll, out value) && value >= 0 && value <= 10)
            {
                R3 = value;
            }
        }
        public int GetSum()
        {
            return R1 + R2 + R3;
        }

    }
}
