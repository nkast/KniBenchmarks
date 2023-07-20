using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class DrawSpriteComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        Texture2D _tx;

        public SpriteSortMode SortMode { get; set; }
        public SpriteEffects Effects { get; set; }


        public DrawSpriteComponent(Game game) : base(game)
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
            
            for (int a = 0; a < 32; a++)
            {
                for (int y = 0; y <= 480/64; y++)
                {
                    for (int x = 0; x <= 800/64; x++)
                    {
                        _spriteBatch.Draw(_tx, new Vector2(x<<6, y<<6), Color.White
                            /*
                            ,
                            0f, // rotation
                            new Vector2(0.5f), // origin
                            new Vector2(1.25f, 0.75f), // scale
                            Effects,
                            0
                            */
                            );
                    }
                }
            }

            _spriteBatch.End();
        }

    }
}
