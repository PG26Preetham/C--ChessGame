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
            if (!IsBeingChecked() || GetLegalMoves().Count != 0) return false; // If not in check or If King has available moves
            if (!board.IsGridSafe(new Grid().Initialize(attacker.currentPos.x, attacker.currentPos.y), attacker.team)) return false; // Enemy attacker can be captured

            if (attacker.type != EPieceType.Night) // Excluding for the block check since Knight can't be blocked
            {
                foreach (BasePiece p in board.AllPiecesOnBoard) 
                {
                    if (p.team == team) continue;

                    for (int i = 0; i < p.GetLegalMoves().Count; i++)
                    {
                        if (attacker.GetLegalMoves().Contains(p.GetLegalMoves()[i])) // Checking if any piece can block for attack line to escape check
                        {
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
            if (bHasMoved || IsBeingChecked()) return;

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
