using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        const int Count = 1024;

        float[] _f;
        Matrix _ma, _mb, _mr;
        Quaternion _qa, _qb, _qr;
        Vector3[] _v3;

        [GlobalSetup]
        public void Setup()
        {
            _f = new float[Count];
            _v3 = new Vector3[Count];
            for (int i = 0; i < Count; i++) { _f[i] = i * 0.01f; _v3[i] = new Vector3(i, 1, 2); }
            _ma = Matrix.CreateRotationX(0.3f) * Matrix.CreateTranslation(1, 2, 3);
            _mb = Matrix.CreateRotationY(0.7f) * Matrix.CreateScale(2f);
            _qa = Quaternion.Normalize(new Quaternion(0.1f, 0.2f, 0.3f, 0.9f));
            _qb = Quaternion.Normalize(new Quaternion(0.4f, 0.1f, 0.2f, 0.8f));
        }

        [Benchmark]
        public float MathHelper_WrapAngle()
        {
            float acc = 0;
            for (int i = 0; i < Count; i++) acc += MathHelper.WrapAngle(_f[i] * 10);
            return acc;
        }

        [Benchmark]
        public float MathHelper_Lerp()
        {
            float acc = 0;
            for (int i = 0; i < Count; i++) acc += MathHelper.Lerp(_f[i], 1f, 0.25f);
            return acc;
        }

        [Benchmark]
        public Matrix Matrix_Multiply()
        {
            for (int i = 0; i < Count; i++) Matrix.Multiply(ref _ma, ref _mb, out _mr);
            return _mr;
        }

        [Benchmark]
        public Matrix Matrix_Invert()
        {
            for (int i = 0; i < Count; i++) Matrix.Invert(ref _ma, out _mr);
            return _mr;
        }

        [Benchmark]
        public Matrix Matrix_CreateRotationY()
        {
            for (int i = 0; i < Count; i++) Matrix.CreateRotationY(_f[i], out _mr);
            return _mr;
        }

        [Benchmark]
        public Matrix Matrix_CreateFromQuaternion()
        {
            for (int i = 0; i < Count; i++) Matrix.CreateFromQuaternion(ref _qa, out _mr);
            return _mr;
        }

        [Benchmark]
        public Quaternion Quaternion_Multiply()
        {
            for (int i = 0; i < Count; i++) Quaternion.Multiply(ref _qa, ref _qb, out _qr);
            return _qr;
        }

        [Benchmark]
        public Quaternion Quaternion_Slerp()
        {
            for (int i = 0; i < Count; i++) Quaternion.Slerp(ref _qa, ref _qb, 0.3f, out _qr);
            return _qr;
        }

        [Benchmark]
        public float Vector3_Dot()
        {
            float acc = 0, d;
            for (int i = 1; i < Count; i++) { Vector3.Dot(ref _v3[i], ref _v3[i - 1], out d); acc += d; }
            return acc;
        }

        [Benchmark]
        public Vector3 Vector3_Cross()
        {
            Vector3 r = Vector3.Zero;
            for (int i = 1; i < Count; i++) Vector3.Cross(ref _v3[i], ref _v3[i - 1], out r);
            return r;
        }

        [Benchmark]
        public Vector3 Vector3_Normalize()
        {
            Vector3 r = Vector3.Zero;
            for (int i = 0; i < Count; i++) Vector3.Normalize(ref _v3[i], out r);
            return r;
        }
    }
}
