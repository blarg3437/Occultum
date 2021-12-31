using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World.Components
{
    interface IComponent
    {
        void update(GameTime gameTime);
        void draw(SpriteBatch spritebatch);
    }
}
