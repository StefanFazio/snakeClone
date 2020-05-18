using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeClone
{
    [Serializable]
    public class Highscore
    {
        private List<HighscoreEntry> highscoreEntries = new List<HighscoreEntry>();
        private string filename;
        private BinaryFormatter formatter = new BinaryFormatter();

        public Highscore()
        {
            filename = AppDomain.CurrentDomain.BaseDirectory + "highscore.hs";

            if (File.Exists(filename))
            {
                LoadHighscore();
            }
            else
            {
                CreateDefaultHighscoreList();
                SaveHighscore();
            }

        }

        private void SaveHighscore()
        {
            using(var stream = File.OpenWrite(filename))
            {
                formatter.Serialize(stream, highscoreEntries);
            }
        }

        private void LoadHighscore()
        {
            using (var stream = File.OpenRead(filename))
            {
                highscoreEntries = (List<HighscoreEntry>)formatter.Deserialize(stream);
            }
        }


        private void CreateDefaultHighscoreList()
        {
            var maxEntriesCount = 10;

            for (int index = 0; index < maxEntriesCount; index++)
            {
                highscoreEntries.Add(DefaultEntry(50 + index * 20));
            }

            highscoreEntries.Sort();
        }

        private HighscoreEntry DefaultEntry(int defaultPoints)
        {
            return new HighscoreEntry("Mr. Default", defaultPoints);
        }

        public List<HighscoreEntry> GetHighscoreList()
        {
            return highscoreEntries;
        }

        public bool ReachedMinimumPoints(int points)
        {
            return points > highscoreEntries[highscoreEntries.Count - 1].Points;
        }

        public void AddNewEntry(HighscoreEntry entry)
        {
            highscoreEntries.Remove(highscoreEntries[highscoreEntries.Count - 1]);
            highscoreEntries.Add(entry);
            highscoreEntries.Sort();
            SaveHighscore();
        }

        public void ShowNewEntryDialog(int points)
        {
            var newEntryWindow = new NewHighscoreWindow();
            newEntryWindow.ShowDialog();
            if(newEntryWindow.DialogResult == true)
            {
                string name = newEntryWindow.GetName();
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                AddNewEntry(new HighscoreEntry(name, points));
            }
        }
    }
}
