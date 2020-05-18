using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeClone
{
    public enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }

    public static class DirectionExtensions
    {
        public static Vector Offset(this Directions direction)
        {
            var offset = new Vector(0,0);

            switch (direction)
            {
                case Directions.Left:
                    offset.X = -GameControl.Measure;
                    break;
                case Directions.Up:
                    offset.Y = -GameControl.Measure;
                    break;
                case Directions.Right:
                    offset.X = GameControl.Measure;
                    break;
                case Directions.Down:
                    offset.Y = GameControl.Measure;
                    break;
                default:
                    throw new Exception(string.Format("The Direction {0} has no offset value!", direction));
            }

            return offset;
        }
    }
}
