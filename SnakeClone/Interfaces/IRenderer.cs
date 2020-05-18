using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SnakeClone
{
    public interface IRenderer
    {
        void RenderObject(object objectToRender);
        void ClearScreen();
    }

    
}
