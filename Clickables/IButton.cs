using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Clickables
{
    class IButton : IClickable
    {
        public Vector2 Position;
        public Rectangle BoundingBox;
        public IButton(Vector2 position, Rectangle bb, bool clickable = false)
        {
            Position = position;
            BoundingBox = bb;
            canBeClicked = clickable;
        }
        public bool CheckCollision(Vector2 point)
        {
            if (BoundingBox.X < point.X && BoundingBox.Y < point.Y && BoundingBox.X + BoundingBox.Width > point.X && BoundingBox.Y + BoundingBox.Height > point.Y)
                return true;
            return false;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}