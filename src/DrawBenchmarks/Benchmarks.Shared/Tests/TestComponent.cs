using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class TestComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _tx;


        public TestComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Game.Content.Load<SpriteFont>("Font");
            _tx = Game.Content.Load<Texture2D>("Tx");

        }


        public override void Draw(GameTime gameTime)
        {
        }

    }
}
