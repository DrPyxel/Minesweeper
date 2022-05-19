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
        GillSansText gillSansText;
        MakeBoardButton _makeBoardButton;
        GameBoardManager gameBoardManager;
        BoardScreen _targetScene;
        int boardWidth;
        int boardHeight;
        List<BoardSizeButton> boardSizeButtons = new List<BoardSizeButton>();
        Tile[,] _tiles = new Tile[0, 0];
        Texture2D _tileBackTexture, _tileFrontTexture, _mineFrontTexture;

        public MakeBoardScreen(ContentManager content, SpriteBatch spritebatch, SceneManager sceneManager, BoardScreen targetScene) : base(content, spritebatch)
        {
            gameBoardManager = new GameBoardManager(3, 3);
            gillSansText = new GillSansText(content, spritebatch);
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    int xFactor = row - 1;
                    int yFactor = column - 1;
                    int value = row + (column * 3) + 3;
                    Vector2 buttonPos = new Vector2(275 * xFactor, 275 * yFactor);
                    BoardSizeButton boardSizeButton = new BoardSizeButton(value, buttonPos, gillSansText, this);
                    boardSizeButtons.Add(boardSizeButton);
                }
            }
            targetScene._gameBoardManager = gameBoardManager;
            _makeBoardButton = new MakeBoardButton(targetScene, sceneManager, gameBoardManager, new Vector2(0, 500f));
        }

        public void Initialize(ContentManager content)
        {
            _tileBackTexture = content.Load<Texture2D>("tile");
            _tileFrontTexture = content.Load<Texture2D>("blank");
            _mineFrontTexture = content.Load<Texture2D>("bomb");
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            Vector2 textDisplacement = new Vector2(0, -500f);
            gillSansText.Draw(spritebatch, "Defender: Choose Board Size", Game1.ScreenCenter + textDisplacement, Color.White, 4f, true);
            base.Draw(spritebatch);
        }
        public override void Load()
        {
            foreach (BoardSizeButton button in boardSizeButtons)
            {
                AddButton(button);
            }
            AddButton(_makeBoardButton);
            base.Load();
        }
        public override void Unload()
        {
            _targetScene.AddTiles(_tiles);
            base.Unload();
        }
        public void SetSize(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;

            gameBoardManager = new GameBoardManager(width, height);
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    int xFactor = i - (boardWidth / 2);
                    int yFactor = j - (boardHeight / 2);
                    Vector2 buttonPos = new Vector2(55 * xFactor, 55 * yFactor);

                    Tile tile = new Tile(buttonPos, _tileFrontTexture, _tileBackTexture);
                    _tiles[i, j] = tile;


                    //float sWidth = Game1.ScreenCenter.X * 2;
                    //float sHeight = Game1.ScreenCenter.Y * 2;
                    //int xdistBetween = (int)sWidth / boardWidth;
                    //int ydistBetween = (int)sHeight / boardHeight;
                    //int xPos = (int)Game1.ScreenCenter.X + xdistBetween * (i - boardWidth / 2);
                    //int yPos = (int)Game1.ScreenCenter.Y + ydistBetween * (j - boardHeight / 2);
                    //Vector2 position = new Vector2(xPos, yPos);
                }
            }
            gameBoardManager.Setup(_tiles);
        }
    }
}