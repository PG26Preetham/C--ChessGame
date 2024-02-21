﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    // Board class to represent the the board display and coordinates
    internal class Board
    {
        public List<BasePiece> AllPiecesOnBoard = new List<BasePiece>();
        public int BoardSize = 8;
        public bool hasDll = true;

        public King BlackKing = null;
        public King WhiteKing = null;

        public Board RefToBoard=null;
        public BasePiece[,] BoardBoxPiece = new BasePiece[8,8];

        public King whiteKing, blackKing;


        public Board()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    BoardBoxPiece[i, j] = null;
                }
            }
        }
        public void InitPiece(Board boardRef,BasePiece Piece)// to init all the piece at the strat of the game
        {
            boardRef.BoardBoxPiece[Piece.currentPos.x, Piece.currentPos.y] = Piece;
        }

        public void InitBoard(Board board)
        {
            RefToBoard = board;
           for (int i = 0; i < 8; i++)
            {
                new Pawn().Initialize(ETeam.Black, EPieceType.Pawn, new Grid().Initialize(1, i), board);
                new Pawn().Initialize(ETeam.White, EPieceType.Pawn, new Grid().Initialize(6, i), board);
            }
            // init rook
            new Rook().Initialize(ETeam.Black, EPieceType.Rook, new Grid().Initialize(0, 0), board);
            new Rook().Initialize(ETeam.Black, EPieceType.Rook, new Grid().Initialize(0, 7), board);
            new Rook().Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(7, 0), board);
            new Rook().Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(7, 7), board);

            // init Knight
            new Knight().Initialize(ETeam.Black, EPieceType.Night, new Grid().Initialize(0, 1), board);
            new Knight().Initialize(ETeam.Black, EPieceType.Night, new Grid().Initialize(0, 6), board);
            new Knight().Initialize(ETeam.White, EPieceType.Night, new Grid().Initialize(7, 1), board);
            new Knight().Initialize(ETeam.White, EPieceType.Night, new Grid().Initialize(7, 6), board);

            // initBishopt
            new Bishop().Initialize(ETeam.Black, EPieceType.Bishop, new Grid().Initialize(0, 2), board);
            new Bishop().Initialize(ETeam.Black, EPieceType.Bishop, new Grid().Initialize(0, 5), board);
            new Bishop().Initialize(ETeam.White, EPieceType.Bishop, new Grid().Initialize(7, 2), board);
            new Bishop().Initialize(ETeam.White, EPieceType.Bishop, new Grid().Initialize(7, 5), board);

            // intKing and Queen
            new King().Initialize(ETeam.Black, EPieceType.King, new Grid().Initialize(0, 4), board);
            blackKing =(King) board.FindPieceAtGrid(new Grid().Initialize(0, 4));
            new Queen().Initialize(ETeam.Black, EPieceType.Queen, new Grid().Initialize(0, 3), board);

            new King().Initialize(ETeam.White, EPieceType.King, new Grid().Initialize(7, 4), board);
            whiteKing = (King)board.FindPieceAtGrid(new Grid().Initialize(7, 4));
            new Queen().Initialize(ETeam.White, EPieceType.Queen, new Grid().Initialize(7, 3), board);
        }
        
        public void PrintBoard()
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write(" |  ");
            //for(int h=0; h<8; h++)
            //{
            //    Console.Write(" {0}  ", (char)('A' + h));
            //}
            Console.WriteLine();
            Console.ResetColor();
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (k == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", 8 - i);
                        Console.ResetColor();
                        for (int j = 0; j < 8; j++)
                        {
                            // Creates background color for pieces
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            if ((i + j) % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }

                            // Making it look like a better square by adding spaces on top and bottom

                            if (BoardBoxPiece[i, j] != null)
                            {
                                Console.Write(" {0} ", SwitchPieceIntoText(BoardBoxPiece[i, j].type, BoardBoxPiece[i,j].team));
                                
                            }
                            else
                            {
                                Console.Write("     ");
                            }
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("  {0}", 8 - i);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("| ");
                        Console.ResetColor();
                        for (int j = 0; j < 8; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            if ((i + j) % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.Write("     ");
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(" |");
                    }
                    
                    
                    Console.ResetColor();
                }

            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Red;
            
            for (int h = 0; h < 8; h++)
            { 
                Console.Write("  {0}  ",(char)('A'+h));
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public string SwitchPieceIntoText(EPieceType mpieceType, ETeam mTeam)
        {
            String rStr = "";
            if(hasDll == false)
            {
                // this returns the string is there are no symbols
                rStr =mTeam.ToString()[0]+""+ mpieceType.ToString()[0]+" ";
                return rStr.ToLower();
            }

            if(mTeam == ETeam.Black)
            {
                switch(mpieceType)
                {
                    case EPieceType.Pawn:
                        rStr = "\u265F";
                        break;
                    case EPieceType.Night:
                        rStr = "\u265E";
                        break;
                    case EPieceType.Bishop:
                        rStr = "\u265D";
                        break;
                    case EPieceType.Rook:
                        rStr = "\u265C";
                        break;
                    case EPieceType.Queen:
                        rStr = "\u265B";
                        break;
                    case EPieceType.King:
                        rStr = "\u265A";
                        break;
                }
            }
            else
            {
                switch (mpieceType)
                {
                    case EPieceType.Pawn:
                        rStr = "\u2659";
                        break;
                    case EPieceType.Night:
                        rStr = "\u2658";
                        break;
                    case EPieceType.Bishop:
                        rStr = "\u2657";
                        break;
                    case EPieceType.Rook:
                        rStr = "\u2656";
                        break;
                    case EPieceType.Queen:
                        rStr = "\u2655";
                        break;
                    case EPieceType.King:
                        rStr = "\u2654";
                        break;
                }
            }
            //This returns the symbols
            rStr = " " + rStr+" ";
            return rStr;
        }

        public void Move(Grid startPos, Grid targetPos)
        {
            BasePiece piece = BoardBoxPiece[startPos.x, startPos.y];
            BoardBoxPiece[targetPos.x, targetPos.y] = piece;
            BoardBoxPiece[startPos.x, startPos.y] = null;
        }

        public bool WasMoveValid(Grid startPos, Grid targetPos)
        {
            BasePiece piece = BoardBoxPiece[startPos.x, startPos.y];
            if (piece == null)
            {
                Console.WriteLine("Piece wasn't found in the start location");
                return false;
            } 

            BasePiece targetPiece = null;

            if (piece.CanMove(targetPos))
            {
                // If there's an enemy piece on the grid,
                if (FindPieceAtGrid(targetPos) != null && piece.team != FindPieceAtGrid(targetPos).team)
                {
                    //remove the piece on the board first 
                    AllPiecesOnBoard.Remove(BoardBoxPiece[targetPos.x, targetPos.y]);
                    targetPiece = BoardBoxPiece[targetPos.x, targetPos.y];
                    BoardBoxPiece[targetPos.x, targetPos.y] = null;
                }

                // Move Piece
                piece.currentPos = targetPos;
               
                // Update board
                BoardBoxPiece[startPos.x, startPos.y] = null;
                BoardBoxPiece[targetPos.x, targetPos.y] = piece;

                #region Check if moving the piece will result in leaving the team's King in check
                // if the team's king is in check. revert back
                
                
                if (piece.team == ETeam.White && whiteKing.IsBeingChecked())
                {
                    // Revert the pieces back
                    piece.currentPos = startPos;

                    BoardBoxPiece[startPos.x, startPos.y] = piece;
                
                    BoardBoxPiece[targetPos.x, targetPos.y] = targetPiece;
                    AllPiecesOnBoard.Add(targetPiece);
                    
                    Console.WriteLine($"TestLine: This results in the {piece.team.ToString()} being in check.");
                    return false;
                }
                else if (piece.team == ETeam.Black &&  blackKing.IsBeingChecked())
                {
                    // Revert the pieces back
                    piece.currentPos = startPos;
      
                    BoardBoxPiece[startPos.x, startPos.y] = piece;
                    BoardBoxPiece[targetPos.x, targetPos.y] = targetPiece;
                    AllPiecesOnBoard.Add(targetPiece);

                    Console.WriteLine($"TestLine: This results in the {piece.team.ToString()} being in check.");
                    return false;
                }
                if (piece.type == EPieceType.Pawn)
                {
                    if( (piece.team ==ETeam.Black && targetPos.x==7) || (piece.team == ETeam.White && targetPos.x == 0))
                    {
                        EPieceType PromotatePieceType = EPieceType.Pawn;
                        //BasePiece PromotedPiece = null;
                        Console.WriteLine("Promotion \n Select One of the following- \n R-Rook\nN-Knight\nB-Bishop\nQ-Queen");
                        while (true)
                        {
                            String Option=Console.ReadLine();
                            Option = Option.ToUpper();
                            //bool DoneProperInupt = false;
                            switch(Option)
                            {
                                case "R":
                                    PromotatePieceType = EPieceType.Rook;
                                    new Rook().Initialize(piece.team,PromotatePieceType,piece.currentPos,this);
                                    AllPiecesOnBoard.Add(FindPieceAtGrid(piece.currentPos));
                                    break;
                                case "N":
                                    PromotatePieceType = EPieceType.Night;
                                    new Knight().Initialize(piece.team, PromotatePieceType, piece.currentPos, this);
                                    AllPiecesOnBoard.Add(FindPieceAtGrid(piece.currentPos));
                                    break;
                                case "B":
                                    PromotatePieceType = EPieceType.Bishop;
                                    new Bishop().Initialize(piece.team, PromotatePieceType, piece.currentPos, this);
                                    AllPiecesOnBoard.Add(FindPieceAtGrid(piece.currentPos));
                                    break;
                                case "Q":
                                    PromotatePieceType = EPieceType.Queen;
                                    new Queen().Initialize(piece.team, PromotatePieceType, piece.currentPos, this);
                                    AllPiecesOnBoard.Add(FindPieceAtGrid(piece.currentPos));
                                    break;
                                default:
                                    break;
                            }
                            if(PromotatePieceType !=EPieceType.Pawn)
                            {
                                break;
                            }
                        }

                        AllPiecesOnBoard.Remove(piece);
                       
                    }
                }

                #endregion

                // Castle
                if (piece.type == EPieceType.King)
                {
                    int x = 0;
                    if (piece.team == ETeam.White) x = 7;

                    if (startPos.y == 4 && targetPos.y == 6)
                    {
                        Move(new Grid().Initialize(x, 7), new Grid().Initialize(x, 5));
                    }
                    else if (startPos.y == 4 && targetPos.y == 2)
                    {
                        Move(new Grid().Initialize(x, 0), new Grid().Initialize(x, 3));
                    }
                }

                // Went through all move validations 
                Console.WriteLine("TestLine: Valid Move");
                piece.bHasMoved = true;
                
                return true;
              
            }
            else
            {
                Console.WriteLine("Not possible move");
                
                return false;
            }
        }

        public BasePiece FindPieceAtGrid(Grid grid)
        {
            for (int i = 0; i < AllPiecesOnBoard.Count; i++)
            {
                if (AllPiecesOnBoard[i]== null) continue;
                if (AllPiecesOnBoard[i].currentPos.x == grid.x && AllPiecesOnBoard[i].currentPos.y == grid.y)
                {
                    return AllPiecesOnBoard[i];
                }
            }
            return null;
        }

        // Used for kings for checking Checks, checkmate, castle 
        public bool IsGridSafe(Grid grid, ETeam team)
        {
            if (FindPieceAtGrid(grid) != null)
            {
                if (FindPieceAtGrid(grid).team != team) return false;
            }
           

            foreach (BasePiece p in AllPiecesOnBoard)
            {
                if (p==null) continue;
                if (p.team == team) continue;
                if (p.type == EPieceType.King) continue; 

                if (p.GetLegalMoves().Contains(grid))
                {
                    return false;
                }
            }

            Console.WriteLine("Grid is safe for king");
            return true;
        }
        public bool IsGridSafeForOthers(Grid grid, ETeam team)
        {
            foreach (BasePiece p in AllPiecesOnBoard)
            {
                if (p == null) continue;
                if (p.team == team) continue;

                if (p.GetLegalMoves().Contains(grid))
                {
                    Console.WriteLine($"{p.team} {p.type} can capture the square");
                    return false;
                }
            }

            return true;
        }



        //public int[,] BoardArray()
        //{
        //    // initial comment
        //   // return int;
        //}


    }
}


//try
//{
//    Pawn p = (Pawn)piece;
//    if (p != null)
//    {
//        if (!p.bHasMoved)
//        {
//            if(p.currentPos.x-targetPos.x == 2 || p.currentPos.x - targetPos.x == -2)
//            {
//                p.SetEnPas();
//            }
//        }
//        else
//        {
//            p.bHasEnPas = false;
//        }
//    }
//}
//catch(Exception e)
//{

//}

// move the piece to the location