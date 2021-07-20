using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Occult.Dungeon;
using Occult.Dungeon.MapStuff;
using Occult.Util;
using Occult.Util.Graphics;
using Occult.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Screens
{
    class DungeonScreen : BaseScreen
    {
        Texture2D tester;
        MapLayer testMap;
        Player player;
        Camera camera;

       
        public override void initialize()
        {
            player = new Player(0,0);
            camera = new Camera(player, testMap);
           
        }

        public override void loadContent(ContentManager manager)
        {
            tester = manager.Load<Texture2D>("Textures/Tile/GrassTile");
            testMap = FileLoader.Instance.readDungeonMap(@"C:\Users\Nicholas\Documents\MapTest.txt");
            player.setTexture(manager.Load<Texture2D>("Textures/Characters/Player/terguy"));
            //eventually load the player from fileloader
        }

        public override void unloadContent()
        {
            tester = null;
           
        }

        public override void update(GameTime gameTime)
        {
            player.update(gameTime);
            camera.update(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Rectangle viewRect = camera.viewFrame;
            
            for(int y = viewRect.Y; y < viewRect.Height; y++)
            {
                for (int x = viewRect.X; x < viewRect.Width; x++)
                {
                    //this bit is temporary until I put in the camera bounding
                    if(testMap.getTileAt(x,y) != -1)
                    {
                        if(testMap.getTileAt(x, y) == 1)
                        spriteBatch.Draw(tester, new Vector2((x - viewRect.X) * Global.resolution, (y - viewRect.Y) * Global.resolution), Color.White);
                    }
                }
                
            }

           
            player.draw(spriteBatch);
            spriteBatch.End();

            
        }
    }
}
