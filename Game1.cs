using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minesweeper.Helpers;
using Minesweeper.Scenes;

namespace Minesweeper
{
    public class Game1 : Game
    {
        public static Vector2 ScreenCenter;

        Texture2D bombTexture;
        Texture2D tileTexture;
        Texture2D tileBackTexture;
        GillSansText gillSansText;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SceneManager sceneManager;
        private GameBoardManager gameBoard;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenCenter = new Vector2(GraphicsDevice.Adapter.CurrentDisplayMode.Width / 2f, GraphicsDevice.Adapter.CurrentDisplayMode.Height / 2f);
            sceneManager = new SceneManager(Content, _spriteBatch);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bombTexture = Content.Load<Texture2D>("bomb");
            tileTexture = Content.Load<Texture2D>("tile");
            tileBackTexture = Content.Load<Texture2D>("blank");
            gillSansText = new GillSansText(Content, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            sceneManager.GetCurrentScene().Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
