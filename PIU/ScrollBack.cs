using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PIU
{
    public class ScrollBack
    {
        Texture2D scrollingBack,scrollingBack2,scrollingBack3;
        private Vector2 position, position2, position3, origin, size, origin2, size2, origin3, size3;

        public ScrollBack(ContentManager content)
        {
            //To load textures for three different backgrounds
            scrollingBack = content.Load<Texture2D>("back_grass");
            scrollingBack2 = content.Load<Texture2D>("back_clouds");
            scrollingBack3 = content.Load<Texture2D>("back_stars");

            //To set properties for these backgrounds
            position = new Vector2(Piu.Screen.X / 2, Piu.Screen.Y / 2);
            position2 = new Vector2(Piu.Screen.X / 2, Piu.Screen.Y / 2);
            position3 = new Vector2(Piu.Screen.X / 2, Piu.Screen.Y / 2);
            origin = new Vector2(scrollingBack.Width / 2, 0);
            size = new Vector2(0,scrollingBack.Height);
            origin2 = new Vector2(scrollingBack2.Width / 2, 0);
            size2 = new Vector2(0, scrollingBack2.Height);
            origin3 = new Vector2(scrollingBack3.Width / 2, 0);
            size3 = new Vector2(0, scrollingBack3.Height);
        }

        public void Update(float deltaY)
        {
            //Moving backgrounds from up to down
            position.Y += deltaY;
            position.Y %= scrollingBack.Height;
            position2.Y += deltaY;
            position2.Y %= scrollingBack2.Height;
            position3.Y += deltaY;
            position3.Y %= scrollingBack3.Height;
        }

        public void Draw(SpriteBatch batch)
        {
            //Drawing backgrounds with checking if it needs to default position property
            //Color.White is multiplied by formula to create an effect of plane going up and down
            if (position.Y < Piu.Screen.Y)
            {
                batch.Draw(scrollingBack, position, null,
                     Color.White * ((500 - Eco.Height) / 500f), 0, origin, 1, SpriteEffects.None, 0f);
            }
            batch.Draw(scrollingBack, position - size, null,
                 Color.White * ((500 - Eco.Height) / 500f), 0, origin, 1, SpriteEffects.None, 0f);

            if (position2.Y < Piu.Screen.Y)
            {
                batch.Draw(scrollingBack2, position2, null, Color.White * ((Eco.Height - 250) / 250f), 0, origin2, 1, SpriteEffects.None, 0f);
            }

            batch.Draw(scrollingBack2, position2 - size2, null,
                 Color.White * ((Eco.Height - 250) / 250f), 0, origin2, 1, SpriteEffects.None, 0f);
        }
    }
}
