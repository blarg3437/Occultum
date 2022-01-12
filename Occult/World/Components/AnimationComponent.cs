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
        private Dictionary<DIRECTION, int[]> framesDictionary;
        Timer timer;
        private DIRECTION previousDirection;
        DIRECTION direction;
        int currentFrame;


        public AnimationComponent(float timeBetweenFrames)
        {

        }
        
        public void draw(SpriteBatch spritebatch)
        {
            return;
        }

        public void update(GameTime gameTime)
        {
            if(timer.tick())
            //when its time use this
            OnSourceUpdate(sourceRectangle);
        }

        public void onPositionChangeHandler(DIRECTION dir)
        {
            if (previousDirectiond is null) previousDirection = dir;
            previousDirection = direction;
            direction = dir;
        }

        public void addFrameArray(DIRECTION dir, int[] arr)
        {
            framesDictionary.Add(dir, arr);
        }

        private void advanceCurrentFrame()
        {
            //I need to check if the direction has changed, and if it has- set the frame to the 
            //first frame designated for that direction animation set.
            if(direction != previousDirection)
            {
                //direction has been updated, so set the animation fram eto the first in the direction set.
                currentFrame = framesDictionary[direction][0];
                previousDirection = direction;
                return;
            }
            //if that is not the case-proceed as normal. 
            if (currentFrame == framesDictionary[direction].LastOrDefault)
            { currentFrame = framesDictionary[direction][0]; return; }

            currentFrame++;
        }
    }
}
