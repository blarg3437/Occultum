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
        Player player;
        Camera camera;
        DungeonLevel dungeon;
        int res;
       
        public override void initialize()
        {
            player = new Player(0,0);                       
            dungeon = new DungeonLevel(3);
            camera = new Camera(player, dungeon.currentMap);//this might cause problems when switching maps, as it is not updated to the camera
            res = Global.resolution;
        }

        public override void loadContent(ContentManager manager)
        {
            tester = manager.Load<Texture2D>("Textures/Tile/SimpleRPGSprite32");
            //testMap = FileLoader.Instance.readDungeonMap(@"C:\Users\Nicholas\Documents\MapTest.txt");
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
            Drawing.Instance.screenWrite(Vector2.Zero, "AX: " + viewRect.X + " AY: " + viewRect.Y, Color.Black);
            
            for (int y = viewRect.Y; y < viewRect.Height; y++)
            {
                for (int x = viewRect.X; x < viewRect.Width; x++)
                {
                    //this bit is temporary until I put in the camera bounding
                    if(dungeon.currentMap.getTileAt(x,y) != null)
                    {
                        Rectangle sourceRect;
                        Vector2 dest = new Vector2((x - viewRect.X) * res, (y - viewRect.Y) * res);
                      
                        //this will have to be contained in the currentmap at some point
                        switch(dungeon.currentMap.getTileAt(x,y).tile)
                            {
                            case (Tile.tiletype.middle):
                             sourceRect = new Rectangle(0, 0, res, res);
                                break;
                            case (Tile.tiletype.left):
                                sourceRect = new Rectangle(5 * res, 0, res, res);
                                break;
                            case (Tile.tiletype.right):
                                sourceRect = new Rectangle(5 * res, 1 * res, res, res);
                                break;
                            case (Tile.tiletype.top):
                                sourceRect = new Rectangle(7 * res, 0, res, res);
                                break;
                            case (Tile.tiletype.bottom):
                                sourceRect = new Rectangle(6 * res, 0, res, res);
                                break;
                            case (Tile.tiletype.path):
                                sourceRect = new Rectangle(0 * res, 1 * res, res, res);
                                break;
                            case (Tile.tiletype.stair):
                                sourceRect = new Rectangle(6 * res, 1 * res, res, res);
                                break;
                            default:
                                sourceRect = new Rectangle(0, 0, res, res);
                                break;
                            }
                            
                            
                            
                        spriteBatch.Draw(
                            texture: tester, 
                            position : dest,
                            sourceRectangle: sourceRect,
                            color: Color.White);
                    }
                }
                
            }

           
            player.draw(spriteBatch);
            player.drawPosition();
            spriteBatch.End();

            
        }
    }
}
