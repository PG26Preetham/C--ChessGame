using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;

namespace c_TEXTChess
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Instructions: To move the pawn from e2 to e4 you would write: Pe2 Pe4");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("                         More Examples");
            Console.WriteLine("                            Ka1 Ka2");
            Console.WriteLine("                            Qg1 Qa7");
            Console.WriteLine("                            Ra3 Rh3");
            Console.WriteLine("                            Ba1 Bh8");

            Board chessBoard = new Board();

            while(true)
            {
                chessBoard.ShowChessBoard();
                Console.Write("Move: ");
                chessBoard.MoveInput();
            }

            /*while (true)
            {
            }*/
       

            /* Commented out just to start working on display
                        Board board = new Board();
                        BasePiece testPiece = new Rook();
                        testPiece.Initialize(ETeam.Black, new Grid().Initialize(4, 4), board);

                        List<Grid> legalMoves = testPiece.GetLegalMoves();

                        for (int i = 0; i < testPiece.GetLegalMoves().Count; i++)
                        {
                            Console.Write(legalMoves[i].x);
                            Console.Write(" , ");
                            Console.WriteLine(legalMoves[i].y);
                        }
            */
        }
    }
}
