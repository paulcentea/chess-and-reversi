using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using BoardGames.API;
using BoardGames.Chess;

namespace BoardGames
{
    public class Queen : AChessPiece
    {
        public Queen(PieceColor color) : base(ChessPieceType.Queen, color)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            if (context.CurrentColor == Color)
            {
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 1, 0, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 0, 1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, -1, 0, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 0, -1, context));

                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 1, 1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, 1, -1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, -1, 1, context));
                availableMoves.AddRange(ConsiderMoveInLine(sourceCoordinate, -1, -1, context));
            }
            return availableMoves;
        }
    }
}
