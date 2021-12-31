using Occult.Dungeon.MapStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon
{
    public class DungeonLevel
    {
        public MapLayer currentMap { get; private set; }
        public Tuple<int, int> spawnLocation;
        public DungeonLevel(int levels)
        {

            currentMap = new MapLayer(70,70);
            currentMap.generatenewMap();
            
            //currentMap.toString();
        }
    }
}
