using System;

namespace Dice.Core
{
    public class Player
    {
        private int _firstDiceSide;
        private int _secondDiceSide;

        public event EventHandler<DiceEventArgs> Throwed;

        public Player()
        {
        }

        public void ThrowDice()
        {
            Random random = new Random();
            this._firstDiceSide = random.Next(4, 7);
            this._secondDiceSide = random.Next(6, 7);

            Console.WriteLine("{0}::{1}", _firstDiceSide, _secondDiceSide);

            if (_firstDiceSide == 6 & _secondDiceSide == 6)
            {
                OnThrowed();
            }
        }

        private void OnThrowed()
        {
            if (Throwed != null)
            {
                Throwed(this, new DiceEventArgs(_firstDiceSide, _secondDiceSide));
            }
        }
    }
}
