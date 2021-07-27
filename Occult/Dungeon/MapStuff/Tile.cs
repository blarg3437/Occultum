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
        public enum tiletype
        {
            middle,
            leftbottom,
            rightbottom,
            lefttop,
            righttop,
            top,
            left,
            right,
            bottom,
            water,
            path,
            stair
        }

        public tiletype tile;
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

        public Tile(tiletype type)
        {
            tile = type;
        }
        

    }
}
