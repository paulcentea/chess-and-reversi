using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class AdaptedCoordinate
    {
        public int Row;
        public int Column;

        public AdaptedCoordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
