using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class Context
    {
        public ALayout Layout { get; set; }
        public PieceColor CurrentColor { get; set; }
        public List<Move> HistoryMoves { get; set; }

        public Context()
        {

        }

        public Context(ALayout layout, List<Move> historyMoves)
        {
            Layout = layout;
            HistoryMoves = historyMoves;
        }

        public Context Clone()
        {
            Context clone = new Context();

            if(HistoryMoves != null)
            {
                clone.HistoryMoves = new List<Move>();
                foreach(var move in HistoryMoves)
                {
                    clone.HistoryMoves.Add(new Move(move.SourceCoordinate, move.DestinationCoordinate));
                }
            }
            
            clone.Layout = Layout.Clone();
            clone.CurrentColor = this.CurrentColor;
            return clone;
        }
    }
}
