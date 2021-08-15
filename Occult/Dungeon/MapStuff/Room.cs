using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    /// <summary>
    /// The room class will be the actual rooms stored inside the map class, and contain information about the loot and such
    /// </summary>
    class Room
    {
        #region variables
        public int width {get;}
       public int height{get;}
       public int startX{get;}
       public int startY { get; }
        public int centerX { get; }
        public int centerY { get; }
        #endregion

        public Room(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
            startX = x;
            startY = y;
            centerX = (this.width / 2) + startX;
            centerY = (this.height / 2) + startY;
        }       

        public Tuple<int, int> ChooseSpawnPoint()
        {
            Random rand = new Random();
            int locationX = rand.Next(width) + startX;
            int locationY = rand.Next(height) + startY;

            return new Tuple<int, int>(locationX, locationY);
        }

        public bool CollidesWith(Room otherRoom)
        {
            Rectangle me = new Rectangle(startX, startY, width, height);
            Rectangle you = new Rectangle(otherRoom.startX, otherRoom.startY, otherRoom.width, otherRoom.height);

            return me.Intersects(you);
        }

        /**
         * determines if the point is within the room or not
         */
        public bool pointInRoom(int x, int y)
        {
            if(x >= startX && x <= startX + width)
            {
                if(y >= startY && y <= startY + height)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
