using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class DrawStringComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Random _random;

        public SpriteSortMode SortMode { get; set; }
        public SpriteEffects Effects { get; set; }


        public DrawStringComponent(Game game) : base(game)
        {
            SortMode = SpriteSortMode.Deferred;
            Effects = SpriteEffects.None;

            _random = new Random();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SortMode, null);

            for (int a = 0; a < 16; a++)
            {
                for (int i = 20; i < 480; i += 20)
                {
                    _spriteBatch.DrawString(_font, "abcdefghijklmnopqrstuvwxyz1234567890 the lazy brown fox jumps over the dog.", new Vector2(0, i), Color.Black
                        //,
                        //(float)(_random.NextDouble() * MathHelper.TwoPi), // rotation
                        //new Vector2(_random.Next(64), _random.Next(64)), // origin
                        //new Vector2((float)_random.NextDouble() * 2, (float)_random.NextDouble() * 2), // scale
                        //Effects,
                        //0
                    );
                }
            }

            _spriteBatch.End();
        }

    }
}
