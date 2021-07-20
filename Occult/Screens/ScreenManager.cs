using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Screens
{
    /**A singleton patterned screen manager 
     */
    public class ScreenManager
    {
        BaseScreen currentScreen;
        BlackLoadingScreen transitionScreen;
        BaseScreen nextScreen;

        Stack<BaseScreen> ScreenStack;

        ContentManager content;
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;

        public int screenWidth;
        public int screenHeight;

        bool isTransistioning;
        bool doneTransitioning;


        private static ScreenManager instance;
        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        private ScreenManager()
        {
            transitionScreen = new BlackLoadingScreen();
            ScreenStack = new Stack<BaseScreen>();
        }

        //total cheap cop-out method, just make sure to call this before running anything
        public void setEssentials( SpriteBatch sb, GraphicsDeviceManager gd)
        {
           
            spriteBatch = sb;
            graphics = gd;
            screenWidth = gd.PreferredBackBufferWidth;
            screenHeight = gd.PreferredBackBufferHeight;
        }
       

        public void LoadContent(ContentManager manager)
        {
            transitionScreen.loadContent(manager);
            content = manager;
        }
        public void update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                switchScreens(new DungeonScreen());
            }

            if (isTransistioning)
            {
                if (transitionScreen.transition(gameTime))
                {
                    unloadAndSwitch();                    
                }
            }
            else
            {
                currentScreen.update(gameTime);
            }

           
        }

        public void draw(SpriteBatch spriteBatch)
        {
            
           if(isTransistioning)
            {
                //I think for now we will let the independent screens do begin and end so they can use their own shaders
                //draw the transisiton draw, but for now just draw a black screen
                transitionScreen.draw(spriteBatch);
            }
            else
            {
                currentScreen.draw(spriteBatch);
            }
            
        }

        public void switchScreens(BaseScreen nextScreen)
        {
            isTransistioning = true;
            doneTransitioning = false;
            this.nextScreen = nextScreen;
        }
        private void unloadAndSwitch()
        {
            doneTransitioning = true;
            if (currentScreen != null)
                currentScreen.unloadContent();
            nextScreen.initialize();
            nextScreen.loadContent(content);
            currentScreen = nextScreen;
            nextScreen = null;//free some memory
            //eventually add some logic in the black loading screen to fade in
            isTransistioning = false;
        }

        public void putScreenOnTop(BaseScreen topScreen)
        {
            if(topScreen != null)
            { ScreenStack.Push(topScreen);
                currentScreen = topScreen;
            }
           
        }

        public void popScreenFromTop()
        {
            ScreenStack.Pop();
            currentScreen = ScreenStack.Peek();
        }
    }
}
