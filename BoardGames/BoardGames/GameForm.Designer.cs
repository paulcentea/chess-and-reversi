
namespace BoardGames
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Play = new System.Windows.Forms.ToolStripMenuItem();
            this.Play_Chess = new System.Windows.Forms.ToolStripMenuItem();
            this.Play_Reversi = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.Replay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Play_Checkers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Play,
            this.Save,
            this.Load,
            this.Replay,
            this.toolStripSeparator1,
            this.Exit});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // Play
            // 
            this.Play.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Play_Chess,
            this.Play_Reversi,
            this.Play_Checkers});
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(180, 22);
            this.Play.Text = "Play";
            // 
            // Play_Chess
            // 
            this.Play_Chess.Name = "Play_Chess";
            this.Play_Chess.Size = new System.Drawing.Size(180, 22);
            this.Play_Chess.Text = "Chess";
            this.Play_Chess.Click += new System.EventHandler(this.Play_Chess_Click);
            // 
            // Play_Reversi
            // 
            this.Play_Reversi.Name = "Play_Reversi";
            this.Play_Reversi.Size = new System.Drawing.Size(180, 22);
            this.Play_Reversi.Text = "Reversi";
            this.Play_Reversi.Click += new System.EventHandler(this.Play_Reversi_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(180, 22);
            this.Save.Text = "&Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(180, 22);
            this.Load.Text = "&Load";
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Replay
            // 
            this.Replay.Name = "Replay";
            this.Replay.Size = new System.Drawing.Size(180, 22);
            this.Replay.Text = "&Replay";
            this.Replay.Click += new System.EventHandler(this.Replay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 22);
            this.Exit.Text = "E&xit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Play_Checkers
            // 
            this.Play_Checkers.Name = "Play_Checkers";
            this.Play_Checkers.Size = new System.Drawing.Size(180, 22);
            this.Play_Checkers.Text = "Checkers";
            this.Play_Checkers.Click += new System.EventHandler(this.Play_Checkers_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "BoardGames";
            this.Resize += new System.EventHandler(this.GameForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Play;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Load;
        private System.Windows.Forms.ToolStripMenuItem Replay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Play_Chess;
        private System.Windows.Forms.ToolStripMenuItem Play_Reversi;
        private System.Windows.Forms.ToolStripMenuItem Play_Checkers;
    }
}

