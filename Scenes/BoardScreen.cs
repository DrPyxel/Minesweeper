using Minesweeper.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Helpers;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Minesweeper.Scenes
{
    public class BoardScreen : Scene
    {
        Texture2D bombTexture;
        Texture2D tileTexture;
        Texture2D tileBackTexture;

        GillSansText gillSansText;
        CursorMode cursorMode;
        FlagButton flagButton;
        DigButton digButton;
        List<Tile> tiles = new List<Tile>();
        public GameBoardManager _gameBoardManager;

        public BoardScreen(ContentManager content, SpriteBatch spritebatch, GameBoardManager gameBoardManager) : base(content, spritebatch)
        {
            bombTexture = Game1.bombTexture;
            tileTexture = Game1.tileTexture;
            tileBackTexture = Game1.tileBackTexture;
            gillSansText = new GillSansText(content, spritebatch);
            _gameBoardManager = gameBoardManager;
            flagButton = new FlagButton(new Vector2(275f, -500f), gillSansText, this);
            digButton = new DigButton(new Vector2(-275f, -500f), gillSansText, this);
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            Vector2 textDisplacement = new Vector2(0, -500f);
            gillSansText.Draw(spritebatch, $"{_gameBoardManager.GetHeight()}x{_gameBoardManager.GetWidth()} Board", Game1.ScreenCenter + textDisplacement, Color.White, 4f, true);
            base.Draw(spritebatch);
        }
        public override void Load()
        {
            int boardWidth = _gameBoardManager.GetWidth();
            int boardHeight = _gameBoardManager.GetHeight();
            for (int column = 0; column < boardWidth; column++)
            {
                for (int row = 0; row < boardWidth; row++)
                {
                    int xFactor = row - boardWidth / 2;
                    int yFactor = column - boardHeight / 2;
                    Vector2 buttonPos = new Vector2(275 * xFactor, 275 * yFactor);
                    Tile tile = new Tile(buttonPos);
                    tiles.Add(tile);
                }
            }

            foreach (Tile tile in tiles)
            {
                AddButton(tile);
            }
            AddButton(flagButton);
            AddButton(digButton);
            base.Load();
        }
        public void SetCursorMode(CursorMode mode)
        {
            cursorMode = mode;
        }
    }
}