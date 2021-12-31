using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Occult.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Occult.World;

namespace Occult.Graphics._2D
{
    class Animation
    {
      

        public Texture2D animationStrip;
        public int frames;
        public int frameSizeX;
        public int frameSizeY;
        public bool flipLeftAndRight;
        public float timeInterval {
            get { return timeInterval; }
            set
            {
                timeInterval = value;
                timer = new Timer(value);
            }
        }
        //all of these frames start assume a start at zero

        public Dictionary<DIRECTION, int[]> allDirectionFrames;       
        private Timer timer;
        private DIRECTION direction;
        private int currentFrame;
        
        public Animation()
        {
            allDirectionFrames = new Dictionary<DIRECTION, int[]>();
            
        }

        public void addDirectionFrame(DIRECTION dir, int[] frames)
        {
            if (allDirectionFrames == null) return;
            allDirectionFrames.Add(dir, frames);
        }
        public void changeDirection(DIRECTION newDirection)
        {        
                direction = newDirection;
            currentFrame = allDirectionFrames[newDirection][0]; //should always be set to the idle position for that...but later.
        }

        public void update(GameTime time)
        {
            if (animationStrip == null) throw new NotImplementedException("Texture not defined");

            try
            {
                if(timer.Tick(time.TotalGameTime.TotalMilliseconds))//tick the timer and see if it is time to update
                {

                    timer.restartTimer();
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error in animation class");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

        public void draw(SpriteBatch batch, Vector2 position)
        {
            batch.Draw(animationStrip, 
                destinationRectangle: new Rectangle((int)position.X, (int)position.Y, frameSizeX, frameSizeY), 
                sourceRectangle: new Rectangle());

        }

        private void moveCurrentFrameForward()
        {
            int upperBound = allDirectionFrames[direction][1];
            int lowerBound = allDirectionFrames[direction][0];

            if(currentFrame == upperBound)
            {
                currentFrame = lowerBound;
                return;
            }
            currentFrame++;
        }
    }
}
