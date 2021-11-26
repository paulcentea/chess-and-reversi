using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class Move
    {
        public Coordinate SourceCoordinate { get; set; }
        public Coordinate DestinationCoordinate{ get; set; }

        public Move(Coordinate sourceCoordinate, Coordinate destinationCoordinate)
        {
            SourceCoordinate = sourceCoordinate;
            DestinationCoordinate = destinationCoordinate;
        }
    }
}
