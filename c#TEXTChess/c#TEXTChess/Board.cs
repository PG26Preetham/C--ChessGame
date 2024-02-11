using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace c_TEXTChess
{
    internal class Board
    {
        public int moveCounter = 1;

        // Setting an initializer for the first initializer
        private bool a1PSet = false;
        private bool a2PSet = false;
        private bool a3PSet = false;
        private bool a4PSet = false;
        private bool a5PSet = false;
        private bool a6PSet = false;
        private bool a7PSet = false;
        private bool a8PSet = false;
        private bool b1PSet = false;
        private bool b2PSet = false;
        private bool b3PSet = false;
        private bool b4PSet = false;
        private bool b5PSet = false;
        private bool b6PSet = false;
        private bool b7PSet = false;
        private bool b8PSet = false;
        private bool c1PSet = false;
        private bool c2PSet = false;
        private bool c3PSet = false;
        private bool c4PSet = false;
        private bool c5PSet = false;
        private bool c6PSet = false;
        private bool c7PSet = false;
        private bool c8PSet = false;
        private bool d1PSet = false;
        private bool d2PSet = false;
        private bool d3PSet = false;
        private bool d4PSet = false;
        private bool d5PSet = false;
        private bool d6PSet = false;
        private bool d7PSet = false;
        private bool d8PSet = false;
        private bool e1PSet = false;
        private bool e2PSet = false;
        private bool e3PSet = false;
        private bool e4PSet = false;
        private bool e5PSet = false;
        private bool e6PSet = false;
        private bool e7PSet = false;
        private bool e8PSet = false;
        private bool f1PSet = false;
        private bool f2PSet = false;
        private bool f3PSet = false;
        private bool f4PSet = false;
        private bool f5PSet = false;
        private bool f6PSet = false;
        private bool f7PSet = false;
        private bool f8PSet = false;
        private bool g1PSet = false;
        private bool g2PSet = false;
        private bool g3PSet = false;
        private bool g4PSet = false;
        private bool g5PSet = false;
        private bool g6PSet = false;
        private bool g7PSet = false;
        private bool g8PSet = false;
        private bool h1PSet = false;
        private bool h2PSet = false;
        private bool h3PSet = false;
        private bool h4PSet = false;
        private bool h5PSet = false;
        private bool h6PSet = false;
        private bool h7PSet = false;
        private bool h8PSet = false;


        // Board pieces
        string wP = " wP ";
        string wN = " wN ";
        string wB = " wB ";
        string wR = " wR ";
        string wQ = " wQ ";
        string wK = " wK ";
        string bP = " bP ";
        string bN = " bN ";
        string bB = " bB ";
        string bR = " bR ";
        string bQ = " bQ ";
        string bK = " bK ";
        string mt = "    ";

        // Last Position for piece
        string a1P;
        string a2P;
        string a3P;
        string a4P;
        string a5P;
        string a6P;
        string a7P;
        string a8P;
        string b1P;
        string b2P;
        string b3P;
        string b4P;
        string b5P;
        string b6P;
        string b7P;
        string b8P;
        string c1P;
        string c2P;
        string c3P;
        string c4P;
        string c5P;
        string c6P;
        string c7P;
        string c8P;
        string d1P;
        string d2P;
        string d3P;
        string d4P;
        string d5P;
        string d6P;
        string d7P;
        string d8P;
        string e1P;
        string e2P;
        string e3P;
        string e4P;
        string e5P;
        string e6P;
        string e7P;
        string e8P;
        string f1P;
        string f2P;
        string f3P;
        string f4P;
        string f5P;
        string f6P;
        string f7P;
        string f8P;
        string g1P;
        string g2P;
        string g3P;
        string g4P;
        string g5P;
        string g6P;
        string g7P;
        string g8P;
        string h1P;
        string h2P;
        string h3P;
        string h4P;
        string h5P;
        string h6P;
        string h7P;
        string h8P;


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
        }

        public string[,] chessBoard;

        public void PlaceStartingPieces()
        {
            chessBoard[1, 1] = bR;
            chessBoard[1, 2] = bN;
            chessBoard[1, 3] = bB;
            chessBoard[1, 4] = bQ;
            chessBoard[1, 5] = bK;
            chessBoard[1, 6] = bB;
            chessBoard[1, 7] = bN;
            chessBoard[1, 8] = bR;
            chessBoard[2, 1] = bP;
            chessBoard[2, 2] = bP;
            chessBoard[2, 3] = bP;
            chessBoard[2, 4] = bP;
            chessBoard[2, 5] = bP;
            chessBoard[2, 6] = bP;
            chessBoard[2, 7] = bP;
            chessBoard[2, 8] = bP;
            chessBoard[3, 1] = mt;
            chessBoard[3, 2] = mt;
            chessBoard[3, 3] = mt;
            chessBoard[3, 4] = mt;
            chessBoard[3, 5] = mt;
            chessBoard[3, 6] = mt;
            chessBoard[3, 7] = mt;
            chessBoard[3, 8] = mt;
            chessBoard[4, 1] = mt;
            chessBoard[4, 2] = mt;
            chessBoard[4, 3] = mt;
            chessBoard[4, 4] = mt;
            chessBoard[4, 5] = mt;
            chessBoard[4, 6] = mt;
            chessBoard[4, 7] = mt;
            chessBoard[4, 8] = mt;
            chessBoard[5, 1] = mt;
            chessBoard[5, 2] = mt;
            chessBoard[5, 3] = mt;
            chessBoard[5, 4] = mt;
            chessBoard[5, 5] = mt;
            chessBoard[5, 6] = mt;
            chessBoard[5, 7] = mt;
            chessBoard[5, 8] = mt;
            chessBoard[6, 1] = mt;
            chessBoard[6, 2] = mt;
            chessBoard[6, 3] = mt;
            chessBoard[6, 4] = mt;
            chessBoard[6, 5] = mt;
            chessBoard[6, 6] = mt;
            chessBoard[6, 7] = mt;
            chessBoard[6, 8] = mt;
            chessBoard[7, 1] = wP;
            chessBoard[7, 2] = wP;
            chessBoard[7, 3] = wP;
            chessBoard[7, 4] = wP;
            chessBoard[7, 5] = wP;
            chessBoard[7, 6] = wP;
            chessBoard[7, 7] = wP;
            chessBoard[7, 8] = wP;
            chessBoard[8, 1] = wR;
            chessBoard[8, 2] = wN;
            chessBoard[8, 3] = wB;
            chessBoard[8, 4] = wQ;
            chessBoard[8, 5] = wK;
            chessBoard[8, 6] = wB;
            chessBoard[8, 7] = wN;
            chessBoard[8, 8] = wR;

        }

        public Board()
        {
            // Initializing ChessBoard Constructor
            InitializeChessBoard();
            PlaceStartingPieces();
        }

        public void ShowChessBoard()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    int sum = row + col;
                    // If it's even make the grid White
                    if ((sum % 2) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    // If it's odd make the grid Green
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    // If its border make reset all the colors to console
                    if (row == 9 || col == 0)
                    {
                        Console.ResetColor();
                    }
                    else if (row == 0 || col == 9)
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(chessBoard[row, col]);
                    Console.ResetColor();

                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        // Chessboard string
        public void InitializeChessBoard()
        {
            // Getting board data
            string move = MoveInput();
            string piece = GetPiece(move);
            string origin = GetOrigin(move);
            string destination = GetDestination(move);

            // Border edge
            string zZ = BorderEmpty();

            // Border identifier for coordinates
            string zH = BorderH();
            string zG = BorderG();
            string zF = BorderF();
            string zE = BorderE();
            string zD = BorderD();
            string zC = BorderC();
            string zB = BorderB();
            string zA = BorderA();
            string z1 = Border1();
            string z2 = Border2();
            string z3 = Border3();
            string z4 = Border4();
            string z5 = Border5();
            string z6 = Border6();
            string z7 = Border7();
            string z8 = Border8();


            // Eigth Col
            string h1 = H1(piece, origin, destination);
            string h2 = H2(piece, origin, destination);
            string h3 = H3(piece, origin, destination);
            string h4 = H4(piece, origin, destination);
            string h5 = H5(piece, origin, destination);
            string h6 = H6(piece, origin, destination);
            string h7 = H7(piece, origin, destination);
            string h8 = H8(piece, origin, destination);

            // Seventh row
            string g1 = G1(piece, origin, destination);
            string g2 = G2(piece, origin, destination);
            string g3 = G3(piece, origin, destination);
            string g4 = G4(piece, origin, destination);
            string g5 = G5(piece, origin, destination);
            string g6 = G6(piece, origin, destination);
            string g7 = G7(piece, origin, destination);
            string g8 = G8(piece, origin, destination);

            // Sixth Col
            string f1 = F1(piece, origin, destination);
            string f2 = F2(piece, origin, destination);
            string f3 = F3(piece, origin, destination);
            string f4 = F4(piece, origin, destination);
            string f5 = F5(piece, origin, destination);
            string f6 = F6(piece, origin, destination);
            string f7 = F7(piece, origin, destination);
            string f8 = F8(piece, origin, destination);

            // Fifth row
            string e1 = E1(piece, origin, destination);
            string e2 = E2(piece, origin, destination);
            string e3 = E3(piece, origin, destination);
            string e4 = E4(piece, origin, destination);
            string e5 = E5(piece, origin, destination);
            string e6 = E6(piece, origin, destination);
            string e7 = E7(piece, origin, destination);
            string e8 = E8(piece, origin, destination);

            // Fourth Col
            string d1 = D1(piece, origin, destination);
            string d2 = D2(piece, origin, destination);
            string d3 = D3(piece, origin, destination);
            string d4 = D4(piece, origin, destination);
            string d5 = D5(piece, origin, destination);
            string d6 = D6(piece, origin, destination);
            string d7 = D7(piece, origin, destination);
            string d8 = D8(piece, origin, destination);

            // Third row
            string c1 = C1(piece, origin, destination);
            string c2 = C2(piece, origin, destination);
            string c3 = C3(piece, origin, destination);
            string c4 = C4(piece, origin, destination);
            string c5 = C5(piece, origin, destination);
            string c6 = C6(piece, origin, destination);
            string c7 = C7(piece, origin, destination);
            string c8 = C8(piece, origin, destination);

            // Second Col
            string b1 = B1(piece, origin, destination);
            string b2 = B2(piece, origin, destination);
            string b3 = B3(piece, origin, destination);
            string b4 = B4(piece, origin, destination);
            string b5 = B5(piece, origin, destination);
            string b6 = B6(piece, origin, destination);
            string b7 = B7(piece, origin, destination);
            string b8 = B8(piece, origin, destination);

            // First Col
            string a1 = A1(piece, origin, destination);
            string a2 = A2(piece, origin, destination);
            string a3 = A3(piece, origin, destination);
            string a4 = A4(piece, origin, destination);
            string a5 = A5(piece, origin, destination);
            string a6 = A6(piece, origin, destination);
            string a7 = A7(piece, origin, destination);
            string a8 = A8(piece, origin, destination);

            // 2d array where the function are then printed on
            chessBoard = new string[,]
            {
                { zZ, zA, zB, zC, zD, zE, zF, zG, zH, zZ },
                { z8, a8, b8, c8, d8, e8, f8, g8, h8, z8 },
                { z7, a7, b7, c7, d7, e7, f7, g7, h7, z7 },
                { z6, a6, b6, c6, d6, e6, f6, g6, h6, z6 },
                { z5, a5, b5, c5, d5, e5, f5, g5, h5, z5 },
                { z4, a4, b4, c4, d4, e4, f4, g4, h4, z4 },
                { z3, a3, b3, c3, d3, e3, f3, g3, h3, z3 },
                { z2, a2, b2, c2, d2, e2, f2, g2, h2, z2 },
                { z1, a1, b1, c1, d1, e1, f1, g1, h1, z1 },
                { zZ, zA, zB, zC, zD, zE, zF, zG, zH, zZ },
            };

        }


        // Display what is on h1
        public string H1(string piece, string origin, string destination)
        {
            if (!h1PSet)
            {
                h1P = wR;
                h1PSet = true;
            }

            if (origin == "h1") // so if the origin was the same as this grid it will go away since the piece moved
            {
                return mt;
            }
            else if (destination == "h1")
            {
                // If it's even update the grid with a black piece (since black moves are 2. 4. etc)
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h1P = bK;
                        return bK;
                    }

                }
                // Else if update the piece with a white piece (since white goes first and it starts at move 1 which is odd)
                else
                {
                    if (piece == "P")
                    {
                        h1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h1P = wK;
                        return wK;
                    }
                }
            }
            return h1P;
        }

        // Display what is on h2
        public string H2(string piece, string origin, string destination)
        {
            if (!h2PSet)
            {
                h2P = wP;
                h2PSet = true;
            }

            if (origin == "h2")
            {
                return mt;
            }
            else if (destination == "h2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h2P = wK;
                        return wK;
                    }
                }
            }
            return h2P;
        }

        // Display what is on h3
        public string H3(string piece, string origin, string destination)
        {
            if (!h3PSet)
            {
                h3P = mt;
                h3PSet = true;
            }

            if (origin == "h3")
            {
                return mt;
            }
            else if (destination == "h3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h3P = wK;
                        return wK;
                    }
                }
            }
            return h3P;
        }

        // Display what is on h4
        public string H4(string piece, string origin, string destination)
        {
            if (!h4PSet)
            {
                h4P = mt;
                h4PSet = true;
            }

            if (origin == "h4")
            {
                return mt;
            }
            else if (destination == "h4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h4P = wK;
                        return wK;
                    }
                }
            }
            return h4P;
        }

        // Display what is on h5
        public string H5(string piece, string origin, string destination)
        {
            if (!h5PSet)
            {
                h5P = mt;
                h5PSet = true;
            }

            if (origin == "h5")
            {
                return mt;
            }
            else if (destination == "h5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h5P = wK;
                        return wK;
                    }
                }
            }
            return h5P;
        }


        // Display what is on h6
        public string H6(string piece, string origin, string destination)
        {
            if (!h6PSet)
            {
                h6P = mt;
                h6PSet = true;
            }

            if (origin == "h6")
            {
                return mt;
            }
            else if (destination == "h6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h6P = bB;   
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h6P = wK;
                        return wK;
                    }
                }
            }
            return h6P;
        }


        // Display what is on h7
        public string H7(string piece, string origin, string destination)
        {
            if (!h7PSet)
            {
                h7P = bP;
                h7PSet = true;
            }

            if (origin == "h7")
            {
                return mt;
            }
            else if (destination == "h7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h7P = wK;
                        return wK;
                    }
                }
            }
            return h7P;
        }

        // Display what is on h8
        public string H8(string piece, string origin, string destination)
        {
            if (!h8PSet)
            {
                h8P = bR;
                h8PSet = true;
            }

            if (origin == "h8")
            {
                return mt;
            }
            else if (destination == "h8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        h8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        h8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        h8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        h8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        h8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        h8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        h8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        h8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        h8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        h8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        h8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        h8P = wK;
                        return wK;
                    }
                }
            }
            return h8P;
        }

        // Display what is on g1
        public string G1(string piece, string origin, string destination)
        {
            if (!g1PSet)
            {
                g1P = wR;
                g1PSet = true;
            }

            if (origin == "g1")
            {
                return mt;
            }
            else if (destination == "g1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g1P = wK;
                        return wK;
                    }
                }
            }
            return g1P;
        }

        // Display what is on g2
        public string G2(string piece, string origin, string destination)
        {
            if (!g2PSet)
            {
                g2P = wP;
                g2PSet = true;
            }

            if (origin == "g2")
            {
                return mt;
            }
            else if (destination == "g2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g2P = wK;
                        return wK;
                    }
                }
            }
            return g2P;
        }


        // Display what is on g3
        public string G3(string piece, string origin, string destination)
        {
            if (!g3PSet)
            {
                g3P = mt;
                g3PSet = true;
            }

            if (origin == "g3")
            {
                return mt;
            }
            else if (destination == "g3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g3P = wK;
                        return wK;
                    }
                }
            }
            return g3P;
        }


        // Display what is on g4
        public string G4(string piece, string origin, string destination)
        {
            if (!g4PSet)
            {
                g4P = mt;
                g4PSet = true;
            }

            if (origin == "g4")
            {
                return mt;
            }
            else if (destination == "g4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g4P = wK;
                        return wK;
                    }
                }
            }
            return g4P;
        }


        // Display what is on g5
        public string G5(string piece, string origin, string destination)
        {
            if (!g5PSet)
            {
                g5P = mt;
                g5PSet = true;
            }

            if (origin == "g5")
            {
                return mt;
            }
            else if (destination == "g5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g5P = wK;
                        return wK;
                    }
                }
            }
            return g5P;
        }



        // Display what is on g6
        public string G6(string piece, string origin, string destination)
        {
            if (!g6PSet)
            {
                g6P = mt;
                g6PSet = true;
            }

            if (origin == "g6")
            {
                return mt;
            }
            else if (destination == "g6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g6P = wK;
                        return wK;
                    }
                }
            }
            return g6P;
        }



        // Display what is on g7
        public string G7(string piece, string origin, string destination)
        {
            if (!g7PSet)
            {
                g7P = bP;
                g7PSet = true;
            }

            if (origin == "g7")
            {
                return mt;
            }
            else if (destination == "g7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g7P = wK;
                        return wK;
                    }
                }
            }
            return g7P;
        }


        // Display what is on g8
        public string G8(string piece, string origin, string destination)
        {
            if (!g8PSet)
            {
                g8P = bR;
                g8PSet = true;
            }

            if (origin == "g8")
            {
                return mt;
            }
            else if (destination == "g8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        g8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        g8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        g8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        g8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        g8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        g8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        g8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        g8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        g8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        g8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        g8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        g8P = wK;
                        return wK;
                    }
                }
            }
            return g8P;
        }


        // Display what is on f1
        public string F1(string piece, string origin, string destination)
        {
            if (!f1PSet)
            {
                f1P = wR;
                f1PSet = true;
            }

            if (origin == "f1") // so if the origin was the same as this grid it will go away since the piece moved
            {
                return mt;
            }
            else if (destination == "f1")
            {
                // If it's even update the grid with a black piece
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f1P = bK;
                        return bK;
                    }
                }
                // Else if update the piece with a white piece (since white goes first and it starts at move 1 which is odd)
                else
                {
                    if (piece == "P")
                    {
                        f1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f1P = wK;
                        return wK;
                    }
                }
            }
            return f1P;
        }


        // Display what is on f2
        public string F2(string piece, string origin, string destination)
        {
            if (!f2PSet)
            {
                f2P = wP;
                f2PSet = true;
            }

            if (origin == "f2")
            {
                return mt;
            }
            else if (destination == "f2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f2P = wK;
                        return wK;
                    }
                }
            }
            return f2P;
        }


        // Display what is on f3
        public string F3(string piece, string origin, string destination)
        {
            if (!f3PSet)
            {
                f3P = mt;
                f3PSet = true;
            }

            if (origin == "f3")
            {
                return mt;
            }
            else if (destination == "f3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f3P = wK;
                        return wK;
                    }
                }
            }
            return f3P;
        }


        // Display what is on f4
        public string F4(string piece, string origin, string destination)
        {
            if (!f4PSet)
            {
                f4P = mt;
                f4PSet = true;
            }

            if (origin == "f4")
            {
                return mt;
            }
            else if (destination == "f4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f4P = wK;
                        return wK;
                    }
                }
            }
            return f4P;
        }


        // Display what is on f5
        public string F5(string piece, string origin, string destination)
        {
            if (!f5PSet)
            {
                f5P = mt;
                f5PSet = true;
            }

            if (origin == "f5")
            {
                return mt;
            }
            else if (destination == "f5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f5P = wK;
                        return wK;
                    }
                }
            }
            return f5P;
        }


        // Display what is on f6
        public string F6(string piece, string origin, string destination)
        {
            if (!f6PSet)
            {
                f6P = mt;
                f6PSet = true;
            }

            if (origin == "f6")
            {
                return mt;
            }
            else if (destination == "f6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f6P = wK;
                        return wK;
                    }
                }
            }
            return f6P;
        }



        // Display what is on f7
        public string F7(string piece, string origin, string destination)
        {
            if (!f7PSet)
            {
                f7P = bP;
                f7PSet = true;
            }

            if (origin == "f7")
            {
                return mt;
            }
            else if (destination == "f7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f7P = wK;
                        return wK;
                    }
                }
            }
            return f7P;
        }


        // Display what is on f8
        public string F8(string piece, string origin, string destination)
        {
            if (!f8PSet)
            {
                f8P = bR;
                f8PSet = true;
            }

            if (origin == "f8")
            {
                return mt;
            }
            else if (destination == "f8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        f8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        f8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        f8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        f8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        f8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        f8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        f8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        f8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        f8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        f8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        f8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        f8P = wK;
                        return wK;
                    }
                }
            }
            return f8P;
        }


        // Display what is on e1
        public string E1(string piece, string origin, string destination)
        {
            if (!e1PSet)
            {
                e1P = wK;
                e1PSet = true;
            }

            if (origin == "e1")
            {
                return mt;
            }
            else if (destination == "e1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e1P = wK;
                        return wK;
                    }
                }
            }
            return e1P;
        }


        // Display what is on e2
        public string E2(string piece, string origin, string destination)
        {
            if (!e2PSet)
            {
                e2P = wP;
                e2PSet = true;
            }

            if (origin == "e2")
            {
                return mt;
            }
            else if (destination == "e2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e2P = wK;
                        return wK;
                    }
                }
            }
            return e2P;
        }


        // Display what is on e3
        public string E3(string piece, string origin, string destination)
        {
            if (!e3PSet)
            {
                e3P = mt;
                e3PSet = true;
            }

            if (origin == "e3")
            {
                return mt;
            }
            else if (destination == "e3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e3P = wK;
                        return wK;
                    }
                }
            }
            return e3P;
        }


        // Display what is on e4
        public string E4(string piece, string origin, string destination)
        {
            if (!e4PSet)
            {
                e4P = mt;
                e4PSet = true;
            }

            if (origin == "e4")
            {
                return mt;
            }
            else if (destination == "e4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e4P = wK;
                        return wK;
                    }
                }
            }
            return e4P;
        }


        // Display what is on e5
        public string E5(string piece, string origin, string destination)
        {
            if (!e5PSet)
            {
                e5P = mt;
                e5PSet = true;
            }

            if (origin == "e5")
            {
                return mt;
            }
            else if (destination == "e5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e5P = wK;
                        return wK;
                    }
                }
            }
            return e5P;
        }


        // Display what is on e6
        public string E6(string piece, string origin, string destination)
        {
            if (!e6PSet)
            {
                e6P = mt;
                e6PSet = true;
            }

            if (origin == "e6")
            {
                return mt;
            }
            else if (destination == "e6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e6P = wK;
                        return wK;
                    }
                }
            }
            return e6P;
        }

        // Display what is on e7
        public string E7(string piece, string origin, string destination)
        {
            if (!e7PSet)
            {
                e7P = bP;
                e7PSet = true;
            }

            if (origin == "e7")
            {
                return mt;
            }
            else if (destination == "e7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e7P = wK;
                        return wK;
                    }
                }
            }
            return e7P;
        }


        // Display what is on e8
        public string E8(string piece, string origin, string destination)
        {
            if (!e8PSet)
            {
                e8P = bK;
                e8PSet = true;
            }

            if (origin == "e8")
            {
                return mt;
            }
            else if (destination == "e8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        e8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        e8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        e8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        e8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        e8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        e8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        e8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        e8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        e8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        e8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        e8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        e8P = wK;
                        return wK;
                    }
                }
            }
            return e8P;
        }


        // Display what is on d1
        public string D1(string piece, string origin, string destination)
        {
            if (!d1PSet)
            {
                d1P = wQ;
                d1PSet = true;
            }

            if (origin == "d1")
            {
                return mt;
            }
            else if (destination == "d1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d1P = wK;
                        return wK;
                    }
                }
            }
            return d1P;
        }


        // Display what is on d2
        public string D2(string piece, string origin, string destination)
        {
            if (!d2PSet)
            {
                d2P = wP;
                d2PSet = true;
            }

            if (origin == "d2")
            {
                return mt;
            }
            else if (destination == "d2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d2P = wK;
                        return wK;
                    }
                }
            }
            return d2P;
        }

        // Display what is on d3
        public string D3(string piece, string origin, string destination)
        {
            if (!d3PSet)
            {
                d3P = mt;
                d3PSet = true;
            }

            if (origin == "d3")
            {
                return mt;
            }
            else if (destination == "d3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d3P = wK;
                        return wK;
                    }
                }
            }
            return d3P;
        }


        // Display what is on d4
        public string D4(string piece, string origin, string destination)
        {
            if (!d4PSet)
            {
                d4P = mt;
                d4PSet = true;
            }

            if (origin == "d4")
            {
                return mt;
            }
            else if (destination == "d4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d4P = wK;
                        return wK;
                    }
                }
            }
            return d4P;
        }


        // Display what is on d5
        public string D5(string piece, string origin, string destination)
        {
            if (!d5PSet)
            {
                d5P = mt;
                d5PSet = true;
            }

            if (origin == "d5")
            {
                return mt;
            }
            else if (destination == "d5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d5P = wK;
                        return wK;
                    }
                }
            }
            return d5P;
        }



        // Display what is on d6
        public string D6(string piece, string origin, string destination)
        {
            if (!d6PSet)
            {
                d6P = mt;
                d6PSet = true;
            }

            if (origin == "d6")
            {
                return mt;
            }
            else if (destination == "d6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d6P = wK;
                        return wK;
                    }
                }
            }
            return d6P;
        }



        // Display what is on d7
        public string D7(string piece, string origin, string destination)
        {
            if (!d7PSet)
            {
                d7P = bP;
                d7PSet = true;
            }

            if (origin == "d7")
            {
                return mt;
            }
            else if (destination == "d7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d7P = wK;
                        return wK;
                    }
                }
            }
            return d7P;
        }


        // Display what is on d8
        public string D8(string piece, string origin, string destination)
        {
            if (!d8PSet)
            {
                d8P = bR;
                d8PSet = true;
            }

            if (origin == "d8")
            {
                return mt;
            }
            else if (destination == "d8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        d8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        d8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        d8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        d8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        d8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        d8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        d8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        d8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        d8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        d8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        d8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        d8P = wK;
                        return wK;
                    }
                }
            }
            return d8P;
        }


        // Display what is on c1
        public string C1(string piece, string origin, string destination)
        {
            if (!c1PSet)
            {
                c1P = bR;
                c1PSet = true;
            }

            if (origin == "c1")
            {
                return mt;
            }
            else if (destination == "c1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c1P = wK;
                        return wK;
                    }
                }
            }
            return c1P;
        }


        // Display what is on c2
        public string C2(string piece, string origin, string destination)
        {
            if (!c2PSet)
            {
                c2P = wP;
                c2PSet = true;
            }

            if (origin == "c2")
            {
                return mt;
            }
            else if (destination == "c2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c2P = wK;
                        return wK;
                    }
                }
            }
            return c2P;
        }


        // Display what is on c3
        public string C3(string piece, string origin, string destination)
        {
            if (!c3PSet)
            {
                c3P = mt;
                c3PSet = true;
            }

            if (origin == "c3")
            {
                return mt;
            }
            else if (destination == "c3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c3P = wK;
                        return wK;
                    }
                }
            }
            return c3P;
        }


        // Display what is on c4
        public string C4(string piece, string origin, string destination)
        {
            if (!c4PSet)
            {
                c4P = mt;
                c4PSet = true;
            }

            if (origin == "c4")
            {
                return mt;
            }
            else if (destination == "c4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c4P = wK;
                        return wK;
                    }
                }
            }
            return c4P;
        }


        // Display what is on c5
        public string C5(string piece, string origin, string destination)
        {
            if (!c5PSet)
            {
                c5P = mt;
                c5PSet = true;
            }

            if (origin == "c5")
            {
                return mt;
            }
            else if (destination == "c5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c5P = wK;
                        return wK;
                    }
                }
            }
            return c5P;
        }


        // Display what is on c6
        public string C6(string piece, string origin, string destination)
        {
            if (!c6PSet)
            {
                c6P = mt;
                c6PSet = true;
            }

            if (origin == "c6")
            {
                return mt;
            }
            else if (destination == "c6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c6P = wK;
                        return wK;
                    }
                }
            }
            return c6P;
        }

        // Display what is on c7
        public string C7(string piece, string origin, string destination)
        {
            if (!c7PSet)
            {
                c7P = bP;
                c7PSet = true;
            }

            if (origin == "c7")
            {
                return mt;
            }
            else if (destination == "c7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c7P = wK;
                        return wK;
                    }
                }
            }
            return c7P;
        }


        // Display what is on c8
        public string C8(string piece, string origin, string destination)
        {
            if (!c8PSet)
            {
                c8P = bR;
                c8PSet = true;
            }

            if (origin == "c8")
            {
                return mt;
            }
            else if (destination == "c8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        c8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        c8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        c8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        c8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        c8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        c8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        c8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        c8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        c8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        c8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        c8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        c8P = wK;
                        return wK;
                    }
                }
            }
            return c8P;
        }

        // Display what is on b1
        public string B1(string piece, string origin, string destination)
        {
            if (!b1PSet)
            {
                b1P = wR;
                b1PSet = true;
            }

            if (origin == "b1")
            {
                return mt;
            }
            else if (destination == "b1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b1P = wK;
                        return wK;
                    }
                }
            }
            return b1P;
        }


        // Display what is on b2
        public string B2(string piece, string origin, string destination)
        {
            if (!b2PSet)
            {
                b2P = wP;
                b2PSet = true;
            }

            if (origin == "b2")
            {
                return mt;
            }
            else if (destination == "b2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b2P = wK;
                        return wK;
                    }
                }
            }
            return b2P;
        }


        // Display what is on b3
        public string B3(string piece, string origin, string destination)
        {
            if (!b3PSet)
            {
                b3P = mt;
                b3PSet = true;
            }

            if (origin == "b3")
            {
                return mt;
            }
            else if (destination == "b3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b3P = wK;
                        return wK;
                    }
                }
            }
            return b3P;
        }


        // Display what is on b4
        public string B4(string piece, string origin, string destination)
        {
            if (!b4PSet)
            {
                b4P = mt;
                b4PSet = true;
            }

            if (origin == "b4")
            {
                return mt;
            }
            else if (destination == "b4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b4P = wK;
                        return wK;
                    }
                }
            }
            return b4P;
        }


        // Display what is on b5
        public string B5(string piece, string origin, string destination)
        {
            if (!b5PSet)
            {
                b5P = mt;
                b5PSet = true;
            }

            if (origin == "b5")
            {
                return mt;
            }
            else if (destination == "b5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b5P = wK;
                        return wK;
                    }
                }
            }
            return b5P;
        }


        // Display what is on b6
        public string B6(string piece, string origin, string destination)
        {
            if (!b6PSet)
            {
                b6P = mt;
                b6PSet = true;
            }

            if (origin == "b6")
            {
                return mt;
            }
            else if (destination == "b6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b6P = wK;
                        return wK;
                    }
                }
            }
            return b6P;
        }



        // Display what is on b7
        public string B7(string piece, string origin, string destination)
        {
            if (!b7PSet)
            {
                b7P = bP;
                b7PSet = true;
            }

            if (origin == "b7")
            {
                return mt;
            }
            else if (destination == "b7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b7P = wK;
                        return wK;
                    }
                }
            }
            return b7P;
        }


        // Display what is on b8
        public string B8(string piece, string origin, string destination)
        {
            if (!b8PSet)
            {
                b8P = bR;
                b8PSet = true;
            }

            if (origin == "b8")
            {
                return mt;
            }
            else if (destination == "b8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        b8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        b8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        b8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        b8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        b8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        b8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        b8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        b8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        b8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        b8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        b8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        b8P = wK;
                        return wK;
                    }
                }
            }
            return b8P;
        }


        // Display what is on a1
        public string A1(string piece, string origin, string destination)
        {
            if (!a1PSet)
            {
                a1P = bR;
                a1PSet = true;
            }

            if (origin == "a1")
            {
                return mt;
            }
            else if (destination == "a1")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a1P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a1P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a1P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a1P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a1P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a1P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a1P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a1P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a1P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a1P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a1P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a1P = wK;
                        return wK;
                    }
                }
            }
            return a1P;
        }


        // Display what is on a2
        public string A2(string piece, string origin, string destination)
        {
            if (!a2PSet)
            {
                a2P = wP;
                a2PSet = true;
            }

            if (origin == "a2")
            {
                return mt;
            }
            else if (destination == "a2")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a2P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a2P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a2P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a2P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a2P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a2P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a2P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a2P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a2P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a2P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a2P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a2P = wK;
                        return wK;
                    }
                }
            }
            return a2P;
        }


        // Display what is on a3
        public string A3(string piece, string origin, string destination)
        {
            if (!a3PSet)
            {
                a3P = mt;
                a3PSet = true;
            }

            if (origin == "a3")
            {
                return mt;
            }
            else if (destination == "a3")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a3P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a3P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a3P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a3P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a3P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a3P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a3P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a3P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a3P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a3P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a3P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a3P = wK;
                        return wK;
                    }
                }
            }
            return a3P;
        }


        // Display what is on a4
        public string A4(string piece, string origin, string destination)
        {
            if (!a4PSet)
            {
                a4P = mt;
                a4PSet = true;
            }

            if (origin == "a4")
            {
                return mt;
            }
            else if (destination == "a4")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a4P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a4P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a4P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a4P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a4P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a4P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a4P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a4P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a4P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a4P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a4P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a4P = wK;
                        return wK;
                    }
                }
            }
            return a4P;
        }


        // Display what is on a5
        public string A5(string piece, string origin, string destination)
        {
            if (!a5PSet)
            {
                a5P = mt;
                a5PSet = true;
            }

            if (origin == "a5")
            {
                return mt;
            }
            else if (destination == "a5")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a5P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a5P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a5P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a5P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a5P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a5P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a5P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a5P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a5P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a5P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a5P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a5P = wK;
                        return wK;
                    }
                }
            }
            return a5P;
        }


        // Display what is on a6
        public string A6(string piece, string origin, string destination)
        {
            if (!a6PSet)
            {
                a6P = mt;
                a6PSet = true;
            }

            if (origin == "a6")
            {
                return mt;
            }
            else if (destination == "a6")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a6P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a6P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a6P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a6P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a6P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a6P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a6P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a6P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a6P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a6P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a6P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a6P = wK;
                        return wK;
                    }
                }
            }
            return a6P;
        }



        // Display what is on a7
        public string A7(string piece, string origin, string destination)
        {
            if (!a7PSet)
            {
                a7P = bP;
                a7PSet = true;
            }

            if (origin == "a7")
            {
                return mt;
            }
            else if (destination == "a7")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a7P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a7P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a7P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a7P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a7P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a7P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a7P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a7P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a7P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a7P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a7P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a7P = wK;
                        return wK;
                    }
                }
            }
            return a7P;
        }


        // Display what is on a8
        public string A8(string piece, string origin, string destination)
        {
            if (!a8PSet)
            {
                a8P = bR;
                a8PSet = true;
            }

            if (origin == "a8")
            {
                return mt;
            }
            else if (destination == "a8")
            {
                if ((moveCounter % 2) == 0)
                {
                    if (piece == "P")
                    {
                        a8P = bP;
                        return bP;
                    }
                    else if (piece == "N")
                    {
                        a8P = bN;
                        return bN;
                    }
                    else if (piece == "B")
                    {
                        a8P = bB;
                        return bB;
                    }
                    else if (piece == "R")
                    {
                        a8P = bR;
                        return bR;
                    }
                    else if (piece == "Q")
                    {
                        a8P = bQ;
                        return bQ;
                    }
                    else if (piece == "K")
                    {
                        a8P = bK;
                        return bK;
                    }
                }
                else
                {
                    if (piece == "P")
                    {
                        a8P = wP;
                        return wP;
                    }
                    else if (piece == "N")
                    {
                        a8P = wN;
                        return wN;
                    }
                    else if (piece == "B")
                    {
                        a8P = wB;
                        return wB;
                    }
                    else if (piece == "R")
                    {
                        a8P = wR;
                        return wR;
                    }
                    else if (piece == "Q")
                    {
                        a8P = wQ;
                        return wQ;
                    }
                    else if (piece == "K")
                    {
                        a8P = wK;
                        return wK;
                    }
                }
            }
            return a8P;
        }


        // Display empty border edge
        public string BorderEmpty()
        {
            return "    ";
        }

        // Display border coordinate for H
        public string BorderH()
        {
            return " h  ";
        }

        // Display border coordinate for G
        public string BorderG()
        {
            return " g  ";
        }

        // Display border coordinate for F
        public string BorderF()
        {
            return " f  ";
        }

        // Display border coordinate for E
        public string BorderE()
        {
            return " e  ";
        }

        // Display border coordinate for D
        public string BorderD()
        {
            return " d  ";
        }

        // Display border coordinate for C
        public string BorderC()
        {
            return " c  ";
        }

        // Display border coordinate for B
        public string BorderB()
        {
            return " b  ";
        }

        // Display border coordinate for A
        public string BorderA()
        {
            return " a  ";
        }

        // Display border coordinate for 1
        public string Border1()
        {
            return "  1 ";
        }

        // Display border coordinate for 2
        public string Border2()
        {
            return "  2 ";
        }

        // Display border coordinate for 3
        public string Border3()
        {
            return "  3 ";
        }

        // Display border coordinate for 4
        public string Border4()
        {
            return "  4 ";
        }

        // Display border coordinate for 5
        public string Border5()
        {
            return "  5 ";
        }

        // Display border coordinate for 6
        public string Border6()
        {
            return "  6 ";
        }

        // Display border coordinate for 7
        public string Border7()
        {
            return "  7 ";
        }

        // Display border coordinate for 8
        public string Border8()
        {
            return "  8 ";
        }

        public string MoveInput()
        {
            string move;

            // moveCounter++;

            while (true)
            {
                string index1 = "";
                string index2 = "";
                string index3 = "";
                string index4 = "";
                string index5 = "";
                string index6 = "";
                string index7 = "";
                string grid1 = "";
                string grid2 = "";

                move = Console.ReadLine();
                int length = move.Length;

                // Getting the string of each letter in the word
                if (length == 7)
                {
                    index1 = move.Substring(0, 1); // for the piece
                    index2 = move.Substring(1, 1); // for the letter coordinate
                    index3 = move.Substring(2, 1); // for the number coordinate
                    index4 = move.Substring(3, 1); // for the space
                    index5 = move.Substring(4, 1); // for the piece
                    index6 = move.Substring(5, 1); // for the letter coordinate
                    index7 = move.Substring(6, 1); // for the number coordinate
                    grid1 = move.Substring(1, 2); // for the first grid
                    grid2 = move.Substring(5, 2); // for the second grid
                }

                if (index1 != "P" && index1 != "N" && index1 != "B" && index1 != "R" && index1 != "Q" && index1 != "K") // Making sure that only pieces in the game are moved
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index2 != "a" && index2 != "b" && index2 != "c" && index2 != "d" && index2 != "e" && index2 != "f" && index2 != "g" && index2 != "h") // Checking if the user inputted a valid cord
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index3 != "1" && index3 != "2" && index3 != "3" && index3 != "4" && index3 != "5" && index3 != "6" && index3 != "7" && index3 != "8")
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index4 != " ")
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index1 != index5) // Making sure that the same piece is being moved
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index6 != "a" && index6 != "b" && index6 != "c" && index6 != "d" && index6 != "e" && index6 != "f" && index6 != "g" && index6 != "h")
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (index7 != "1" && index7 != "2" && index7 != "3" && index7 != "4" && index7 != "5" && index7 != "6" && index7 != "7" && index7 != "8")
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else if (grid1 == grid2)
                {
                    Console.WriteLine("Wrong format");
                    Console.Write("Move: ");
                }
                else
                {
                    Console.WriteLine("Correct format");
                    Console.WriteLine($"Move: {moveCounter}");
                    break;
                }
            }

            return move;

        }

        public string GetOrigin(string move)
        {
            string origin = move.Substring(1, 2);
            return origin;
        }

        public string GetDestination(string move)
        {
            string destination = move.Substring(5, 2);
            return destination;
        }

        public string GetPiece(string move)
        {
            string piece = move.Substring(0, 1);
            return piece;
        }

    }
}
