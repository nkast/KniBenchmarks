using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestFontNoKerningComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;
        
        SpriteFont _fontNoKerning;


        public TestFontNoKerningComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");

            _fontNoKerning = Game.Content.Load<SpriteFont>("SpriteTests\\FontNoKerning");
  
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            Vector2 pos = new Vector2(16, 16);
            
            _spriteBatch.DrawString(_fontNoKerning, "the lazy brown fox jumps over the dog.", pos, Color.White);
            pos.Y += 4 + _fontNoKerning.LineSpacing;

            _spriteBatch.End();

        }

    }
}
