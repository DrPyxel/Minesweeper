using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;
using Minesweeper.Helpers;

namespace Minesweeper.Tiles
{
	public class Tile : IButton
	{
		const int BUTTON_WIDTH = 50;
		const int BUTTON_HEIGHT = 50;

		public TileType Type { get; }
		public TileState State { get; }


		public Tile(Vector2 location, bool clickable = true, TileType type = TileType.NoMine, TileState state = TileState.Back)
		{
			Rectangle buttonBoundingBox = new Rectangle((int)(Game1.ScreenCenter.X - BUTTON_WIDTH / 2 + location.X), (int)(Game1.ScreenCenter.Y - BUTTON_HEIGHT / 2 + location.Y), BUTTON_WIDTH, BUTTON_HEIGHT);
			BoundingBox = buttonBoundingBox;

			Type = type;
			State = state;
		}

		public override void OnClick()
		{
			DoTileAction(Type);
			base.OnClick();
		}

		public override void Draw(SpriteBatch spritebatch)
		{
			SpriteUtils spriteUtil = new SpriteUtils(spritebatch.GraphicsDevice);
			spriteUtil.Begin();
			spriteUtil.FillRectangle(BoundingBox, Color.White);
			spriteUtil.End();
			switch (State)
			{
				case TileState.Front:
					break;
				case TileState.Back:
				default:
					break;
			}
			base.Draw(spritebatch);
		}

		private void DoTileAction(TileType type)
		{
			switch (type)
			{
				case TileType.Mine:
					break;
				case TileType.NoMine:
				default:
					break;
			}
		}
	}
}
