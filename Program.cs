// Tic Tac Toe program CSE 210
// Emily Rowley

using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Tic-Tac-Toe program!");
            Console.WriteLine();
        
            // Declaring a blank board array and putting it into an array
            string[] boardPlaces = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> board = new List<string>(boardPlaces);

            do
            {
                Console.WriteLine();
                DisplayBoard(board);
                bool isXsTurn = Program.XTurn(board);
                int choice = 0;
                while (choice == 0)
                {
                    choice = UserChoice(board, isXsTurn);
                }
                ChangeBoard(board, choice, isXsTurn);
            }while(HasWon(board) != true);

        }
        public static bool XTurn(List<string> board)
        // Decides who's turn it is. If it is X's turn it will return true, otherwise it will return false. Default is for X to start.
        {
            int xCount = 0;
            int oCount = 0;
            foreach (string place in board)
            {
                if (place == "X")
                {
                    xCount ++;
                }
                else if (place == "O")
                {
                    oCount ++;
                }
            }

            if (xCount <= oCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int UserChoice(List<string> board, bool isXTurn)
        // Prompt the user for what place they would like to play. Returns that number.
        {
            string letter;
            if (isXTurn)
            {
                letter = "X";
            }
            else
            {
                letter = "O";
            }
            Console.Write($"{letter}'s turn (1-9): ");
            string sChoice = Console.ReadLine();
            int iChoice = int.Parse(sChoice);
            
            if (iChoice > 9 || iChoice < 1)
            {
                Console.WriteLine("Please enter a number between 1 and 9.");
                return 0;
            }
            else
            {
                foreach (string square in board)
                {
                    if (square == sChoice)
                    {
                        return iChoice;
                    }
                }
                Console.WriteLine("That place is taken, please try again.");
                return 0;
            }
        }

        public static void DisplayBoard(List<string> board)
        // Displays the current board.
        {
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
        }

        public static bool HasWon(List<string> board)
        // Determines if the game has been won and returns true if it has.
        {
            // Win combinations
            int[] diagonalWin = {0, 4, 8};
            int[] column1Win = {0, 3, 6};
            int[] column2Win = {1, 4, 7};
            int[] column3Win = {2, 5, 8};
            int[] row1Win = {0, 1, 2};
            int[] row2Win = {3, 4, 5};
            int[] row3Win = {6, 7, 8};
            List<int[]> winCombos = new List<int[]>();
            winCombos.Add(diagonalWin);
            winCombos.Add(column1Win);
            winCombos.Add(column2Win);
            winCombos.Add(column3Win);
            winCombos.Add(row1Win);
            winCombos.Add(row2Win);
            winCombos.Add(row3Win);

            foreach (int[] combo in winCombos)
            {
                if (board[combo[0]] == board[combo[1]] && board[combo[1]] == board[combo[2]])
                {
                    DisplayBoard(board);
                    Console.WriteLine($"Congrats player {board[combo[0]]} won!");
                    return true;
                }
            }
            if (board[0] != "1" && board[1] != "2" && board[2] != "3" && board[3] != "4" && board[4] != "5" && board[5] != "6" && board[6] != "7" && board[7] != "8" && board[8] != "9")
            {
                DisplayBoard(board);
                Console.WriteLine("Tie game");
                return true;
            }
            return false;
        }

        public static void ChangeBoard(List<string> board, int NumToChange, bool isXTurn)
        // Updates the current board after each player's turn.
        {
            string letter;
            if (isXTurn)
            {
               letter = "X"; 
            }
            else
            {
                letter = "O";
            }

            board[NumToChange - 1] = letter;
        }
    }
}