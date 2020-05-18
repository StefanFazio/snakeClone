using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClone
{
    [Serializable]
    public class HighscoreEntry : IComparable<HighscoreEntry>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public HighscoreEntry(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public int CompareTo(HighscoreEntry entry)
        {
            if (entry == null) return 1;

            if (entry.Points > this.Points)
                return 1;
            else if (entry.Points < this.Points)
                return -1;
            else
                return 0;
        }
    }
    
}
