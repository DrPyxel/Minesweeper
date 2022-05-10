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
        public GameBoardManager gameBoardManager;
        List<BoardSizeButton> boardSizeButtons = new List<BoardSizeButton>();
        
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
                    BoardSizeButton boardSizeButton = new BoardSizeButton(value, buttonPos, gillSansText, gameBoardManager, this);
                    boardSizeButtons.Add(boardSizeButton);
                }
            }
            targetScene._gameBoardManager = gameBoardManager;
            _makeBoardButton = new MakeBoardButton(targetScene, sceneManager, gameBoardManager, new Vector2(0, 500f));

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
    }
}