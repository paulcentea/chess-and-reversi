using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    public class ChessPieceFactory : IPieceFactory
    {
        public APiece GetPiece(int type, PieceColor color)
        {
            APiece aPiece = null;

            switch (type)
            {
                case (int)ChessPieceType.Queen:
                    aPiece = new Queen(color);
                    break;
                case (int)ChessPieceType.King:
                    aPiece = new King(color);
                    break;
                case (int)ChessPieceType.Rook:
                    aPiece = new Rook(color);
                    break;
                case (int)ChessPieceType.Knight:
                    aPiece = new Knight(color);
                    break;
                case (int)ChessPieceType.Bishop:
                    aPiece = new Bishop(color);
                    break;
                case (int)ChessPieceType.Pawn:
                    aPiece = new Pawn(color);
                    break;
                default:
                    throw new Exception("Unsupported piece type!");
            }
            return aPiece; 
        }
    }
}
