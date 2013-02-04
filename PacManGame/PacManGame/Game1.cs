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
        Texture2D image;
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
        Tiles game_grid;
        //Texture2D bground;
        KeyboardState curr;
        KeyboardState prev;
        int world_width;
        int world_height;
        int l_dim;
        int p_dim;
        Vector2 pos;
        Vector2 pos2;
        Vector2 vel;

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

            pos = new Vector2(0,0);
            vel = new Vector2(0, 0);
            p_dim = 30;
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

            image = Content.Load<Texture2D>("ball");
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

            //Initialize the level grid
            game_grid = new Tiles(empty, pellet, pill, wall, 
                                  wall_up, wall_down, wall_left, wall_right,
                                  wall_tlc, wall_trc, wall_blc, wall_brc, 
                                  wall_blci, wall_brci, wall_tlci, wall_trci);

            //Set Pac-Man to his starting position
            pos.X = game_grid.tile_grid[13, 26].pos.X +5;
            pos.Y = game_grid.tile_grid[13, 26].pos.Y-5;
            //bground = Content.Load<Texture2D>("Sky");

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

            pos.X += vel.X;
            pos.Y -= vel.Y;

            if (pos.X <= 0 || pos.X >= world_width - p_dim)
            {
                if (pos.X < 0) pos.X = 0;
                if (pos.X > world_width - p_dim) pos.X = world_width - p_dim;
                vel.X = 0;
            }
            if (pos.Y <= 0 || pos.Y >= world_height - p_dim)
            {
                if (pos.Y < 0) pos.Y = 0;
                if (pos.Y > world_height - p_dim) pos.Y = world_height - p_dim;
                vel.Y = 0;
            }

            curr = Keyboard.GetState();

            if (curr.IsKeyDown(Keys.Up) && prev.IsKeyUp(Keys.Up))
            {
                vel.X = 0;
                vel.Y = 2;
            }

            if (curr.IsKeyDown(Keys.Down) && prev.IsKeyUp(Keys.Down))
            {
                vel.X = 0;
                vel.Y = -2;
            }

            if (curr.IsKeyDown(Keys.Left) && prev.IsKeyUp(Keys.Left))
            {
                vel.X = -2;
                vel.Y = 0;
            }

            if (curr.IsKeyDown(Keys.Right) && prev.IsKeyUp(Keys.Right))
            {
                vel.X = 2;
                vel.Y = 0;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
            prev = curr;
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

            //spriteBatch.Draw(bground, new Rectangle(0, 0, world_width, world_height), Color.White);

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

            spriteBatch.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, p_dim, p_dim), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

