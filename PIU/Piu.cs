using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PIU
{

    //Main Initialize-Load-Update-Draw game module
    public class Piu : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputHelper inputHelper;
        static Eco eco;
        static Point screen;

        public Piu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            inputHelper = new InputHelper();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            eco = new Eco(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update();
            eco.HandleInput(inputHelper);
            eco.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            eco.Draw(gameTime,spriteBatch);
        }

        public static Point Screen
        {
            get { return screen; }
        }

        private static Eco Eco
        {
            get { return eco; }
        }
    }
}
