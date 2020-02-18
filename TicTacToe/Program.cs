using System;

namespace TicTacToe
{
    class Program
    {
        static string[,] array2D = new string[,]
            {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
            };
        static int turn = 1;
        static string xOrO;
        static int[] selectedValues = new int[10];
        static string input;
        static bool wasInputValid;
        static string currentPlayer;
        static void Main(string[] args)
        {
            do
            {
                PrintBoard();
                DetermineCurrentPlayer();
                Console.WriteLine($"{currentPlayer}: choose your field!");
                input = Console.ReadLine();
                int inputAsInt;
                wasInputValid = int.TryParse(input, out inputAsInt);
                while (!wasInputValid)
                {
                    Console.WriteLine("Input was invalid, please enter a correct value:");
                    input = Console.ReadLine();
                    wasInputValid = int.TryParse(input, out inputAsInt);
                }
                while (inputAsInt < 0 || inputAsInt > 9)
                {
                    Console.WriteLine("Value must be a number between 0 and 9, please enter a correct input:");
                    input = Console.ReadLine();
                    wasInputValid = int.TryParse(input, out inputAsInt);
                    while (!wasInputValid)
                    {
                        Console.WriteLine("Input was invalid, please enter a correct value:");
                        input = Console.ReadLine();
                        wasInputValid = int.TryParse(input, out inputAsInt);
                    }
                }
                while (Array.IndexOf(selectedValues, inputAsInt) > 0)
                {
                    Console.WriteLine("Value has already been selected, please choose another value:");
                    input = Console.ReadLine();
                    wasInputValid = int.TryParse(input, out inputAsInt);
                    while (!wasInputValid)
                    {
                        Console.WriteLine("Input was invalid, please enter a correct value:");
                        input = Console.ReadLine();
                        wasInputValid = int.TryParse(input, out inputAsInt);
                    }
                    while (inputAsInt < 0 || inputAsInt > 9)
                    {
                        Console.WriteLine("Value must be a number between 0 and 9, please enter a correct input:");
                        input = Console.ReadLine();
                        wasInputValid = int.TryParse(input, out inputAsInt);
                        while (!wasInputValid)
                        {
                            Console.WriteLine("Input was invalid, please enter a correct value:");
                            input = Console.ReadLine();
                            wasInputValid = int.TryParse(input, out inputAsInt);
                        }
                    }
                }
                switch (inputAsInt)
                {
                    case 1:
                        array2D[0, 0] = xOrO;
                        break;
                    case 2:
                        array2D[0, 1] = xOrO;
                        break;
                    case 3:
                        array2D[0, 2] = xOrO;
                        break;
                    case 4:
                        array2D[1, 0] = xOrO;
                        break;
                    case 5:
                        array2D[1, 1] = xOrO;
                        break;
                    case 6:
                        array2D[1, 2] = xOrO;
                        break;
                    case 7:
                        array2D[2, 0] = xOrO;
                        break;
                    case 8:
                        array2D[2, 1] = xOrO;
                        break;
                    case 9:
                        array2D[2, 2] = xOrO;
                        break;
                }
                selectedValues[turn] = inputAsInt;
                turn++;
                DetermineWinner();
                DetermineDraw();
            } while (turn <= 10);
        }
        static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array2D[0, 0]}  |  {array2D[0, 1]}  |  {array2D[0, 2]}   ");
            Console.WriteLine("____ |_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array2D[1, 0]}  |  {array2D[1, 1]}  |  {array2D[1, 2]}   ");
            Console.WriteLine("____ |_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array2D[2, 0]}  |  {array2D[2, 1]}  |  {array2D[2, 2]}   ");
            Console.WriteLine("     |     |     ");
        }
        static void DetermineCurrentPlayer()
        {
            if(turn % 2 != 0)
            {
                currentPlayer = "Player 1";
                xOrO = "O";
            }
            else
            {
                currentPlayer = "Player 2";
                xOrO = "X";
            }
        }
        static void DetermineWinner()
        {
            if ((array2D[0, 0] == array2D[0, 1] && array2D[0, 1] == array2D[0, 2]) ||
                    (array2D[1, 0] == array2D[1, 1] && array2D[1, 1] == array2D[1, 2]) ||
                    (array2D[2, 0] == array2D[2, 1] && array2D[2, 1] == array2D[2, 2]) ||
                    (array2D[0, 0] == array2D[1, 0] && array2D[1, 1] == array2D[2, 0]) ||
                    (array2D[0, 1] == array2D[1, 1] && array2D[1, 1] == array2D[2, 1]) ||
                    (array2D[0, 2] == array2D[1, 2] && array2D[1, 2] == array2D[2, 2]) ||
                    (array2D[0, 0] == array2D[1, 1] && array2D[1, 1] == array2D[2, 2]) ||
                    (array2D[0, 2] == array2D[1, 1] && array2D[1, 1] == array2D[2, 0]))
            {
                PrintBoard();
                Console.WriteLine($"{currentPlayer} has won the game!");
                Console.WriteLine("Press any key to re-start the game:");
                Console.ReadKey();
                turn = 1;
                array2D[0, 0] = "1";
                array2D[0, 1] = "2";
                array2D[0, 2] = "3";
                array2D[1, 0] = "4";
                array2D[1, 1] = "5";
                array2D[1, 2] = "6";
                array2D[2, 0] = "7";
                array2D[2, 1] = "8";
                array2D[2, 2] = "9";
                selectedValues = new int[10];
            }
        }
        static void DetermineDraw()
        {
            if(turn == 10)
            {
                PrintBoard();
                Console.WriteLine("Match was a draw!");
                Console.WriteLine("Press any key to re-start the game:");
                Console.ReadKey();
                turn = 1;
                array2D[0, 0] = "1";
                array2D[0, 1] = "2";
                array2D[0, 2] = "3";
                array2D[1, 0] = "4";
                array2D[1, 1] = "5";
                array2D[1, 2] = "6";
                array2D[2, 0] = "7";
                array2D[2, 1] = "8";
                array2D[2, 2] = "9";
                selectedValues = new int[10];
            }
        }

    }
}
