using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace OccultumEditor.EditorForms.DialogEditor.Components
{
    class DialogEditorWindow : MonoGame.Forms.Controls.MonoGameControl
    {
        private bool inFocus;
       
        protected override void Draw()
        {
            if (inFocus)
            {
                GraphicsDevice.Clear(Color.Red);
            }
            else
            {
                base.GraphicsDevice.Clear(Color.Blue);
            }
            base.Draw();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            inFocus = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            inFocus = false;
        }
    }
}
