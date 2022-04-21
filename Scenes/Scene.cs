using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;

namespace Minesweeper.Scenes
{
    public abstract class Scene
    {
        ButtonManager _buttonManager;

        public Scene(ContentManager content, SpriteBatch spritebatch)
        {
            ButtonManager buttonManager = new ButtonManager(content, spritebatch);
            _buttonManager = buttonManager;
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            _buttonManager.DrawButtons();
        }
        public virtual void Update(Vector2 clickpos)
        {
            _buttonManager.Update(clickpos);
        }
        public virtual void Load()
        {

        }
        public virtual void Unload()
        {
            _buttonManager.Clear();
        }
        public void AddButton(IButton button)
        {
            _buttonManager.AddButton(button);
        }
        public void RemoveButton(IButton button)
        {
            _buttonManager.RemoveButton(button);
        }
    }
}