using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class AdaptedAPiece
    {
        public PieceColor Color;
        public int Type;

        public AdaptedAPiece(PieceColor color, int type)
        {
            Color = color;
            Type = type;
        }
    }
}
