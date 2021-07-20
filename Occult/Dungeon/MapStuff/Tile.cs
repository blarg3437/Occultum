using Occult.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class Tile
    {
        private int TileID;
        private Actor actorOnMe;

        public bool setActor(Actor actor)
        {
            if (actorOnMe == null)
            {
                return false;
            }
            else
            {
                actorOnMe = actor;
                return true;
            }
        }
    }
}
