using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Clickables
{

    public class ButtonManager
    {
        ContentManager Content;
        SpriteBatch Spritebatch;
        List<IButton> buttons = new List<IButton>();

        public ButtonManager(ContentManager content, SpriteBatch spriteBatch)
        {
            Content = content;
            Spritebatch = spriteBatch;
        }

        public void Update()
        {
            foreach(IButton button in buttons)
            {
                button.Update();
            }
        }

        public void DrawButtons()
        {
            foreach(IButton button in buttons)
            {
                button.Draw(Spritebatch);
            }
        }

        public IButton AddButton(IButton button)
        {
            buttons.Add(button);
            return button;
        }

        public bool RemoveButton(IButton button)
        {
            return buttons.Remove(button);
        }
    }
}