using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class DungeonMap
    {
        int[,] tileMap;

        public DungeonMap(int sizeX, int sizeY)
        {
            tileMap = new int[sizeX, sizeY];//idk if I will keep this here
        }

        public void setTileMap(int[,] arr) { tileMap = arr; }

        public int getTileAt(int x, int y) => tileMap[x, y];
        
    }
}
