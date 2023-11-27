using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class ContentMultithreadLoadComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        
        ConcurrentBag<SpriteFont> _spriteFonts = new ConcurrentBag<SpriteFont>();
        ConcurrentBag<SoundEffect> _soundEffects = new ConcurrentBag<SoundEffect>();
        ConcurrentBag<Texture2D> _textures = new ConcurrentBag<Texture2D>();
        ConcurrentBag<Effect> _effects = new ConcurrentBag<Effect>();
        Stopwatch _sw = new Stopwatch();
        TimeSpan _loadTime;
        String _strLoadTime;

        public ContentMultithreadLoadComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");

            _sw.Start();
            BenchmarkLoadContent(Game.Content).ContinueWith(t =>
            {
                _sw.Stop();
                _loadTime = _sw.Elapsed;
                _strLoadTime = String.Format("Load time: {0}s.", ((int)_loadTime.TotalMilliseconds) / 1000f);
                if (t.IsFaulted)
                    _strLoadTime = t.Exception.InnerException.Message;
            });
        }

        private Task BenchmarkLoadContent(ContentManager content)
        {
            Task task = Task.Run(() =>
            {
                Parallel.For(0, 64, (i) =>
                {
                    int num = 1001 + i;
                    _spriteFonts.Add(content.Load<SpriteFont>("BenchmarksFonts\\Font" + num));
                    _soundEffects.Add(content.Load<SoundEffect>("BenchmarksSounds\\Sound" + num));
                    _textures.Add(content.Load<Texture2D>("BenchmarksTextures\\Tx" + num));
                    _effects.Add(content.Load<Effect>("BenchmarksEffects\\Effect" + num));
                });
            });

            return task;
        }

        public override void Draw(GameTime gameTime)
        {
            string strLoadTime = _strLoadTime;

            if (strLoadTime == null)
            {
                strLoadTime = "Loading...";
                int c = (int)(_sw.Elapsed.TotalMilliseconds / (1000.0/ 60.0));
                c = c % 5;
                for (int i = 0; i < c; i++)
                    strLoadTime += ".";
            }

            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            _spriteBatch.DrawString(_font, strLoadTime, new Vector2(16, 16), Color.White);

            _spriteBatch.End();
        }

    }
}
