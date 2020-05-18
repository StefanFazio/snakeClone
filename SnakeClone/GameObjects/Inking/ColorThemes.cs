using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeClone
{
    public class ColorThemes
    {
        public static ColorTheme SnakeHead { get; private set; }
        public static ColorTheme SnakeBody { get; private set; }
        public static ColorTheme Apple { get; private set; }
        public static ColorTheme PinkApple { get; private set; }
        public static ColorTheme Obstacles { get; private set; }

        static ColorThemes()
        {
            var defaultBorderColor = Colors.White;

            SnakeHead = new ColorTheme(Colors.Red, defaultBorderColor);
            SnakeBody = new ColorTheme(Colors.Black, defaultBorderColor);
            Apple = new ColorTheme(Colors.Green, defaultBorderColor);
            PinkApple = new ColorTheme(Colors.Purple, defaultBorderColor);
            Obstacles = new ColorTheme(Colors.Red);
        }
    }
}
