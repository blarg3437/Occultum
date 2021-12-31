using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Occult.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Occult.World.Components
{
    class AnimationComponent : IComponent
    {
        private Rectangle sourceRectangle;

        public delegate void passSource(Rectangle a);
        public event passSource OnSourceUpdate;


        //Actual animation stuff
        Timer timer;
        DIRECTION direction;

        public AnimationComponent(float timeBetweenFrames)
        {

        }
        
        public void draw(SpriteBatch spritebatch)
        {
            return;
        }

        public void update(GameTime gameTime)
        {
            
            //when its time use this
            OnSourceUpdate(sourceRectangle);
        }
    }
}
