using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using Unity;

namespace BoardGames.API
{
    public abstract class APiece
    {
        public PieceColor Color { get; set; }

        public int Type { get; private set; }

        protected static Dictionary<PieceColor, Dictionary<int, Bitmap>> AllPieceImages { get; set; }

        public APiece(int type, PieceColor color)
        {
            Color = color;
            Type = type;
        }

        public abstract Bitmap GetImage();

        public abstract List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, Context context);

        protected abstract List<Coordinate> ConsiderMoveInLine(Coordinate sourceCoordinate, int directionRow, int directionColumn, Context context);
    }
}
