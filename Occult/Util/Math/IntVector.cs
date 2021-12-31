using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Util.Math
{
    public struct IntVector
    {
        public int x;
        public int y;

        public IntVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2 toVector2()
        {
            return new Vector2(x, y);
        }

        public static IntVector toIntVector(Vector2 a)
        {
            return new IntVector((int)a.X, (int)a.Y);
        }
    }
}
