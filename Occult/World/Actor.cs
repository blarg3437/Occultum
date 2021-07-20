using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World
{
    abstract class Actor
    {
        private static int lastID;
        public int ID { get; private set; }

        public delegate void Move(Actor sender);
        public event Move onMoveEvent;

        protected bool isMoving;
        private float timer;
        public int moveTimerMilli;
        int newX, newY;

        protected Vector2 position;
        public Vector2 getPostion() => position;
        
        public Actor(int posX, int posY)
        {
            ID = ++lastID;
            position = new Vector2(posX, posY);
            moveTimerMilli = 250;
        }

      
        protected virtual void MoveBy(int Xoff, int Yoff)
        {
            //eventually put a bit of collision detection
            if (!isMoving)
            {
                position.X += Xoff;
                position.Y += Yoff;
                isMoving = true;
                onMoveEvent(this);
            }        
           
        }

        
        public virtual void update(GameTime gameTime)
        {
            if (isMoving)
            {
                if (timer <= moveTimerMilli)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    timer = 0;
                    isMoving = false;
                }
            }
        }
    }
}
