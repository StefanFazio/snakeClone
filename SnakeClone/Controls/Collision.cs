using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeClone
{
    public class Collision
    {
        private Snake snake;
        private Apple apple;
        private PinkApple pinkApple;
        private Vector playgroundDimensions;

        public Collision(Snake snake, Apple apple, PinkApple pinkApple, Vector playgroundDimensions)
        {
            this.snake = snake;
            this.apple = apple;
            this.pinkApple = pinkApple;
            this.playgroundDimensions = playgroundDimensions;
        }

        public CollisionTyp CheckCollision(Vector toCheck)
        {
            if (CollideWithBodyElement(toCheck) || CollideWithBorder(toCheck))
                return CollisionTyp.Obstacle;

            else if (CollideWithApple(toCheck))
                return CollisionTyp.Apple;

            else if (CollideWithPinkApple(toCheck))
                return CollisionTyp.PinkApple;

            else
                return CollisionTyp.Nothing;
        }

        /// <summary>
        /// Check if the Snakehead collide with some other Gameobjects
        /// </summary>
        /// <returns>The type of the collided object or type Nothing</returns>
        public CollisionTyp CheckCollision()
        {
            return CheckCollision(snake[0].GetCurrentPosition());
        }

        private bool CollideWithBodyElement(Vector vectorToCheck)
        {
            if (snake == null) return false;

            for (int element = 1; element < snake.Count; element++)
            {
                var vectorBodyElement = snake[element].GetCurrentPosition();
                if(vectorToCheck.X == vectorBodyElement.X && vectorToCheck.Y == vectorBodyElement.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CollideWithBorder(Vector vectorToCheck)
        {
            if (CheckLeftSide(vectorToCheck.X))
                return true;
            else if (CheckRightSide(vectorToCheck.X))
                return true;
            else if (CheckTopSide(vectorToCheck.Y))
                return true;
            else if (CheckBottomSide(vectorToCheck.Y))
                return true;
            else
                return false;
        }

        private bool CheckLeftSide(double XPos)
        {
            return XPos < GameControl.Measure;
        }

        private bool CheckRightSide(double XPos)
        {
            return XPos > (playgroundDimensions.X - 2) * GameControl.Measure;
        }

        private bool CheckTopSide(double YPos)
        {
            return YPos < GameControl.Measure;
        }

        private bool CheckBottomSide(double YPos)
        {
            return YPos > (playgroundDimensions.Y -2) * GameControl.Measure;
        }

        private bool CollideWithApple(Vector vectorToCheck)
        {
            if (apple == null) return false;

            var applePos = apple.GetCurrentPosition();
            return (applePos.X == vectorToCheck.X && applePos.Y == vectorToCheck.Y);
        }

        private bool CollideWithPinkApple(Vector vectorToCheck)
        {
            if(pinkApple == null) return false;

            var pinkApplePos = pinkApple.GetCurrentPosition();
            return (pinkApplePos.X == vectorToCheck.X && pinkApplePos.Y == vectorToCheck.Y);
        }
    }
}
