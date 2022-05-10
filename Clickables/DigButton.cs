using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;
using Minesweeper.Helpers;
using Minesweeper.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    class DigButton : IButton
    {
        GillSansText gillSansText;
        const int BUTTON_WIDTH = 250;
        const int BUTTON_HEIGHT = 250;
        BoardScreen _gameBoard;

        public DigButton(Vector2 location, GillSansText text, BoardScreen gameBoard, bool clickable = true)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)(Game1.ScreenCenter.X - BUTTON_WIDTH / 2 + location.X), (int)(Game1.ScreenCenter.Y - BUTTON_HEIGHT / 2 + location.Y), BUTTON_WIDTH, BUTTON_HEIGHT);
            BoundingBox = buttonBoundingBox;
            canBeClicked = clickable;
            gillSansText = text;
            _gameBoard = gameBoard;
        }

        public override void OnClick()
        {
            if (canBeClicked)
            {
                _gameBoard.SetCursorMode(CursorMode.Digging);

            }
            base.OnClick();
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
            spriteUtil.Begin();
            spriteUtil.FillRectangle(BoundingBox, Color.Black);
            spriteUtil.End();

            base.Draw(spritebatch);
        }
    }
}