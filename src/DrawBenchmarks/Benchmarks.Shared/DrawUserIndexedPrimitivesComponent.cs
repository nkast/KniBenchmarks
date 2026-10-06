using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Benchmarks
{
    public class DrawUserIndexedPrimitivesComponent : DrawableGameComponent
    {
        const int Columns = 32;
        const int Rows = 20;
        const int Repeat = 64;

        BasicEffect _effect;
        VertexPositionColor[] _vertices;
        short[] _indices;

        public DrawUserIndexedPrimitivesComponent(Game game) : base(game)
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

            // 4 vertices and 6 indices per quad
            _vertices = new VertexPositionColor[Columns * Rows * 4];
            _indices = new short[Columns * Rows * 6];
            int v = 0, i = 0;
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    var c = new Color(x * 255 / Columns, y * 255 / Rows, 128);
                    float x0 = x * 24, y0 = y * 24, x1 = x0 + 20, y1 = y0 + 20;
                    _vertices[v + 0] = new VertexPositionColor(new Vector3(x0, y0, 0), c);
                    _vertices[v + 1] = new VertexPositionColor(new Vector3(x1, y0, 0), c);
                    _vertices[v + 2] = new VertexPositionColor(new Vector3(x0, y1, 0), c);
                    _vertices[v + 3] = new VertexPositionColor(new Vector3(x1, y1, 0), c);
                    _indices[i++] = (short)(v + 0);
                    _indices[i++] = (short)(v + 1);
                    _indices[i++] = (short)(v + 2);
                    _indices[i++] = (short)(v + 1);
                    _indices[i++] = (short)(v + 3);
                    _indices[i++] = (short)(v + 2);
                    v += 4;
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
                GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, _vertices, 0, _vertices.Length, _indices, 0, _indices.Length / 3);
            }
        }
    }
}
