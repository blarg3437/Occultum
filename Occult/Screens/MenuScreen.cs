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
    class MenuScreen : BaseScreen
    {
        Texture2D start;
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Texture);
            spriteBatch.Draw(start, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        public override void initialize()
        {
           
        }

        public override void loadContent(ContentManager manager)
        {
            start = manager.Load<Texture2D>("Textures/Menu/new_game_disabled");
            
        }

        public override void unloadContent()
        {
            start = null;
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
