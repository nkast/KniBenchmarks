using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class SimpleAnimationComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        Texture2D _tx;

        public SpriteSortMode SortMode { get; set; }
        public SpriteEffects Effects { get; set; }


        public SimpleAnimationComponent(Game game) : base(game)
        {
            SortMode = SpriteSortMode.Deferred;
            Effects = SpriteEffects.None;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tx = Game.Content.Load<Texture2D>("Tx");
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SortMode, null);

            Vector2 txCenter = _tx.Bounds.Center.ToVector2();
            Vector2 vpCenter = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            float x = (vpCenter.X - txCenter.X) * (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds * Math.PI/2);

            _spriteBatch.Draw(_tx, vpCenter + new Vector2(x, 0), null, Color.White,
                              0f, txCenter, 1f, SpriteEffects.None, 0);

            _spriteBatch.End();
        }

    }
}
