using Minesweeper.Tiles;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper
{
    public class GameBoardManager
    {
        private int numMines;
        private int boardWidth;
        private int boardHeight;
        Tile[,] tiles = new Tile[0, 0];

        public GameBoardManager(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;
            tiles = new Tile[width, height];

            Setup();
        }

        public void Setup()
        {
            numMines = boardWidth * boardHeight / 10;
        }

        public void DrawTiles(SpriteBatch spritebatch)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(spritebatch);
            }
        }
    }
}