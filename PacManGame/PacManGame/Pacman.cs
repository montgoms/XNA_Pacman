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
        KeyboardState curr_key;
        KeyboardState prev_key;
        string curr_direction;
        int coll_trig_x;
        int coll_trig_y;

        /*** Default Constructor ***/
        public Pacman()
        {
            pos = new Vector2(0, 0);
            vel = new Vector2(0, 0);
            image = null;
            game_grid = null;
            coll_trig_x = 0;
            coll_trig_y = 0;
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
            coll_trig_x = 10;
            coll_trig_y = 10;
            curr_direction = "";
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

            curr_key = Keyboard.GetState();

            /*** Check for Keyboard Input ***/
            if (curr_key.IsKeyDown(Keys.Up) && prev_key.IsKeyUp(Keys.Up))
            {
                curr_direction = "up";
            }
            else if (curr_key.IsKeyDown(Keys.Down) && prev_key.IsKeyUp(Keys.Down))
            {
                curr_direction = "down";
            }
            else if (curr_key.IsKeyDown(Keys.Left) && prev_key.IsKeyUp(Keys.Left))
            {
                curr_direction = "left";
            }
            else if (curr_key.IsKeyDown(Keys.Right) && prev_key.IsKeyUp(Keys.Right))
            {
                curr_direction = "right";
            }

            //Update Collision Triggers
            if (vel.X != 0 && coll_trig_x != 0) coll_trig_x--;
            if (vel.Y != 0 && coll_trig_y != 0) coll_trig_y--;

            //Check for wall colision
            if (coll_trig_x == 0 || coll_trig_y == 0 || (vel.X == 0 && vel.Y == 0))
            {
                if (curr_direction == "right")
                {
                    Vector2 temp_tile = new Vector2(0, 0);
                    int next_tile = 0;
                    temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                    temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                    if (temp_tile.X >= 27) next_tile = 27;
                    else next_tile = (int)temp_tile.X + 1;
                    if (!(game_grid.tile_grid[next_tile, (int)temp_tile.Y].state == 3))
                    {
                        vel.X = 2;
                        vel.Y = 0;
                        //pos.X -= (p_dim / 4);
                    }
                }
                else if (curr_direction == "left")
                {
                    Vector2 temp_tile = new Vector2(0, 0);
                    int next_tile = 0;
                    temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                    temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                    if (temp_tile.X <= 0) next_tile = 0;
                    else next_tile = (int)temp_tile.X - 1;
                    if (!(game_grid.tile_grid[next_tile, (int)temp_tile.Y].state == 3))
                    {
                        vel.X = -2;
                        vel.Y = 0;
                        Console.Write("Success");
                        Console.WriteLine();
                        //pos.X += (p_dim / 4);
                    }
                }
                else if (curr_direction == "up")
                {
                    Vector2 temp_tile = new Vector2(0, 0);
                    temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                    temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                    if (!(game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y-1].state == 3))
                    {
                        vel.X = 0;
                        vel.Y = 2;
                        //pos.Y += (p_dim / 4);
                    }
                }
                else if (curr_direction == "down")
                {
                    Vector2 temp_tile = new Vector2(0, 0);
                    temp_tile.X = (int)((pos.X + (p_dim / 2)) / 20);
                    temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                    if (!(game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y+1].state == 3))
                    {
                        vel.X = 0;
                        vel.Y = -2;
                        //pos.Y -= (p_dim / 4);
                    }
                }
                coll_trig_x = 10;
                coll_trig_y = 10;
            }
            if (vel.X > 0)
            {
                Vector2 temp_tile = new Vector2(0, 0);
                temp_tile.X = (int)((pos.X + (p_dim / 2) + (p_dim / 4)) / 20);
                temp_tile.Y = (int)((pos.Y + (p_dim / 2)) / 20);
                if (game_grid.tile_grid[(int)temp_tile.X, (int)temp_tile.Y].state == 3)
                {
                    vel.X = 0;
                    coll_trig_x = 0;
                    coll_trig_y = 0;
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
                    coll_trig_x = 0;
                    coll_trig_y = 0;
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
                    coll_trig_x = 0;
                    coll_trig_y = 0;
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
                    coll_trig_x = 0;
                    coll_trig_y = 0;
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

            //Check Wrap-Around Special Cases
            if (curr_tile.X == 27 && curr_tile.Y == 17)
            {
                pos.X = 0+10;
                pos.Y = (17 * 20) - 10;
            }
            if (curr_tile.X == 0 && curr_tile.Y == 17)
            {
                pos.X = (25 * 20) + 10;
                pos.Y = (17 * 20) - 10;
            }

            //Update Pacman Position
            pos.X += vel.X;
            pos.Y -= vel.Y;

            /*Console.Write("Left Adjacent Tile State: ");
            Console.Write(game_grid.tile_grid[(int)curr_tile.X-1, (int)curr_tile.Y].state);
            Console.WriteLine();
            Console.Write("Left Adjacent Tile: ");
            Console.Write((int)curr_tile.X-1);
            Console.Write(" ");
            Console.Write((int)curr_tile.Y);
            Console.WriteLine();
            Console.Write(curr_direction);
            Console.WriteLine();
            Vector2 temp_tile1 = new Vector2(0, 0);
            temp_tile1.X = (int)((pos.X + (p_dim / 2) - (p_dim / 4)) / 20);
            temp_tile1.Y = (int)((pos.Y + (p_dim / 2)) / 20);
            Console.Write((int)temp_tile1.X - 1);
            Console.Write(" ");
            Console.Write((int)temp_tile1.Y);
            Console.WriteLine();*/
            Console.Write(pos/20);
            Console.WriteLine();

            prev_key = curr_key;
        }

        public void Update_Tile(Vector2 pos, int new_state, Texture2D new_state_image)
        {
            game_grid.tile_grid[(int)pos.X, (int)pos.Y].state = new_state;
            game_grid.tile_grid[(int)pos.X, (int)pos.Y].state_image = new_state_image;
        }
        public void reset_vel()
        {
            vel.X = 0;
            vel.Y = 0;
        }

    }
}
