using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScoreLibrary;
using System.Diagnostics;

namespace SnakeGame
{
    public partial class ScoreEntryForm : Form
    {
        #region Properties

        public Score CreatedScore { get; private set; }

        #endregion Properties

        #region Custom events

        #endregion Custom events

        #region Constructor(s)

        public ScoreEntryForm()
        {
            InitializeComponent();
            this.Valider.Enabled = false;
        }

        public ScoreEntryForm(int score)
        {
            InitializeComponent();
            if (labelScore != null)
                labelScore.Text = score.ToString();
        }

        #endregion Constructor(s)

        #region Event management

        private void Valider_Click(object sender, EventArgs e)
        {
           
            try
            {
                CreatedScore =  new Score(PseudoEntry.Text, Int32.Parse(labelScore.Text));

                Score.LoadData(ScoreForm.SCORE_FILENAME);
                Score.RegisterScore(CreatedScore);

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creating the new score");
                Debug.WriteLine(ex.ToString());
            }

            Score.SaveData(ScoreForm.SCORE_FILENAME);
            
            this.Close();

        }

        #endregion Event management

        private void PseudoEntry_TextChanged(object sender, EventArgs e)
        {
            this.Valider.Enabled = (this.PseudoEntry.Text !="");
        }
    }
}
