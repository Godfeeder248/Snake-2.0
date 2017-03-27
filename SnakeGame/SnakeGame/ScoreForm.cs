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
    public partial class ScoreForm : Form
    {
        #region Constants

        public const string SCORE_FILENAME = @"..\..\..\data\scores.xml";

        #endregion Constants

        public ScoreForm()
        {
            InitializeComponent();
        }

        private void ScoreForm_Load(object sender, EventArgs e)
        {
            // Load data from default file
            this.LoadData(SCORE_FILENAME);
        }

        private void LoadData(String Filename)
        {
            // Load data
            Score.LoadData(Filename);

            // Update the display
            this.ViewUpdate();
        }
        
        private void SaveData(String Filename)
        {
            Score.SaveData(Filename);

            // Update the display
            this.ViewUpdate();

        }

        private void NewScoreEvent(Score score)
        {    

            Score.RegisterScore(score);
            this.ViewUpdate();
        }


        public void ViewUpdate()
        {
            // Clear display
            this.listViewScore.Items.Clear();
       
            // Reload data display
            foreach (Score score in Score.Scores)
            {
                this.listViewScore.Items.Add(
                    new ListViewItem(new String[] {
                        score.Pseudo,
                        score.PointScore.ToString() }));
            }
        }
    }
}
