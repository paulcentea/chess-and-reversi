using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoardGames.API
{
    public abstract class Game
    {
        public IBoard Board { get; private set; }
        protected Referee Referee { get; set; }
        private MovePlayer MovePlayer { get; set; }

        public Game()
        {

        }

        public void Initialize(IBoard board)
        {
            Board = board;
            Board.Initialize();
            Referee = new Referee();
            Referee.Initialize();

            Referee.ContextChanged += Board.OnContextChanged;
            Board.MoveProposed += Referee.OnMoveProposed;
        }

        public abstract void Start();
        //{
        //    Referee?.Start();
        //}

        public void Save(string fileName)
        {
            GameSaver gameSaver = new GameSaver();
            gameSaver.Save(Referee.GetContext(), fileName);
        }

        public void Load(string fileName)
        {
            GameLoader gameLoader = new GameLoader();
            Context deserializedContex = gameLoader.Load(fileName);
            Referee.StartWith(deserializedContex);
        }

        public void Replay(string fileName)
        {
            GameLoader gameLoader = new GameLoader();
            Context deserializedContex = gameLoader.Load(fileName);
            MovePlayer = new MovePlayer(deserializedContex.HistoryMoves);
            MovePlayer.Initialize(Board, Referee);

            Board.SupressMouseInteractions();

            MovePlayer.ReplayMoves();
        } 

        public void Cleanup()
        {
            MovePlayer?.Cleanup();
            MovePlayer = null;
            Board.MoveProposed -= Referee.OnMoveProposed;
            Referee.ContextChanged -= Board.OnContextChanged;
            Referee.Cleanup();
            Referee = null;
            Board.Cleanup();
            Board = null;
        }
    }
}
