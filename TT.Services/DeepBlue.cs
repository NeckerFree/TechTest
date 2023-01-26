using System.ComponentModel;

namespace TT.Services
{
    internal static class DeepBlue
    {
        internal static bool? CalculateWinner(short userMovement, short computerMove)
        {
            bool? tie = null;
            bool winUser = false;
            bool winComputer = true;
            int rock = 1;
            int paper = 2;
            int scissors = 3;
            if (userMovement == computerMove)
            {
                return tie;
            }
            if (userMovement == rock)
            {
                if (computerMove == paper)
                {
                    return winComputer;
                }
                if (computerMove == scissors)
                {
                    return winUser;
                }
            }
            if (userMovement == paper)
            {
                if (computerMove == rock)
                {
                    return winUser;
                }
                if (computerMove == scissors)
                {
                    return winComputer;
                }
            }
            if (userMovement == scissors)
            {
                if (computerMove == rock)
                {
                    return winComputer;
                }
                if (computerMove == paper)
                {
                    return winUser;
                }
            }
            return tie;
        }

        internal static byte GenerateMove()
        {
            Random rnd = new Random();
            byte movement = (byte)rnd.Next(1, 4);
            return movement;
        }
    }
}
