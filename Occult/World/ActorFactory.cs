using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Occult.Dungeon.MapStuff;
using Occult.Graphics._2D;
using Occult.Util.Math;
using Occult.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World
{
    public static class ActorFactory
    {
        public static ContentManager content;
        public static Actor createPlayer(int x, int y, Dungeon.DungeonLevel level)
        {
            Animation anim = new Animation()
            {
                animationStrip = content.Load<Texture2D>("Textures/Characters/Player/NinjaSpriteAnim"),
                frames = 8,
                

                
                
                flipLeftAndRight = true,
                frameSizeX = 16,
                frameSizeY = 16,
                timeInterval = 0.5f
            };
            
                
            anim.addDirectionFrame(DIRECTION.forward, new int[] { 5, 6 });
            anim.addDirectionFrame(DIRECTION.backward, new int[] { 3, 4 });
            anim.addDirectionFrame(DIRECTION.right, new int[] { 0, 2 });
            anim.addDirectionFrame(DIRECTION.left, new int[] { 0, 2 });

            return new Actor(x, y, level, anim);
        }

        public static NewActor CreatePlayer(IntVector position, Dungeon.DungeonLevel level)
        {
            //player has an animation
            //player has translation
            //player has a renderer

            NewActor temp = new NewActor();
            
            AnimationComponent animComponent = new AnimationComponent(0.5f); ;
            TranslationComponent translationComponent = new TranslationComponent();
            InputComponent input = new InputComponent();
            
            RenderComponent renderer = new RenderComponent(temp,
                content.Load<Texture2D>("Textures/Characters/Player/NinjaSpriteAnim"),
                sourceRectangle: new Rectangle(0, 0, 16, 16),
                destinationRectangle: new Rectangle(0, 0, 16, 16));
            //hooking up the connections here
            animComponent.OnSourceUpdate += renderer.AnimationSourceHandler;
            translationComponent.onPositionUpdate += renderer.PositionChangeHandler;
            input.onKeyboardDown += translationComponent/


            return temp;
        }
        
    }
    }

