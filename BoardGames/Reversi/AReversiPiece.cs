using BoardGames.API;
using BoardGames;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Reversi
{
    public abstract class AReversiPiece : APiece
    {
        protected static Bitmap reversiPiecesImage = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("BoardGames.Reversi.Resources.ReversiPieces.png"));

        public AReversiPiece(ReversiPieceType type, PieceColor color) : base((int)type, color)
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
                AllPieceImages[Color].Add(Type, reversiPiecesImage.Clone(new Rectangle(reversiPiecesImage.Width / 2 * (int)Color, 0, reversiPiecesImage.Width - reversiPiecesImage.Width / 2, reversiPiecesImage.Height), reversiPiecesImage.PixelFormat));
            }

            return AllPieceImages[Color][Type];
        }

        protected override List<Coordinate> ConsiderMoveInLine(Coordinate sourceCoordinate, int directionRow, int directionColumn, Context context)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();

            foreach (var coordinate in context.Layout.Keys)
            {
                if (context.Layout[coordinate].Color == context.CurrentColor)
                {
                    for (int i = 1; i < 9; i++)
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
                                for(int j = i - 1; j > 0; j--)
                                {
                                    if (context.Layout.ContainsKey(Coordinate.GetInstance(coordinate.Row + j * directionRow, coordinate.Column + j * directionColumn)))
                                    {
                                        if(context.Layout[Coordinate.GetInstance(coordinate.Row + j * directionRow, coordinate.Column + j * directionColumn)].Color != context.CurrentColor)
                                        {
                                            availableMoves.Add(Coordinate.GetInstance(coordinate.Row + i * directionRow, coordinate.Column + i * directionColumn));
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    break;
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
