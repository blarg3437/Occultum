using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Util.Graphics
{
    class Drawing
    {
        Texture2D red;
        GraphicsDevice graphic;
        SpriteFont font;
        SpriteBatch batch;
        private static Drawing instance;
        public static Drawing Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Drawing();
                }

                return instance;
            }
        }

        //make sure to call this before using the log function
        public void AddSpriteFont(SpriteFont defaultFont)
        {
            font = defaultFont;
        }
            
        private Drawing()
        {
            graphic = Util.Global.graphics.GraphicsDevice;
            red = new Texture2D(graphic, 1, 1);
            batch = new SpriteBatch(graphic);
        }
        //doesnt work
        public void drawLine(Vector2 start, Vector2 end, Color color)
        {            
            float length = Vector2.Distance(end, start);
            float opp = end.Y - start.Y;
            float adj = end.X - start.X;
            float angle = (float)Math.Atan(opp / adj);
            Rectangle rect = new Rectangle((int)start.X, (int)start.Y, (int)(length + start.X), 1);
            batch.Begin(); 
            batch.Draw(red, rect, null, color, angle, start, SpriteEffects.None, 1);
            batch.End();
        }

        public void screenWrite(Vector2 position, string message, Color color)
        {
            batch.Begin();
            batch.DrawString(font, message, position, color);
            batch.End();
        }
    }
}
