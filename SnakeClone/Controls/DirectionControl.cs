using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClone
{

    public class DirectionControl
    {
        private static Turn nextTurn;
        private static Directions currentDirection;

        public static void SetTurn(Turn turn)
        {
            nextTurn = turn;
        }

        public static Directions GetDirection()
        {
            var countOfDirections = Enum.GetNames(typeof(Directions)).Length;
            int directionValue;

            switch (nextTurn)
            {
                case Turn.None:
                    directionValue = (int)currentDirection;
                    break;

                case Turn.Clockwise:
                    directionValue = (int)(currentDirection + 1) % countOfDirections;
                    break;

                case Turn.Conterclockwise:
                    directionValue = (int)(currentDirection - 1) % countOfDirections;
                    break;

                default:
                    throw new ArgumentException(string.Format("{0} is not defined!", nextTurn));
            }

            if (directionValue < 0)
                directionValue += countOfDirections;

            currentDirection = (Directions)directionValue;
            return currentDirection;
        }

        public static void ResetTurn()
        {
            nextTurn = Turn.None;
        }

        public static void ResetDirection()
        {
            currentDirection = Directions.Up;
        }
    }
}
