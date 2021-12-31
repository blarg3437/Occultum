using Microsoft.Xna.Framework;
using Occult.Dungeon;
using Occult.Dungeon.MapStuff;
using Occult.Util;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Occult.Graphics._2D;
using Microsoft.Xna.Framework.Graphics;

namespace Occult.World
{
    class Actor
    {
        private static int lastID;
        public int ID { get; private set; }

        public delegate void Move(Actor sender);
        public event Move onMoveEvent;
        public int moveTimerMilli;

        
        private float timer;
        private Animation anim;

        protected bool isMoving;
        protected Vector2 position;
        protected DungeonLevel dungeonImIn;
        protected bool isVisible;
        public Vector2 getPostion() => position;
        
        
        public Actor(int posX, int posY, DungeonLevel level, Animation anim)
        {
            ID = ++lastID;
            position = new Vector2(posX, posY);
            moveTimerMilli = Global.moveTime;
            dungeonImIn = level;
        }

        public void setDungeonLevel(DungeonLevel level) => dungeonImIn = level;

        protected virtual void MoveBy(int Xoff, int Yoff)
        {
            //eventually put a bit of collision detection
            if (!isMoving)
            {
                if (!willCollide((int)position.X+Xoff, (int)position.Y+Yoff))
                {
                    position.X += Xoff;
                    position.Y += Yoff;
                    isMoving = true;
                    onMoveEvent(this);
                }
                else
                {

                }
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
            
            if (anim != null) anim.update(gameTime);
        }

        protected virtual void draw(SpriteBatch batch)
        {
           // if (anim != null) anim.draw(batch);
        }

        protected bool willCollide(int newX, int newY)
        {
            Tile tempTile = dungeonImIn.currentMap.getTileAt(newX, newY);
            if (tempTile != null)
            {
                if (tempTile.tile == Dungeon.MapStuff.TileType.path)
                {
                    return false;
                }
            }
            return true;
        }



    }
}
