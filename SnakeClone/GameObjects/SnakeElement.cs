using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeClone
{
    public class SnakeElement : GameObject
    {
        private Vector formerPosition;

        public SnakeElement(Vector spawnPosition, ColorTheme colorTheme)
            :base(colorTheme)
        {
            SetPositionOnCanvas(spawnPosition);
        }

        protected override void CreateShape()
        {
            shape = new Rectangle();
        }

        public override void SetPositionOnCanvas(Vector newPosition)
        {
            SetNewAndSaveFormerPosition(newPosition);
            base.SetPositionOnCanvas(newPosition);
        }

        private void SetNewAndSaveFormerPosition(Vector newPosition)
        {
            formerPosition = currentPosition;
            currentPosition = newPosition;
        }

        public Vector GetFormerPosition()
        {
            return formerPosition;
        }
    }
}
