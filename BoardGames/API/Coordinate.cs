using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class Coordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        private static Dictionary<int, Dictionary<int, Coordinate>> Instances { get; set; }

        private Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static Coordinate GetInstance(int row, int column)
        {
            if (row < 0 || row > 7 || column < 0 || column > 7)
            {
                throw new Exception($"Invalid arguments Row: {row}, Column: {column}");
            }

            if (Instances == null)
            {
                Instances = new Dictionary<int, Dictionary<int, Coordinate>>();
            }

            if (!Instances.ContainsKey(row))
            {
                Instances.Add(row, new Dictionary<int, Coordinate>());
            }

            if (!Instances[row].ContainsKey(column))
            {
                Instances[row].Add(column, new Coordinate(row,column));
            }

            return Instances[row][column];
        }

        public override string ToString()
        {
            return $"{Row} {Column}";
        }
    }
}
