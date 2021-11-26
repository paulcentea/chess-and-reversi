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
    public class Knight : AChessPiece
    {

        public Knight(PieceColor color) : base(ChessPieceType.Knight, color)
        {

        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            if (context.CurrentColor == Color)
            {
                for (int x = -2; x < 3; x++)
                {
                    for (int y = -2; y < 3; y++)
                    {
                        if (x == 0 || y == 0 || Math.Abs(x) == Math.Abs(y))
                        {
                            continue;
                        }

                        if (sourceCoordinate.Row + x >= 0 && sourceCoordinate.Row + x <= 7 && sourceCoordinate.Column + y >= 0 && sourceCoordinate.Column + y <= 7)
                        {
                            if (!context.Layout.ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row + x, sourceCoordinate.Column + y)) || context.Layout[Coordinate.GetInstance(sourceCoordinate.Row + x, sourceCoordinate.Column + y)].Color != context.CurrentColor)
                            {
                                availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row + x, sourceCoordinate.Column + y));
                            }
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}
