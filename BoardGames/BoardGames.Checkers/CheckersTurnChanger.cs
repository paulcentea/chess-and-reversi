using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class CheckersTurnChanger : ITurnChanger
    {
        public PieceColor ChangeTurn(PieceColor currentColor, Context context)
        {
            return currentColor = currentColor == PieceColor.Black ? PieceColor.White : PieceColor.Black;
        }
    }
}
