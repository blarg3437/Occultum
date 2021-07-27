using Occult.Dungeon.MapStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon
{
    class DungeonLevel
    {
        public MapLayer currentMap { get; private set; }

        public DungeonLevel(int levels)
        {
            currentMap = MapGenerator.generatenewMap(30, 30);//temporary
            //currentMap.toString();
        }
    }
}
