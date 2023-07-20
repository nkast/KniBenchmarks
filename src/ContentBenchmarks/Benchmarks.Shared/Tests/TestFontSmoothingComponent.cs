using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestFontSmoothingComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;
        
        SpriteFont _fontSmoothingNormal;
        SpriteFont _fontSmoothingLight;
        SpriteFont _fontSmoothingAutoHint;
        SpriteFont _fontSmoothingDisable;


        public TestFontSmoothingComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");

            _fontSmoothingNormal = Game.Content.Load<SpriteFont>("SpriteTests\\FontSmoothingNormal");
            _fontSmoothingLight = Game.Content.Load<SpriteFont>("SpriteTests\\FontSmoothingLight");
            _fontSmoothingAutoHint = Game.Content.Load<SpriteFont>("SpriteTests\\FontSmoothingAutoHint");
            _fontSmoothingDisable = Game.Content.Load<SpriteFont>("SpriteTests\\FontSmoothingDisable");

        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            Vector2 pos = new Vector2(16, 16);

            _spriteBatch.DrawString(_fontSmoothingNormal, "the lazy brown fox jumps over the dog. - Smoothing: Normal", pos, Color.White);
            pos.Y += 4 + _fontSmoothingNormal.LineSpacing;
            _spriteBatch.DrawString(_fontSmoothingLight, "the lazy brown fox jumps over the dog. - Smoothing: Light", pos, Color.White);
            pos.Y += 4 + _fontSmoothingLight.LineSpacing;
            _spriteBatch.DrawString(_fontSmoothingAutoHint, "the lazy brown fox jumps over the dog. - Smoothing: AutoHint", pos, Color.White);
            pos.Y += 4 + _fontSmoothingAutoHint.LineSpacing;
            _spriteBatch.DrawString(_fontSmoothingDisable, "the lazy brown fox jumps over the dog. - Smoothing: Disable", pos, Color.White);
            pos.Y += 4 + _fontSmoothingDisable.LineSpacing;

            _spriteBatch.End();

        }

    }
}
