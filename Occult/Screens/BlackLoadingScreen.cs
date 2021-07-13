using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Screens
{
    class BlackLoadingScreen : BaseScreen
    {

        Texture2D blackWipe;
        float transistionTime;
        private float elapsedTime = 0;

        
        public BlackLoadingScreen(float transTime = 1000)
        {
            transistionTime = transTime;
        }

        //counts up to the transition time
        public bool transition(GameTime gt)
        {
            if (elapsedTime >= transistionTime)
            {
                elapsedTime = 0;
                return true;
            }
            elapsedTime += (float)gt.ElapsedGameTime.TotalMilliseconds;
            return false;
        }
       

        public override void initialize()
        {
            throw new NotImplementedException();
        }

        public override void loadContent(ContentManager manager)
        {
           blackWipe = manager.Load<Texture2D>("Black1");
        }

        public override void unloadContent()
        {
            throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();//eventually throw a cool shader in here
            spriteBatch.Draw(blackWipe, new Rectangle(0, 0, ScreenManager.Instance.screenWidth, ScreenManager.Instance.screenHeight), Color.White);
            spriteBatch.End();
        }
    }
}
