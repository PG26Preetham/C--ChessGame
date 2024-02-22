using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class King : BasePiece
    {
        
        public bool canKingSideCastle = false;
        public bool canQueenSideCastle = false;

        // function for checking if the current grid is safe for king
        public bool IsBeingChecked()
        {
            if (!board.IsGridSafe(new Grid().Initialize(currentPos.x, currentPos.y), team))
            {
                Console.WriteLine("CHECK");
                return true;
            }
            return false;

        }

        // Multiple checks for checkmate
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
                // if king isnt close enough to capture 
                if (!GetLegalMoves().Contains(new Grid().Initialize(attacker.currentPos.x, attacker.currentPos.y)))
                {
                    Console.WriteLine("CHECKMATE? : ENEMY CAN BE CAPTURED");

                    return false;
                } 
                // if king can capture, check if the grid is safe 
                else if (board.IsGridSafe(new Grid().Initialize(attacker.currentPos.x, attacker.currentPos.y), team))
                {
                    Console.WriteLine("NEW DEBUG: King is safe to capture");

                    return false;
                }

                Console.WriteLine("NEW DEBUG: King is not safe to capture");
            }

            // check if its the king that can capture the attacker


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

                        

                        Console.WriteLine($"Direction: {xDir} {yDir} ");

                        
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


        // Checking for castle
        public void CheckCastle()
        {
            //Console.WriteLine("Checking for castles");
            if (IsBeingChecked()) return;

            canKingSideCastle = true;
            canQueenSideCastle = true;

            // Check if there are any pieces between the king and knights
            // Queenside Castle
            for (int i = 1; i < 4; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - i)) != null)
                {
                    //Console.WriteLine($"Found {board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - i))} piece between {team} king and left rook");
                    canQueenSideCastle = false;
                }
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x, currentPos.y - i)), team))
                {
                    //Console.WriteLine("The castling grid is not safe for king");
                    canQueenSideCastle = false;
                }
            }

            // Kingside Castle
            for (int i = 1; i < 3; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + i)) != null) 
                {
                    //Console.WriteLine($"Found {board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + 1))} piece between {team} king and right rook");
                    canKingSideCastle = false;
                }
                if (!board.IsGridSafe((new Grid().Initialize(currentPos.x, currentPos.y + i)), team)) canKingSideCastle = false; 
            }      

            // Look for rook
            // Queenside Castle
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - 4)) != null && canQueenSideCastle)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - 4));
                if (!p.bHasMoved) canQueenSideCastle = true;
                
            }
            // Kingside Castle
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + 3)) != null && canKingSideCastle)
            {
                BasePiece p = board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + 3));
                if (!p.bHasMoved) canKingSideCastle = true;
            }
        }


        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            Console.WriteLine("Checking King's legal moves");

            IsBeingChecked();

            // Castle check if king hasnt moved
            if (!bHasMoved)
            {
                Console.WriteLine($"Checking if {type} can castle");
                CheckCastle();

                if (canKingSideCastle)
                {
                    Console.WriteLine($"{team} King can king side castle");
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + 2));
                }

                if (canQueenSideCastle)
                {
                    Console.WriteLine($"{team} King can queen side castle");
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y - 2));
                }
            }


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
