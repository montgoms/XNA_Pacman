using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacManGame
{
    public class TileState
    {
        public Vector2 pos;
        public Texture2D state_image;
        public int state; //0 = empty, 1 = pellet, 2 = pill, 3 = wall 

        /* Default Constructor */
        public TileState()
        {
            pos = new Vector2(0, 0);
            state = 1;
        }

    }

    public class Tiles
    {
        public TileState [,] tile_grid;
        Texture2D empty_image;
        Texture2D pellet_image;
        Texture2D pill_image;
        Texture2D wall_image;

        /* Default Constructor */
        public Tiles()
        {
        }

        public Tiles(Texture2D empty, Texture2D pellet)
        {
            int curr_x = 0;
            int curr_y = 0;
            tile_grid = new TileState [28,36];
            empty_image = empty;
            pellet_image = pellet;

            for (int i = 0; i < tile_grid.GetLength(0); i++)
            {
                for (int j = 0; j < tile_grid.GetLength(1); j++)
                {
                    TileState temp = new TileState();
                    temp.pos = new Vector2(curr_x, curr_y);
                    temp.state_image = empty_image;
                    temp.state = 0;
                    tile_grid[i, j] = temp;
                    curr_y += 20;
                }
                curr_x += 20;
                curr_y = 0;
            }

            /*** Hard code in the Pellets ***/
            int row = 1;
            int col = 4;
            for (; row <= 12; row++)
            {
                tile_grid[row,col].state_image = pellet_image;
                tile_grid[row,col].state = 1;
            }

            row = 15;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 1;
            for (; col <= 11; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            col = 23;
            for (; col <= 26; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            col = 29;
            for (; col <= 32; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 6;
            int row2 = 21;
            col = 4;
            for (; col <= 29; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
                tile_grid[row2, col].state_image = pellet_image;
                tile_grid[row2, col].state = 1;
            }

            row = 1;
            col = 8;
            int col2 = 32;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
                tile_grid[row, col2].state_image = pellet_image;
                tile_grid[row, col2].state = 1;
            }

            row = 26;
            col = 4;
            for (; col <= 11; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            col = 23;
            for (; col <= 26; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            col = 29;
            for (; col <= 32; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 6;
            row2 = 12;
            int row3 = 15;
            col = 5;
            for (; col <= 7; col++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
                tile_grid[row2, col].state_image = pellet_image;
                tile_grid[row2, col].state = 1;
                tile_grid[row3, col].state_image = pellet_image;
                tile_grid[row3, col].state = 1;
            }


            tile_grid[6, 9].state_image = pellet_image;
            tile_grid[6, 10].state = 1;
            tile_grid[9, 9].state_image = pellet_image;
            tile_grid[9, 10].state = 1;
            tile_grid[18, 9].state_image = pellet_image;
            tile_grid[18, 10].state = 1;

            row = 1;
            col = 11;
            for (; row <= 6; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 9;
            for (; row <= 12; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 15;
            for (; row <= 18; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 22;
            for (; row <= 25; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 1;
            col = 23;
            for (; row <= 12; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 15;
            col = 23;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 1;
            col = 26;
            for (; row <= 3; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 6;
            col = 26;
            for (; row <= 12; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 15;
            col = 26;
            for (; row <= 21; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 24;
            col = 26;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 1;
            col = 29;
            for (; row <= 6; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 9;
            col = 29;
            for (; row <= 12; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 15;
            col = 29;
            for (; row <= 18; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            row = 21;
            col = 29;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = pellet_image;
                tile_grid[row, col].state = 1;
            }

            tile_grid[9, 10].state_image = pellet_image;
            tile_grid[9, 10].state = 1;
            tile_grid[18, 10].state_image = pellet_image;
            tile_grid[18, 10].state = 1;

            tile_grid[12, 24].state_image = pellet_image;
            tile_grid[12, 24].state = 1;
            tile_grid[12, 25].state_image = pellet_image;
            tile_grid[12, 25].state = 1;

            tile_grid[12, 24].state_image = pellet_image;
            tile_grid[12, 24].state = 1;
            tile_grid[12, 25].state_image = pellet_image;
            tile_grid[12, 25].state = 1;
            tile_grid[15, 24].state_image = pellet_image;
            tile_grid[15, 24].state = 1;
            tile_grid[15, 25].state_image = pellet_image;
            tile_grid[15, 25].state = 1;

            tile_grid[12, 30].state_image = pellet_image;
            tile_grid[12, 30].state = 1;
            tile_grid[12, 31].state_image = pellet_image;
            tile_grid[12, 31].state = 1;
            tile_grid[15, 30].state_image = pellet_image;
            tile_grid[15, 30].state = 1;
            tile_grid[15, 31].state_image = pellet_image;
            tile_grid[15, 31].state = 1;


            tile_grid[3, 27].state_image = pellet_image;
            tile_grid[3, 27].state = 1;
            tile_grid[3, 28].state_image = pellet_image;
            tile_grid[3, 28].state = 1;
            tile_grid[9, 27].state_image = pellet_image;
            tile_grid[9, 27].state = 1;
            tile_grid[9, 28].state_image = pellet_image;
            tile_grid[9, 28].state = 1;
            tile_grid[18, 27].state_image = pellet_image;
            tile_grid[18, 27].state = 1;
            tile_grid[18, 28].state_image = pellet_image;
            tile_grid[18, 28].state = 1;
            tile_grid[24, 27].state_image = pellet_image;
            tile_grid[24, 27].state = 1;
            tile_grid[24, 28].state_image = pellet_image;
            tile_grid[24, 28].state = 1;

            /*** Hard code in the Pills ***/


        }
    }
}
