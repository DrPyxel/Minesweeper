using Microsoft.Xna.Framework.Graphics;
using System;
using Minesweeper.Helpers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Minesweeper.Scenes
{
    public class TitleScreen : Scene
    {
        GillSansText titleText;
        public TitleScreen(ContentManager content, SpriteBatch spriteBatch)
        {
            titleText = new GillSansText(content, spriteBatch);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            titleText.Draw(spritebatch, "Minesweeper", Game1.ScreenCenter, Color.White, 5f, true);
            base.Draw(spritebatch);
        }
    }
}
