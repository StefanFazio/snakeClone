using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeClone
{
    public class PinkApple: Apple
    {
        private Vector offScreen;

        public PinkApple(ColorTheme colorTheme)
            :base(colorTheme)
        {
            offScreen = new Vector(-1, -1) * GameControl.Measure;
        }

        public void HideApple()
        {
            currentPosition = offScreen;
            SetPositionOnCanvas(currentPosition);
        }
    }
}
