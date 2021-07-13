using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OccultumEditor.CustomControls
{
    class EditorWindow : WinFormsGraphicsDevice.GraphicsDeviceControl
    {    
        protected override void Initialize()
        {
            throw new NotImplementedException();
        }
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Lavender);
        }

    }
}
