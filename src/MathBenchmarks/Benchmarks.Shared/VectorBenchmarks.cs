using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class VectorBenchmarks
    {
        const int Count = 1024;

        Vector2[] _v2a, _v2b, _v2r;
        Vector3[] _v3a, _v3b, _v3r;
        Vector4[] _v4a, _v4b, _v4r;
        Matrix _matrix;
        Quaternion _quat;

        [GlobalSetup]
        public void Setup()
        {
            _v2a = new Vector2[Count]; _v2b = new Vector2[Count]; _v2r = new Vector2[Count];
            _v3a = new Vector3[Count]; _v3b = new Vector3[Count]; _v3r = new Vector3[Count];
            _v4a = new Vector4[Count]; _v4b = new Vector4[Count]; _v4r = new Vector4[Count];
            for (int i = 0; i < Count; i++)
            {
                float f = i + 1;
                _v2a[i] = new Vector2(f, f * 0.5f);
                _v2b[i] = new Vector2(f * 0.25f + 1, f * 0.75f + 1);
                _v3a[i] = new Vector3(f, f * 0.5f, f * 0.25f);
                _v3b[i] = new Vector3(f * 0.25f + 1, f * 0.75f + 1, f * 0.1f + 1);
                _v4a[i] = new Vector4(f, f * 0.5f, f * 0.25f, 1);
                _v4b[i] = new Vector4(f * 0.25f + 1, f * 0.75f + 1, f * 0.1f + 1, 1);
            }
            _matrix = Matrix.CreateRotationX(0.3f) * Matrix.CreateRotationY(0.5f) * Matrix.CreateTranslation(1, 2, 3);
            _quat = Quaternion.Normalize(new Quaternion(0.1f, 0.2f, 0.3f, 0.9f));
        }

        // Transform by matrix

        [Benchmark, BenchmarkCategory("Transform")]
        public void Vector2_Transform_Matrix()
        {
            for (int i = 0; i < Count; i++) Vector2.Transform(ref _v2a[i], ref _matrix, out _v2r[i]);
        }

        [Benchmark]
        public void Vector2_TransformNormal_Matrix()
        {
            for (int i = 0; i < Count; i++) Vector2.TransformNormal(ref _v2a[i], ref _matrix, out _v2r[i]);
        }

        [Benchmark]
        public void Vector3_Transform_Matrix()
        {
            for (int i = 0; i < Count; i++) Vector3.Transform(ref _v3a[i], ref _matrix, out _v3r[i]);
        }

        [Benchmark]
        public void Vector3_TransformNormal_Matrix()
        {
            for (int i = 0; i < Count; i++) Vector3.TransformNormal(ref _v3a[i], ref _matrix, out _v3r[i]);
        }

        [Benchmark]
        public void Vector3_Transform_Quaternion()
        {
            for (int i = 0; i < Count; i++) Vector3.Transform(ref _v3a[i], ref _quat, out _v3r[i]);
        }

        [Benchmark]
        public void Vector4_Transform_Matrix()
        {
            for (int i = 0; i < Count; i++) Vector4.Transform(ref _v4a[i], ref _matrix, out _v4r[i]);
        }

        [Benchmark]
        public void Vector3_TransformArray_Matrix()
        {
            Vector3.Transform(_v3a, ref _matrix, _v3r);
        }

        // Multiply

        [Benchmark]
        public void Vector2_Multiply()
        {
            for (int i = 0; i < Count; i++) Vector2.Multiply(ref _v2a[i], ref _v2b[i], out _v2r[i]);
        }

        [Benchmark]
        public void Vector2_Multiply_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector2.Multiply(ref _v2a[i], 2.5f, out _v2r[i]);
        }

        [Benchmark]
        public void Vector3_Multiply()
        {
            for (int i = 0; i < Count; i++) Vector3.Multiply(ref _v3a[i], ref _v3b[i], out _v3r[i]);
        }

        [Benchmark]
        public void Vector3_Multiply_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector3.Multiply(ref _v3a[i], 2.5f, out _v3r[i]);
        }

        [Benchmark]
        public void Vector4_Multiply()
        {
            for (int i = 0; i < Count; i++) Vector4.Multiply(ref _v4a[i], ref _v4b[i], out _v4r[i]);
        }

        [Benchmark]
        public void Vector4_Multiply_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector4.Multiply(ref _v4a[i], 2.5f, out _v4r[i]);
        }

        // Add

        [Benchmark]
        public void Vector2_Add()
        {
            for (int i = 0; i < Count; i++) Vector2.Add(ref _v2a[i], ref _v2b[i], out _v2r[i]);
        }

        [Benchmark]
        public void Vector3_Add()
        {
            for (int i = 0; i < Count; i++) Vector3.Add(ref _v3a[i], ref _v3b[i], out _v3r[i]);
        }

        [Benchmark]
        public void Vector3_Add_Operator()
        {
            for (int i = 0; i < Count; i++) _v3r[i] = _v3a[i] + _v3b[i];
        }

        [Benchmark]
        public void Vector4_Add()
        {
            for (int i = 0; i < Count; i++) Vector4.Add(ref _v4a[i], ref _v4b[i], out _v4r[i]);
        }

        // Divide

        [Benchmark]
        public void Vector2_Divide()
        {
            for (int i = 0; i < Count; i++) Vector2.Divide(ref _v2a[i], ref _v2b[i], out _v2r[i]);
        }

        [Benchmark]
        public void Vector2_Divide_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector2.Divide(ref _v2a[i], 2.5f, out _v2r[i]);
        }

        [Benchmark]
        public void Vector3_Divide()
        {
            for (int i = 0; i < Count; i++) Vector3.Divide(ref _v3a[i], ref _v3b[i], out _v3r[i]);
        }

        [Benchmark]
        public void Vector3_Divide_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector3.Divide(ref _v3a[i], 2.5f, out _v3r[i]);
        }

        [Benchmark]
        public void Vector4_Divide()
        {
            for (int i = 0; i < Count; i++) Vector4.Divide(ref _v4a[i], ref _v4b[i], out _v4r[i]);
        }

        [Benchmark]
        public void Vector4_Divide_Scalar()
        {
            for (int i = 0; i < Count; i++) Vector4.Divide(ref _v4a[i], 2.5f, out _v4r[i]);
        }
    }
}
