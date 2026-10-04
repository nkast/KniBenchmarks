using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    public static class MathBenchmarks
    {
        const int Iterations = 10000000;
        const int Runs = 5;

        static float _sink;

        public static void RunAll()
        {
            Run("MathHelper.Lerp", Lerp);
            Run("MathHelper.Clamp", Clamp);
            Run("MathHelper.WrapAngle", WrapAngle);
            Run("Vector2.Normalize", Vector2Normalize);
            Run("Vector2.Transform(Matrix)", Vector2Transform);
            Run("Vector3.Dot", Vector3Dot);
            Run("Vector3.Cross", Vector3Cross);
            Run("Vector3.Normalize", Vector3Normalize);
            Run("Vector3.Transform(Matrix)", Vector3Transform);
            Run("Vector3.Lerp", Vector3Lerp);
            Run("Vector4.Transform(Matrix)", Vector4Transform);
            Run("Matrix.Multiply", MatrixMultiply);
            Run("Matrix.Invert", MatrixInvert);
            Run("Matrix.CreateRotationY", MatrixCreateRotationY);
            Run("Matrix.CreateFromQuaternion", MatrixCreateFromQuaternion);
            Run("Quaternion.Multiply", QuaternionMultiply);
            Run("Quaternion.Slerp", QuaternionSlerp);
            Run("Quaternion.Normalize", QuaternionNormalize);
            Run("BoundingBox.Intersects(BoundingBox)", BoundingBoxIntersects);
            Run("BoundingSphere.Intersects(BoundingSphere)", BoundingSphereIntersects);
            Run("Ray.Intersects(BoundingSphere)", RaySphereIntersects);
            Console.WriteLine("(sink: " + _sink + ")");
        }

        static void Run(string name, Action test)
        {
            test(); // warm-up

            double best = double.MaxValue;
            for (int r = 0; r < Runs; r++)
            {
                var sw = Stopwatch.StartNew();
                test();
                sw.Stop();
                if (sw.Elapsed.TotalMilliseconds < best)
                    best = sw.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("{0,-45} {1,10:F2} ms  {2,8:F2} ns/op", name, best, best * 1000000.0 / Iterations);
        }

        static void Lerp()
        {
            float acc = 0;
            for (int i = 0; i < Iterations; i++)
                acc += MathHelper.Lerp(i, 1f, 0.25f);
            _sink += acc;
        }

        static void Clamp()
        {
            float acc = 0;
            for (int i = 0; i < Iterations; i++)
                acc += MathHelper.Clamp(i, 10f, 1000f);
            _sink += acc;
        }

        static void WrapAngle()
        {
            float acc = 0;
            for (int i = 0; i < Iterations; i++)
                acc += MathHelper.WrapAngle(i * 0.01f);
            _sink += acc;
        }

        static void Vector2Normalize()
        {
            Vector2 acc = Vector2.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var v = new Vector2(i + 1, 2f);
                Vector2.Normalize(ref v, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y;
        }

        static void Vector2Transform()
        {
            Matrix m = Matrix.CreateRotationZ(0.5f) * Matrix.CreateTranslation(1, 2, 3);
            Vector2 acc = Vector2.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var v = new Vector2(i, 1f);
                Vector2.Transform(ref v, ref m, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y;
        }

        static void Vector3Dot()
        {
            var b = new Vector3(0.1f, 0.2f, 0.3f);
            float acc = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var a = new Vector3(i, 2f, 3f);
                float d;
                Vector3.Dot(ref a, ref b, out d);
                acc += d;
            }
            _sink += acc;
        }

        static void Vector3Cross()
        {
            var b = new Vector3(0.1f, 0.2f, 0.3f);
            Vector3 acc = Vector3.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var a = new Vector3(i, 2f, 3f);
                Vector3 c;
                Vector3.Cross(ref a, ref b, out c);
                acc += c;
            }
            _sink += acc.X + acc.Y + acc.Z;
        }

        static void Vector3Normalize()
        {
            Vector3 acc = Vector3.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var v = new Vector3(i + 1, 2f, 3f);
                Vector3.Normalize(ref v, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y + acc.Z;
        }

        static void Vector3Transform()
        {
            Matrix m = Matrix.CreateRotationY(0.5f) * Matrix.CreateTranslation(1, 2, 3);
            Vector3 acc = Vector3.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var v = new Vector3(i, 1f, 2f);
                Vector3.Transform(ref v, ref m, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y + acc.Z;
        }

        static void Vector3Lerp()
        {
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(4, 5, 6);
            Vector3 acc = Vector3.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                Vector3 v;
                Vector3.Lerp(ref a, ref b, (i & 255) / 255f, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y + acc.Z;
        }

        static void Vector4Transform()
        {
            Matrix m = Matrix.CreateRotationX(0.5f) * Matrix.CreateTranslation(1, 2, 3);
            Vector4 acc = Vector4.Zero;
            for (int i = 0; i < Iterations; i++)
            {
                var v = new Vector4(i, 1f, 2f, 1f);
                Vector4.Transform(ref v, ref m, out v);
                acc += v;
            }
            _sink += acc.X + acc.Y + acc.Z + acc.W;
        }

        static void MatrixMultiply()
        {
            Matrix a = Matrix.CreateRotationX(0.3f) * Matrix.CreateTranslation(1, 2, 3);
            Matrix b = Matrix.CreateRotationY(0.7f) * Matrix.CreateScale(2f);
            Matrix r = Matrix.Identity;
            for (int i = 0; i < Iterations; i++)
            {
                Matrix.Multiply(ref a, ref b, out r);
                a.M41 = i;
            }
            _sink += r.M11 + r.M44;
        }

        static void MatrixInvert()
        {
            Matrix a = Matrix.CreateRotationX(0.3f) * Matrix.CreateTranslation(1, 2, 3);
            Matrix r = Matrix.Identity;
            for (int i = 0; i < Iterations; i++)
            {
                a.M41 = i;
                Matrix.Invert(ref a, out r);
            }
            _sink += r.M11 + r.M44;
        }

        static void MatrixCreateRotationY()
        {
            Matrix r = Matrix.Identity;
            for (int i = 0; i < Iterations; i++)
                Matrix.CreateRotationY(i * 0.001f, out r);
            _sink += r.M11 + r.M13;
        }

        static void MatrixCreateFromQuaternion()
        {
            Quaternion q = Quaternion.Normalize(new Quaternion(0.1f, 0.2f, 0.3f, 0.9f));
            Matrix r = Matrix.Identity;
            for (int i = 0; i < Iterations; i++)
            {
                q.X = (i & 15) * 0.01f;
                Matrix.CreateFromQuaternion(ref q, out r);
            }
            _sink += r.M11 + r.M33;
        }

        static void QuaternionMultiply()
        {
            Quaternion a = Quaternion.Normalize(new Quaternion(0.1f, 0.2f, 0.3f, 0.9f));
            Quaternion b = Quaternion.Normalize(new Quaternion(0.4f, 0.1f, 0.2f, 0.8f));
            Quaternion r = Quaternion.Identity;
            for (int i = 0; i < Iterations; i++)
            {
                Quaternion.Multiply(ref a, ref b, out r);
                a.X = (i & 15) * 0.01f;
            }
            _sink += r.X + r.W;
        }

        static void QuaternionSlerp()
        {
            Quaternion a = Quaternion.Normalize(new Quaternion(0.1f, 0.2f, 0.3f, 0.9f));
            Quaternion b = Quaternion.Normalize(new Quaternion(0.4f, 0.1f, 0.2f, 0.8f));
            Quaternion r = Quaternion.Identity;
            for (int i = 0; i < Iterations; i++)
                Quaternion.Slerp(ref a, ref b, (i & 255) / 255f, out r);
            _sink += r.X + r.W;
        }

        static void QuaternionNormalize()
        {
            Quaternion r = Quaternion.Identity;
            for (int i = 0; i < Iterations; i++)
            {
                var q = new Quaternion(i + 1, 2f, 3f, 4f);
                Quaternion.Normalize(ref q, out r);
            }
            _sink += r.X + r.W;
        }

        static void BoundingBoxIntersects()
        {
            var a = new BoundingBox(new Vector3(0, 0, 0), new Vector3(2, 2, 2));
            int hits = 0;
            for (int i = 0; i < Iterations; i++)
            {
                float o = (i & 7) * 0.5f;
                var b = new BoundingBox(new Vector3(o, o, o), new Vector3(o + 2, o + 2, o + 2));
                bool res;
                a.Intersects(ref b, out res);
                if (res) hits++;
            }
            _sink += hits;
        }

        static void BoundingSphereIntersects()
        {
            var a = new BoundingSphere(Vector3.Zero, 2f);
            int hits = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var b = new BoundingSphere(new Vector3((i & 7) * 0.5f, 0, 0), 1f);
                bool res;
                a.Intersects(ref b, out res);
                if (res) hits++;
            }
            _sink += hits;
        }

        static void RaySphereIntersects()
        {
            var s = new BoundingSphere(new Vector3(0, 0, 5), 1f);
            int hits = 0;
            for (int i = 0; i < Iterations; i++)
            {
                var ray = new Ray(new Vector3((i & 7) * 0.25f, 0, 0), Vector3.Forward * -1f);
                float? res;
                ray.Intersects(ref s, out res);
                if (res.HasValue) hits++;
            }
            _sink += hits;
        }
    }
}
