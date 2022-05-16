using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Helpers;
using Minesweeper.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Clickables
{
    public class BoardSizeButton : IButton
    {
        GillSansText gillSansText;
        const int BUTTON_WIDTH = 250;
        const int BUTTON_HEIGHT = 250;
        MakeBoardScreen makeBoard;
        int value { get; }
        Color color;

        public BoardSizeButton(int value, Vector2 location, GillSansText text, MakeBoardScreen makeBoardScreen, bool clickable = true)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)(Game1.ScreenCenter.X - BUTTON_WIDTH / 2 + location.X), (int)(Game1.ScreenCenter.Y - BUTTON_HEIGHT / 2 + location.Y), BUTTON_WIDTH, BUTTON_HEIGHT);
            BoundingBox = buttonBoundingBox;
            canBeClicked = clickable;
            gillSansText = text;
            makeBoard = makeBoardScreen;
            this.value = value;
            color = Color.LightSlateGray;
        }

        public override void OnClick()
        {
            makeBoard.SetSize(value, value);
            base.OnClick();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
            spriteUtil.Begin();
            spriteUtil.FillRectangle(BoundingBox, color);
            gillSansText.Draw(spritebatch, value.ToString(), BoundingBox.Center.ToVector2(), Color.White, 5f, true);
            spriteUtil.End();
            base.Draw(spritebatch);
        }

    }
}