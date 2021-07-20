using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Util.Graphics
{
    class Drawing
    {
        Texture2D red;
        GraphicsDevice graphic;
        public Drawing()
        {
            graphic = Util.Global.graphics.GraphicsDevice;
            red = new Texture2D(graphic, 1, 1);
            
        }
        //doesnt work
        public void drawLine(SpriteBatch batch, Vector2 start, Vector2 end, Color color)
        {
            float length = Vector2.Distance(end, start);
            float opp = end.Y - start.Y;
            float adj = end.X - start.X;
            float angle = (float)Math.Atan(opp / adj);
            Rectangle rect = new Rectangle((int)start.X, (int)start.Y, (int)(length + start.X), 1);
            batch.Draw(red, rect, null, color, angle, start, SpriteEffects.None, 1);
        }
    }
}
