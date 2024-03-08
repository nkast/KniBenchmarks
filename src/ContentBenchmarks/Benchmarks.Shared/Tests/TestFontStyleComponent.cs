using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestFontStyleComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;
        
        SpriteFont _fontStyleRegular;
        SpriteFont _fontStyleItalic;
        SpriteFont _fontStyleBoldItalic;
        SpriteFont _fontStyleBold;


        public TestFontStyleComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");

            _fontStyleRegular = Game.Content.Load<SpriteFont>("SpriteTests\\FontStyleRegular");
            _fontStyleItalic = Game.Content.Load<SpriteFont>("SpriteTests\\FontStyleItalic");
            _fontStyleBoldItalic = Game.Content.Load<SpriteFont>("SpriteTests\\FontStyleBoldItalic");
            _fontStyleBold = Game.Content.Load<SpriteFont>("SpriteTests\\FontStyleBold");
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            Vector2 pos = new Vector2(16, 16);

            _spriteBatch.DrawString(_fontStyleRegular, "the quick brown fox jumps over the lazy dog. - Calibri, Style: Regular", pos, Color.White);
            pos.Y += 4 + _fontStyleRegular.LineSpacing;
            _spriteBatch.DrawString(_fontStyleItalic, "the quick brown fox jumps over the lazy dog. - Calibri, Style: Italic", pos, Color.White);
            pos.Y += 4 + _fontStyleItalic.LineSpacing;
            _spriteBatch.DrawString(_fontStyleBoldItalic, "the quick brown fox jumps over the lazy dog. - Calibri, Style: Bold, Italic", pos, Color.White);
            pos.Y += 4 + _fontStyleBoldItalic.LineSpacing;
            _spriteBatch.DrawString(_fontStyleBold, "the quick brown fox jumps over the lazy dog. - Calibri, Style: Bold", pos, Color.White);
            pos.Y += 4 + _fontStyleBold.LineSpacing;

            _spriteBatch.End();

        }

    }
}
