using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ScoreLibrary
{
    [Serializable]
    public class Score
    {
        #region Class context (static)

        #region Library internal context

        // Current students list
        //   ==> if no call to load data is made a static initialization 
        //       is required (avoid null testing)
        private static List<Score> score = new List<Score>();

        // For serialization (static initialization)
        private static XmlSerializer xs = new XmlSerializer(typeof(List<Score>));

        #endregion Library internal context

        #region XML management (serialization)

        // Deserialization of data from disk
        // An empty cotext is available if no data available
        public static void LoadData(String filename)
        {
            Debug.WriteLine("[LIBINFO] Reading file " + filename);

            // Forget about current data
            score = null;

            // Read from disk managing error in case the file is corrupted
            try
            {
                if (File.Exists(filename))
                {
                    using (XmlReader xr = XmlReader.Create(filename))
                    {
                        score = (List<Score>)xs.Deserialize(xr);
                        
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[LIBERROR] Error reading the file " + filename);
                Debug.WriteLine("           " + e.ToString());
            }
            finally
            {
                // if no data in the file
                if (score == null)
                {
                    score = new List<Score>();
                }
            }
        }

        // Serialization on disk
        public static void SaveData(String filename)
        {
            Debug.WriteLine("[LIBINFO] Writing file " + filename);

            // Store data on the disk managing error
            try
            {
                using (XmlWriter xw = XmlWriter.Create(filename))
                {
                    xs.Serialize(xw, score);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("[LIBERROR] Error writing the file " + filename);
                Debug.WriteLine("           " + e.ToString());
            }
        }

        public static void ResetData()
        {
            Debug.WriteLine("[LIBINFO] Reset data context");
            score = new List<Score>();
        }

        #endregion XML management (serialization)

        #region Dump management

        // Dump the current student list on debug window
        public static void DebugDump()
        {
            foreach (Score student in score)
            {
                Debug.WriteLine(score.ToString());
            }
        }

        #endregion Dump management

        #region Student registration 

        // Register a new student
        public static Score RegisterScore(Score NewScore)
        {
            score.Add(NewScore);
            return NewScore;
        }

        public static Score RegisterScore(String pseudo, int score)
        {
            return RegisterScore(new Score(pseudo, score));
        }

        #endregion Student registration

        #region Accessors

        // Warning: internal list is exposed there ... need some data protection in "real life"
        public static List<Score> Scores
        {
            get { return score; }
        }

        #endregion Accessors

        #endregion Class context (static)

        #region Instance context

        #region Properties

        public String Pseudo { get;  /*private*/ set; } // not private for serialization
        public Int32 PointScore{ get; /*private*/ set; } // not private for serialization

        #endregion Properties

        #region Constructor(s)

        // for serialization only
        public Score()
        {
            this.PointScore = 0;
            this.Pseudo = null;
        }

        public Score(String pseudo, int score)
        {
            this.PointScore = score;
            this.Pseudo = pseudo;
        }

        #endregion Constructor(s)

        public override string ToString()
        {
            return this.Pseudo + " : \t" + this.PointScore;
        }

        #endregion Instance context



    }
}
