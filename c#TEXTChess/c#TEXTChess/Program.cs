using System;
using System.Collections.Generic;

namespace c_TEXTChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            Rook whiteRook1 = new Rook();
            Rook whiteRook2 = new Rook();
            King whiteKing = new King();

            whiteRook1.Initialize(ETeam.White, new Grid().Initialize(1, 8), board);
            whiteRook2.Initialize(ETeam.White, new Grid().Initialize(8, 8), board);
            whiteKing.Initialize(ETeam.White, new Grid().Initialize(5, 8), board);

            List<Grid> whiteKingLegalMoves = whiteKing.GetLegalMoves();

            Console.WriteLine(whiteKing.canKingSideCastle + " " + whiteKing.canQueenSideCastle);

            for (int i = 0; i < whiteKing.GetLegalMoves().Count; i++)
            {
                Console.Write(whiteKingLegalMoves[i].x);
                Console.Write(" , ");
                Console.WriteLine(whiteKingLegalMoves[i].y);
            }
            





            /*            
                        Board board = new Board();

                        BasePiece whiteRook1 = new Rook();
                        whiteRook1.Initialize(ETeam.Black, new Grid().Initialize(4, 4), board);

                        List<Grid> legalMoves = whiteRook1.GetLegalMoves();

                        for (int i = 0; i < whiteRook1.GetLegalMoves().Count; i++)
                        {
                            Console.Write(legalMoves[i].x);
                            Console.Write(" , ");
                            Console.WriteLine(legalMoves[i].y);
                        }*/
        }
    }
}
