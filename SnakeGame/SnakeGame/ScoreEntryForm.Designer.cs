namespace SnakeGame
{
    partial class ScoreEntryForm
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
            this.PseudoEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Valider = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PseudoEntry
            // 
            this.PseudoEntry.Location = new System.Drawing.Point(15, 82);
            this.PseudoEntry.Name = "PseudoEntry";
            this.PseudoEntry.Size = new System.Drawing.Size(142, 20);
            this.PseudoEntry.TabIndex = 0;
            this.PseudoEntry.TextChanged += new System.EventHandler(this.PseudoEntry_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Veuillez rentrer votre Pseudo : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bravo votre Score est de :";
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(178, 81);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(71, 21);
            this.Valider.TabIndex = 3;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(191, 21);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(25, 13);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "356";
            // 
            // ScoreEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 114);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PseudoEntry);
            this.Name = "ScoreEntryForm";
            this.Text = "ScoreEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PseudoEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Label labelScore;
    }
}