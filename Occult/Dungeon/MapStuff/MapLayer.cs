using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class MapLayer
    {
        private int[,] tileMap;
        public int width{get; private set;}
        public int height { get; private set; }

        public MapLayer(int sizeX, int sizeY)
        {
            tileMap = new int[sizeX, sizeY];//idk if I will keep this here
            width = sizeX;
            height = sizeY;
        }

        public void setTileMap(int[,] arr) { tileMap = arr; }

        public int getTileAt(int x, int y)
        {
            if(x < width && x >= 0)
            {
                if(y < height && y >= 0)
                {
                    return tileMap[x, y];
                }
            }
            return -1;
        }

        
      
    }
}
