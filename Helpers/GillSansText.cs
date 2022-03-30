using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.Helpers
{
    public class GillSansText
    {
        SpriteFont font;

        public GillSansText(ContentManager content, SpriteBatch spriteBatch)
        {
            font = content.Load<SpriteFont>("GillSans");
        }

        public void Draw(SpriteBatch spritebatch, string text, Vector2 position, Color color, float scale, bool center)
        {
            Vector2 stringSize = font.MeasureString(text) * 0.5f;
            Vector2 stringPos = center ? position - (stringSize * scale) : position;
            spritebatch.DrawString(font, text, stringPos, color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}