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

            Console.Clear();

            board.MovePiece(board.BoardBoxPiece[1, 0], new Grid().Initialize(2, 0));
            board.PrintBoard();
        }
    }
}
