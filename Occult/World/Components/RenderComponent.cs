using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Occult.Util.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World.Components
{
    /*
     * In charge of holding onto the texture and everything for the actor.
     * will also render the component.
     * can subscribe to the animation component to update the source rectangle when an animation is complete.
     * if not, it will just pull from the preset source rectangle
     */
    class RenderComponent : IComponent
    {
        private NewActor Attached;
        private Texture2D texture; 
        Rectangle sourceRectangle; //will be updated with an event
        Rectangle destinationRectangle;

        IntVector position; //will be updated through an event

        #region setters

        #endregion
        public RenderComponent(NewActor myActor, Texture2D textureSource, Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            Attached = myActor;
            texture = textureSource;
            this.sourceRectangle = sourceRectangle;
            this.destinationRectangle = destinationRectangle;
        }

        public void draw(SpriteBatch spritebatch)
        {
           
        }

        public void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void AnimationSourceHandler(Rectangle newSource)
        {
            sourceRectangle = newSource;
        }

        public void PositionChangeHandler(IntVector newPosition)
        {
            position = newPosition;
        }
    }
}
