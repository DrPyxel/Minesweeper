﻿using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.Scenes
{
    public abstract class Scene
    {
        SpriteBatch spriteBatch;

        public Scene()
        {

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {

        }
    }
}