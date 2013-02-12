using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacManGame
{
    public class Pacman
    {
        public Vector2 pos;
        Vector2 vel;
        Tiles game_grid;
        public Texture2D image;
        int p_dim;
        int wwidth;
        int wheight;
        KeyboardState curr;
        KeyboardState prev;

        /*** Default Constructor ***/
        public Pacman()
        {
            pos = new Vector2(0, 0);
            vel = new Vector2(0, 0);
            image = null;
            game_grid = null;
        }

        public Pacman(int pdim, int world_width, int world_height, Tiles grid)
        {
            p_dim = pdim;
            wwidth = world_width;
            wheight = world_height;
            pos = new Vector2(0, 0);
            vel = new Vector2(0, 0);
            image = null;
            game_grid = grid;
        }

        public void Update()
        {
            Vector2 curr_tile = new Vector2(0, 0);
            if (pos.X > 0) curr_tile.X = (int)((pos.X+(p_dim/2)) / 20);
            else curr_tile.X = 0;
            //Add 1 to the second element for round-up
            if (pos.Y > 0) curr_tile.Y = (int)((pos.Y+(p_dim / 2)) / 20);
            else curr_tile.Y = 0;

            //Boundary Check (TEMPORARY)
            if (pos.X <= 0 || pos.X >= wwidth - p_dim)
            {
                if (pos.X < 0) pos.X = 0;
                if (pos.X > wwidth - p_dim) pos.X = wwidth - p_dim;
                vel.X = 0;
            }
            if (pos.Y <= 0 || pos.Y >= wheight - p_dim)
            {
                if (pos.Y < 0) pos.Y = 0;
                if (pos.Y > wheight - p_dim) pos.Y = wheight - p_dim;
                vel.Y = 0;
            }

            curr = Keyboard.GetState();

            /*** Check for Keyboard Input ***/
            if (curr.IsKeyDown(Keys.Up) && prev.IsKeyUp(Keys.Up))
            {
                    vel.X = 0;
                    vel.Y = 2;
            }
            else if (curr.IsKeyDown(Keys.Down) && prev.IsKeyUp(Keys.Down))
            {
                    vel.X = 0;
                    vel.Y = -2;
            }
            else if (curr.IsKeyDown(Keys.Left) && prev.IsKeyUp(Keys.Left))
            { 
                    vel.X = -2;
                    vel.Y = 0;
            }
            else if (curr.IsKeyDown(Keys.Right) && prev.IsKeyUp(Keys.Right))
            {
                    vel.X = 2;
                    vel.Y = 0;
            }

            //Check for wall colision
            if (vel.X > 0)
            {
                Vector2 temp_tile = new Vector2(0, 0);
                temp_tile.X = (int)((pos.X + (p_dim / 2) + (p_dim / 4)) / 20);
                temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                if (game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y].state == 3)
                {
                    vel.X = 0;
                    //pos.X -= (p_dim / 4);
                }
            }
            else if (vel.X < 0)
            {
                Vector2 temp_tile = new Vector2(0, 0);
                temp_tile.X = (int)((pos.X + (p_dim / 2) - (p_dim / 4)) / 20);
                temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                if (game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y].state == 3)
                {
                    vel.X = 0;
                    //pos.X += (p_dim / 4);
                }
            }
            else if (vel.Y > 0)
            {
                Vector2 temp_tile = new Vector2(0, 0);
                temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                temp_tile.Y = (int)((pos.Y + (p_dim / 2) - (p_dim / 4)) / 20);
                if (game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y].state == 3)
                {
                    vel.Y = 0;
                    //pos.Y += (p_dim / 4);
                }
            }
            else if (vel.Y < 0)
            {
                Vector2 temp_tile = new Vector2(0, 0);
                temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                temp_tile.Y = (int)((pos.Y + (p_dim / 2) + (p_dim / 4)) / 20);
                if (game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y].state == 3)
                {
                    vel.Y = 0;
                    //pos.Y -= (p_dim / 4);
                }
            }
            /*if (vel.X > 0 && game_grid.tile_grid[(int)curr_tile.X + 1, (int)curr_tile.Y].state == 3
                || vel.X < 0 && game_grid.tile_grid[(int)curr_tile.X - 1, (int)curr_tile.Y].state == 3)
            {
                vel.X = 0;
            }
            if (vel.Y > 0 && game_grid.tile_grid[(int)curr_tile.X, (int)curr_tile.Y - 1].state == 3
                || vel.Y < 0 && game_grid.tile_grid[(int)curr_tile.X, (int)curr_tile.Y + 1].state == 3)
            {
                vel.Y = 0;
            }*/

            //Update Pacman Position
            pos.X += vel.X;
            pos.Y -= vel.Y;

            Console.Write("Left Adjacent Tile State: ");
            Console.Write(game_grid.tile_grid[(int)curr_tile.X-1, (int)curr_tile.Y].state);
            Console.WriteLine();
            Console.Write("Left Adjacent Tile: ");
            Console.Write((int)curr_tile.X-1);
            Console.Write(" ");
            Console.Write((int)curr_tile.Y);
            Console.WriteLine();

            prev = curr;
        }

    }
}
