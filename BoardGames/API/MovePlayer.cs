using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace BoardGames.API
{
    public class MovePlayer
    {
        public List<Move> MoveHistory { get; set; }
        private Referee Referee { get; set; }
        public IBoard Board { get; set; }
        private Context CurrentContext { get; set; }
        private BackgroundWorker Worker { get; set; }

        public MovePlayer()
        {
                
        }

        public void Initialize(IBoard board, Referee referee)
        {
            Board = board;
            Referee = referee;
            CurrentContext = new Context(DependencyContainer.Container.Resolve<ALayout>(), new List<Move>());
            CurrentContext.Layout.Initialize();
        }

        public MovePlayer(List<Move> moveHistory)
        {
            MoveHistory = moveHistory;
        }

        public void ReplayMoves()
        {
            if (Worker != null)
            {
                Cleanup();
            }

            if (MoveHistory != null)
            {
                Worker = new BackgroundWorker();
                Worker.DoWork += DoWork;
                Worker.ProgressChanged += ProgressChanged;
                Worker.RunWorkerCompleted += RunWorkerCompleted;
                Worker.WorkerReportsProgress = true;
                
                Board.SupressMouseInteractions();

                Worker.RunWorkerAsync();
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Worker.ReportProgress(0);
            int i = 0;

            foreach (var move in MoveHistory)
            {
                Thread.Sleep(1000);

                CurrentContext.Layout.Move(move);
                CurrentContext.HistoryMoves.Add(move);
                CurrentContext.CurrentColor = CurrentContext.CurrentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
                Worker.ReportProgress(i++);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Referee.StartWith(CurrentContext);
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Board.ResumeMouseInteractions();
            Cleanup();
        }

        public void Cleanup()
        {
            if(Worker != null)
            {
                if (Worker.IsBusy)
                {
                    Worker.WorkerSupportsCancellation = true;
                    Worker.CancelAsync();
                }

                Worker.ProgressChanged -= ProgressChanged;
                Worker.DoWork -= DoWork;
                Worker = null;
            }

            if(CurrentContext != null)
            {
                CurrentContext.Layout.Cleanup();
                CurrentContext.Layout = null;
                CurrentContext.HistoryMoves = null;
                CurrentContext = null;
            }
        }
    }
}
