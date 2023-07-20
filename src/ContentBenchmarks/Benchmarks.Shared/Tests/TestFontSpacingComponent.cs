using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestFontSpacingComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;
        
        SpriteFont _fontSpacing;


        public TestFontSpacingComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");

            _fontSpacing = Game.Content.Load<SpriteFont>("SpriteTests\\FontSpacing");
  
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            Vector2 pos = new Vector2(16, 16);
            
            _spriteBatch.DrawString(_fontSpacing,
                "the lazy brown fox jumps over the dog.\n" +
                "the lazy brown fox jumps over the dog.\n" +
                "the lazy brown fox jumps over the dog.\n",
                pos, Color.White);
            pos.Y += 4 + _fontSpacing.LineSpacing * 3;
            _spriteBatch.End();

        }

    }
}
