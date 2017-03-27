namespace SnakeGame
{
    partial class GameWindow
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
        private void InitializeComponent(string mode)
        {
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonScores = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(795, 45);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(107, 39);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // 
            // buttonScores
            // 
            this.buttonScores.Location = new System.Drawing.Point(795, 152);
            this.buttonScores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(107, 39);
            this.buttonScores.TabIndex = 1;
            this.buttonScores.Text = "Scores";
            this.buttonScores.UseVisualStyleBackColor = true;
            this.buttonScores.Click += new System.EventHandler(this.buttonScores_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(795, 97);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(107, 39);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click_1);
            // 
            // panel1
            //
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "game";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.game_Paint);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 750);
            //this.Controls.Add(this.game);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonScores);
            this.Controls.Add(this.buttonNewGame);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameWindow";
            this.Text = "Snake Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonScores;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Panel panel1;
    }
}