using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Xml;


namespace c_TEXTChess
{
    internal class Program
    {
        // Purpose to import the dll function
        [DllImport("ChangeConsole-CPPHelper.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int ChangeFont(int FontSize);

        // Variable for storing the current team
        public static ETeam currentTeam = ETeam.White;
        public static void CPPCall(Board board)
        {
            // This block calls the ChangeFont function if the dll file exists or else it displays the error and changes the board
            try
            {
                ChangeFont(20);
                board.hasDll = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Missing ChangeConsole-CPPHelper.dll {0}", e.ToString());
                board.hasDll = false;
            }

        }
        static void Main(string[] args)
        {
           //BasePiece myPiecedd = new Rook();
            // Creates an instance of board
            Board board = new Board();
            CPPCall(board); // Comment to add text symbols, uncomment to add chess pieces
            Console.OutputEncoding = Encoding.UTF8; // We need to encode this line to get access to Chess Symbols
            board.InitBoard(board); // Initializes the board
            GameplayLoop(board);

        }

        // Function that handles the base play game loop
        public static void GameplayLoop(Board board)
        {
            while (true)
            {
                Console.Clear(); // Resets the board after every move
                board.PrintBoard();
                CheckForCastles(board);
                List<Grid> startEndGrids = GetPlayerMoveInput();// Gets input from the player

                Console.WriteLine($"{startEndGrids[0].x}{startEndGrids[0].y} {startEndGrids[1].x}{startEndGrids[1].y}");
               
                //checking if the player picked his own piece
                if (board.FindPieceAtGrid(startEndGrids[0]) == null || board.FindPieceAtGrid(startEndGrids[0]).team == currentTeam)
                {
                    //check if the move was valid and the piece has moved
                    if (board.WasMoveValid(startEndGrids[0], startEndGrids[1]))
                    {                   
                       // Console.WriteLine("Can Kingside Castle?: " + board.whiteKing.canKingSideCastle);
                       // Console.WriteLine("Can Queenside Castle?: " + board.whiteKing.canQueenSideCastle);

                        BasePiece attacker = board.FindPieceAtGrid(startEndGrids[1]);

                        if (attacker == null)
                        {
                            Console.WriteLine("Attacker is null. No piece found at the start grid position.");
                        }

                        //this block is to check if the move made leads to a check and if it does we check for checkmate
                        if (attacker.team == ETeam.Black && attacker.GetLegalMoves().Contains(board.whiteKing.currentPos))
                        {
                            Console.WriteLine($"Check? : {board.whiteKing.IsBeingChecked()}");

                            if(board.whiteKing.IsCheckmate(board.FindPieceAtGrid(attacker.currentPos)))
                            {
                                PrintWinner(ETeam.Black);
                                break;
                            }

                            Console.WriteLine($"Checkmate? : {board.whiteKing.IsCheckmate(board.FindPieceAtGrid(attacker.currentPos))}");

                            for (int i = 0; i < board.whiteKing.GetLegalMoves().Count; i++)
                            {
                                Console.WriteLine($"Legal move: {board.whiteKing.GetLegalMoves()[i].x}, {board.whiteKing.GetLegalMoves()[i].y}");
                            }
                        }
                        else if (attacker.team == ETeam.White && attacker.GetLegalMoves().Contains(board.blackKing.currentPos))
                        {
                            Console.WriteLine($"Check? : {board.blackKing.IsBeingChecked()}");
                            Console.WriteLine($"Checkmate? : {board.blackKing.IsCheckmate(board.FindPieceAtGrid(attacker.currentPos))}");

                            if(board.blackKing.IsCheckmate(board.FindPieceAtGrid(attacker.currentPos)))
                            {
                                PrintWinner(ETeam.White); break;
                            }

                        }


                        //change the current team so the next player can play
                        ChangeCurrentTeam();
                    }
                    else
                    {
                        Console.WriteLine("Move wasn't valid");
                    }
                }
                else
                {
                    Console.WriteLine("Not your piece");
                }

                CheckForCastles(board);
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }
        }

        //function to change the current team 
        public static void ChangeCurrentTeam()
        {
            if (currentTeam == ETeam.White)
            {
                currentTeam = ETeam.Black;
            }
            else
            {
                currentTeam = ETeam.White;
            }
        }

        //function to get the input from the player
        static private List<Grid> GetPlayerMoveInput()
        {
            // Temp Variables
            List<Grid> startEndGrids = new List<Grid>();
            char[] moveInput;
            int startPosX;
            int startPosY;
            int endPosX;
            int endPosY;

            bool askAgain = true;

            while (askAgain)
            {
                // Prompt Player for Input
                Console.WriteLine("{0}-> Please enter a move: (StartPos EndPos) ", currentTeam.ToString());
                string playerInput = Console.ReadLine().ToLower();
                moveInput = playerInput.ToCharArray();

                // Checks for segmentation fault
                if (moveInput.Length != 5 ||
                    !char.IsLetter(moveInput[0]) ||
                    !char.IsLetter(moveInput[3]) ||
                    !char.IsDigit(moveInput[1]) ||
                    !char.IsDigit(moveInput[4])
                    )
                {
                    Console.WriteLine("Invalid Input. Please enter in the correct format (Example: `B2 C5`)");
                    continue;
                }

                // Convert Char Array to Numbers
                // startPosY and endPosY represents the letters of chessboard
                // startPosX and endPosX represents the numbers of chessboard
                startPosY = ConvertAlphabetToNum(moveInput[0]);
                endPosY = endPosX = ConvertAlphabetToNum(moveInput[3]);
                startPosX = 8 - (int.Parse(moveInput[1].ToString()) - 1);
                endPosX = 8 - (int.Parse(moveInput[4].ToString()) - 1);

                // In Range Check
                if (startPosX == 0 || startPosY < 1 || startPosY > 8 || endPosX == 0 || endPosY < 1 || endPosY > 8)
                {
                    Console.WriteLine("Invalid Grid Position. Enter within A-H, 1-8");
                    continue;
                }

                // Return a List with Start Position and End Position by getting the index of startPosXY, endPosXY
                startEndGrids.Add(new Grid().Initialize(startPosX - 1, startPosY - 1));
                startEndGrids.Add(new Grid().Initialize(endPosX - 1, endPosY - 1));

                askAgain = false;
            }

            return startEndGrids;
        }


        //returns the number , from the given char , and the number is used for the board
        static private int ConvertAlphabetToNum(char alphabet)
        {
            switch (alphabet)
            {
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                default:
                    return 0;
            }
        }

        //Function to print the winnig team
        static private void PrintWinner(ETeam WinTeam)
        {
            //Console.Clear();
            Console.WriteLine("{0} Wins!!!!!!", WinTeam);
        }


        //Function to check is castle is possible
        static private void CheckForCastles(Board board)
        {
            board.whiteKing.CheckCastle();
            board.blackKing.CheckCastle();
        }
     
    }
}
