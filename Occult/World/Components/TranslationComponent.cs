using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Occult.Util.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World.Components
{
    class TranslationComponent : IComponent
    {
        IntVector position;
        DIRECTION direction;
        
        public delegate void translateCarrier(IntVector v);
        public event translateCarrier onPositionUpdate;

        public TranslationComponent(IntVector position)
        {

        }
        public void draw(SpriteBatch spritebatch)
        {
            //possibly put some debug option here
        }

        public void update(GameTime gameTime)
        {
           
        }

        public void keyboardDownHandler(Keys[] k)
        {
            //check for movement related crap here
        }
    }
}
