using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World.Components
{
    /**
     * a component to recieve input from the keyboard/mouse, and issue out events based on that.
     */
    class InputComponent : IComponent
    {
        public delegate void keyboardCarrier(Keys[] a);
        public delegate void mouseCarrier(MouseState m);
        
        public event keyboardCarrier onKeyboardDown;
        public event keyboardCarrier onKeyboardChanged;
        
        public event mouseCarrier onMouseButton;
        public event mouseCarrier onMouseMove;

        Keys[] previousKeys;
        MouseState previousMouse;
        public void draw(SpriteBatch spritebatch)
        {
            return;
        }

        public void update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            Keys[] kArr = kState.GetPressedKeys();
            if (kArr.Length != 0) onKeyboardDown.Invoke(kArr);


            //mouse
            if (mState.Position.X != previousMouse.Position.X || mState.Position.Y != previousMouse.Position.Y)
                onMouseMove.Invoke(mState);

            //implement mouse buttons.

        }
    }
}
