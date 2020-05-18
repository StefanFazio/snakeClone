using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeClone
{
    public class ColorTheme
    {
        public SolidColorBrush FillColor { get; private set; }
        public SolidColorBrush BorderColor { get; private set; }

        /// <summary>
        /// For Shapes where border and fill color are different
        /// </summary>
        public ColorTheme(Color fillColor, Color borderColor)
        {
            CreateColorTheme(fillColor, borderColor);
        }

        /// <summary>
        /// For Shapes without a different border color
        /// </summary>
        public ColorTheme(Color fillColor)
        {
            CreateColorTheme(fillColor, fillColor);
        }

        private void CreateColorTheme(Color fillColor, Color borderColor)
        {
            FillColor = new SolidColorBrush(fillColor);
            BorderColor = new SolidColorBrush(borderColor);
        }
    }
}
