using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class DrawUserPrimitivesComponent : DrawableGameComponent
    {
        const int Columns = 32;
        const int Rows = 20;
        const int Repeat = 16;

        BasicEffect _effect;
        VertexPositionColor[] _vertices;


        public DrawUserPrimitivesComponent(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _effect = new BasicEffect(GraphicsDevice);
            _effect.VertexColorEnabled = true;
            _effect.TextureEnabled = false;
            _effect.LightingEnabled = false;
            _effect.World = Matrix.Identity;
            _effect.View = Matrix.Identity;

            // 2 triangles (6 vertices) per quad
            _vertices = new VertexPositionColor[Columns * Rows * 6];
            int i = 0;
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    var c = new Color(x * 255 / Columns, y * 255 / Rows, 128);
                    float x0 = x * 24, y0 = y * 24, x1 = x0 + 20, y1 = y0 + 20;
                    _vertices[i++] = new VertexPositionColor(new Vector3(x0, y0, 0), c);
                    _vertices[i++] = new VertexPositionColor(new Vector3(x1, y0, 0), c);
                    _vertices[i++] = new VertexPositionColor(new Vector3(x0, y1, 0), c);
                    _vertices[i++] = new VertexPositionColor(new Vector3(x1, y0, 0), c);
                    _vertices[i++] = new VertexPositionColor(new Vector3(x1, y1, 0), c);
                    _vertices[i++] = new VertexPositionColor(new Vector3(x0, y1, 0), c);
                }
            }
        }

        protected override void UnloadContent()
        {
            if (_effect != null)
                _effect.Dispose();
            _effect = null;
        }

        public override void Draw(GameTime gameTime)
        {
            var viewport = GraphicsDevice.Viewport;
            _effect.Projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1);
            _effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            for (int a = 0; a < Repeat; a++)
            {
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, _vertices.Length / 3);
            }
        }
    }
}
