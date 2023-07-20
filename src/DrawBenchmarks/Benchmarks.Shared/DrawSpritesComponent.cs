using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class DrawSpritesComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        Texture2D _tx;
        Texture2D _tx1;

        public SpriteSortMode SortMode { get; set; }
        public SpriteEffects Effects { get; set; }


        public DrawSpritesComponent(Game game) : base(game)
        {
            SortMode = SpriteSortMode.Deferred;
            Effects = SpriteEffects.None;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tx = Game.Content.Load<Texture2D>("Tx");
            _tx1 = Game.Content.Load<Texture2D>("Tx1");
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SortMode, null);
            
            for (int a = 0; a < 32 / 2; a++)
            {
                for (int y = 0; y <= 480/64; y++)
                {
                    for (int x = 0; x <= 800/64; x++)
                    {
                        _spriteBatch.Draw(_tx, new Vector2(x<<6, y<<6), Color.White);
                        _spriteBatch.Draw(_tx1, new Vector2((x<<6)+48, (y<<6)+48), Color.Coral);
                    }
                }
            }

            _spriteBatch.End();
        }

    }
}
