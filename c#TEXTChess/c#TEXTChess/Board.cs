using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace c_TEXTChess
{
    internal class Board
    {
<<<<<<< HEAD
        public string[,] chessBoard;

        public Board()
        {
            // Initializing ChessBoard Constructor
            InitializeChessBoard();
=======
        //
        List<BasePiece> AllPiecesOnBoard = new List<BasePiece>();

        public BasePiece FindPieceAtGrid(Grid grid)
        {
            for (int i = 0; i < AllPiecesOnBoard.Count; i++)
            {
                if (AllPiecesOnBoard[i].currentPos.x == grid.x && AllPiecesOnBoard[i].currentPos.y == grid.y)
                {
                    return AllPiecesOnBoard[i];
                }
            }
            return null;
>>>>>>> origin/Pieces
        }
        //public int[,] BoardArray()
        //{
        //    // initial comment
        //   // return int;
        //}

        public void ShowChessBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    int sum = row + col;
                    if ((sum % 2) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(chessBoard[row, col]);

                }
                Console.WriteLine();
            }
        }

        // Chessboard string
        public void InitializeChessBoard()
        {
            // First row
            string h1 = H1();
            string h2 = H2();
            string h3 = H3();
            string h4 = H4();
            string h5 = H5();
            string h6 = H6();
            string h7 = H7();
            string h8 = H8();

            // Second row
            string g1 = G1();
            string g2 = G2();
            string g3 = G3();
            string g4 = G4();
            string g5 = G5();
            string g6 = G6();
            string g7 = G7();
            string g8 = G8();

            // Third row
            string f1 = F1();
            string f2 = F2();
            string f3 = F3();
            string f4 = F4();
            string f5 = F5();
            string f6 = F6();
            string f7 = F7();
            string f8 = F8();

            // Fourth row
            string e1 = E1();
            string e2 = E2();
            string e3 = E3();
            string e4 = E4();
            string e5 = E5();
            string e6 = E6();
            string e7 = E7();
            string e8 = E8();

            // Fifth row
            string d1 = D1();
            string d2 = D2();
            string d3 = D3();
            string d4 = D4();
            string d5 = D5();
            string d6 = D6();
            string d7 = D7();
            string d8 = D8();

            // Sixth row
            string c1 = C1();
            string c2 = C2();
            string c3 = C3();
            string c4 = C4();
            string c5 = C5();
            string c6 = C6();
            string c7 = C7();
            string c8 = C8();

            // Seventh row
            string b1 = B1();
            string b2 = B2();
            string b3 = B3();
            string b4 = B4();
            string b5 = B5();
            string b6 = B6();
            string b7 = B7();
            string b8 = B8();

            // Eighth row
            string a1 = A1();
            string a2 = A2();
            string a3 = A3();
            string a4 = A4();
            string a5 = A5();
            string a6 = A6();
            string a7 = A7();
            string a8 = A8();


            chessBoard = new string[,]
            {
                { h1, h2, h3, h4, h5, h6, h7, h8 },
                { g1, g2, g3, g4, g5, g6, g7, g8 },
                { f1, f2, f3, f4, f5, f6, f7, f8 },
                { e1, e2, e3, e4, e5, e6, e7, e8 },
                { d1, d2, d3, d4, d5, d6, d7, d8 },
                { c1, c2, c3, c4, c5, c6, c7, c8 },
                { b1, b2, b3, b4, b5, b6, b7, b8 },
                { a1, a2, a3, a4, a5, a6, a7, a8 },
            };

        }

        // Display what is on h1
        public string H1()
        {
            return " bR ";
        }

        // Display what is on h2
        public string H2()
        {
            return " bN ";
        }

        // Display what is on h3
        public string H3()
        {
            return " bB ";
        }

        // Display what is on h4
        public string H4()
        {
            return " bQ ";
        }

        // Display what is on h5
        public string H5()
        {
            return " bK ";
        }

        // Display what is on h6
        public string H6()
        {
            return " bB ";
        }

        // Display what is on h7
        public string H7()
        {
            return " bN ";
        }

        // Display what is on h8
        public string H8()
        {
            return " bR ";
        }

        // Display what is on g1
        public string G1()
        {
            return " bP ";
        }

        // Display what is on g2
        public string G2()
        {
            return " bP ";
        }

        // Display what is on g3
        public string G3()
        {
            return " bP ";
        }

        // Display what is on g4
        public string G4()
        {
            return " bP ";
        }

        // Display what is on g5
        public string G5()
        {
            return " bP ";
        }

        // Display what is on g6
        public string G6()
        {
            return " bP ";
        }

        // Display what is on g7
        public string G7()
        {
            return " bP ";
        }

        // Display what is on g8
        public string G8()
        {
            return " bP ";
        }

        // Display what is on f1
        public string F1()
        {
            return "    ";
        }

        // Display what is on f2
        public string F2()
        {
            return "    ";
        }

        // Display what is on f3
        public string F3()
        {
            return "    ";
        }

        // Display what is on f4
        public string F4()
        {
            return "    ";
        }

        // Display what is on f5
        public string F5()
        {
            return "    ";
        }

        // Display what is on f6
        public string F6()
        {
            return "    ";
        }

        // Display what is on f7
        public string F7()
        {
            return "    ";
        }

        // Display what is on f8
        public string F8()
        {
            return "    ";
        }

        // Display what is on e1
        public string E1()
        {
            return "    ";
        }

        // Display what is on e2
        public string E2()
        {
            return "    ";
        }

        // Display what is on e3
        public string E3()
        {
            return "    ";
        }

        // Display what is on e4
        public string E4()
        {
            return "    ";
        }

        // Display what is on e5
        public string E5()
        {
            return "    ";
        }

        // Display what is on e6
        public string E6()
        {
            return "    ";
        }

        // Display what is on e7
        public string E7()
        {
            return "    ";
        }

        // Display what is on e8
        public string E8()
        {
            return "    ";
        }

        // Display what is on d1
        public string D1()
        {
            return "    ";
        }

        // Display what is on d2
        public string D2()
        {
            return "    ";
        }

        // Display what is on d3
        public string D3()
        {
            return "    ";
        }

        // Display what is on d4
        public string D4()
        {
            return "    ";
        }

        // Display what is on d5
        public string D5()
        {
            return "    ";
        }

        // Display what is on d6
        public string D6()
        {
            return "    ";
        }

        // Display what is on d7
        public string D7()
        {
            return "    ";
        }

        // Display what is on d8
        public string D8()
        {
            return "    ";
        }

        // Display what is on c1
        public string C1()
        {
            return "    ";
        }

        // Display what is on c2
        public string C2()
        {
            return "    ";
        }

        // Display what is on c3
        public string C3()
        {
            return "    ";
        }

        // Display what is on c4
        public string C4()
        {
            return "    ";
        }

        // Display what is on c5
        public string C5()
        {
            return "    ";
        }

        // Display what is on c6
        public string C6()
        {
            return "    ";
        }

        // Display what is on c7
        public string C7()
        {
            return "    ";
        }

        // Display what is on c8
        public string C8()
        {
            return "    ";
        }

        // Display what is on b1
        public string B1()
        {
            return " wP ";
        }

        // Display what is on b2
        public string B2()
        {
            return " wP ";
        }

        // Display what is on b3
        public string B3()
        {
            return " wP ";
        }

        // Display what is on b4
        public string B4()
        {
            return " wP ";
        }

        // Display what is on b5
        public string B5()
        {
            return " wP ";
        }

        // Display what is on b6
        public string B6()
        {
            return " wP ";
        }

        // Display what is on b7
        public string B7()
        {
            return " wP ";
        }

        // Display what is on b8
        public string B8()
        {
            return " wP ";
        }

        // Display what is on a1
        public string A1()
        {
            return " wR ";
        }

        // Display what is on a2
        public string A2()
        {
            return " wN ";
        }

        // Display what is on a3
        public string A3()
        {
            return " wB ";
        }

        // Display what is on a4
        public string A4()
        {
            return " wQ ";
        }

        // Display what is on a5
        public string A5()
        {
            return " wK ";
        }

        // Display what is on a6
        public string A6()
        {
            return " wB ";
        }

        // Display what is on a7
        public string A7()
        {
            return " wN ";
        }

        // Display what is on a8
        public string A8()
        {
            return " wR ";
        }

    }
}
