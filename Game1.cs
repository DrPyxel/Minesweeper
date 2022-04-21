using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Minesweeper.Clickables;
using Minesweeper.Helpers;
using Minesweeper.Scenes;
using System;

namespace Minesweeper
{
    // Minesweeper
    // By: Elliot Chun and Chris Cho
    // Date: 4/8/2022
    public class Game1 : Game
    {
        public static Vector2 ScreenCenter;

        Texture2D bombTexture;
        Texture2D tileTexture;
        Texture2D tileBackTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spritebatch;

        private SceneManager _sceneManager;
        private TitleScreen _titleScreen;
        private MakeBoardScreen _makeBoardScreen;
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spritebatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bombTexture = Content.Load<Texture2D>("bomb");
            tileTexture = Content.Load<Texture2D>("tile");
            tileBackTexture = Content.Load<Texture2D>("blank");
            _sceneManager = new SceneManager(Content, _spritebatch);
            _makeBoardScreen = new MakeBoardScreen(Content, _spritebatch);
            _titleScreen = new TitleScreen(Content, _spritebatch, _sceneManager, _makeBoardScreen);

            _sceneManager.SetScene(_titleScreen);
            //_sceneManager.GetCurrentScene().Load();
        }

        protected override void Update(GameTime gameTime)
        {
            Vector2 clickPos = Vector2.Zero;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                //Only Fire Select Once it's been released
                if (touchCollection[0].State == TouchLocationState.Moved || touchCollection[0].State == TouchLocationState.Pressed)
                {
                    clickPos = touchCollection[0].Position;
                }
            }
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
                clickPos = new Vector2(mouse.Position.X, mouse.Position.Y);
            _sceneManager.Update(clickPos);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spritebatch.Begin();
            _sceneManager.Draw(_spritebatch);
            _spritebatch.End();
            base.Draw(gameTime);
        }
    }
}
