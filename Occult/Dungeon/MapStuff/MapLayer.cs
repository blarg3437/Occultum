using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class MapLayer
    {
        private Tile[,] tileMap;
        public int width{get; private set;}
        public int height { get; private set; }

        public MapLayer(int sizeX, int sizeY)
        {
            tileMap = new Tile[sizeX, sizeY];//idk if I will keep this here
            width = sizeX;
            height = sizeY;
        }

        public void setTileMap(Tile[,] arr) { tileMap = arr; }

        public Tile getTileAt(int x, int y)
        {
           if(isInBounds(x, y))
            {                  
                return tileMap[x, y];               
            }
            return null;
        }
   
      
        public void changeTileType(int x, int y, Tile.tiletype type)
        {
           if(isInBounds(x, y))
            {
                tileMap[x, y].tile = type;
            }
        }

        private bool isInBounds(int x, int y)
        {
            if (x < width && x >= 0)
            {
                if (y < height && y >= 0)
                {
                    return true;
                }
            }
            return false;
            }


        public void toString()
        {
            StreamWriter river = new StreamWriter(@"C:\Users\Nicholas\Pictures\MyPixArt\out.txt");
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    river.Write((int)tileMap[j, i].tile+",");
                }
                river.WriteLine();
            }
            river.Close();
        }
    }
}
