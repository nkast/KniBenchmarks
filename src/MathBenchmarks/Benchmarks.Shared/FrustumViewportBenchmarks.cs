using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class FrustumViewportBenchmarks
    {
        const int Count = 1024;

        BoundingFrustum _frustum;
        BoundingBox[] _boxes;
        BoundingSphere[] _spheres;
        Vector3[] _points, _results;
        Vector3[] _corners;
        Viewport _viewport;
        Matrix _view, _projection, _world;

        [GlobalSetup]
        public void Setup()
        {
            _view = Matrix.CreateLookAt(new Vector3(0, 5, 20), Vector3.Zero, Vector3.Up);
            _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16f / 9f, 0.1f, 1000f);
            _world = Matrix.Identity;
            _viewport = new Viewport(0, 0, 1280, 720);
            _frustum = new BoundingFrustum(_view * _projection);
            _corners = new Vector3[8];

            _boxes = new BoundingBox[Count];
            _spheres = new BoundingSphere[Count];
            _points = new Vector3[Count];
            _results = new Vector3[Count];
            for (int i = 0; i < Count; i++)
            {
                var c = new Vector3((i % 32 - 16) * 2f, (i / 32 - 16) * 2f, -(i % 64) * 3f);
                _points[i] = c;
                _boxes[i] = new BoundingBox(c - Vector3.One, c + Vector3.One);
                _spheres[i] = new BoundingSphere(c, 1.5f);
            }
        }

        [Benchmark]
        public BoundingFrustum BoundingFrustum_Create()
        {
            Matrix vp = _view * _projection;
            BoundingFrustum f = null;
            for (int i = 0; i < Count; i++) f = new BoundingFrustum(vp);
            return f;
        }

        [Benchmark]
        public int BoundingFrustum_Contains_Point()
        {
            int n = 0;
            for (int i = 0; i < Count; i++)
                if (_frustum.Contains(_points[i]) != ContainmentType.Disjoint) n++;
            return n;
        }

        [Benchmark]
        public int BoundingFrustum_Contains_BoundingBox()
        {
            int n = 0;
            for (int i = 0; i < Count; i++)
                if (_frustum.Contains(_boxes[i]) != ContainmentType.Disjoint) n++;
            return n;
        }

        [Benchmark]
        public int BoundingFrustum_Contains_BoundingSphere()
        {
            int n = 0;
            for (int i = 0; i < Count; i++)
                if (_frustum.Contains(_spheres[i]) != ContainmentType.Disjoint) n++;
            return n;
        }

        [Benchmark]
        public int BoundingFrustum_Intersects_BoundingBox()
        {
            int n = 0;
            for (int i = 0; i < Count; i++)
                if (_frustum.Intersects(_boxes[i])) n++;
            return n;
        }

        [Benchmark]
        public int BoundingFrustum_Intersects_BoundingSphere()
        {
            int n = 0;
            for (int i = 0; i < Count; i++)
                if (_frustum.Intersects(_spheres[i])) n++;
            return n;
        }

        [Benchmark]
        public void BoundingFrustum_GetCorners()
        {
            for (int i = 0; i < Count; i++) _frustum.GetCorners(_corners);
        }

        [Benchmark]
        public void Viewport_Project()
        {
            for (int i = 0; i < Count; i++)
                _results[i] = _viewport.Project(_points[i], _projection, _view, _world);
        }

        [Benchmark]
        public void Viewport_Unproject()
        {
            for (int i = 0; i < Count; i++)
                _results[i] = _viewport.Unproject(new Vector3(i % 1280, i % 720, (i & 255) / 255f), _projection, _view, _world);
        }

        [Benchmark]
        public void Viewport_Project_Unproject_RoundTrip()
        {
            for (int i = 0; i < Count; i++)
            {
                Vector3 p = _viewport.Project(_points[i], _projection, _view, _world);
                _results[i] = _viewport.Unproject(p, _projection, _view, _world);
            }
        }
    }
}
