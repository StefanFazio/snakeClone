using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SnakeClone
{
    public abstract class GameObject
    {
        protected Shape shape;
        protected Vector currentPosition;
        protected int shapeDimension;

        public GameObject(ColorTheme colorTheme)
        {
            shapeDimension = GameControl.Measure;
            CreateShape();
            SetDimension();
            InkingShape(colorTheme);
        }

        protected abstract void CreateShape();

        protected void SetDimension()
        {
            shape.Width = shapeDimension;
            shape.Height = shapeDimension;
        }

        protected void InkingShape(ColorTheme colorTheme)
        {
            shape.Fill = colorTheme.FillColor;
            shape.Stroke = colorTheme.BorderColor;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public Vector GetCurrentPosition()
        {
            return currentPosition;
        }

        public virtual void SetPositionOnCanvas(Vector newPosition)
        {
            Canvas.SetLeft(shape, newPosition.X);
            Canvas.SetTop(shape, newPosition.Y);
        }

    }
}
