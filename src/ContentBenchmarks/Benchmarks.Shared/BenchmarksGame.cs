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
        TestFontNoKerningComponent _testFontNoKerningComponent;
        TestFontSmoothingComponent _testFontSmoothingComponent;
        TestFontSpacingComponent _testFontSpacingComponent;
        TestFontLineSpacingComponent _testFontLineSpacingComponent;

        ContentLoadComponent _contentLoadComponent;
        ContentThreadLoadComponent _contentThreadLoadComponent;
        ContentMultithreadLoadComponent _contentMultithreadLoadComponent;
        DrawStringComponent _drawStringComponent;


        public BenchmarksGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

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


            _drawStringComponent = new DrawStringComponent(this);
            _drawStringComponent.Visible = false;
            this.Components.Add(_drawStringComponent);

            _testComponent = new TestComponent(this);
            this.Components.Add(_testComponent);

            _testFontNoKerningComponent = new TestFontNoKerningComponent(this);
            _testFontNoKerningComponent.Visible = false;
            this.Components.Add(_testFontNoKerningComponent);

            _testFontSmoothingComponent = new TestFontSmoothingComponent(this);
            _testFontSmoothingComponent.Visible = false;
            this.Components.Add(_testFontSmoothingComponent);

            _testFontSpacingComponent = new TestFontSpacingComponent(this);
            _testFontSpacingComponent.Visible = false;
            this.Components.Add(_testFontSpacingComponent);
            
            _testFontLineSpacingComponent = new TestFontLineSpacingComponent(this);
            _testFontLineSpacingComponent.Visible = false;
            this.Components.Add(_testFontLineSpacingComponent);

            _fpsComponent = new FpsComponent(this);
            _fpsComponent.DrawOrder = int.MaxValue;
            this.Components.Add(_fpsComponent);

            _contentLoadComponent = new ContentLoadComponent(this);
            _contentLoadComponent.Visible = true;
            this.Components.Add(_contentLoadComponent);

            _contentThreadLoadComponent = new ContentThreadLoadComponent(this);
            _contentThreadLoadComponent.Visible = true;
            //this.Components.Add(_contentThreadLoadComponent);

            _contentMultithreadLoadComponent = new ContentMultithreadLoadComponent(this);
            _contentMultithreadLoadComponent.Visible = true;
            //this.Components.Add(_contentMultithreadLoadComponent);

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
