using Occult.Dungeon.MapStuff;
using Occult.World;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon
{
    /**
     * this class is a container of the actual map and all its data for the dungeon screen to hold.
     */
    class DungeonLevel
    {
        public int currentLevel { get; private set; }
        public MapLayer currentMap { get; private set; }
        public Tuple<int, int> spawnLocation;
        public int numberOfLevels;
        public DungeonLevel(int levels)
        {
            currentLevel = 0;
            numberOfLevels = levels;
            currentMap = new MapLayer(70,70);
            currentMap.generatenewMap();
            
            //currentMap.toString();
        }

        public void generateNewMapLayer()
        {
            currentMap.generatenewMap();
            currentLevel++;
        }


    }
}
