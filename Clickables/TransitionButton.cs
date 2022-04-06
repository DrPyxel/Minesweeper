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
        SceneManager _sceneManager;
        Scene _targetScene;
        public TransitionButton(SceneManager sceneManager, Rectangle bb, Scene targetScene, bool clickable = true) : base(bb, clickable)
        {
            BoundingBox = bb;
            canBeClicked = clickable;

            _sceneManager = sceneManager;
            _targetScene = targetScene;
        }
        public override void ClickEvent()
        {
            _sceneManager.SetScene(_targetScene);
            canBeClicked = false;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
            spriteUtil.Begin();
            spriteUtil.FillRectangle(BoundingBox, Color.White);
            spriteUtil.End();
            base.Draw(spritebatch);
        }
    }
}