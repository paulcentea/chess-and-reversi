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
    public class Pawn : AChessPiece
    {
        public Pawn(PieceColor color) : base(ChessPieceType.Pawn, color)
        {
            
        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            if (context.CurrentColor == Color)
            {
                for (int i = -2; i < 0; i++)
                {
                    if (sourceCoordinate.Row + (2 * (int)Color - 1) * i >= 0 && sourceCoordinate.Row + (2 * (int)Color - 1) * i <= 7 && sourceCoordinate.Column >= 0 && sourceCoordinate.Column <= 7)
                    {
                        if (!context.Layout.ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row + (2 * (int)Color - 1) * i, sourceCoordinate.Column)))
                        {
                            if (sourceCoordinate.Row == 6 || sourceCoordinate.Row == 1)
                            {
                                availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row + (2 * (int)Color - 1) * i, sourceCoordinate.Column));
                            }
                            else
                            {
                                availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row + (2 * (int)Color - 1) * (-1), sourceCoordinate.Column));
                            }
                        }
                    }
                }

                for (int j = -1; j < 2; j++)
                {
                    if (j == 0)
                    {
                        continue;
                    }

                    if (sourceCoordinate.Row - (2 * (int)Color - 1) >= 0 && sourceCoordinate.Row - (2 * (int)Color - 1) <= 7 && sourceCoordinate.Column + (2 * (int)Color - 1) * j >= 0 && sourceCoordinate.Column + (2 * (int)Color - 1) * j <= 7)
                    {
                        if (context.Layout.ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row - (2 * (int)Color - 1), sourceCoordinate.Column + (2 * (int)Color - 1) * j)) && context.Layout[Coordinate.GetInstance(sourceCoordinate.Row - (2 * (int)Color - 1), sourceCoordinate.Column + (2 * (int)Color - 1) * j)].Color != context.CurrentColor)
                        {
                            availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row - (2 * (int)Color - 1), sourceCoordinate.Column + (2 * (int)Color - 1) * j));
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}
