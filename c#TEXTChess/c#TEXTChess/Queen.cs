using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    internal class Queen : BasePiece
    {
        public override bool Move(Grid startPoint, Grid endPoint)
        {


            return true;
        }

        public override List<Grid> GetLegalMoves()
        {
            List<Grid> legalMove = new List<Grid>();

            #region Horizontal, Vertical, Diagonal Checks
            for (int i = 0; i < 8; i++)
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
            for (int i = 0; i < 8; i++)
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
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y + 1)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y + 1));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x, currentPos.y - 1)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x, currentPos.y - 1));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y + i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y + 1));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x + i, currentPos.y - i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x + i, currentPos.y - i));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y + i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y + i));
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board.FindPieceAtGrid(new Grid().Initialize(currentPos.x - i, currentPos.y - i)) == null)
                {
                    legalMove.Add(new Grid().Initialize(currentPos.x - i, currentPos.y - i));
                }
                else
                {
                    break;
                }
            }
            #endregion

            legalMove = CheckBounds(legalMove);

            return legalMove;
        }
    }
}
