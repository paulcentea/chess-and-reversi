using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Reversi
{
    public class ReversiTurnChanger : ITurnChanger
    {
        public PieceColor ChangeTurn(PieceColor currentColor, Context context)
        {
            context.CurrentColor = context.CurrentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
            Coordinate aCoordinateOfCurrentColor = context.Layout.Keys.FirstOrDefault(c => context.Layout[c].Color == context.CurrentColor);

            if (aCoordinateOfCurrentColor != null && context.Layout[aCoordinateOfCurrentColor].GetAvailableMoves(aCoordinateOfCurrentColor, context).Count > 0)
            {
                return context.CurrentColor;
            }
            else
            {
                context.CurrentColor = currentColor;
            }

            return currentColor;
        }
    }
}
