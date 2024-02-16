using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class King : BasePiece
    {
        
        public bool canKingSideCastle = false;
        public bool canQueenSideCastle = false;

        public bool IsBeingChecked()
        {
            if (!board.IsGridSafe(new Grid().Initialize(currentPos.x, currentPos.y), team))
            {
                Console.WriteLine("CHECK");
                return true;
            }
            return false;

        }

        public bool IsCheckmate(BasePiece attacker)
        {
            if (!IsBeingChecked())  
            {
                Console.WriteLine("CHECKMATE? : NOT IN CHECK");
                return false;
            }

            Console.WriteLine(attacker.team);

            if (!board.IsGridSafeForOthers(new Grid().Initialize(attacker.currentPos.x, attacker.currentPos.y), attacker.team))// Enemy attacker can be captured
            {
                Console.WriteLine("CHECKMATE? : ENEMY CAN BE CAPTURED");

                return false;
            }

            foreach (Grid grid in GetLegalMoves())
            {
                if (board.IsGridSafe(grid, team)) 
                {
                    Console.WriteLine("CHECKMATE? : KING HAS AVAILABLE MOVES");
                    return false;
                }
            }

            if (attacker.type != EPieceType.Night) // Excluding for the block check since Knight can't be blocked
            {
                foreach (BasePiece p in board.AllPiecesOnBoard) 
                {
                    if (p.team != team) continue;

                    for (int i = 0; i < p.GetLegalMoves().Count; i++)
                    {

                        // attack position -> king position    - Get the grids for these
                        // f (attacker.GetLegalMoves().Contains(the grids above))

                        int yDir = currentPos.y - attacker.currentPos.y;
                        int xDir = currentPos.x - attacker.currentPos.x;

                        

                        Console.WriteLine($"Direction: {yDir} {xDir}");

                        
                        if (attacker.GetMoveInDirection(yDir, xDir).Contains(p.GetLegalMoves()[i])) // Checking if any piece can block for attack line to escape check
                        {
                            Console.WriteLine("CHECKMATE? : ALLY CAN BODY BLOCK FOR KING");
                            Console.WriteLine($"Can be bodyblocked by {p.team} {p.type} {p.currentPos.x}, {p.currentPos.y}");
                            return false;
                        }
                    }
                }
            }

            // Went through all checks, it's Checkmate
            Console.WriteLine("Checkmate");
            return true;
        }



        public void CheckCastle()
        {
            if (IsBeingChecked()) return;

            for (int i = 1; i < 3; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y)) != null) return;
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x - i, currentPos.y)), team)) return;          
            }
            for (int i = 1; i < 2; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y)) != null) return;
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x + i, currentPos.y)), team)) return;
            }      

            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - 4, currentPos.y)) != null)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - 4, currentPos.y));
                if (!p.bHasMoved) canQueenSideCastle = true;
                
            }
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + 3, currentPos.y)) != null)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + 3, currentPos.y));
                if (!p.bHasMoved) canKingSideCastle = true;
            }
        }


        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            if (!bHasMoved)
            {
                IsBeingChecked();
                CheckCastle();

                if (canKingSideCastle) legalMove.Add(new Grid().Initialize(currentPos.x + 2, currentPos.y));

                if (canQueenSideCastle) legalMove.Add(new Grid().Initialize(currentPos.x - 2, currentPos.y));
            }

            IsBeingChecked();
            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y));
            legalMove.Add(new Grid().Initialize(currentPos.x -1, currentPos.y));
            legalMove.Add(new Grid().Initialize(currentPos.x +1, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x -1, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y+1));
            legalMove.Add(new Grid().Initialize(currentPos.x + 1, currentPos.y-1));
            legalMove.Add(new Grid().Initialize(currentPos.x - 1, currentPos.y-1));
            legalMove.Add(new Grid().Initialize(currentPos.x , currentPos.y-1));
            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
