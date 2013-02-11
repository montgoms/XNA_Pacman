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
            /*** Initialize Member Variables ***/

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

            /*** Initialize all tiles to Empty ***/

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

            code_image(1, 6, pill_image, 2);
            code_image(26, 6, pill_image, 2);
            code_image(1, 26, pill_image, 2);
            code_image(26, 26, pill_image, 2);

            /*** Hard code in the Standard Walls ***/

            code_image(3, 6, wall_image, 3);
            code_image(4, 6, wall_image, 3);
            code_image_loop(8, 6, 10, 0, wall_image, 3);
            code_image(23, 6, wall_image, 3);
            code_image(24, 6, wall_image, 3);
            code_image_loop(17, 6, 19, 0, wall_image, 3);

            /*** Hard code in the Up Walls ***/

            code_image(3, 5, wallu_image, 3);
            code_image(4, 5, wallu_image, 3);
            code_image_loop(8, 5, 10, 0, wallu_image, 3);
            code_image_loop(17, 5, 19, 0, wallu_image, 3);
            code_image(23, 5, wallu_image, 3);
            code_image(24, 5, wallu_image, 3);
            code_image(3, 9, wallu_image, 3);
            code_image(4, 9, wallu_image, 3);
            code_image_loop(11, 9, 16, 0, wallu_image, 3);
            code_image(23, 9, wallu_image, 3);
            code_image(24, 9, wallu_image, 3);
            code_image(3, 24, wallu_image, 3);
            code_image(4, 24, wallu_image, 3);
            code_image_loop(8, 24, 10, 0, wallu_image, 3);
            code_image_loop(17, 24, 19, 0, wallu_image, 3);
            code_image(23, 24, wallu_image, 3);
            code_image(24, 24, wallu_image, 3);
            code_image_loop(11, 27, 16, 0, wallu_image, 3);
            code_image_loop(1, 33, 26, 0, wallu_image, 3);
            code_image_loop(1, 12, 4, 0, wallu_image, 3);
            code_image_loop(23, 12, 26, 0, wallu_image, 3);
            code_image_loop(0, 18, 4, 0, wallu_image, 3);
            code_image_loop(23, 18, 27, 0, wallu_image, 3);
            code_image_loop(11, 21, 16, 0, wallu_image, 3);
            code_image(1, 27, wallu_image, 3);
            code_image(26, 27, wallu_image, 3);
            code_image(18, 12, wallu_image, 3);
            code_image(17, 12, wallu_image, 3);
            code_image(10, 12, wallu_image, 3);
            code_image(9, 12, wallu_image, 3);
            code_image(11, 15, wallu_image, 3);
            code_image(12, 15, wallu_image, 3);
            code_image(15, 15, wallu_image, 3);
            code_image(16, 15, wallu_image, 3);
            code_image_loop(3, 30, 6, 0, wallu_image, 3);
            code_image(9, 30, wallu_image, 3);
            code_image(10, 30, wallu_image, 3);
            code_image_loop(21, 30, 24, 0, wallu_image, 3);
            code_image(17, 30, wallu_image, 3);
            code_image(18, 30, wallu_image, 3);

            /*** Hard code in the Down Walls ***/

            code_image_loop(1, 3, 12, 0, walld_image, 3);
            code_image_loop(15, 3, 26, 0, walld_image, 3);
            code_image(3, 7, walld_image, 3);
            code_image(4, 7, walld_image, 3);
            code_image_loop(8, 7, 10, 0, walld_image, 3);
            code_image_loop(17, 7, 19, 0, walld_image, 3);
            code_image(23, 7, walld_image, 3);
            code_image(24, 7, walld_image, 3);
            code_image(3, 10, walld_image, 3);
            code_image(4, 10, walld_image, 3);
            code_image(11, 10, walld_image, 3);
            code_image(12, 10, walld_image, 3);
            code_image(15, 10, walld_image, 3);
            code_image(16, 10, walld_image, 3);
            code_image(23, 10, walld_image, 3);
            code_image(24, 10, walld_image, 3);
            code_image(9, 13, walld_image, 3);
            code_image(10, 13, walld_image, 3);
            code_image(17, 13, walld_image, 3);
            code_image(18, 13, walld_image, 3);
            code_image_loop(0, 16, 4, 0, walld_image, 3);
            code_image_loop(23, 16, 27, 0, walld_image, 3);
            code_image_loop(1, 22, 4, 0, walld_image, 3);
            code_image_loop(23, 22, 26, 0, walld_image, 3);
            code_image(11, 22, walld_image, 3);
            code_image(12, 22, walld_image, 3);
            code_image(15, 22, walld_image, 3);
            code_image(16, 22, walld_image, 3);
            code_image(3, 25, walld_image, 3);
            code_image_loop(8, 25, 10, 0, walld_image, 3);
            code_image_loop(17, 25, 19, 0, walld_image, 3);
            code_image(24, 25, walld_image, 3);
            code_image(26, 28, walld_image, 3);
            code_image(1, 28, walld_image, 3);
            code_image(15, 28, walld_image, 3);
            code_image(16, 28, walld_image, 3);
            code_image(11, 28, walld_image, 3);
            code_image(12, 28, walld_image, 3);
            code_image_loop(3, 31, 10, 0, walld_image, 3);
            code_image_loop(17, 31, 24, 0, walld_image, 3);
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
            code_image(25, 27, walltlc_image, 3);
            code_image(25, 28, wallblc_image, 3);
            code_image(13, 22, wallblci_image, 3);
            code_image(13, 23, walll_image, 3);
            code_image(13, 24, walll_image, 3);
            code_image(13, 25, wallblc_image, 3);
            code_image(4, 25, wallblci_image, 3);
            code_image(4, 26, walll_image, 3);
            code_image(4, 27, walll_image, 3);
            code_image(4, 28, wallblc_image, 3);
            code_image(22, 24, walltlc_image, 3);
            code_image_loop(22, 25, 0, 27, walll_image, 3);
            code_image(22, 28, wallblc_image, 3);
            code_image(27, 22, wallblci_image, 3);
            code_image_loop(27, 23, 0, 26, walll_image, 3);
            code_image(27, 27, walltlci_image, 3);
            code_image(27, 28, wallblci_image, 3);
            code_image_loop(27, 29, 0, 32, walll_image, 3);
            code_image(27, 33, walltlci_image, 3);
            code_image(10, 27, walltlc_image, 3);
            code_image(10, 28, wallblc_image, 3);
            code_image(13, 28, wallblci_image, 3);
            code_image(13, 29, walll_image, 3);
            code_image(13, 30, walll_image, 3);
            code_image(13, 31, wallblc_image, 3);
            code_image(2, 30, walltlc_image, 3);
            code_image(2, 31, wallblc_image, 3);
            code_image(16, 30, walltlc_image, 3);
            code_image(16, 31, wallblc_image, 3);
            code_image(7, 27, walltlc_image, 3);
            code_image(7, 28, walll_image, 3);
            code_image(7, 29, walll_image, 3);
            code_image(7, 30, walltlci_image, 3);
            code_image(19, 27, walltlc_image, 3);
            code_image(19, 28, walll_image, 3);
            code_image(19, 29, walll_image, 3);
            code_image(19, 30, walltlci_image, 3);

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
            code_image(2, 27, walltrc_image, 3);
            code_image(2, 28, wallbrc_image, 3);
            code_image(14, 22, wallbrci_image, 3);
            code_image(14, 23, wallr_image, 3);
            code_image(14, 24, wallr_image, 3);
            code_image(14, 25, wallbrc_image, 3);
            code_image(5, 24, walltrc_image, 3);
            code_image_loop(5, 25, 0, 27, wallr_image, 3);
            code_image(5, 28, wallbrc_image, 3);
            code_image(23, 25, wallbrci_image, 3);
            code_image(23, 26, wallr_image, 3);
            code_image(23, 27, wallr_image, 3);
            code_image(23, 28, wallbrc_image, 3);
            code_image(0, 22, wallbrci_image, 3);
            code_image_loop(0, 23, 0, 26, wallr_image, 3);
            code_image(0, 27, walltrci_image, 3);
            code_image(0, 28, wallbrci_image, 3);
            code_image_loop(0, 29, 0, 32, wallr_image, 3);
            code_image(0, 33, walltrci_image, 3);
            code_image(17, 27, walltrc_image, 3);
            code_image(17, 28, wallbrc_image, 3);
            code_image(14, 28, wallbrci_image, 3);
            code_image(14, 29, wallr_image, 3);
            code_image(14, 30, wallr_image, 3);
            code_image(14, 31, wallbrc_image, 3);
            code_image(11, 30, walltrc_image, 3);
            code_image(11, 31, wallbrc_image, 3);
            code_image(25, 30, walltrc_image, 3);
            code_image(25, 31, wallbrc_image, 3);
            code_image(8, 27, walltrc_image, 3);
            code_image(8, 28, wallr_image, 3);
            code_image(8, 29, wallr_image, 3);
            code_image(8, 30, walltrci_image, 3);
            code_image(20, 27, walltrc_image, 3);
            code_image(20, 28, wallr_image, 3);
            code_image(20, 29, wallr_image, 3);
            code_image(20, 30, walltrci_image, 3);
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
