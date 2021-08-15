using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Occult.Graphics.Components
{
    interface IComponent
    {
        void draw(SpriteBatch batch);
        void update(GameTime time);
    }
}
