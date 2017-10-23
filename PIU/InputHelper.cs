﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PIU
{
    class InputHelper
    {
        MouseState currentMouseState, previousMouseState;
        KeyboardState currentKeyboardState, previousKeyboardState;

        public void Update()
        {
            previousMouseState = currentMouseState;
            previousKeyboardState = currentKeyboardState;
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        public bool MouseLeftButtonPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool KeyUp(Keys k)
        {
            return previousKeyboardState.IsKeyUp(k);
        }
        public bool KeyDown(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k);
        }
        public bool KeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }
    }
}