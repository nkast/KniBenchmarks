using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class ContentLoadComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;

        List<SpriteFont> _spriteFonts = new List<SpriteFont>();
        List<Model> _models = new List<Model>();
        List<SoundEffect> _soundEffects = new List<SoundEffect>();
        List<Texture2D> _textures = new List<Texture2D>();
        List<Effect> _effects = new List<Effect>();
        TimeSpan _loadTime;
        String _strLoadTime;

        public ContentLoadComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            BenchmarkLoadContent(Game.Content);
            sw.Stop();
            _loadTime = sw.Elapsed;
            _strLoadTime = String.Format("Load time: {0}s.", ((int)_loadTime.TotalMilliseconds) / 1000f);
        }

        private void BenchmarkLoadContent(ContentManager content)
        {
            for (int i = 0; i < 64; i++)
            {
                int num = 1001 + i;
                _spriteFonts.Add(content.Load<SpriteFont>("BenchmarksFonts\\Font" + num));
                _models.Add(content.Load<Model>("BenchmarksModels\\Model" + num));
                _soundEffects.Add(content.Load<SoundEffect>("BenchmarksSounds\\Sound" + num));
                _textures.Add(content.Load<Texture2D>("BenchmarksTextures\\Tx" + num));
                _effects.Add(content.Load<Effect>("BenchmarksEffects\\Effect" + num));
            }
        }

        public override void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin(SpriteSortMode.Deferred, null);
            
            _spriteBatch.DrawString(_font, _strLoadTime, new Vector2(16, 16), Color.White);

            _spriteBatch.End();
        }

    }
}
