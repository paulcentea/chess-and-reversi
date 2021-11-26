using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    public class ChessLayout : ALayout
    {
        public override void Initialize()
        {
            ChessPieceFactory chessPieceFactory = new ChessPieceFactory();

            for (int j = 0; j < 8; j++)
            {
                Add(Coordinate.GetInstance(6, j), chessPieceFactory.GetPiece((int)ChessPieceType.Pawn, PieceColor.White));
                Add(Coordinate.GetInstance(1, j), chessPieceFactory.GetPiece((int)ChessPieceType.Pawn, PieceColor.Black));
            }

            Add(Coordinate.GetInstance(0, 0), chessPieceFactory.GetPiece((int)ChessPieceType.Rook, PieceColor.Black));
            Add(Coordinate.GetInstance(7, 0), chessPieceFactory.GetPiece((int)ChessPieceType.Rook, PieceColor.White));
            Add(Coordinate.GetInstance(7, 7), chessPieceFactory.GetPiece((int)ChessPieceType.Rook, PieceColor.White));
            Add(Coordinate.GetInstance(0, 7), chessPieceFactory.GetPiece((int)ChessPieceType.Rook, PieceColor.Black));

            Add(Coordinate.GetInstance(7, 2), chessPieceFactory.GetPiece((int)ChessPieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(7, 5), chessPieceFactory.GetPiece((int)ChessPieceType.Bishop, PieceColor.White));
            Add(Coordinate.GetInstance(0, 2), chessPieceFactory.GetPiece((int)ChessPieceType.Bishop, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 5), chessPieceFactory.GetPiece((int)ChessPieceType.Bishop, PieceColor.Black));

            Add(Coordinate.GetInstance(7, 1), chessPieceFactory.GetPiece((int)ChessPieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(7, 6), chessPieceFactory.GetPiece((int)ChessPieceType.Knight, PieceColor.White));
            Add(Coordinate.GetInstance(0, 1), chessPieceFactory.GetPiece((int)ChessPieceType.Knight, PieceColor.Black));
            Add(Coordinate.GetInstance(0, 6), chessPieceFactory.GetPiece((int)ChessPieceType.Knight, PieceColor.Black));

            Add(Coordinate.GetInstance(7, 3), chessPieceFactory.GetPiece((int)ChessPieceType.Queen, PieceColor.White));
            Add(Coordinate.GetInstance(0, 3), chessPieceFactory.GetPiece((int)ChessPieceType.Queen, PieceColor.Black));

            Add(Coordinate.GetInstance(7, 4), chessPieceFactory.GetPiece((int)ChessPieceType.King, PieceColor.White));
            Add(Coordinate.GetInstance(0, 4), chessPieceFactory.GetPiece((int)ChessPieceType.King, PieceColor.Black));
        }

        public override void Move(Move move)
        {
            if (!ContainsKey(move.SourceCoordinate) || move.DestinationCoordinate == null)
            {
                return;
            }

            APiece piece = this[move.SourceCoordinate];
            Remove(move.SourceCoordinate);

            if (ContainsKey(move.DestinationCoordinate))
            {
                Remove(move.DestinationCoordinate);
            }

            Add(move.DestinationCoordinate, piece);
        }

        public override ALayout Clone()
        {
            ALayout clone = new ChessLayout();

            foreach(var coordinate in this.Keys) 
            {
                clone.Add(coordinate, this[coordinate]);
            }
            
            return clone;
        }
    }
}
