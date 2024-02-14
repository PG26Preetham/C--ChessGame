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
        //
        public List<BasePiece> AllPiecesOnBoard = new List<BasePiece>();
        public int BoardSize = 8;

        public BoxBase[,] BoardBoxes=new BoxBase[8,8];
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
           for (int i = 0; i < 8; i++)
            {
                new Pawn().Initialize(ETeam.Black, EPieceType.Pawn, new Grid().Initialize(1, i), board);
                new Pawn().Initialize(ETeam.White, EPieceType.Pawn, new Grid().Initialize(6, i), board);
            }
            //init rook
            new Rook().Initialize(ETeam.Black, EPieceType.Rook, new Grid().Initialize(0, 0), board);
            new Rook().Initialize(ETeam.Black, EPieceType.Rook, new Grid().Initialize(0, 7), board);
            new Rook().Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(7, 0), board);
            new Rook().Initialize(ETeam.White, EPieceType.Rook, new Grid().Initialize(7, 7), board);

            //init Knight
            new Knight().Initialize(ETeam.Black, EPieceType.Night, new Grid().Initialize(0, 1), board);
            new Knight().Initialize(ETeam.Black, EPieceType.Night, new Grid().Initialize(0, 6), board);
            new Knight().Initialize(ETeam.White, EPieceType.Night, new Grid().Initialize(7, 1), board);
            new Knight().Initialize(ETeam.White, EPieceType.Night, new Grid().Initialize(7, 6), board);

            //initBishopt
            new Bishop().Initialize(ETeam.Black, EPieceType.Bishop, new Grid().Initialize(0, 2), board);
            new Bishop().Initialize(ETeam.Black, EPieceType.Bishop, new Grid().Initialize(0, 5), board);
            new Bishop().Initialize(ETeam.White, EPieceType.Bishop, new Grid().Initialize(7, 2), board);
            new Bishop().Initialize(ETeam.White, EPieceType.Bishop, new Grid().Initialize(7, 5), board);

            //intKing and Queen
            new King().Initialize(ETeam.Black, EPieceType.King, new Grid().Initialize(0, 4), board);
            blackKing =(King) board.FindPieceAtGrid(new Grid().Initialize(0, 4));
            new Queen().Initialize(ETeam.Black, EPieceType.Queen, new Grid().Initialize(0, 3), board);

            new King().Initialize(ETeam.White, EPieceType.King, new Grid().Initialize(7, 4), board);
            blackKing = (King)board.FindPieceAtGrid(new Grid().Initialize(7, 4));
            new Queen().Initialize(ETeam.White, EPieceType.Queen, new Grid().Initialize(7, 3), board);
        }
        
        public void PrintBoard()
        {
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (BoardBoxPiece[i, j] != null) 
                    {
                        Console.Write("\t{0}\t",BoardBoxPiece[i, j].type.ToString()[0]);
                    }
                    else
                    {
                        Console.Write("\t0\t");
                    }
                }
                Console.WriteLine();
            }
        }
        public bool WasMoveValid(Grid startPos, Grid targetPos)
        {
            BasePiece piece = BoardBoxPiece[startPos.x, startPos.y];
            BasePiece targetPiece = null;

            if (piece.CanMove(targetPos))
            {
                // If there's an enemy piece on the grid,
                if (FindPieceAtGrid(targetPos) != null && piece.team != FindPieceAtGrid(targetPos).team)
                {
                    //remove the piece on the board first 

                    targetPiece = BoardBoxPiece[targetPos.x, targetPos.y];
                }

                // Move Piece
                piece.currentPos = targetPos;

                // Update board
                BoardBoxPiece[startPos.x, startPos.y] = null;
                BoardBoxPiece[targetPos.x, targetPos.y] = piece;

                #region Check if moving the piece will result in leaving the team's King in check
                // if the team's king is in check. revert back
                if (piece.team == ETeam.White && whiteKing.isBeingChecked)
                {
                    // Revert the pieces back
                    piece.currentPos = startPos;

                    BoardBoxPiece[startPos.x, startPos.y] = piece;
                    if (targetPiece != null)
                    {
                        BoardBoxPiece[targetPos.x, targetPos.y] = targetPiece;
                    }

                    Console.WriteLine($"TestLine: This results in the {piece.team.ToString()} being in check.");
                    return false;
                }
                else if (piece.team == ETeam.Black && blackKing.isBeingChecked)
                {
                    // Revert the pieces back
                    piece.currentPos = startPos;
      
                    BoardBoxPiece[startPos.x, startPos.y] = piece;
                    if (targetPiece != null)
                    {
                        BoardBoxPiece[targetPos.x, targetPos.y] = targetPiece;
                    }
                    Console.WriteLine($"TestLine: This results in the {piece.team.ToString()} being in check.");
                    return false;
                }
                #endregion

                // Went through all move validations 
                Console.WriteLine("TestLine: Valid Move");
                piece.bHasMoved = true;
                return true;
            }
            else
            {
                Console.WriteLine("TestLine: Invalid Move");
                return false;
            }
        }

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

        // Used for kings for checking Checks, checkmate, castle 
        public bool IsGridSafe(Grid grid, ETeam team)
        {
            foreach (BasePiece p in AllPiecesOnBoard)
            {
                if (p.team == team) continue;

                if (p.GetLegalMoves().Contains(grid)) return false;
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