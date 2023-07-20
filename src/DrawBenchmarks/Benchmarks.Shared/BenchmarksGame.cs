using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Benchmarks
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BenchmarksGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        FpsComponent _fpsComponent;
        TestComponent _testComponent;

        DrawSpriteComponent _drawSpriteComponentImmediate;
        DrawSpriteComponent _drawSpriteComponent;
        DrawSpritesComponent _drawSpritesComponent;
        DrawStringComponent _drawStringComponentFlipped;
        DrawStringComponent _drawStringComponent;


        public BenchmarksGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            _graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;

            this.IsMouseVisible = true;
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

            _drawSpriteComponentImmediate = new DrawSpriteComponent(this);
            _drawSpriteComponentImmediate.SortMode = SpriteSortMode.Immediate;
            _drawSpriteComponentImmediate.Visible = false;
            this.Components.Add(_drawSpriteComponentImmediate);

            _drawSpriteComponent = new DrawSpriteComponent(this);
            _drawSpriteComponent.Visible = false;
            this.Components.Add(_drawSpriteComponent);

            _drawSpritesComponent = new DrawSpritesComponent(this);
            _drawSpritesComponent.Visible = false;
            this.Components.Add(_drawSpritesComponent);

            _drawStringComponentFlipped = new DrawStringComponent(this);
            _drawStringComponentFlipped.Effects = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            _drawStringComponentFlipped.Visible = false;
            this.Components.Add(_drawStringComponentFlipped);

            _drawStringComponent = new DrawStringComponent(this);
            _drawStringComponent.Visible = true;
            this.Components.Add(_drawStringComponent);

            _testComponent = new TestComponent(this);
            this.Components.Add(_testComponent);

            _fpsComponent = new FpsComponent(this);
            _fpsComponent.DrawOrder = int.MaxValue;
            this.Components.Add(_fpsComponent);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

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
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
#if BLAZORGL
            GamePadState gamePadState = default;
#else
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
#endif

            if (keyboardState.IsKeyDown(Keys.Escape) ||
                keyboardState.IsKeyDown(Keys.Back) ||
                gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                try { Exit(); }
                catch (PlatformNotSupportedException ex) { }
            }

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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
