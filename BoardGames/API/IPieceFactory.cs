using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public interface IPieceFactory
    {
        APiece GetPiece(int type, PieceColor color);
    }
}
