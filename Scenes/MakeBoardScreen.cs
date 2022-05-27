using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;
using Minesweeper.Helpers;
using Minesweeper.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Scenes
{
    public class MakeBoardScreen : Scene
    {
        const int BOARD_SIZE = 3;

        GillSansText gillSansText;
        MakeBoardButton _makeBoardButton;
        GameBoardManager gameBoardManager;
        int boardWidth;
        int boardHeight;
        List<BoardSizeButton> boardSizeButtons = new List<BoardSizeButton>();
        Tile[,] _tiles = new Tile[0, 0];
        Texture2D _tileBackTexture, _tileFrontTexture, _mineFrontTexture;
        bool lose;
        public MakeBoardScreen(ContentManager content, SpriteBatch spritebatch, SceneManager sceneManager, BoardScreen targetScene) : base(content, spritebatch)
        {
            gameBoardManager = new GameBoardManager(3, 3);
            gillSansText = new GillSansText(content, spritebatch);
            int numMines = BOARD_SIZE * BOARD_SIZE / 4;
            for (int column = 0; column < BOARD_SIZE; column++)
            {
                for (int row = 0; row < BOARD_SIZE; row++)
                {
                    int xFactor = row - BOARD_SIZE / 2;
                    int yFactor = column - BOARD_SIZE / 2;
                    bool isMine = false;
                    Random random = new Random();
                    if (numMines > 0 && random.NextDouble() < 0.25)
                    {
                        isMine = true;
                        numMines--;
                    }

                    int BUTTON_SIZE = 375 - 20 * BOARD_SIZE;
                    Vector2 buttonPos = new Vector2(BUTTON_SIZE * xFactor, BUTTON_SIZE * yFactor);
                    BoardSizeButton boardSizeButton = new BoardSizeButton(isMine, buttonPos, gillSansText, this);
                    boardSizeButtons.Add(boardSizeButton);
                }
            }
            targetScene._gameBoardManager = gameBoardManager;
            lose = false;
            //_makeBoardButton = new MakeBoardButton(targetScene, sceneManager, gameBoardManager, new Vector2(0, 500f));
        }

        public void Initialize(ContentManager content)
        {
            _tileBackTexture = content.Load<Texture2D>("tile");
            _tileFrontTexture = content.Load<Texture2D>("blank");
            _mineFrontTexture = content.Load<Texture2D>("bomb");
        }
        public override void Update(Vector2 clickpos)
        {

            base.Update(clickpos);
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            Vector2 textDisplacement = new Vector2(0, -700f);
            string statusText = lose ? "You lose." : "";
            gillSansText.Draw(spritebatch, statusText, Game1.ScreenCenter + textDisplacement, Color.White, 4f, true);
            base.Draw(spritebatch);
        }
        public override void Load()
        {
            foreach (BoardSizeButton button in boardSizeButtons)
            {
                AddButton(button);
            }
            //AddButton(_makeBoardButton);
            base.Load();
        }
        public override void Unload()
        {
            base.Unload();
        }

        public void Lose()
        {
            lose = true;
        }
    }
}