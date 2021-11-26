using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Reversi
{
    public class ReversiPieceFactory : IPieceFactory
    {
        public APiece GetPiece(int type, PieceColor color)
        {
            APiece aPiece = null;

            switch (type)
            {
                case (int)ReversiPieceType.Disk:
                    aPiece = new Disk(color);
                    break;
                default:
                    throw new Exception("Unsupported piece type!");
            }
            return aPiece;
        }
    }
}
