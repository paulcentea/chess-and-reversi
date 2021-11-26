using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Unity;

namespace BoardGames.API
{
    public class GameLoader
    {
        private Context FillAdaptedContext(AdaptedContext adaptedContext)
        {
            Context context = new Context
            {
                Layout = DependencyContainer.Container.Resolve<ALayout>(),
                HistoryMoves = new List<Move>()
            };

            if (adaptedContext != null && adaptedContext.AdaptedLayout != null)
            {
                foreach(var piece in adaptedContext.AdaptedLayout)
                {
                    context.Layout.Add(Coordinate.GetInstance(piece.Key.Row, piece.Key.Column), DependencyContainer.Container.Resolve<IPieceFactory>().GetPiece(piece.Value.Type, piece.Value.Color));
                }
                context.CurrentColor = adaptedContext.CurrentColor;
            }

            if(adaptedContext != null && adaptedContext.AdaptedMoves != null)
            {
                foreach(var move in adaptedContext.AdaptedMoves)
                {
                    var adaptedMove = new Move(Coordinate.GetInstance(move.SourceCoordinate.Row, move.SourceCoordinate.Column), Coordinate.GetInstance(move.DestinationCoordinate.Row, move.DestinationCoordinate.Column));
                    context.HistoryMoves.Add(adaptedMove);
                }
            }

            return context;
        }

        public Context Load(string fileName)
        {
            AdaptedContext adaptedContext = JsonConvert.DeserializeObject<AdaptedContext>(File.ReadAllText(fileName));

            Context context = FillAdaptedContext(adaptedContext);

            return context;
        }
    }
}
