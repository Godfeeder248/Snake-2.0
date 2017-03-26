namespace SnakeGame
{
    partial class ScoreForm
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
            this.listViewScore = new System.Windows.Forms.ListView();
            this.columnHeaderPseudo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewScore
            // 
            this.listViewScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPseudo,
            this.columnHeaderScore});
            this.listViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewScore.Location = new System.Drawing.Point(0, 0);
            this.listViewScore.Name = "listViewScore";
            this.listViewScore.Size = new System.Drawing.Size(212, 257);
            this.listViewScore.TabIndex = 0;
            this.listViewScore.UseCompatibleStateImageBehavior = false;
            this.listViewScore.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPseudo
            // 
            this.columnHeaderPseudo.Text = "Pseudo";
            // 
            // columnHeaderScore
            // 
            this.columnHeaderScore.Text = "Score";
            // 
            // ScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 257);
            this.Controls.Add(this.listViewScore);
            this.Name = "ScoreForm";
            this.Text = "ScoreForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewScore;
        private System.Windows.Forms.ColumnHeader columnHeaderPseudo;
        private System.Windows.Forms.ColumnHeader columnHeaderScore;
    }
}