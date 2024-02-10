using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_TEXTChess
{
    enum ETeam
    {
        White = 0,
        Black
    }


    internal class BasePiece
    {
        public ETeam team { private set; get; }

        public virtual bool Move()
        {



            return true;
        }
    }
}
