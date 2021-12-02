using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class DoubleMan : ACheckersPiece
    {
        public DoubleMan(PieceColor color) : base (CheckersPieceType.DoubleMan, color) 
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            if (context.CurrentColor == Color)
            {
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 1, 1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 1, -1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, -1, 1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, -1, -1, context));
            }

            return availableMoves;
        }
    }
}
