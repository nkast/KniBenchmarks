using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestFontLineSpacingComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;
        Texture2D _txDot;

        SpriteFont _fontCalibri;
        SpriteFont _fontSegoeUI;


        public TestFontLineSpacingComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");
            _txDot = new Texture2D(Game.GraphicsDevice, 1, 1);
            _txDot.SetData<Color>(new[] {Color.White } );

            _fontCalibri = Game.Content.Load<SpriteFont>("SpriteTests\\FontCalibri");
            _fontSegoeUI = Game.Content.Load<SpriteFont>("SpriteTests\\FontSegoeUI");
  
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null);

            Vector2 pos = new Vector2(16, 16);
            
            DrawString2(_fontCalibri, "the quick brown fox jumps over the lazy dog.", pos, Color.White);
            
            pos = new Vector2(16, 80);
            
            DrawString2(_fontSegoeUI, "the quick brown fox jumps over the lazy dog.", pos, Color.White);            
            
            _spriteBatch.End();
        }

        public void DrawString2(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            Vector2 txtSize = spriteFont.MeasureString(text);
            Rectangle bounds = new Rectangle((int)position.X, (int)position.Y, (int)txtSize.X, (int)txtSize.Y);

            _spriteBatch.Draw(_txDot, bounds, Color.White * 0.3f);

            _spriteBatch.DrawString(spriteFont, text, position, color);
        }

    }
}
