using Minesweeper.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Minesweeper
{
    public class GameBoardManager
    {
        private int numMines;
        private int boardWidth;
        private int boardHeight;
        public Tile[,] _tiles = new Tile[0, 0];
        

        public GameBoardManager(int width, int height)
        {
            SetSize(width, height);
        }
        public int GetWidth()
        {
            return boardWidth;
        }
        public int GetHeight()
        {
            return boardHeight;
        }

        public void Setup(Tile[,] tiles)
        {
            numMines = boardWidth * boardHeight / 4;
            _tiles = new Tile[boardWidth, boardHeight];
            _tiles = tiles;

            while(numMines > 0)
            {
                Random rand = new Random();
                int mineX = rand.Next(boardWidth);
                int mineY = rand.Next(boardHeight);

                _tiles[mineX, mineY].ChangeTileType(TileType.Mine);
                numMines--;
            }
        }

        public void DrawTiles(SpriteBatch spritebatch)
        {
            foreach (Tile tile in _tiles)
            {
                tile.Draw(spritebatch);
            }
        }

        private void SetSize(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;
        }
    }
}