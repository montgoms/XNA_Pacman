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
        Texture2D wallu_image;
        Texture2D walld_image;
        Texture2D walll_image;
        Texture2D wallr_image;
        Texture2D walltlc_image;
        Texture2D walltrc_image;
        Texture2D wallbrc_image;
        Texture2D wallblc_image;
        Texture2D wallblci_image;
        Texture2D walltlci_image;
        Texture2D walltrci_image;
        Texture2D wallbrci_image;

        /* Default Constructor */
        public Tiles()
        {
        }

        public Tiles(Texture2D empty, Texture2D pellet, Texture2D pill, Texture2D wall,
                     Texture2D up, Texture2D down, Texture2D left, Texture2D right,
                     Texture2D tlc, Texture2D trc, Texture2D blc, Texture2D brc,
                     Texture2D blci, Texture2D brci, Texture2D tlci, Texture2D trci)
        {
            int curr_x = 0;
            int curr_y = 0;
            tile_grid = new TileState [28,36];
            empty_image = empty;
            pellet_image = pellet;
            pill_image = pill;
            wall_image = wall;
            wallu_image = up;
            walld_image = down;
            walll_image = left;
            wallr_image = right;
            walltlc_image = tlc;
            walltrc_image = trc;
            wallblc_image = blc;
            wallbrc_image = brc;
            wallblci_image = blci;
            wallbrci_image = brci;
            walltlci_image = tlci;
            walltrci_image = trci;

            /*** Initialize all tiles to Wall ***/
            for (int i = 0; i < tile_grid.GetLength(0); i++)
            {
                for (int j = 0; j < tile_grid.GetLength(1); j++)
                {
                    TileState temp = new TileState();
                    temp.pos = new Vector2(curr_x, curr_y);
                    temp.state_image = wall_image;
                    temp.state = 3;
                    tile_grid[i, j] = temp;
                    curr_y += 20;
                }
                curr_x += 20;
                curr_y = 0;
            }

            int row;
            int row2;
            int col;

            /*** Hard code in the Pellets ***/
            code_image_loop(1, 4, 12, 0, pellet_image, 1);
            code_image_loop(15, 4, 26, 0, pellet_image, 1);
            code_image_loop(1, 4, 0, 11, pellet_image, 1);
            code_image_loop(1, 23, 0, 26, pellet_image, 1);
            code_image_loop(1, 29, 0, 32, pellet_image, 1);
            code_image_loop(6, 4, 0, 29, pellet_image, 1);
            code_image_loop(21, 4, 0, 29, pellet_image, 1);
            code_image_loop(1, 8, 26, 0, pellet_image, 1);
            code_image_loop(1, 32, 26, 0, pellet_image, 1);
            code_image_loop(26, 4, 0, 11, pellet_image, 1);
            code_image_loop(26, 23, 0, 26, pellet_image, 1);
            code_image_loop(26, 29, 0, 32, pellet_image, 1);
            code_image_loop(6, 5, 0, 7, pellet_image, 1);
            code_image_loop(12, 5, 0, 7, pellet_image, 1);
            code_image_loop(15, 5, 0, 7, pellet_image, 1);
            code_image(6, 9, pellet_image, 1);
            code_image(9, 9, pellet_image, 1);
            code_image(18, 9, pellet_image, 1);
            code_image_loop(1, 11, 6, 0, pellet_image, 1);
            code_image_loop(9, 5, 12, 0, pellet_image, 1);
            code_image_loop(15, 5, 18, 0, pellet_image, 1);
            code_image_loop(22, 5, 25, 0, pellet_image, 1);
            code_image_loop(1, 23, 12, 0, pellet_image, 1);
            code_image_loop(15, 23, 26, 0, pellet_image, 1);
            code_image_loop(1, 26, 3, 0, pellet_image, 1);
            code_image_loop(6, 26, 12, 0, pellet_image, 1);
            code_image_loop(15, 26, 21, 0, pellet_image, 1);
            code_image_loop(24, 26, 26, 0, pellet_image, 1);
            code_image_loop(1, 29, 6, 0, pellet_image, 1);
            code_image_loop(9, 29, 12, 0, pellet_image, 1);
            code_image_loop(15, 29, 18, 0, pellet_image, 1);
            code_image_loop(21, 29, 26, 0, pellet_image, 1);
            code_image_loop(2, 11, 5, 0, pellet_image, 1);
            code_image_loop(22, 11, 25, 0, pellet_image, 1);
            code_image(9, 10, pellet_image, 1);
            code_image(18, 10, pellet_image, 1);
            code_image(12, 24, pellet_image, 1);
            code_image(12, 25, pellet_image, 1);
            code_image(15, 24, pellet_image, 1);
            code_image(15, 25, pellet_image, 1);
            code_image(12, 30, pellet_image, 1);
            code_image(12, 31, pellet_image, 1);
            code_image(15, 30, pellet_image, 1);
            code_image(15, 31, pellet_image, 1);
            code_image(3, 27, pellet_image, 1);
            code_image(3, 28, pellet_image, 1);
            code_image(9, 27, pellet_image, 1);
            code_image(9, 28, pellet_image, 1);
            code_image(18, 27, pellet_image, 1);
            code_image(18, 28, pellet_image, 1);
            code_image(24, 27, pellet_image, 1);
            code_image(24, 28, pellet_image, 1);
            code_image_loop(9, 11, 12, 0, pellet_image, 1);
            code_image_loop(15, 11, 18, 0, pellet_image, 1);
            code_image(18, 29, pellet_image, 1);


            /*** Hard code in the Pills ***/
            tile_grid[1, 6].state_image = pill_image;
            tile_grid[1, 6].state = 3;
            tile_grid[26, 6].state_image = pill_image;
            tile_grid[26, 6].state = 3;
            tile_grid[1, 26].state_image = pill_image;
            tile_grid[1, 26].state = 3;
            tile_grid[26, 26].state_image = pill_image;
            tile_grid[26, 26].state = 3;

            /*** Hard code in the empty space ***/
            row = 0;
            col = 0;
            for (; row <= 27; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
                tile_grid[row, col+1].state_image = empty_image;
                tile_grid[row, col+1].state = 0;
                tile_grid[row, col+2].state_image = empty_image;
                tile_grid[row, col+2].state = 0;
                tile_grid[row, col + 34].state_image = empty_image;
                tile_grid[row, col + 34].state = 0;
                tile_grid[row, col + 35].state_image = empty_image;
                tile_grid[row, col + 35].state = 0;

            }

            tile_grid[12, 12].state_image = empty_image;
            tile_grid[12, 12].state = 0;
            tile_grid[15, 12].state_image = empty_image;
            tile_grid[15, 12].state = 0;
            tile_grid[12, 13].state_image = empty_image;
            tile_grid[12, 13].state = 0;
            tile_grid[15, 13].state_image = empty_image;
            tile_grid[15, 13].state = 0;

            row = 9;
            col = 14;
            for (; row <= 18; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
            }

            row = 9;
            row2 = 18;
            col = 15;
            for (; col <= 22; col++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
                tile_grid[row2, col].state_image = empty_image;
                tile_grid[row2, col].state = 0;
            }

            row = 10;
            col = 20;
            for (; row <= 17; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
            }

            row = 18;
            row2 = 7;
            col = 17;
            for (; row <= 20; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
                tile_grid[row2, col].state_image = empty_image;
                tile_grid[row2, col].state = 0;
                row2++;
            }

            row = 22;
            row2 = 0;
            col = 17;
            for (; row <= 27; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
                tile_grid[row2, col].state_image = empty_image;
                tile_grid[row2, col].state = 0;
                row2++;
            }

            tile_grid[13, 26].state_image = empty_image;
            tile_grid[13, 26].state = 0;
            tile_grid[14, 26].state_image = empty_image;
            tile_grid[14, 26].state = 0;

            row = 11;
            col = 16;
            for (; row <= 16; row++)
            {
                tile_grid[row, col].state_image = empty_image;
                tile_grid[row, col].state = 0;
                tile_grid[row, col+1].state_image = empty_image;
                tile_grid[row, col+1].state = 0;
            }

            code_image(13, 15, empty_image, 0);
            code_image(14, 15, empty_image, 0);

            code_image_loop(11, 16, 16, 0, empty_image, 0);
            code_image_loop(11, 17, 16, 0, empty_image, 0);
            code_image_loop(11, 18, 16, 0, empty_image, 0);

            /*** Hard code in the Up Walls ***/
            tile_grid[3, 5].state_image = wallu_image;
            tile_grid[3, 5].state = 3;
            tile_grid[4, 5].state_image = wallu_image;
            tile_grid[4, 5].state = 3;

            row = 8;
            col = 5;
            for (; row <= 10; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
                tile_grid[row+9, col].state_image = wallu_image;
                tile_grid[row+9, col].state = 3;
            }

            tile_grid[23, 5].state_image = wallu_image;
            tile_grid[23, 5].state = 3;
            tile_grid[24, 5].state_image = wallu_image;
            tile_grid[24, 5].state = 3;

            tile_grid[3, 9].state_image = wallu_image;
            tile_grid[3, 9].state = 3;
            tile_grid[4, 9].state_image = wallu_image;
            tile_grid[4, 9].state = 3;

            row = 11;
            col = 9;
            for (; row <= 16; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            tile_grid[23, 9].state_image = wallu_image;
            tile_grid[23, 9].state = 3;
            tile_grid[24, 9].state_image = wallu_image;
            tile_grid[24, 9].state = 3;

            tile_grid[3, 24].state_image = wallu_image;
            tile_grid[3, 24].state = 3;
            tile_grid[4, 24].state_image = wallu_image;
            tile_grid[4, 24].state = 3;

            row = 8;
            col = 24;
            for (; row <= 10; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 9, col].state_image = wallu_image;
                tile_grid[row + 9, col].state = 3;
            }

            tile_grid[23, 24].state_image = wallu_image;
            tile_grid[23, 24].state = 3;
            tile_grid[24, 24].state_image = wallu_image;
            tile_grid[24, 24].state = 3;

            row = 11;
            col = 27;
            for (; row <= 16; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 1;
            col = 33;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 1;
            col = 12;
            for (; row <= 4; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 23;
            col = 12;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 0;
            col = 18;
            for (; row <= 4; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 23;
            col = 18;
            for (; row <= 27; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            row = 11;
            col = 21;
            for (; row <= 16; row++)
            {
                tile_grid[row, col].state_image = wallu_image;
                tile_grid[row, col].state = 3;
            }

            tile_grid[1, 27].state_image = wallu_image;
            tile_grid[1, 27].state = 3;
            tile_grid[26, 27].state_image = wallu_image;
            tile_grid[26, 27].state = 3;

            code_image(18, 12, wallu_image, 3);
            code_image(17, 12, wallu_image, 3);

            code_image(10, 12, wallu_image, 3);
            code_image(9, 12, wallu_image, 3);

            code_image(11, 15, wallu_image, 3);
            code_image(12, 15, wallu_image, 3);
            code_image(15, 15, wallu_image, 3);
            code_image(16, 15, wallu_image, 3);

            /*** Hard code in the Down Walls ***/
            row = 1;
            col = 3;
            for (; row <= 12; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
            }

            row = 15;
            col = 3;
            for (; row <= 26; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
            }

            tile_grid[3, 7].state_image = walld_image;
            tile_grid[3, 7].state = 3;
            tile_grid[4, 7].state_image = walld_image;
            tile_grid[4, 7].state = 3;

            row = 8;
            col = 7;
            for (; row <= 10; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 9, col].state_image = walld_image;
                tile_grid[row + 9, col].state = 3;
            }

            tile_grid[23, 7].state_image = walld_image;
            tile_grid[23, 7].state = 3;
            tile_grid[24, 7].state_image = walld_image;
            tile_grid[24, 7].state = 3;

            tile_grid[3, 10].state_image = walld_image;
            tile_grid[3, 10].state = 3;
            tile_grid[4, 10].state_image = walld_image;
            tile_grid[4, 10].state = 3;

            tile_grid[11, 10].state_image = walld_image;
            tile_grid[11, 10].state = 3;
            tile_grid[12, 10].state_image = walld_image;
            tile_grid[12, 10].state = 3;

            tile_grid[15, 10].state_image = walld_image;
            tile_grid[15, 10].state = 3;
            tile_grid[16, 10].state_image = walld_image;
            tile_grid[16, 10].state = 3;

            tile_grid[23, 10].state_image = walld_image;
            tile_grid[23, 10].state = 3;
            tile_grid[24, 10].state_image = walld_image;
            tile_grid[24, 10].state = 3;

            tile_grid[9, 13].state_image = walld_image;
            tile_grid[9, 13].state = 3;
            tile_grid[10, 13].state_image = walld_image;
            tile_grid[10, 13].state = 3;

            tile_grid[17, 13].state_image = walld_image;
            tile_grid[17, 13].state = 3;
            tile_grid[18, 13].state_image = walld_image;
            tile_grid[18, 13].state = 3;

            row = 0;
            col = 16;
            for (; row <= 4; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 23, col].state_image = walld_image;
                tile_grid[row + 23, col].state = 3;
            }

            row = 1;
            col = 22;
            for (; row <= 4; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 22, col].state_image = walld_image;
                tile_grid[row + 22, col].state = 3;
            }

            tile_grid[11, 22].state_image = walld_image;
            tile_grid[11, 22].state = 3;
            tile_grid[12, 22].state_image = walld_image;
            tile_grid[12, 22].state = 3;

            tile_grid[15, 22].state_image = walld_image;
            tile_grid[15, 22].state = 3;
            tile_grid[16, 22].state_image = walld_image;
            tile_grid[16, 22].state = 3;

            tile_grid[3, 25].state_image = walld_image;
            tile_grid[3, 25].state = 3;

            row = 8;
            col = 25;
            for (; row <= 10; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 9, col].state_image = walld_image;
                tile_grid[row + 9, col].state = 3;
            }

            tile_grid[24, 25].state_image = walld_image;
            tile_grid[24, 25].state = 3;

            tile_grid[26, 28].state_image = walld_image;
            tile_grid[26, 28].state = 3;
            tile_grid[1, 28].state_image = walld_image;
            tile_grid[1, 28].state = 3;
            tile_grid[15, 28].state_image = walld_image;
            tile_grid[15, 28].state = 3;
            tile_grid[16, 28].state_image = walld_image;
            tile_grid[16, 28].state = 3;
            tile_grid[11, 28].state_image = walld_image;
            tile_grid[11, 28].state = 3;
            tile_grid[12, 28].state_image = walld_image;
            tile_grid[12, 28].state = 3;

            row = 3;
            col = 31;
            for (; row <= 10; row++)
            {
                tile_grid[row, col].state_image = walld_image;
                tile_grid[row, col].state = 3;
                tile_grid[row + 14, col].state_image = walld_image;
                tile_grid[row + 14, col].state = 3;
            }

            code_image_loop(11, 19, 16, 0, walld_image, 3);

            /*** Hard code in the Left and Left Corner Walls ***/

            code_image(2, 5, walltlc_image, 3);
            code_image(2, 6, walll_image, 3);
            code_image(2, 7, wallblc_image, 3);

            code_image(7, 5, walltlc_image, 3);
            code_image(7, 6, walll_image, 3);
            code_image(7, 7, wallblc_image, 3);

            code_image(16, 5, walltlc_image, 3);
            code_image(16, 6, walll_image, 3);
            code_image(16, 7, wallblc_image, 3);

            code_image(22, 5, walltlc_image, 3);
            code_image(22, 6, walll_image, 3);
            code_image(22, 7, wallblc_image, 3);

            code_image(13, 3, wallblci_image, 3);
            code_image_loop(13, 4, 0, 6, walll_image, 3);
            code_image(13, 7, wallblc_image, 3);

            code_image(27, 3, wallblci_image, 3);
            code_image_loop(27, 4, 0, 11, walll_image, 3);
            code_image(27, 12, walltlci_image, 3);

            code_image(2, 9, walltlc_image, 3);
            code_image(2, 10, wallblc_image, 3);

            code_image(7, 9, walltlc_image, 3);
            code_image_loop(7, 10, 0, 15, walll_image, 3);
            code_image(7, 16, wallblc_image, 3);

            code_image(10, 9, walltlc_image, 3);
            code_image(10, 10, wallblc_image, 3);

            code_image(19, 9, walltlc_image, 3);
            code_image(19, 10, walll_image, 3);
            code_image(19, 11, walll_image, 3);
            code_image(19, 12, walltlci_image, 3);

            code_image(22, 9, walltlc_image, 3);
            code_image(22, 10, wallblc_image, 3);

            code_image(13, 10, wallblci_image, 3);
            code_image(13, 11, walll_image, 3);
            code_image(13, 12, walll_image, 3);
            code_image(13, 13, wallblc_image, 3);

            code_image(16, 12, walltlc_image, 3);
            code_image(16, 13, wallblc_image, 3);

            code_image(22, 12, walltlc_image, 3);
            code_image_loop(22, 13, 0, 15, walll_image, 3);
            code_image(22, 16, wallblc_image, 3);

            code_image(22, 18, walltlc_image, 3);
            code_image_loop(22, 19, 0, 21, walll_image, 3);
            code_image(22, 22, wallblc_image, 3);

            code_image(19, 13, wallblci_image, 3);
            code_image(19, 14, walll_image, 3);
            code_image(19, 15, walll_image, 3);
            code_image(19, 16, wallblc_image, 3);

            code_image(10, 15, walltlc_image, 3);
            code_image_loop(10, 16, 0, 18, walll_image, 3);
            code_image(10, 19, wallblc_image, 3);

            code_image(7, 18, walltlc_image, 3);
            code_image_loop(7, 19, 0, 21, walll_image, 3);
            code_image(7, 22, wallblc_image, 3);

            code_image(19, 18, walltlc_image, 3);
            code_image_loop(19, 19, 0, 21, walll_image, 3);
            code_image(19, 22, wallblc_image, 3);

            code_image(10, 21, walltlc_image, 3);
            code_image(10, 22, wallblc_image, 3);

            code_image(2, 24, walltlc_image, 3);
            code_image(2, 25, wallblc_image, 3);

            code_image(7, 24, walltlc_image, 3);
            code_image(7, 25, wallblc_image, 3);

            code_image(16, 24, walltlc_image, 3);
            code_image(16, 25, wallblc_image, 3);

            /*** Hard code in the Right and Right Corner Walls ***/
            code_image(11, 5, walltrc_image, 3);
            code_image(11, 6, wallr_image, 3);
            code_image(11, 7, wallbrc_image, 3);

            code_image(25, 5, walltrc_image, 3);
            code_image(25, 6, wallr_image, 3);
            code_image(25, 7, wallbrc_image, 3);

            code_image(0, 3, wallbrci_image, 3);
            code_image_loop(0, 4, 0, 11, wallr_image, 3);
            code_image(0, 12, walltrci_image, 3);

            code_image(5, 5, walltrc_image, 3);
            code_image(5, 6, wallr_image, 3);
            code_image(5, 7, wallbrc_image, 3);

            code_image(14, 3, wallbrci_image, 3);
            code_image_loop(14, 4, 0, 6, wallr_image, 3);
            code_image(14, 7, wallbrc_image, 3);

            code_image(20, 5, walltrc_image, 3);
            code_image(20, 6, wallr_image, 3);
            code_image(20, 7, wallbrc_image, 3);

            code_image(5, 9, walltrc_image, 3);
            code_image(5, 10, wallbrc_image, 3);

            code_image(8, 9, walltrc_image, 3);
            code_image(8, 10, wallr_image, 3);
            code_image(8, 11, wallr_image, 3);
            code_image(8, 13, wallbrci_image, 3);
            code_image(8, 14, wallr_image, 3);
            code_image(8, 15, wallr_image, 3);
            code_image(8, 16, wallbrc_image, 3);

            code_image(17, 9, walltrc_image, 3);
            code_image(17, 10, wallbrc_image, 3);

            code_image(25, 9, walltrc_image, 3);
            code_image(25, 10, wallbrc_image, 3);

            code_image(14, 10, wallbrci_image, 3);
            code_image(14, 11, wallr_image, 3);
            code_image(14, 12, wallr_image, 3);
            code_image(14, 13, wallbrc_image, 3);

            code_image(8, 12, walltrci_image, 3);

            code_image(11, 12, walltrc_image, 3);
            code_image(11, 13, wallbrc_image, 3);

            code_image(5, 12, walltrc_image, 3);
            code_image_loop(5, 13, 0, 15, wallr_image, 3);
            code_image(5, 16, wallbrc_image, 3);

            code_image(5, 18, walltrc_image, 3);
            code_image_loop(5, 19, 0, 21, wallr_image, 3);
            code_image(5, 22, wallbrc_image, 3);

            code_image(20, 9, walltrc_image, 3);
            code_image_loop(20, 10, 0, 15, wallr_image, 3);
            code_image(20, 16, wallbrc_image, 3);

            code_image(17, 15, walltrc_image, 3);
            code_image_loop(17, 16, 0, 18, wallr_image, 3);
            code_image(17, 19, wallbrc_image, 3);

            code_image(8, 18, walltrc_image, 3);
            code_image_loop(8, 19, 0, 21, wallr_image, 3);
            code_image(8, 22, wallbrc_image, 3);

            code_image(20, 18, walltrc_image, 3);
            code_image_loop(20, 19, 0, 21, wallr_image, 3);
            code_image(20, 22, wallbrc_image, 3);

            code_image(17, 21, walltrc_image, 3);
            code_image(17, 22, wallbrc_image, 3);

            code_image(25, 24, walltrc_image, 3);
            code_image(25, 25, wallbrc_image, 3);

            code_image(20, 24, walltrc_image, 3);
            code_image(20, 25, wallbrc_image, 3);

            code_image(11, 24, walltrc_image, 3);
            code_image(11, 25, wallbrc_image, 3);

        }

        private void code_image(int row, int col, Texture2D image, int state){
            tile_grid[row, col].state_image = image;
            tile_grid[row, col].state = state;
        }

        private void code_image_loop(int row, int col, int row_range, int col_range, Texture2D image, int state)
        {
            if (col_range == 0)
            {
                for (; row <= row_range; row++)
                {
                    tile_grid[row, col].state_image = image;
                    tile_grid[row, col].state = state;
                }
            }
            else if (row_range == 0)
            {
                for (; col <= col_range; col++)
                {
                    tile_grid[row, col].state_image = image;
                    tile_grid[row, col].state = state;
                }
            }
        }
    }
}
