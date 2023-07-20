using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Benchmarks
{
    public class FpsComponent : DrawableGameComponent
    {
        Stopwatch _sw;
        int _prevSecond;
        
        int _totalFramesCount;
        int _avgFps;
        int _framesCount;
        int _fps;

        SpriteBatch _spriteBatch;
        SpriteFont _font;
        StringBuilder _sbfps, _sbavgfps;


        public FpsComponent(Game game) : base(game)
        {
            _sw = new Stopwatch();

            _sbfps = new StringBuilder(16);
            _sbavgfps = new StringBuilder(16);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            if ((keyboardState.IsKeyDown(Keys.LeftControl) || keyboardState.IsKeyDown(Keys.RightControl))
            &&  keyboardState.IsKeyDown(Keys.R))
            {
                _totalFramesCount = 0;
                _framesCount = 0;
                _avgFps = 0;
                _fps = 0;
                _prevSecond = 0;
                _sw.Restart();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {
            if (!_sw.IsRunning)
                _sw.Start();
            TimeSpan dt = _sw.Elapsed;
            int second = (int)dt.TotalSeconds;

            if (second > _prevSecond)
            {
                _avgFps = _totalFramesCount / second;

                _fps = _framesCount / (second - _prevSecond);
                _framesCount = 0;

                _prevSecond = second;
            }
            _totalFramesCount++;
            _framesCount++;

            _sbfps.Clear();
            UIntToStringBuilder((uint)_fps, _sbfps);

            _sbavgfps.Clear();
            _sbavgfps.Append("~");
            UIntToStringBuilder((uint)_avgFps, _sbavgfps);

            float scale = 2 * this.GraphicsDevice.PresentationParameters.BackBufferWidth / 800;
            Vector2 fpssize = _font.MeasureString(_sbfps);
            Vector2 avgfpssize = _font.MeasureString(_sbavgfps);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearClamp, null, null);
            
            _spriteBatch.DrawString(_font, _sbfps, new Vector2(this.GraphicsDevice.PresentationParameters.BackBufferWidth, _font.LineSpacing * scale * 0 + 2), Color.Black,
                0, new Vector2(1, 0) * fpssize, scale, SpriteEffects.None, 0);
            _spriteBatch.DrawString(_font, _sbavgfps, new Vector2(this.GraphicsDevice.PresentationParameters.BackBufferWidth, _font.LineSpacing * scale * 1 + 2), Color.Black,
                0, new Vector2(1, 0) * avgfpssize, scale, SpriteEffects.None, 0);

            _spriteBatch.DrawString(_font, _sbfps, new Vector2(this.GraphicsDevice.PresentationParameters.BackBufferWidth - 2, _font.LineSpacing * scale * 0), Color.LightGreen,
                0, new Vector2(1,0) * fpssize, scale, SpriteEffects.None, 0);
            _spriteBatch.DrawString(_font, _sbavgfps, new Vector2(this.GraphicsDevice.PresentationParameters.BackBufferWidth - 2, _font.LineSpacing * scale * 1), Color.LightGreen,
                0, new Vector2(1, 0) * avgfpssize, scale, SpriteEffects.None, 0);

            _spriteBatch.End();

            //_sbfps.Append("Fps");
            //Game.Window.Title = _sbfps.ToString();
        }

        // Garbage free integer to StringBuilder.
        private void UIntToStringBuilder(uint value, StringBuilder sb)
        {
            uint rem = value % 10;
            if (value >= 10)
                UIntToStringBuilder(value/10, sb);

            sb.Append((char)('0' + rem));
        }
    }
}
