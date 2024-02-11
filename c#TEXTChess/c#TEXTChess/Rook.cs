﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Rook : BasePiece
    {
       
        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            for (int i = 1; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y));
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y));
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + i));
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y - i));
                }
                else
                {
                    break;
                }
            }



            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
