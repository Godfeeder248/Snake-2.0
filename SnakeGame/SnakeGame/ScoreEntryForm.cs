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

        public delegate void NewScoreEventHandler(Score NewScore);

        public event NewScoreEventHandler NewScoreEvent;

        #endregion Custom events

        #region Constructor(s)

        public ScoreEntryForm()
        {
            InitializeComponent();
            this.Valider.Enabled = false;
        }

        #endregion Constructor(s)

        #region Event management

        private void Valider_Click(object sender, EventArgs e)
        {
            try
            {
                this.CreatedScore =
                    new Score(this.PseudoEntry.Text, Int32.Parse(this.labelScore.Text));
                if (this.NewScoreEvent!= null)
                {
                    this.NewScoreEvent(this.CreatedScore);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creating the new score");
                Debug.WriteLine(ex.ToString());
            }
            

            this.Close();

        }

        #endregion Event management

        private void PseudoEntry_TextChanged(object sender, EventArgs e)
        {
            this.Valider.Enabled = (this.PseudoEntry.Text !="");
        }
    }
}
