using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BoardGames.API;
using BoardGames;
using System.Reflection;

namespace BoardGames.Chess
{
    public abstract class AChessPiece : APiece
    {
        protected static Bitmap chessPiecesImage = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("BoardGames.Chess.Resources.ChessPiecesArray.png"));

        public AChessPiece(ChessPieceType type, PieceColor color) : base((int)type, color)
        {

        }

        public override Bitmap GetImage()
        {
            if (AllPieceImages == null)
            {
                AllPieceImages = new Dictionary<PieceColor, Dictionary<int, Bitmap>>();
            }

            if (!AllPieceImages.ContainsKey(Color))
            {
                AllPieceImages.Add(Color, new Dictionary<int, Bitmap>());
            }

            if (!AllPieceImages[Color].ContainsKey(Type))
            {
                AllPieceImages[Color].Add(Type, chessPiecesImage.Clone(new Rectangle(chessPiecesImage.Width * Type / 6, (chessPiecesImage.Height / 2) * (int)Color, chessPiecesImage.Width / 4 - chessPiecesImage.Width / 12, chessPiecesImage.Height / 2), chessPiecesImage.PixelFormat));
            }

            return AllPieceImages[Color][Type];
        }


        protected override List<Coordinate> ConsiderMoveInLine(Coordinate sourceCoordinate, int directionRow, int directionColumn, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            for (int i = 1; i < 9; i++)
            {
                if (sourceCoordinate.Row + i * directionRow >= 0 && sourceCoordinate.Row + i * directionRow <= 7 && sourceCoordinate.Column + i * directionColumn >= 0 && sourceCoordinate.Column + i * directionColumn <= 7)
                {
                    if (!context.Layout.ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row + i * directionRow, sourceCoordinate.Column + i * directionColumn)))
                    {
                        availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row + i * directionRow, sourceCoordinate.Column + i * directionColumn));
                    }
                    else
                    {
                        if (context.Layout[Coordinate.GetInstance(sourceCoordinate.Row + i * directionRow, sourceCoordinate.Column + i * directionColumn)].Color != context.CurrentColor)
                        {
                            availableMoves.Add(Coordinate.GetInstance(sourceCoordinate.Row + i * directionRow, sourceCoordinate.Column + i * directionColumn));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return availableMoves;
        }
    }
}
