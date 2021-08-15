using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Occult.Dungeon;
using Occult.Dungeon.MapStuff;
using Occult.Util;
using Occult.Util.Graphics;
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

        public delegate void OnTileStep();//eventually might want to migrate to base class
        public static event OnTileStep OnStairStep;
        public Player(int x, int y, DungeonLevel level) : base(x,y, level)
        {
            widthOffset = Global.screenWidth/2;
            heightOffset = Global.screenHeight/2;
        }

        public void setTexture(Texture2D text) => playerTex = text;
        
        public override void update(GameTime gameTime)
        {
            
            
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.W)) MoveBy(0, -1);
                if (state.IsKeyDown(Keys.A)) MoveBy(-1, 0);
                if (state.IsKeyDown(Keys.S)) MoveBy(0, 1);
                if (state.IsKeyDown(Keys.D)) MoveBy(1, 0);

            if (dungeonImIn.currentMap.getTileAt((int)position.X, (int)position.Y).tile == TileType.stair)
            {
                OnStairStep();
                //check if it is the last level
                //otherwise advance the level, and if it is then call dungeonscreen complete dungeon.
            }
            
            base.update(gameTime);
        }

        /*
         * specifically for the player, to deal with player specific things like stairs
         */
        protected override void MoveBy(int Xoff, int Yoff)
        {
            
            base.MoveBy(Xoff, Yoff);
        }

        


        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(playerTex, 
                new Rectangle(widthOffset, heightOffset, Global.resolution, Global.resolution),
                Color.White);//eventually add a tween offset, and add it here
        }

        public void drawPosition()
        {
            Drawing.Instance.screenWrite(new Vector2(0, 32), "PX: " + position.X + " PY: " + position.Y, Color.Red);
        }
    }
}
