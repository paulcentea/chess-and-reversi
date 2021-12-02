using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace BoardGames.Checkers
{
    public abstract class ACheckersPiece : APiece
    {
        protected static Bitmap checkersPiecesImage = new Bitmap(100, 100);

        public ACheckersPiece(CheckersPieceType type, PieceColor color) : base((int)type, color)
        {

        }

        public override Bitmap GetImage()
        {
            Graphics g = Graphics.FromImage(checkersPiecesImage);
            g.FillEllipse(Color == PieceColor.White ? Brushes.BurlyWood : Brushes.Black, 0, 0, 100, 100);

            return checkersPiecesImage;
        }

        protected override List<Coordinate> ConsiderMoveInLine(Coordinate sourceCoordinate, int directionRow, int directionColumn, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            foreach (var coordinate in context.Layout.Keys)
            {
                if (context.Layout[coordinate].Color == context.CurrentColor)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (i == 1)
                        {
                            if (coordinate.Row + i * directionRow >= 0 && coordinate.Row + i * directionRow <= 7 && coordinate.Column + i * directionColumn >= 0 && coordinate.Column + i * directionColumn <= 7)
                            {
                                if (!context.Layout.ContainsKey(Coordinate.GetInstance(coordinate.Row + i * directionRow, coordinate.Column + i * directionColumn)))
                                {
                                    break;
                                }
                            }
                        }

                        if (coordinate.Row + i * directionRow >= 0 && coordinate.Row + i * directionRow <= 7 && coordinate.Column + i * directionColumn >= 0 && coordinate.Column + i * directionColumn <= 7)
                        {
                            if (!context.Layout.ContainsKey(Coordinate.GetInstance(coordinate.Row + i * directionRow, coordinate.Column + i * directionColumn)))
                            {
                                if (context.Layout.ContainsKey(Coordinate.GetInstance(coordinate.Row + (i - 1) * directionRow, coordinate.Column + (i - 1) * directionColumn)))
                                {
                                    if (context.Layout[Coordinate.GetInstance(coordinate.Row + (i - 1) * directionRow, coordinate.Column + (i - 1) * directionColumn)].Color != context.CurrentColor)
                                    {
                                        availableMoves.Add(Coordinate.GetInstance(coordinate.Row + i * directionRow, coordinate.Column + i * directionColumn));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}
