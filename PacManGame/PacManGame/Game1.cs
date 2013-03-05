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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pacman;
        Texture2D pellet;
        Texture2D pill;
        Texture2D empty;
        Texture2D wall;
        Texture2D wall_right;
        Texture2D wall_up;
        Texture2D wall_down;
        Texture2D wall_left;
        Texture2D wall_brc;
        Texture2D wall_brci;
        Texture2D wall_blc;
        Texture2D wall_blci;
        Texture2D wall_trc;
        Texture2D wall_trci;
        Texture2D wall_tlc;
        Texture2D wall_tlci;
        Texture2D test;
        SpriteFont font;
        ulong score;
        Tiles game_grid;
        Pacman player;
        //Texture2D bground;
        KeyboardState curr;
        KeyboardState prev;
        int world_width;
        int world_height;
        int l_dim;
        int p_dim;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;

            /*** Set Screen Dimensions Here ***/
            graphics.PreferredBackBufferWidth = 560;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Initialize Member Variables
            p_dim = 40;
            l_dim = 20;
            world_height = graphics.GraphicsDevice.Viewport.Height;
            world_width = graphics.GraphicsDevice.Viewport.Width;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Initialize the level grid
            game_grid = new Tiles();

            font = Content.Load<SpriteFont>("Score");

            pacman = Content.Load<Texture2D>("ball");
            empty = Content.Load<Texture2D>("Empty");
            pellet = Content.Load<Texture2D>("Pellet");
            pill = Content.Load<Texture2D>("Pill");
            wall = Content.Load<Texture2D>("Wall");
            wall_up = Content.Load<Texture2D>("Wall_up");
            wall_down = Content.Load<Texture2D>("Wall_down");
            wall_left = Content.Load<Texture2D>("Wall_left");
            wall_right = Content.Load<Texture2D>("Wall_right");
            wall_tlc = Content.Load<Texture2D>("Wall_tlc");
            wall_trc = Content.Load<Texture2D>("Wall_trc");
            wall_brc = Content.Load<Texture2D>("Wall_brc");
            wall_blc = Content.Load<Texture2D>("Wall_blc");
            wall_blci = Content.Load<Texture2D>("Wall_blci");
            wall_tlci = Content.Load<Texture2D>("Wall_tlci");
            wall_trci = Content.Load<Texture2D>("Wall_trci");
            wall_brci = Content.Load<Texture2D>("Wall_brci");
            test = Content.Load<Texture2D>("Empty2");

            //Load the images into the level grid
            game_grid.load_images(empty, pellet, pill, wall, 
                                  wall_up, wall_down, wall_left, wall_right,
                                  wall_tlc, wall_trc, wall_blc, wall_brc, 
                                  wall_blci, wall_brci, wall_tlci, wall_trci);

            //Code the level onto the game grid
            game_grid.load_level();

                        //Initialize pacman
            player = new Pacman(p_dim, world_width, world_height, game_grid);

            //Set Pac-Man to his starting position
            player.pos.X = game_grid.tile_grid[13, 26].pos.X+10;
            player.pos.Y = game_grid.tile_grid[13, 26].pos.Y-10;
            //Set Pacman image
            player.image = pacman;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            player.Update();
            Vector2 curr_tile = new Vector2(0, 0);
            if (player.pos.X > 0) curr_tile.X = (int)((player.pos.X + (p_dim / 2)) / 20);
            else curr_tile.X = 0;
            if (player.pos.Y > 0) curr_tile.Y = (int)((player.pos.Y + (p_dim / 2)) / 20);
            else curr_tile.Y = 0;
            if (game_grid.tile_grid[(int)curr_tile.X, (int)curr_tile.Y].state == 1)
            {
                player.Update_Tile(curr_tile, 0, empty);
                game_grid.Update_Tile(curr_tile, 0, empty);
                score += 100;
            }
            if (game_grid.tile_grid[(int)curr_tile.X, (int)curr_tile.Y].state == 2)
            {
                player.Update_Tile(curr_tile, 0, empty);
                game_grid.Update_Tile(curr_tile, 0, empty);
                score += 250;
            }
            if (game_grid.pellets_cleared())
            {
                game_grid.load_level();
                player.pos.X = game_grid.tile_grid[13, 26].pos.X + 10;
                player.pos.Y = game_grid.tile_grid[13, 26].pos.Y - 10;
                player.reset_vel();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            for (int i = 0; i < game_grid.tile_grid.GetLength(0); i++)
            {
                for (int j = 0; j < game_grid.tile_grid.GetLength(1); j++)
                {
                    spriteBatch.Draw(game_grid.tile_grid[i, j].state_image,
                    new Rectangle((int)game_grid.tile_grid[i, j].pos.X,
                                  (int)game_grid.tile_grid[i, j].pos.Y, l_dim, l_dim), 
                    Color.White);
                }
            }

            Vector2 curr_tile = new Vector2(0, 0);
            if (player.pos.X > 0) curr_tile.X = (int)((player.pos.X +(p_dim/2)) / 20);
            else curr_tile.X = 0;
            if (player.pos.Y > 0) curr_tile.Y = (int)((player.pos.Y+(p_dim / 2)) / 20);
            else curr_tile.Y = 0;

            spriteBatch.Draw(player.image, new Rectangle((int)player.pos.X, (int)player.pos.Y, p_dim, p_dim), Color.White);
            /*spriteBatch.Draw(test, new Rectangle((int)game_grid.tile_grid[(int)curr_tile.X,(int)curr_tile.Y].pos.X,
                                                 (int)game_grid.tile_grid[(int)curr_tile.X, (int)curr_tile.Y].pos.Y, 
                                                 l_dim, l_dim), Color.White);*/
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

