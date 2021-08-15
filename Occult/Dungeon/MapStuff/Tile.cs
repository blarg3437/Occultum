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
        public enum FloorType { Room, Hallway, NAN};

        public FloorType typeOfFloor = FloorType.NAN;

        public TileType tile;
        public bool walkable;
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
