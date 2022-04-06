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
        TransitionButton transitionButton;

        public TitleScreen(SceneManager sceneManager, ContentManager content, SpriteBatch spritebatch)
        {
            Rectangle buttonBoundingBox = new Rectangle((int)Game1.ScreenCenter.X, (int)Game1.ScreenCenter.Y, 100, 100);
            titleText = new GillSansText(content, spritebatch);
            transitionButton = new TransitionButton(sceneManager, buttonBoundingBox, this);
            
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            titleText.Draw(spritebatch, "Minesweeper", Game1.ScreenCenter, Color.White, 5f, true);
            transitionButton.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
