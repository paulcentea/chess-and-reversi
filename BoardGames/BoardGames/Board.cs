using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGames
{
    public class Board : Panel, IBoard
    {
        private int CellSize { get; set; }
        private  Context CurrentContext { get; set; }
        private Coordinate CurrentCoordinate { get; set; }
        private Coordinate MoveSourceCoordinate { get; set; }

        private Pen RedPen = new Pen(Brushes.Red, 3);

        private Pen YellowPen = new Pen(Brushes.Yellow, 3);

        public delegate void MoveProposedEventHandler(object sender, MoveEventArgs e);
        public Action<object, MoveEventArgs> MoveProposed { get; set; }

        public Board()
        {

        }

        public void Initialize()
        {
            ResumeMouseInteractions();
            DoubleBuffered = true;
        }

        public void Cleanup()
        {
            CurrentContext = null;
        }

        public void SupressMouseInteractions()
        {
            MouseUp -= OnMouseUp;
            MouseDown -= OnMouseDown;
            MouseMove -= OnMouseMove;
        }

        public void ResumeMouseInteractions()
        {
            MouseUp += OnMouseUp;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }

        public void OnContextChanged(object sender, ContextChangedEventArgs e)
        {
            try
            {
                CurrentContext = e.Context.Clone();
                Refresh();
            }
            catch(Exception exception)
            {
                Logger.Log(exception);
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentCoordinate = Coordinate.GetInstance(e.Y / CellSize, e.X / CellSize);
                if (CurrentCoordinate != null && CurrentCoordinate.Row >= 0 && CurrentCoordinate.Row <= 7 && CurrentCoordinate.Column >= 0 && CurrentCoordinate.Column <= 7)
                {
                    if (CurrentContext != null && CurrentContext.Layout != null && CurrentContext.Layout.ContainsKey(CurrentCoordinate))
                    {
                        Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentCoordinate = Coordinate.GetInstance(e.Y / CellSize, e.X / CellSize);

                if (CurrentCoordinate.Row >= 0 && CurrentCoordinate.Row <= 7 && CurrentCoordinate.Column >= 0 && CurrentCoordinate.Column <= 7)
                {
                    if (MoveSourceCoordinate != null && MoveSourceCoordinate.Row >= 0 && MoveSourceCoordinate.Row <= 7 && MoveSourceCoordinate.Column >= 0 && MoveSourceCoordinate.Column <= 7)
                    {
                        Move move = new Move(MoveSourceCoordinate, CurrentCoordinate);

                        MoveProposed?.Invoke(this, new MoveEventArgs(move));
                    }
                }
                Cursor.Current = Cursors.Default;
                MoveSourceCoordinate = null;
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                MoveSourceCoordinate = Coordinate.GetInstance(e.Y / CellSize, e.X / CellSize);

                if (MoveSourceCoordinate.Row >= 0 && MoveSourceCoordinate.Row <= 7 && MoveSourceCoordinate.Column >= 0 && MoveSourceCoordinate.Column <= 7)
                {
                    Bitmap cursorBitmap = new Bitmap(CellSize, CellSize);

                    if (CurrentContext != null && CurrentContext.Layout.ContainsKey(MoveSourceCoordinate))
                    {
                        Graphics cursorGraphics = Graphics.FromImage(cursorBitmap);
                        cursorGraphics.DrawImage(CurrentContext.Layout[MoveSourceCoordinate].GetImage(), 0, 0, CellSize, CellSize);

                        Cursor.Current = new Cursor(cursorBitmap.GetHicon());

                        CurrentContext.Layout.Remove(MoveSourceCoordinate);
                        Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                DrawBoard(e.Graphics);
                DrawPieces(e.Graphics);
                HighlightCurrentPiece(e.Graphics);
                HighlightAvailableMoves(e.Graphics);
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
            }
        }

        private void DrawBoard(Graphics g) 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.FillRectangle((i + j) % 2 == 0 ? Brushes.LightYellow : Brushes.SaddleBrown, i * CellSize, j * CellSize, CellSize, CellSize);
                }
            }
        }

        private void DrawPieces(Graphics g)
        {
            if (CurrentContext != null && CurrentContext.Layout != null) 
            {
                foreach (Coordinate coordinate in CurrentContext.Layout.Keys)
                {
                    g.DrawImage(CurrentContext.Layout[coordinate].GetImage(), coordinate.Column * CellSize, coordinate.Row * CellSize, CellSize, CellSize);
                }
            }
        }

        private void HighlightCurrentPiece(Graphics g) 
        {
            if (CurrentContext != null && CurrentContext.Layout != null && CurrentCoordinate != null && CurrentContext.Layout.ContainsKey(CurrentCoordinate))
            {
                g.DrawRectangle(RedPen, CurrentCoordinate.Column * CellSize, CurrentCoordinate.Row * CellSize, CellSize, CellSize);
            }
        }

        private void HighlightAvailableMoves(Graphics g)
        {
            if (CurrentContext != null && CurrentContext.Layout != null && CurrentCoordinate != null && CurrentContext.Layout.ContainsKey(CurrentCoordinate) && CurrentContext.Layout[CurrentCoordinate].Color == CurrentContext.CurrentColor)
            {
                foreach (var availableMove in CurrentContext.Layout[CurrentCoordinate].GetAvailableMoves(CurrentCoordinate, CurrentContext))
                {
                    g.DrawRectangle(YellowPen, availableMove.Column * CellSize, availableMove.Row * CellSize, CellSize, CellSize);
                }
            }
        }

        public void Reshape(int width, int height, int menuHeight)
        {
            CellSize = Math.Min(height - menuHeight, width) / 8;

            SetBounds((width - CellSize * 8) / 2, (height - CellSize * 8 + menuHeight) / 2, CellSize * 8, CellSize * 8);

            Refresh();
        }
    }
}
