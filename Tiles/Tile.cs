using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.Tiles
{
	public class Tile
	{
		public TileType Type { get; }
		public TileState State { get; }


		public Tile(TileType type = TileType.NoMine, TileState state = TileState.Back)
		{
			Type = type;
			State = state;
		}

		public void OnClick()
		{
			DoTileAction(Type);
		}

		public void Draw(SpriteBatch spritebatch)
		{
			switch (State)
			{
				case TileState.Front:
					break;
				case TileState.Back:
				default:
					break;
			}
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
