using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BoardGames.Reversi
{
    public class Disk : AReversiPiece
    {
        public Disk(PieceColor color) : base(ReversiPieceType.Disk, color)
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
