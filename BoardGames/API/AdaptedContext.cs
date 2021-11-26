using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class AdaptedContext
    {
        public List<KeyValuePair<AdaptedCoordinate, AdaptedAPiece>> AdaptedLayout;
        public List<AdaptedCoordinate> AdaptedCoordinate;
        public List<AdaptedMove> AdaptedMoves;
        public AdaptedAPiece AdaptedAPiece;
        public PieceColor CurrentColor;

        public AdaptedContext()
        {

        }
    }
}
