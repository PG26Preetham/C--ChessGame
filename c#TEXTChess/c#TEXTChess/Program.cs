using System;
using System.Collections.Generic;

namespace c_TEXTChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            board.InitBoard(board);


            board.PrintBoard();
            Rook whiteRook1 = new Rook();
            Rook whiteRook2 = new Rook();
            King whiteKing = new King();

            whiteRook1.Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(1, 8), board);
            whiteRook2.Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(8, 8), board);
            whiteKing.Initialize(ETeam.White, EPieceType.King, new Grid().Initialize(5, 8), board);

            List<Grid> whiteKingLegalMoves = whiteKing.GetLegalMoves();

            Console.WriteLine(whiteKing.canKingSideCastle + " " + whiteKing.canQueenSideCastle);

            for (int i = 0; i < whiteKing.GetLegalMoves().Count; i++)
            {
                Console.Write(whiteKingLegalMoves[i].x);
                Console.Write(" , ");
                Console.WriteLine(whiteKingLegalMoves[i].y);
            }

            Console.WriteLine("Player Turn");
            List<Grid> startEndGrids = GetPlayerMoveInput();
            Console.WriteLine($"{startEndGrids[0].x}{startEndGrids[0].y} {startEndGrids[1].x}{startEndGrids[1].y}");

            Console.Clear();

            board.MovePiece(board.BoardBoxPiece[1, 0], new Grid().Initialize(2, 0));
            board.PrintBoard();
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
                Console.WriteLine("Please enter a move: (StartPos EndPos)");
                string playerInput = Console.ReadLine().ToLower();
                moveInput = playerInput.ToCharArray();

                Console.WriteLine(moveInput[2]);

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
                startPosX = ConvertAlphabetToNum(moveInput[0]);
                startPosY = int.Parse(moveInput[1].ToString());
                endPosX = ConvertAlphabetToNum(moveInput[3]);
                endPosY = int.Parse(moveInput[4].ToString());

                // In Range Check
                if (startPosX == 0 || startPosY < 1 || startPosY > 8 || endPosX == 0 || endPosY < 1 || endPosY > 8)
                {
                    Console.WriteLine("Invalid Grid Position. Enter within A-H, 1-8");
                    continue;
                }

                // Return a List with Start Position and End Position
                startEndGrids.Add(new Grid().Initialize(startPosX, startPosY));
                startEndGrids.Add(new Grid().Initialize(endPosX, endPosY));

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
