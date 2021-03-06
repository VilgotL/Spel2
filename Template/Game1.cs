﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player p;
        List<Bullet> bL;
        List<Enemy> eL;
        List<SidewaysEnemy> sEL;

        KeyboardState kNewState;
        KeyboardState kOldState;

        //KOmentarrrr
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
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
            p = new Player(Content.Load<Texture2D>("xwing"), new Vector2(200, 600), new Rectangle(200, 600, 50, 50));
            bL = new List<Bullet>();
            eL = new List<Enemy>();
            sEL = new List<SidewaysEnemy>();
            Enemy.TimeStart();

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            kNewState = Keyboard.GetState();
            p.Update();
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
            {
                bL.Add(new Bullet(Content.Load<Texture2D>("bullet4"), new Vector2(p.Position.X + 16, p.Position.Y), new Rectangle(p.Position.ToPoint(), new Point(20, 20))));
            }

            if (Enemy.Time.ElapsedMilliseconds > Enemy.SpawnTime)
            {
                Enemy.UpdateForEach();
                Enemy.Time.Stop();
                Enemy.Time.Reset();
                eL.Add(new Enemy(Content.Load<Texture2D>("xwingRotaded"), new Vector2(Enemy.XPos, -50), new Rectangle(Enemy.XPos, -50, 40, 40)));
                Enemy.Time.Start();
            }

            foreach (Bullet element in bL)
            {
                element.Update();
                foreach (Enemy enemy in eL)
                {
                    if(element.Rec.Intersects(enemy.Rec))
                    {
                        enemy.Remove();
                        element.Remove();
                    }
                }
            }
            foreach(Enemy element in eL)
            {
                element.Update();
                if (element.Rec.Intersects(p.Rec))
                {
                    Exit();
                }
                if (element.Pos.Y >= 800)
                    Exit();
            }

            kOldState = kNewState;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here.

            spriteBatch.Begin();
            p.Draw(spriteBatch);
            foreach(Bullet element in bL)
            {
                element.Draw(spriteBatch);
            }
            foreach(Enemy element in eL)
            {
                element.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
