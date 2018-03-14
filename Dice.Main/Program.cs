using Dice.Core;
using System;

namespace Dice.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            var player = new Player();
            player.Throwed += (sender, e) =>
            {
                Console.WriteLine("Sum of two dices equal 12 {0}::{1}. My congratulations this game is yours!!!", e.FirstDiceSide, e.SecondDiceSide);
            };

            do
            {
                player.ThrowDice();
                Console.WriteLine("Try again (Press SPACE). To quit click press any key");
                keyInfo = Console.ReadKey(true);
            }
            while (keyInfo.Key == ConsoleKey.Spacebar);
        }
    }
}
