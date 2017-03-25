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
        private void InitializeComponent()
        {
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonScores = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.Snake_window = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Snake_window)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(63, 388);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(80, 32);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // 
            // buttonScores
            // 
            this.buttonScores.Location = new System.Drawing.Point(264, 388);
            this.buttonScores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(68, 32);
            this.buttonScores.TabIndex = 1;
            this.buttonScores.Text = "Scores";
            this.buttonScores.UseVisualStyleBackColor = true;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(456, 388);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(66, 32);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // Snake_window
            // 
            this.Snake_window.Location = new System.Drawing.Point(13, 13);
            this.Snake_window.Name = "Snake_window";
            this.Snake_window.Size = new System.Drawing.Size(449, 359);
            this.Snake_window.TabIndex = 3;
            this.Snake_window.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 431);
            this.Controls.Add(this.Snake_window);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonScores);
            this.Controls.Add(this.buttonNewGame);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GameWindow";
            this.Text = "Snake Game";
            ((System.ComponentModel.ISupportInitialize)(this.Snake_window)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonScores;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.PictureBox Snake_window;
    }
}