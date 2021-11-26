using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BoardGames.API
{
    public class Referee
    {
        private Context Context { get; set; }

        public delegate void ContextChangedEventHandler(object sender, ContextChangedEventArgs e);
        public event ContextChangedEventHandler ContextChanged;

        public Referee()
        {

        }

        public void Initialize()
        {
            Context = new Context(DependencyContainer.Container.Resolve<ALayout>(), new List<Move>());
            Context.Layout.Initialize();
        }

        public void Cleanup()
        {
            if (Context != null && Context.Layout != null)
            {
                Context.Layout.Cleanup();
                Context.Layout = null;
            }

            Context = null;
        }

        public void Start(PieceColor color)
        {
            Context.CurrentColor = color;
            ContextChanged?.Invoke(this, new ContextChangedEventArgs(Context.Clone()));
        }

        public void StartWith(Context context)
        {
            Context = context.Clone();
            ContextChanged?.Invoke(this, new ContextChangedEventArgs(Context.Clone()));
        }

        public void OnMoveProposed(object sender, MoveEventArgs e)
        {
            try
            {
                if (IsValid(e.Move))
                {
                    Context.Layout.Move(e.Move);

                    Context.HistoryMoves.Add(e.Move);

                    Console.WriteLine(e.Move.SourceCoordinate + " " + e.Move.DestinationCoordinate);

                    Context.CurrentColor = DependencyContainer.Container.Resolve<ITurnChanger>().ChangeTurn(Context.CurrentColor, Context);
                }
                ContextChanged?.Invoke(this, new ContextChangedEventArgs(Context.Clone()));
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        private bool IsValid(Move move)
        {
            return Context != null && Context.Layout != null && move != null && Context.Layout.ContainsKey(move.SourceCoordinate) && Context.Layout[move.SourceCoordinate].GetAvailableMoves(move.SourceCoordinate, Context).Contains(move.DestinationCoordinate);
        }

        public Context GetContext()
        {
            return Context.Clone();
        }
    }
}
