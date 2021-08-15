using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Occult.Graphics.Components
{
    /**
     * this represents 1 animation, and it will keep track of the current frame and all that 
     *for the actor its attached to
     */
    class Animation
    {
        Texture2D spriteSheet;
        int maxFrames;
        int currentFrame;
        int delay;
        int frameTotal;//used when were counting the number of frames
        int res;
        Rectangle region;//the rectangle to draw out of
        Rectangle currentDrawRegion;
        bool slicing;
        bool playonce;
        bool playing;
        double timer;
        

        public Animation(Texture2D texture, int frames, int resolution, int delay = 500)
        {
            maxFrames = frames;
            this.delay = delay;
            currentFrame = 0;
            spriteSheet = texture;
            slicing = false;
            timer = 0;
            res = resolution;
        }

        public Animation(Texture2D textureToBeSliced, Rectangle relevantAnimationFrames, int frames, int resolution, int delay = 500)
        {
            maxFrames = frames;
            this.delay = delay;
            currentFrame = 0;
            spriteSheet = textureToBeSliced;
            region = relevantAnimationFrames;
            slicing = true;
            timer = 0;
            res = resolution;
        }

        public void update(GameTime gameTime)
        {
            if(playing)
            {
                if(timer >= delay)
                {
                    timer = 0;
                    advanceNextFrame();
                }
                else
                {
                    timer += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }    
        }

        public void Start()
        {
            playonce = false;
            playing = true;
            currentFrame = 0;
        }

        public void Stop()
        {
            playonce = false;
            playing = false;
        }

        public void playFrames(int frameAmount)
        {
            
        }
        private void advanceNextFrame()
        {
          if(currentFrame == maxFrames)
            {
                currentFrame = 0;
                frameTotal++;
            }
          
           if(!slicing)
            {
                currentDrawRegion = new Rectangle(currentFrame * res, 0, res, res);
            }
            else
            {
                currentDrawRegion = new Rectangle(region.X + (currentFrame * res), region.Y, res, res);
            }
        }

        public void draw(SpriteBatch batch, Rectangle destRectangle, Color color)
        {
            batch.Draw(spriteSheet, currentDrawRegion, destRectangle, color);
        }
    }
}
