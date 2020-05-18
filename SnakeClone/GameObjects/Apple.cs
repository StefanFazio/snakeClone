using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace SnakeClone
{
    public class Apple : GameObject
    {
        private Collision collision;

        public Apple(ColorTheme colorTheme)
            :base (colorTheme)
        {

        }

        public void SetCollision(Collision collision)
        {
            this.collision = collision;
        }

        protected override void CreateShape()
        {
            shape = new Ellipse();
        }
        
        public void ReplaceApple()
        {
            currentPosition = GetFreeSpawnPosition();
            base.SetPositionOnCanvas(currentPosition);
        }

        private Vector GetFreeSpawnPosition()
        {
            var random = new Random();
            Vector spawnPosition;
            do
            {
                var xPos = random.Next(1, 38);
                var yPos = random.Next(1, 28);
                spawnPosition = new Vector(xPos, yPos) * GameControl.Measure;

            } while (collision.CheckCollision(spawnPosition) != CollisionTyp.Nothing);

            return spawnPosition;
        }
    }
}
