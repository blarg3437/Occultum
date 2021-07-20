using Microsoft.Xna.Framework;
using Occult.Dungeon.MapStuff;
using Occult.Util;
using Occult.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon
{
    class Camera
    {
        /*
         * This camera will operate as follows:
         * the following actor will move on the map, doing its checks and all based on the tilemap.
         * then the camera will tween up, and the action will look lik ehte camera is following the actor at the same time
         */

        Actor following;
        public Rectangle viewFrame { get; private set; }//a rectanlge representing the 4 corners of the viewframe
        private MapLayer layer;

        private int centerX, centerY;
        private int width, height;
        
        
        public int moveTimerMilli = 250;
        private float timer;
        bool isMoving;
        public Camera(Actor following, MapLayer layer)
        {
            changeFocus(following);
            
            this.layer = layer;
            viewFrame = new Rectangle();
            width = Util.Global.screenWidth;
            height = Util.Global.screenHeight;
            updateViewFrame();
        }

        public void changeFocus(Actor newActor)
        {
            if (newActor != null)
                following = newActor;
            newActor.onMoveEvent += followerMoveHandler;
            followerMoveHandler(newActor);
        }

        public void update(GameTime gametime)
        {
            if(isMoving)
            {
                if (timer <= moveTimerMilli)
                {
                    timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    timer = 0;
                    isMoving = false;
                }
            }
            
        }

        private void followerMoveHandler(Actor sender)
        {
            if (!isMoving)
            {
                isMoving = true;
                //from here the camera must move to the tweened position 
                centerX = (int)sender.getPostion().X;
                centerY = (int)sender.getPostion().Y;
                updateViewFrame();
            }
        }
        private void updateViewFrame()
        {            
            
            int AX = centerX - width / Global.resolution / 2;
            int AY = centerY - height / Global.resolution / 2;
            int AWidth = AX + width; //possibly unecesary
            int AHeight = AY + height;
            viewFrame = new Rectangle(AX, AY, AWidth, AHeight);
        }
    }
}
