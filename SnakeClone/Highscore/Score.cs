using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClone
{
    public class Score : Observable
    {
        private int points;
        public int Points
        {
            get
            {
                return points;
            }
            private set
            {
                points = value;
            }
        }

        public void AddPoints(int newPoints)
        {
            Points += newPoints;
            NotifyObservers();
        }

        public void ResetScore()
        {
            Points = 0;
        }
    }
}
