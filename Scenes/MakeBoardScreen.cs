using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Scenes
{
    public class MakeBoardScreen : Scene
    {
        GillSansText gillSansText;
        public MakeBoardScreen(ContentManager content, SpriteBatch spritebatch) : base(content, spritebatch)
        {
            gillSansText = new GillSansText(content, spritebatch);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            Vector2 textDisplacement = new Vector2(0, -200f);
            gillSansText.Draw(spritebatch, "Defender: Choose Board Size", Game1.ScreenCenter + textDisplacement, Color.White, 4f, true);
            base.Draw(spritebatch);
        }
    }
}