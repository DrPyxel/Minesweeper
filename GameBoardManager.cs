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
        Tile[,] _tiles = new Tile[0, 0];
        Texture2D _tileBackTexture, _tileFrontTexture, _mineFrontTexture;

        public GameBoardManager(Texture2D tileBackTexture, Texture2D tileFrontTexture, Texture2D mineFrontTexture)
        {
            _tileBackTexture = tileBackTexture;
            _tileFrontTexture = tileFrontTexture;
            _mineFrontTexture = mineFrontTexture;
            GameBoardManager(3, 3);
        }

        public GameBoardManager(int width, int height, List<Tile> tiles)
        {
            boardWidth = width;
            boardHeight = height;

            Setup(tiles);
        }
        public int GetWidth()
        {
            return boardWidth;
        }
        public int GetHeight()
        {
            return boardHeight;
        }

        public void Setup(List<Tile> tiles)
        {
            numMines = boardWidth * boardHeight / 4;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Tile tile = tiles.get(i + j);
                    _tiles[i, j] = tile;
                    

                    //float sWidth = Game1.ScreenCenter.X * 2;
                    //float sHeight = Game1.ScreenCenter.Y * 2;
                    //int xdistBetween = (int)sWidth / boardWidth;
                    //int ydistBetween = (int)sHeight / boardHeight;
                    //int xPos = (int)Game1.ScreenCenter.X + xdistBetween * (i - boardWidth / 2);
                    //int yPos = (int)Game1.ScreenCenter.Y + ydistBetween * (j - boardHeight / 2);
                    //Vector2 position = new Vector2(xPos, yPos);
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