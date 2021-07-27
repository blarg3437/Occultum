using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    /// <summary>
    /// The room class will be the actual rooms stored inside the map class, and contain information about the loot and such
    /// </summary>
    class Room
    {
       public int width {get;}
       public int height{get;}
       public int startX{get;}
       public int startY { get; }
    
        public Room(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
            startX = x;
            startY = y;
        }
      
        public Tile[,] generateRoom()
        {
            Tile[,] temp = new Tile[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int j = 0; j < width; j++)
                {
                    Tile eFrat = new Tile(Tile.tiletype.path);

                    if (j == 0)
                    {
                        eFrat.tile = Tile.tiletype.left;
                    }
                    if (j == width - 1)
                    {
                        eFrat.tile = Tile.tiletype.right;
                    }

                    if (y == 0)
                    {
                        if (j == 0)
                            eFrat.tile = Tile.tiletype.lefttop;
                        else if (j == width-1)
                            eFrat.tile = Tile.tiletype.righttop;
                        else
                            eFrat.tile = Tile.tiletype.top;

                    }
                    if (y == height - 1)
                    {
                        if (j == 0)
                            eFrat.tile = Tile.tiletype.leftbottom;
                        else if (j == width - 1)
                            eFrat.tile = Tile.tiletype.rightbottom;
                        else
                            eFrat.tile = Tile.tiletype.bottom;
                    }
                   
                    temp[j, y] = eFrat;
                }
            }
            return temp;
        }
    }
}
