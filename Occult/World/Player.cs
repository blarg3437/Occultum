using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Occult.Dungeon;
using Occult.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World
{
    class Player:Actor
    {
        private Texture2D playerTex;
        private int widthOffset, heightOffset;
        public Player(int x, int y) : base(x,y)
        {
            widthOffset = Global.screenWidth/2;
            heightOffset = Global.screenHeight/2;
        }

        public void setTexture(Texture2D text) => playerTex = text;
        
        public override void update(GameTime gameTime)
        {

            
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.W)) base.MoveBy(0, -1);
                if (state.IsKeyDown(Keys.A)) base.MoveBy(-1, 0);
                if (state.IsKeyDown(Keys.S)) base.MoveBy(0, 1);
                if (state.IsKeyDown(Keys.D)) base.MoveBy(1, 0);

                Debug.WriteLine("X:" + base.position.X + " Y:" + base.position.Y);
            
            base.update(gameTime);
        }
        
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(playerTex, 
                new Rectangle(widthOffset-playerTex.Width/2, heightOffset-playerTex.Height/2, Global.resolution, Global.resolution),
                Color.White);//eventually add a tween offset, and add it here
        }
    }
}
