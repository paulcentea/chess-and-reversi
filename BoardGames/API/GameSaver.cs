using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace BoardGames.API
{
    public class GameSaver
    {
        private AdaptedContext FillAdaptedContext(Context obtainedContext)
        {
            AdaptedContext adaptedContext = new AdaptedContext();
            adaptedContext.AdaptedLayout = new List<KeyValuePair<AdaptedCoordinate, AdaptedAPiece>>();
            adaptedContext.AdaptedMoves = new List<AdaptedMove>();
            adaptedContext.AdaptedCoordinate = new List<AdaptedCoordinate>();

            if (obtainedContext != null && obtainedContext.Layout != null)
            {
                foreach(var piece in obtainedContext.Layout)
                {
                    adaptedContext.AdaptedCoordinate.Add(new AdaptedCoordinate(piece.Key.Row, piece.Key.Column));
                    adaptedContext.AdaptedAPiece = new AdaptedAPiece(piece.Value.Color, piece.Value.Type);
                    adaptedContext.AdaptedLayout.Add(new KeyValuePair<AdaptedCoordinate, AdaptedAPiece>(new AdaptedCoordinate(piece.Key.Row, piece.Key.Column), new AdaptedAPiece(piece.Value.Color, piece.Value.Type)));
                }
            }

            if(obtainedContext != null && obtainedContext.HistoryMoves != null)
            {
                foreach(var move in obtainedContext.HistoryMoves)
                {
                    var adaptedMove = new AdaptedMove(new AdaptedCoordinate(move.SourceCoordinate.Row, move.SourceCoordinate.Column), new AdaptedCoordinate(move.DestinationCoordinate.Row, move.DestinationCoordinate.Column));
                    adaptedContext.AdaptedMoves.Add(adaptedMove);
                }
            }

            adaptedContext.CurrentColor = obtainedContext.CurrentColor;

            return adaptedContext;
        }

        public void Save(Context currentContex, string fileName)
        {
            var adaptedContext = FillAdaptedContext(currentContex);

            string serializedContext = JsonConvert.SerializeObject(adaptedContext, Formatting.Indented);
            StreamWriter streamWriter = new StreamWriter(fileName);
            streamWriter.Write(serializedContext);
            streamWriter.Flush();
        }
    }
}
