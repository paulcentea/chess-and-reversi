using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Reversi
{
    public class ReversiLayout : ALayout
    {
        public override void Initialize()
        {
            ReversiPieceFactory reversiPieceFactory = new ReversiPieceFactory();

            Add(Coordinate.GetInstance(3, 3), reversiPieceFactory.GetPiece((int)ReversiPieceType.Disk, PieceColor.White));
            Add(Coordinate.GetInstance(4, 4), reversiPieceFactory.GetPiece((int)ReversiPieceType.Disk, PieceColor.White));
            Add(Coordinate.GetInstance(3, 4), reversiPieceFactory.GetPiece((int)ReversiPieceType.Disk, PieceColor.Black));
            Add(Coordinate.GetInstance(4, 3), reversiPieceFactory.GetPiece((int)ReversiPieceType.Disk, PieceColor.Black));
        }

        public override void Move(Move move)
        {
            if (!ContainsKey(move.SourceCoordinate) || move.DestinationCoordinate == null)
            {
                return;
            }

            APiece piece = this[move.SourceCoordinate];
            List<Coordinate> availablePrisoners = new List<Coordinate>();

            Add(move.DestinationCoordinate, piece);

            availablePrisoners.AddRange(GetPrisoners(move.DestinationCoordinate, piece.Color));
            foreach(var prisoner in availablePrisoners)
            {
                Remove(prisoner);
                Add(prisoner, piece);
            }
        }

        public List<Coordinate> GetPrisoners (Coordinate destinationCoordinate, PieceColor color)
        {
            List<Coordinate> availablePrisoners = new List<Coordinate>();

            for(int directionRow = -1; directionRow < 2; directionRow++)
            {
                for (int directionColumn = -1; directionColumn < 2; directionColumn++)
                {
                    if (directionRow == 0 && directionColumn == 0)
                    {
                        continue;
                    }

                    for (int i = 1; i < 9; i++)
                    {
                        if (destinationCoordinate.Row + i * directionRow >= 0 && destinationCoordinate.Row + i * directionRow <= 7 && destinationCoordinate.Column + i * directionColumn >= 0 && destinationCoordinate.Column + i * directionColumn <= 7)
                        {
                            if (this.ContainsKey(Coordinate.GetInstance(destinationCoordinate.Row + i * directionRow, destinationCoordinate.Column + i * directionColumn)))
                            {
                                if (this[Coordinate.GetInstance(destinationCoordinate.Row + i * directionRow, destinationCoordinate.Column + i * directionColumn)].Color == color)
                                {
                                    if (i == 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        for (int j = i - 1; j > 0; j--)
                                        {
                                            if(this.ContainsKey(Coordinate.GetInstance(destinationCoordinate.Row + j * directionRow, destinationCoordinate.Column + j * directionColumn)))
                                            {
                                                if (this[Coordinate.GetInstance(destinationCoordinate.Row + j * directionRow, destinationCoordinate.Column + j * directionColumn)].Color != color)
                                                {
                                                    availablePrisoners.Add(Coordinate.GetInstance(destinationCoordinate.Row + j * directionRow, destinationCoordinate.Column + j * directionColumn));
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return availablePrisoners;
        }

        public override ALayout Clone()
        {
            ALayout clone = new ReversiLayout();

            foreach (var coordinate in this.Keys)
            {
                clone.Add(coordinate, this[coordinate]);
            }

            return clone;
        }
    }
}
