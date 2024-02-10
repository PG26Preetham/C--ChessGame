using System;

namespace c_TEXTChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Board chessBoard = new Board();
            chessBoard.DisplayChessBoard();
        }
    }
}
