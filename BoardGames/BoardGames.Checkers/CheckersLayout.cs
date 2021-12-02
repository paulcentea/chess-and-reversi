using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class CheckersLayout : ALayout
    {
        public override void Initialize()
        {
            CheckersPieceFactory checkersPieceFactory = new CheckersPieceFactory();

            for(int i = 0; i < 3; i++)
            {
                if(i % 2 == 0)
                {
                    for(int j = 1; j < 8; j += 2)
                    {
                        Add(Coordinate.GetInstance(i, j), checkersPieceFactory.GetPiece(0, PieceColor.White));
                    }
                }
                else
                {
                    for(int j = 0; j < 7; j += 2)
                    {
                        Add(Coordinate.GetInstance(i, j), checkersPieceFactory.GetPiece(0, PieceColor.White));
                    }
                }
            }

            for(int i = 5; i < 8; i++)
            {
                if(i % 2 == 0)
                {
                    for(int j = 1; j < 8; j += 2)
                    {
                        Add(Coordinate.GetInstance(i, j), checkersPieceFactory.GetPiece(0, PieceColor.Black));
                    }
                }
                else
                {
                    for (int j = 0; j < 7; j += 2)
                    {
                        Add(Coordinate.GetInstance(i, j), checkersPieceFactory.GetPiece(0, PieceColor.Black));
                    }
                }
            }
        }

        public override void Move(Move move)
        {
            if (!ContainsKey(move.SourceCoordinate) || move.DestinationCoordinate == null)
            {
                return;
            }

            APiece piece = this[move.SourceCoordinate];
            List<Coordinate> availablePrisoners = new List<Coordinate>();

            Remove(move.SourceCoordinate);

            availablePrisoners.AddRange(GetPrisoners(move.SourceCoordinate, piece.Color));
            foreach (var prisoner in availablePrisoners)
            {
                Remove(prisoner);
            }

            Add(move.DestinationCoordinate, piece);
        }

        public List<Coordinate> GetPrisoners(Coordinate sourceCoordinate, PieceColor color)
        {
            List<Coordinate> availablePrisoners = new List<Coordinate>();

            for (int directionRow = -1; directionRow < 2; directionRow++)
            {
                for (int directionColumn = -1; directionColumn < 2; directionColumn++)
                {
                    if ((directionRow == 0 && directionColumn == 0) || directionRow == 0 || directionColumn == 0)
                    {
                        continue;
                    }

                    int i = 2;

                    if (sourceCoordinate.Row + i * directionRow >= 0 && sourceCoordinate.Row + i * directionRow <= 7 && sourceCoordinate.Column + i * directionColumn >= 0 && sourceCoordinate.Column + i * directionColumn <= 7)
                    {
                        if (!ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row + i * directionRow, sourceCoordinate.Column + i * directionColumn)))
                        {
                            if (ContainsKey(Coordinate.GetInstance(sourceCoordinate.Row + (i - 1) * directionRow, sourceCoordinate.Column + (i - 1) * directionColumn)))
                            {
                                if (this[Coordinate.GetInstance(sourceCoordinate.Row + (i - 1) * directionRow, sourceCoordinate.Column + (i - 1) * directionColumn)].Color != color)
                                {
                                    availablePrisoners.Add(Coordinate.GetInstance(sourceCoordinate.Row + (i - 1) * directionRow, sourceCoordinate.Column + (i - 1) * directionColumn));
                                }
                            }
                        }
                    }
                }
            }
            return availablePrisoners;
        }

        public override ALayout Clone()
        {
            ALayout clone = new CheckersLayout();

            foreach (var coordinate in this.Keys)
            {
                clone.Add(coordinate, this[coordinate]);
            }

            return clone;
        }
    }
}
