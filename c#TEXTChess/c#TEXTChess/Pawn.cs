﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Pawn : BasePiece
    {
        Grid enPasGrid;
        public bool canEnPas = false;
        
        public void SetEnPas()
        {
            int direction = 1;
            if (team == ETeam.Black) { direction = -1; }
            enPasGrid = new Grid().Initialize(currentPos.x, currentPos.y + direction);
            canEnPas = true;
        }
        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();
            int direction = -1;
            if (team == ETeam.Black) { direction = 1; }//changing the direction base on the team
            else { direction = -1; }
           

            legalMove.Add(new Grid().Initialize(currentPos.x + direction, currentPos.y));

            //Adding extra space to move if it is the first time moving
            if(bHasMoved==false)
            {
                if(board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + (2 * direction), currentPos.y))==null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + (2 * direction), currentPos.y));
                }
                         
            }
            //to check if the pawn can move to cut a piece
            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x+ direction, currentPos.y + 1 )) != null)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y + 1)).team != team)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x +direction, currentPos.y +1));
                }
            }

            if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1)) != null)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1)).team != team)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + direction, currentPos.y - 1));
                }
            }

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
