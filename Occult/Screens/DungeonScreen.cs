using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Screens
{
    class DungeonScreen : BaseScreen
    {
        Texture2D tester;

      

        public override void initialize()
        {
            
        }

        public override void loadContent(ContentManager manager)
        {
            tester = manager.Load<Texture2D>("Textures/Tile/GrassTile");
        }

        public override void unloadContent()
        {
            tester = null;
           
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tester, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}
