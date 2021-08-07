using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        int sourceres;//temporary really, just until I get some tight textures up
       
        public override void initialize()
        {
                                 
            dungeon = new DungeonLevel(3);
            player = new Player(dungeon.currentMap.spawnLocation.Item1, dungeon.currentMap.spawnLocation.Item2, dungeon);
            camera = new Camera(player, dungeon.currentMap);//this might cause problems when switching maps, as it is not updated to the camera
            res = Global.resolution;
            sourceres = 32;//temporary----------------------------------------------------------
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
                            case (TileType.middle):
                             sourceRect = new Rectangle(0, 0, res, res);
                                break;
                            case (TileType.left):
                                sourceRect = new Rectangle(5 * sourceres, 0, res, res);
                                break;
                            case (TileType.right):
                                sourceRect = new Rectangle(5 *sourceres, 1 * sourceres, res, res);
                                break;
                            case (TileType.top):
                                sourceRect = new Rectangle(7 *sourceres, 0, res, res);
                                break;
                            case (TileType.bottom):
                                sourceRect = new Rectangle(6 * sourceres, 0,res, res);
                                break;
                            case (TileType.path):
                                sourceRect = new Rectangle(0 * sourceres, 1 * sourceres, res, res);
                                break;
                            case (TileType.stair):
                                sourceRect = new Rectangle(6 * sourceres, 1 * sourceres, res, res);
                                break;
                            default:
                                sourceRect = new Rectangle(0, 0, res, res);
                                break;
                            }

                        sourceRect.Width = sourceRect.Height = sourceres;


                        spriteBatch.Draw(
                            texture: tester,
                            destinationRectangle: new Rectangle(dest.ToPoint(), new Point(res)),
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
