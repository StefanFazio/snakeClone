using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SnakeClone
{
    public class Snake : List<SnakeElement>
    {
        private IRenderer renderer;
        private SnakeElement snakeHead;

        public Snake(Vector startPosition, IRenderer renderer)
        {
            this.renderer = renderer;
            CreateHead(startPosition);
        }

        private void CreateHead(Vector startPosition)
        {
            snakeHead = new SnakeElement(startPosition, ColorThemes.SnakeHead);
            Canvas.SetZIndex(snakeHead.GetShape(), 1);
            this.Add(snakeHead);
            renderer.RenderObject(snakeHead.GetShape());
        }

        public void Move()
        {
            var newPosition = snakeHead.GetCurrentPosition() + DirectionControl.GetDirection().Offset();
            DirectionControl.ResetTurn();
            snakeHead.SetPositionOnCanvas(newPosition);

            for (int index = 1; index < this.Count; index++)
            {
                this[index].SetPositionOnCanvas(this[index - 1].GetFormerPosition());
            }
        }

        public void Grow()
        {
            var spawnPosition = this[this.Count - 1].GetFormerPosition();
            var snakeElement = new SnakeElement(spawnPosition, ColorThemes.SnakeBody);
            snakeElement.SetPositionOnCanvas(spawnPosition);
            renderer.RenderObject(snakeElement.GetShape());
            this.Add(snakeElement);
        }
    }
}
