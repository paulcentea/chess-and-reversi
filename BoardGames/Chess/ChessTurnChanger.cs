using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Chess
{
    public class ChessTurnChanger : ITurnChanger
    {
        public PieceColor ChangeTurn(PieceColor currentColor, Context context)
        {
            return currentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }
    }
}
