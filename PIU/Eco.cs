using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PIU
{
    //Our game world HandleInput-Update-Draw module
    class Eco
    {
        Jet jet;
        ScrollBack scrollBack;
        private static int height;

        public Eco(ContentManager Content)
        {
            //To initialize plane, background and plane height
            jet = new Jet(Content);
            scrollBack = new ScrollBack(Content);
            height = 10;
        }

        public void HandleInput(InputHelper inputHelper)
        {
            //To handle input for plane
            jet.HandleInput(inputHelper);
        }

        public void Update(GameTime gameTime)
        {
            //To update backgrounds
            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            scrollBack.Update(elapsed * (100 + jet.Velocity*5));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //To draw backgrounds and plane
            spriteBatch.Begin();
            scrollBack.Draw(spriteBatch);
            jet.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public Jet Jet
        {
            get { return jet; }
        }

        public ScrollBack ScrollBack
        {
            get { return scrollBack; }
        }

        public static int Height
        {
            get { return height; }
            set { height = value; }
        }

    }
}
