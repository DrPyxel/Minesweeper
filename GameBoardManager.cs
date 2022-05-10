using Minesweeper.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        public int GetWidth()
        {
            return boardWidth;
        }
        public int GetHeight()
        {
            return boardHeight;
        }

        public void Setup()
        {
            numMines = boardWidth * boardHeight / 4;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    float sWidth = Game1.ScreenCenter.X * 2;
                    float sHeight = Game1.ScreenCenter.Y * 2;
                    int xdistBetween = (int)sWidth / boardWidth;
                    int ydistBetween = (int)sHeight / boardHeight;
                    
                    int xPos = (int)Game1.ScreenCenter.X + xdistBetween * (i - boardWidth / 2);
                    int yPos = (int)Game1.ScreenCenter.Y + ydistBetween * (j - boardHeight / 2);
                    Vector2 position = new Vector2(xPos, yPos);
                    tiles[i, j] = new Tile(position);

                }
            }
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