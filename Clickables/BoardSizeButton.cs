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
using Minesweeper.Tiles;
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
        Color color;
        TileState tileState;
        TileType tileType;

        public BoardSizeButton(bool isMine, Vector2 location, GillSansText text, MakeBoardScreen makeBoardScreen, bool clickable = true)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)(Game1.ScreenCenter.X - BUTTON_WIDTH / 2 + location.X), (int)(Game1.ScreenCenter.Y - BUTTON_HEIGHT / 2 + location.Y), BUTTON_WIDTH, BUTTON_HEIGHT);
            BoundingBox = buttonBoundingBox;
            canBeClicked = clickable;
            gillSansText = text;
            makeBoard = makeBoardScreen;
            
            color = Color.LightSlateGray;
            tileState = TileState.Back;
            tileType = TileType.NoMine;
            if (isMine)
                tileType = TileType.Mine;
        }

        public override void OnClick()
        {
            //makeBoard.SetSize(value, value);
            tileState = TileState.Front;
            if (tileType == TileType.Mine)
                makeBoard.Lose();
            base.OnClick();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
            spriteUtil.Begin();
            spriteUtil.FillRectangle(BoundingBox, color);
            if (tileState == TileState.Front)
            {
                gillSansText.Draw(spritebatch, tileType == TileType.NoMine ? "" : "Mine", BoundingBox.Center.ToVector2(), Color.Black, 5f, true);
                color = Color.White;
            }
            spriteUtil.End();
            base.Draw(spritebatch);
        }

    }
}