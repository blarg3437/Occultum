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
        

        protected Vector2 position;
        public Vector2 getPostion() => position;
        protected DungeonLevel dungeonImIn;
        
        public Actor(int posX, int posY, DungeonLevel level)
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
