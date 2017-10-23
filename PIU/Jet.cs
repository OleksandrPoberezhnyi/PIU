using System;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PIU
{
    public class Jet
    {
        Texture2D jetPlane;
        Vector2 position,size;
        private float velocity_x, velocity_y;
        private bool movementX, movementY;
        private int x,y,scale,velocity_max;
        private float[] tableX;
        private float[] tableY;
       
        public Jet(ContentManager content)
        {
            //To get texture for plane with custom scale
            jetPlane = content.Load<Texture2D>("jet2");
            scale = 5;
            position = new Vector2(Piu.Screen.X / 2 , Piu.Screen.Y - jetPlane.Height / (scale * 2) );
            size = Vector2.One / scale;

            //To create two tables with exponential valuables to create effect of inertia for plane moving in two axis
            tableX = new float[100];
            tableY = new float[100];
            x = 0;
            while (x < 100)
            {
                if (x < 50) tableX[x] = -(float) Math.Pow(x - 50, 2) / 250;
                else tableX[x] = (float)Math.Pow(x - 50, 2) / 250;
                x++;
            }
            x = 50;
            velocity_x = tableX[x];

            y = 0;
            while (y < 100)
            {
                if (y < 50) tableY[y] = -(float)Math.Pow(y - 50, 2) / 250;
                else tableY[y] = (float)Math.Pow(y - 50, 2) / 250;
                y++;
            }
            y = 50;
            velocity_y = tableY[y];
            velocity_max = 15;
        }

        internal void HandleInput(InputHelper inputHelper)
        {

            // To control plane by WASD keys
            if (inputHelper.KeyDown(Keys.A))
            {
                movementX = true;
                if (x > 1) x -= 2;
            }

            if (inputHelper.KeyDown(Keys.D))
            {
                movementX = true;
                if (x < 98) x += 2;
            }

            if (inputHelper.KeyDown(Keys.W))
            {
                movementY = true;
                if (velocity_max < Piu.Screen.Y/5)
                {
                    velocity_max++;
                }
                
                if (y > 1) y--;

            }

            if (inputHelper.KeyDown(Keys.S))
            {
                movementY = true;

                    if (velocity_max > 15) velocity_max--;

                if (y < Piu.Screen.Y / 5) y++;
            }

            //To control plane height by P and L keys
            if (inputHelper.KeyDown(Keys.P))
            {
                if (Eco.Height<500) Eco.Height++;
            }

            if (inputHelper.KeyDown(Keys.L))
            {
                if (Eco.Height > 0) Eco.Height--;
            }

            //If no key is pressed then to check if we need to create inertia movement for plane
            if (!movementX)
            {
                if (x < 50) x++;
                else if (x > 50) x--;
            }

            if (!movementY)
            {
                if (y < 50) y++;
                else if (y > 50) y--;
            }

            //To get velocity and to add it to position
            velocity_x = tableX[x];
            velocity_y = tableY[y];

            position.X += velocity_x;
            position.Y += velocity_y;

            //To check if plane came to one of edges of game screen
            if (position.X > Piu.Screen.X - jetPlane.Width/ (scale * 2) )
            {
                position.X = Piu.Screen.X - jetPlane.Width/ (scale * 2);
                x = 50;
            }
            if (position.X < jetPlane.Width / (scale * 2))
            {
                position.X = jetPlane.Width / (scale * 2);
                x = 50;
            }
            if (position.Y > Piu.Screen.Y - jetPlane.Height / (scale * 2))
            {
                position.Y = Piu.Screen.Y - jetPlane.Height / (scale * 2);
                y = 50;
            }
            if (position.Y < jetPlane.Height / (scale * 2))
            {
                position.Y = jetPlane.Height / (scale * 2);
                y = 50;
            }

            //To reset movement
            movementX = false;
            movementY = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //To draw plane and its shadow
            spriteBatch.Draw(jetPlane, position, null, null, Center*2, 0.0f, Size, Color.Black*((500- Eco.Height) /500f), SpriteEffects.None, 0);
            spriteBatch.Draw(jetPlane, position, null, null, Center, 0.0f, Size, Color.White, SpriteEffects.None, 0);
        }

        public Vector2 Center
        {
            get { return new Vector2(jetPlane.Width, jetPlane.Height) / 2;}
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public float Velocity
        {
            get { return (float)Math.Sqrt(50*(Piu.Screen.Y - position.Y)); }
        }
    }
}