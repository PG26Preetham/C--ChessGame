using System;
using System.Collections.Generic;

namespace c_TEXTChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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
        }
    }
}
