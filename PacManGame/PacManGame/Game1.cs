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
        Texture2D empty;
        Tiles game_grid;
        //Texture2D bground;
        KeyboardState curr;
        KeyboardState prev;
        int world_width;
        int world_height;
        int dim;
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
            pos2 = new Vector2(400, 360);
            vel = new Vector2(2, 0);
            dim = 30;
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

            //Initialize the level grid
            game_grid = new Tiles(empty, pellet);

            //Set Pac-Man to his starting position
            pos.X = game_grid.tile_grid[13, 26].pos.X + 10;
            pos.Y = game_grid.tile_grid[13, 26].pos.Y;
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

            if (pos.X <= 0 || pos.X >= world_width - dim)
            {
                if (pos.X < 0) pos.X = 0;
                if (pos.X > world_width - dim) pos.X = world_width - dim;
                vel.X = 0;
            }
            if (pos.Y <= 0 || pos.Y >= world_height - dim)
            {
                if (pos.Y < 0) pos.Y = 0;
                if (pos.Y > world_height - dim) pos.Y = world_height - dim;
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
                                  (int)game_grid.tile_grid[i, j].pos.Y, dim, dim), 
                    Color.White);
                }
            }

            spriteBatch.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, dim, dim), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

