using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class Man : ACheckersPiece
    {
        public Man(PieceColor color) : base(CheckersPieceType.Man, color) 
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

                if(availableMoves.Count != 0)
                {
                    return availableMoves;
                }
                else
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            continue;
                        }

                        if (sourceCoordinate.Row - (1 - 2 * (int)Color) >= 0 && sourceCoordinate.Row - (1 - 2 * (int)Color) <= 7 && sourceCoordinate.Column + (1 - 2 * (int)Color) * j >= 0 && sourceCoordinate.Column + (1 - 2 * (int)Color) * j <= 7)
                        {
                            if (!context.Layout.ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row - (1 - 2 * (int)Color), sourceCoordinate.Column + (1 - 2 * (int)Color) * j)))
                            {
                                availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row - (1 - 2 * (int)Color), sourceCoordinate.Column + (1 - 2 * (int)Color) * j));
                            }
                        }
                    }
                }
                
            }
            return availableMoves;
        }
    }
}
