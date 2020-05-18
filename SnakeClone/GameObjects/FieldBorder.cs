using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SnakeClone
{
    public class FieldBorder
    {
        private List<Rectangle> borderElements;

        public FieldBorder(IRenderer renderer, int xDimension, int yDimension)
        {
            borderElements = new List<Rectangle>();
            CreateHorizontalBorders(xDimension);
            CreateVerticalBorder(yDimension);
            InkingBorderElements();
            SetPositionOnCanvas(xDimension, yDimension);
            RenderBorder(renderer);
        }

        private void CreateHorizontalBorders(int xDimension)
        {
            for (int horizontalBars = 0; horizontalBars < 2; horizontalBars++)
            {
                var rectangle = new Rectangle();
                rectangle.Width = xDimension * GameControl.Measure;
                rectangle.Height = GameControl.Measure;

                borderElements.Add(rectangle);
            }
        }

        private void CreateVerticalBorder(int yDimension)
        {
            for(int verticalBars = 0; verticalBars < 2; verticalBars++)
            {
                var rectangle = new Rectangle();
                rectangle.Width = GameControl.Measure;
                rectangle.Height = yDimension * GameControl.Measure;

                borderElements.Add(rectangle);
            }
        }

        private void InkingBorderElements()
        {
            foreach (var element in borderElements)
            {
                element.Fill = ColorThemes.Obstacles.FillColor;
                element.Stroke = ColorThemes.Obstacles.BorderColor;
            }
        }

        private void SetPositionOnCanvas(int xDimension, int yDimension)
        {
            // top horizontal bar
            Canvas.SetTop(borderElements[0], 0);
            Canvas.SetLeft(borderElements[0], 0);

            // bottom horizontal bar
            Canvas.SetTop(borderElements[1], (yDimension - 1) * GameControl.Measure);
            Canvas.SetLeft(borderElements[1], 0);

            // left vertical bar
            Canvas.SetTop(borderElements[2], 0);
            Canvas.SetLeft(borderElements[2], 0);

            // right vertical bar
            Canvas.SetTop(borderElements[3], 0);
            Canvas.SetLeft(borderElements[3], (xDimension - 1) * GameControl.Measure);
        }

        private void RenderBorder(IRenderer renderer)
        {
            foreach (var element in borderElements)
            {
                renderer.RenderObject(element);
            }
        }
    }
}
