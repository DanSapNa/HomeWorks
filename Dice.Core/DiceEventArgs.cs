using System;

namespace Dice.Core
{
    public class DiceEventArgs : EventArgs
    {
        public int FirstDiceSide { get; private set; }
        public int SecondDiceSide { get; private set; }

        public DiceEventArgs(int firstDiceSide, int secondDiceSide)
        {
            FirstDiceSide = firstDiceSide;
            SecondDiceSide = secondDiceSide;
        }
    }
}
