using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;
using Minesweeper.Helpers;

namespace Minesweeper.Scenes
{
    public class TitleScreen : Scene
    {
        GillSansText titleText;
        TransitionButton _transitionButton;
        SceneManager _sceneManager;
        Scene targetScene;

        public TitleScreen(ContentManager content, SpriteBatch spritebatch, SceneManager sceneManager, Scene targetScene) : base(content, spritebatch)
        {
            titleText = new GillSansText(content, spritebatch);
            _transitionButton = new TransitionButton(targetScene, sceneManager, new Vector2(0, 200f));
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            titleText.Draw(spritebatch, "Minesweeper", Game1.ScreenCenter, Color.White, 5f, true);
            
            base.Draw(spritebatch);
        }
        public override void Load()
        {
            AddButton(_transitionButton);
            base.Load();
        }
        public override void Unload()
        {
            RemoveButton(_transitionButton);
            base.Unload();
        }
    }
}
