using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccultLevelEditor
{
    class MainScreen : MonoGame.Forms.Controls.MonoGameControl
    {
        
        protected override void Draw()
        {
            //spritebatch is in editor.spritbatch
            GraphicsDevice.Clear(Color.Black);
            base.Draw();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
