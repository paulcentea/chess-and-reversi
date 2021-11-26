using BoardGames.API;
using BoardGames.Chess;
using BoardGames.Reversi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BoardGames
{
    public partial class GameForm : Form
    {
        public Game Game { get; set; }
        private Board Board { get; set; }
        private string GameType { get; set; }

        public GameForm()
        {
            InitializeComponent();
        }

        public void InitializeGame()
        {
            Game?.Cleanup();
            Board = new Board();
            Game = DependencyContainer.Container.Resolve<Game>();
            Game.Initialize(Board);

            Board.Reshape(this.ClientSize.Width, this.ClientSize.Height, menuStrip1.Height);
            this.Controls.Add(Board);
        }

        public void InitializeChessContainer()
        {
            DependencyContainer.Container.RegisterType<Game, ChessGame>();
            DependencyContainer.Container.RegisterType<ALayout, ChessLayout>();
            DependencyContainer.Container.RegisterType<IPieceFactory, ChessPieceFactory>();
            DependencyContainer.Container.RegisterType<ITurnChanger, ChessTurnChanger>();
        }

        public void InitializeReversiContainer()
        {
            DependencyContainer.Container.RegisterType<Game, ReversiGame>();
            DependencyContainer.Container.RegisterType<ALayout, ReversiLayout>();
            DependencyContainer.Container.RegisterType<IPieceFactory, ReversiPieceFactory>();
            DependencyContainer.Container.RegisterType<ITurnChanger, ReversiTurnChanger>();
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            try
            {
                Board?.Reshape(this.ClientSize.Width, this.ClientSize.Height, menuStrip1.Height);
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        private void Play_Chess_Click(object sender, EventArgs e)
        {
            try
            {
                GameType = "chess";

                InitializeChessContainer();
                InitializeGame();

                Game.Start();
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                MessageBox.Show("Chess Game couldn't start. We will solve the exception as soon as possible.");
            }
        }

        private void Play_Reversi_Click(object sender, EventArgs e)
        {
            try
            {
                GameType = "reversi";

                InitializeReversiContainer();
                InitializeGame();

                Game.Start();
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                MessageBox.Show("Reversi Game couldn't start. We will solve the exception as soon as possible.");
            }
        }

        public void Cleanup()
        {
            this.Controls.Remove(Board);
            Board = null;
            Game?.Cleanup();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Game != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.InitialDirectory = ConfigurationManager.AppSettings["DefaultDirectoryPath"];
                    saveFileDialog.Filter = "json files (* ." + GameType + ")|*." + GameType;
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Game.Save(saveFileDialog.FileName);
                        MessageBox.Show("Saved!");
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                MessageBox.Show("Context couldn't be saved!");
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.InitialDirectory = ConfigurationManager.AppSettings["DefaultDirectoryPath"];
                openFileDialog.Filter = "json files (* .chess; * .reversi)|*.chess; *.reversi";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Game == null)
                    {
                        if (openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf(".") + 1) == "chess")
                        {
                            GameType = "chess";
                            InitializeChessContainer();
                        }
                        else if (openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf(".") + 1) == "reversi")
                        {
                            GameType = "reversi";
                            InitializeReversiContainer();
                        }

                        InitializeGame();
                    }

                    Game.Load(openFileDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                MessageBox.Show("Context couldn't be loaded!");
            }
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.InitialDirectory = ConfigurationManager.AppSettings["DefaultDirectoryPath"];
                openFileDialog.Filter = "json files (* .chess; * .reversi)|*.chess; *.reversi";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Game == null)
                    {
                        if (openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf(".") + 1) == "chess")
                        {
                            GameType = "chess";
                            InitializeChessContainer();
                        }
                        else if (openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf(".") + 1) == "reversi")
                        {
                            GameType = "reversi";
                            InitializeReversiContainer();
                        }

                        InitializeGame();
                    }
                    Game.Replay(openFileDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                MessageBox.Show("Context couldn't be replayed!");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }
    }
}
