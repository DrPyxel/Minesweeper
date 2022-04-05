using Microsoft.Xna.Framework.Graphics;
using System;
using Minesweeper.Helpers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Minesweeper.Clickables;

namespace Minesweeper.Scenes
{
    public class TitleScreen : Scene
    {
        GillSansText titleText;
        TransitionButton transitionButton;

        public TitleScreen(SceneManager sceneManager, ContentManager content, SpriteBatch spritebatch)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y, 100, 100);
            _spriteBatch = spritebatch;
            titleText = new GillSansText(content, _spriteBatch);
            transitionButton = new TransitionButton(sceneManager, buttonBoundingBox, this);
            
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            titleText.Draw(_spriteBatch, "Minesweeper", Game1.ScreenCenter, Color.White, 5f, true);
            transitionButton.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
