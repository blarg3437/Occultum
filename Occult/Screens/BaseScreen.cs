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
    public abstract class BaseScreen
    {

        public abstract void initialize();
        public abstract void loadContent(ContentManager manager);
        public abstract void unloadContent();
        public abstract void draw(SpriteBatch spriteBatch);
        public abstract void update(GameTime gameTime);

    }
}
