using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Minesweeper.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Clickables
{
    class MakeBoardButton : TransitionButton
    {
        GameBoardManager _gameBoardManager;
        public MakeBoardButton(Scene targetScene, SceneManager sceneManager, GameBoardManager gameBoardManager, Vector2 location, bool clickable = true) : base(targetScene, sceneManager, location, clickable)
        {
            _gameBoardManager = gameBoardManager;
        }

        public override void OnClick()
        {
            base.OnClick();
        }
    }
}