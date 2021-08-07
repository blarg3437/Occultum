using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoGame.Extended.Shapes;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Win32.SafeHandles;
using SharpDX.DXGI;
using MonoGame.Extended.VectorDraw;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;

namespace SpriteAssigner
{
    /**
     * this project will be a simple one. It is just going to be used to consume a spritesheet off the internet, and generate
     * some sort of file that contains source rectangles, which are associated with tileID's. It should have a button or something to start
     * assigning all of the tile ID's, in order. Once you get going, there will be an option to select what size the textures are, then go through and 
     * click on whatever ID is currently selected. I think the application should select what TILEID its assigning at the moment, so you can just focus on clicking the correct
     * sprite on scene.
     */
    class MainWindow : MonoGame.Forms.Controls.MonoGameControl
    {
        int spriteSize;
        Texture2D texToDisplay;
        bool hasImported = false;
        public bool canClick = false;
        Vector2 mouseOffset;
        float zoom = 1f;
        Form1 formfoMe;

        Texture2D overlayTex;
        public void giveMeForm(Form1 form) => formfoMe = form;

        public delegate void updateClicked(Rectangle rect);
        public event updateClicked clickedEvent;

        //incase u forget, call base.editor for stuff
        protected override void Draw()
        {
            base.Draw();
            
            
            
            if (hasImported)
            {
                Editor.spriteBatch.Begin(SpriteSortMode.Texture);
                Editor.spriteBatch.Draw(texToDisplay, new Rectangle(mouseOffset.ToPoint(), new Point((int)(texToDisplay.Width), (int)(texToDisplay.Height))) , Color.White);
               
                foreach (Rectangle item in formfoMe.refs.Values)
                {
                    Random rand = new Random();
                    Color col = new Color(rand.Next(255), rand.Next(255), rand.Next(255), 255);
                    Vector2 start = new Vector2((int)(item.X), (int)(item.Y ));                   
                    Editor.spriteBatch.Draw(overlayTex, destinationRectangle: new Rectangle((int)((start.X * spriteSize) + mouseOffset.X), (int)((start.Y * spriteSize) + mouseOffset.Y), item.Width , item.Height), col);                  
                }
               
                Editor.spriteBatch.End();

                
            }
            
        }

        
        protected override void Initialize()
        {
           GimmeTheGoods(@"C:\Users\Nicholas\Pictures\SpriteSheet1.png", 16);
           
            overlayTex = new Texture2D(GraphicsDevice, 1,1);
            overlayTex.SetData(new[] { Color.White });
            base.Initialize();
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void GimmeTheGoods(string location, int spriteSize)
        {
            texToDisplay = Texture2D.FromStream(GraphicsDevice, new FileStream(location, FileMode.Open));
            this.spriteSize = spriteSize;
            hasImported = true;
        }

        public void BigButtonClick()
        {
            if(hasImported)
            {
                if(canClick)
                {
                    canClick = false;
                }
                else
                {
                    canClick = true;
                }
            }
        }
        #region eventhandlers
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (canClick)
            {
                Debug.WriteLine("CLicked");
                Vector2 locationClicked = new Vector2((e.X - mouseOffset.X) / spriteSize, (e.Y - mouseOffset.Y) / spriteSize);
                //I need to construct a rectangle and store it with the associated id pair.
                Rectangle rect = new Rectangle(locationClicked.ToPoint(), new Point(spriteSize));
                Debug.WriteLine("New Rect({0}, {1}, {2}, {3})", rect.X, rect.Y, rect.Width, rect.Height);
                clickedEvent(rect);
            }
            base.OnMouseClick(e);

        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if(Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
            {
                mouseOffset.X += e.Delta / 120 * spriteSize / 2;
            }
            else if(Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
            {
                zoom += (e.Delta / 120) * spriteSize / 4;
            }
            else
            {
                mouseOffset.Y += e.Delta / 120 * spriteSize / 2;
            }
            base.OnMouseWheel(e);
        }
        #endregion
    }
}
