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

namespace Minesweeper.Clickables
{
    public class TransitionButton : IButton
    {
        const int BUTTON_WIDTH = 350;
        const int BUTTON_HEIGHT = 150;
        SceneManager _sceneManager;
        Scene _targetScene;
        Color color;

        public TransitionButton(Scene targetScene, SceneManager sceneManager, Vector2 location, bool clickable = true)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)(Game1.ScreenCenter.X - BUTTON_WIDTH / 2 + location.X), (int)(Game1.ScreenCenter.Y - BUTTON_HEIGHT / 2 + location.Y), BUTTON_WIDTH, BUTTON_HEIGHT);
            BoundingBox = buttonBoundingBox;
            canBeClicked = clickable;

            _targetScene = targetScene;
            _sceneManager = sceneManager;

            color = Color.White;
        }

        public override void OnClick()
        {
            _sceneManager.SetScene(_targetScene);
            canBeClicked = false;
            base.OnClick();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
            spriteUtil.Begin();
            spriteUtil.FillRectangle(BoundingBox, color);
            spriteUtil.End();
            base.Draw(spritebatch);
        }

        public void ChangeColor(Color color)
        {
            this.color = color;
        }
    }
}