using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class AdaptedMove
    {
        public AdaptedCoordinate SourceCoordinate;
        public AdaptedCoordinate DestinationCoordinate;

        public AdaptedMove(AdaptedCoordinate sourceCoordinate, AdaptedCoordinate destinationCoordinate)
        {
            SourceCoordinate = sourceCoordinate;
            DestinationCoordinate = destinationCoordinate;
        }
    }
}
