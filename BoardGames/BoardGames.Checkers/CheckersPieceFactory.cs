using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class CheckersPieceFactory : IPieceFactory
    {
        public APiece GetPiece(int type, PieceColor color)
        {
            APiece aPiece = null;

            switch (type)
            {
                case (int)CheckersPieceType.Man:
                    aPiece = new Man(color);
                    break;
                case (int)CheckersPieceType.DoubleMan:
                    aPiece = new DoubleMan(color);
                    break;
                default:
                    throw new Exception("Unsupported piece type!");
            }
            return aPiece;
        }
    }
}
