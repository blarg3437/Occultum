using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EditorWindow.DialogEditor.Custom_Control
{
    class DialogEditorMono : MonoGame.Forms.Controls.MonoGameControl
    {
        bool isFocused;
        SpriteFont font;

        public DialogEditorMono()
        {
           // font = new SpriteFont()
        }
        protected override void OnGotFocus(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Focus");
            base.OnGotFocus(e);
            isFocused = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UnFocus");

            base.OnLostFocus(e);
            isFocused = false;
        }

        protected override void Draw()
        {
            base.Draw();
            if(isFocused)
            {              
                BackColor = System.Drawing.Color.Red;
            }
            else
            {
                BackColor = System.Drawing.Color.Blue;
               
            }
            
            Invalidate();
        }
    }
}
