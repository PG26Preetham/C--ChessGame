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
        [DllImport("ChangeConsole-CPPHelper.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int ChangeFont(int FontSize);

        public static ETeam currentTeam = ETeam.White;
        public static void CPPCall()
        {
            ChangeFont(20);
        }
        static void Main(string[] args)
        {
            CPPCall();
            Board board = new Board();
            Console.OutputEncoding = Encoding.UTF8;
            board.InitBoard(board);
            GameplayLoop(board);

            
            //string a = "\u265F";
            //Console.WriteLine("♙");
            //Console.WriteLine(a);
            //Console.WriteLine("ggg");
           

            //List<Grid> Qgrid = new List<Grid>();
            //Qgrid=board.FindPieceAtGrid(new Grid().Initialize(0,3)).GetLegalMoves();
            //for(int i = 0; i < Qgrid.Count; i++)
            //{
            //    Console.WriteLine("{0} - {1}", Qgrid[i].x, Qgrid[i].y);
            //}
        }

        public static void GameplayLoop(Board board)
        {
            while(true)
            {
                Console.Clear();
                board.PrintBoard();
                List<Grid> startEndGrids = GetPlayerMoveInput();
                BasePiece attacker = board.FindPieceAtGrid(startEndGrids[0]);

                Console.WriteLine($"{startEndGrids[0].x}{startEndGrids[0].y} {startEndGrids[1].x}{startEndGrids[1].y}");
                if (attacker.team== currentTeam)
                {
                   if( board.WasMoveValid(attacker.currentPos, startEndGrids[1]))
                    {
                        if (attacker.team == ETeam.White && attacker.GetLegalMoves().Contains(board.whiteKing.currentPos))
                        {
                            Console.WriteLine($"Check? : {board.whiteKing.IsBeingChecked()}");
                            Console.WriteLine($"Checkmate? : {board.whiteKing.IsCheckmate(board.FindPieceAtGrid(startEndGrids[0]))}");
                        }
                        else if (attacker.team == ETeam.Black && attacker.GetLegalMoves().Contains(board.blackKing.currentPos))
                        {
                            Console.WriteLine($"Check? : {board.blackKing.IsBeingChecked()}");
                            Console.WriteLine($"Checkmate? : {board.blackKing.IsCheckmate(board.FindPieceAtGrid(startEndGrids[0]))}");
                        }

                        ChangeCurrentTeam();
                    }
                }
                else
                {
                    Console.WriteLine("Not your piece");
                }
                
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine() ;
            }
        }

        public static void ChangeCurrentTeam()
        {
            if(currentTeam == ETeam.White)
            {
                currentTeam = ETeam.Black;
            }
            else
            {
                currentTeam = ETeam.White;
            }
        }

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
                Console.WriteLine("{0}-> Please enter a move: (StartPos EndPos) ",currentTeam.ToString());
                string playerInput = Console.ReadLine().ToLower();
                moveInput = playerInput.ToCharArray();

                // Correct Type Check
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

                // Return a List with Start Position and End Position
                startEndGrids.Add(new Grid().Initialize(startPosX - 1, startPosY - 1));
                startEndGrids.Add(new Grid().Initialize(endPosX - 1, endPosY - 1));

                askAgain = false;
            }

            return startEndGrids;
        }

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
    }
}
