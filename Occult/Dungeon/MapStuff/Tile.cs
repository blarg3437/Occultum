using Occult.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class Tile
    {
        

        public TileType tile;
        public Actor actorOnMe
        {
            set {
                if (value != null)
                { actorOnMe = value; }
            }
            get{ return actorOnMe; }
        }
        public Tile()
        {

        }

        public Tile(TileType type)
        {
            tile = type;
        }
        

    }
}
