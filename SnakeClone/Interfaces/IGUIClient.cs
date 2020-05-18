using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClone
{
    public interface IGUIClient
    {
        void UpdatePoints(int points);
        void UpdateTime(string time);
        void ShowGameOver();
        void SetVisibilityOfResume(bool show);
    }
}
