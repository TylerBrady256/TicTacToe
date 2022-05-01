using System; 
using System.Collections.Generic;

namespace TicTacToe
{
    class game
    {
        static void Main(string[] args)
        {
            int turns = 1 ;

            List<string> gameBoard= createGrid();
            printBoard(gameBoard);

            while (turns <= 9)
            {
                string player = playerTurn(turns);
                gameBoard = playerMove(gameBoard,player);
                printBoard(gameBoard);


                if (turns >= 5)
                {
                    bool win = checkForWin(gameBoard,player);
                    if (win == true)
                    {
                        Console.WriteLine($"{player}'s have won, good game!");
                        turns = 10;
                    }
            
                }
            
                turns++;
            }
        }


        static List<string> playerMove(List<string> gameboard , string player)
        {
            bool correctMove = false;
            while (correctMove == false)
            {
            Console.WriteLine($"it is {player}'s turn");
            Console.WriteLine("which space would you like to conquer?");

            // This will throw Errors if we do not change it to only accept int values
            string playerMove = Console.ReadLine();
            int location = int.Parse(playerMove);

            if (gameboard[location] == "X"||gameboard[location] == "O")
            {
                Console.WriteLine("Pleases make a valid entry");
            }
            else
            {
                correctMove = true;
                gameboard[location] = player;
            }
            
            }
            
            return gameboard;
        }

        static List<string> createGrid()
        {
            List<string> board = new List<string>();

            for (int i=0; i<=9 ;i++)
            {
                string placement = i.ToString();
                board.Add($"{placement}");
            }
            return  board;
        }

        static void printBoard(List<string> gameBoard)
        {
            Console.WriteLine(
            $"{gameBoard[0]}  |  {gameBoard[1]}  |  {gameBoard[2]}\n"+
            "---+-----+---\n"+
            $"{gameBoard[3]}  |  {gameBoard[4]}  |  {gameBoard[5]}\n"+
             "---+-----+---\n"+
            $"{gameBoard[6]}  |  {gameBoard[7]}  |  {gameBoard[8]}"
            );

        }

        static string playerTurn(int turns)
        {
            string player = "X";
            
            if (turns % 2 == 0)
            {
                player = "O";  
            }

            return player ;

        }

        static bool checkForWin(List<string> gameBoard , string player)
        {

            // straights increase by 1 diagonals one by 4 the other by 2 columns increase by 3
            //straights increase base by 3 diagonals by 2 colums by 1
            
            for (int entry=0;entry<=8; entry=entry+3)
            {
                int iteration = 0;
                int diagonal = 0;
                

                if (gameBoard[entry] == player && gameBoard[entry+1] == player && gameBoard[entry+2] == player)
                {
                    return true;
                }
                else if (gameBoard[entry-iteration] == player && gameBoard[entry-iteration+3] == player && gameBoard[entry-iteration+6] == player)
                {
                    return true;
                }
                else if (entry < 6 && (gameBoard[entry+diagonal] == player && gameBoard[4] == player && gameBoard[8-iteration] == player))
                {
                    return true;
                }

                iteration = iteration+2;
                diagonal++;
                
            }

            // if (gameBoard[0] == player && gameBoard[1] == player && gameBoard[2] == player||
            // gameBoard[3] == player && gameBoard[4] == player && gameBoard[5] == player||
            // gameBoard[6] == player && gameBoard[7] == player && gameBoard[8] == player||
            // gameBoard[0] == player && gameBoard[4] == player && gameBoard[8] == player||
            // gameBoard[2] == player && gameBoard[4] == player && gameBoard[6] == player||
            // gameBoard[0] == player && gameBoard[3] == player && gameBoard[6] == player||
            // gameBoard[1] == player && gameBoard[4] == player && gameBoard[7] == player||
            // gameBoard[2] == player && gameBoard[5] == player && gameBoard[8] == player)
            // {
            //     return true;
            // }
            
            return false;
        }

    }

}