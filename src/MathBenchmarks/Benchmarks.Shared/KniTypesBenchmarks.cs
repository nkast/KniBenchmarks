#if KNI
using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    // Complex, Pose2 and Pose3 exist only in KNI.
    [MemoryDiagnoser]
    public class KniTypesBenchmarks
    {
        const int Count = 1024;

        Complex[] _ca, _cb, _cr;
        Pose2[] _p2a, _p2b, _p2r;
        Pose3[] _p3a, _p3b, _p3r;

        [GlobalSetup]
        public void Setup()
        {
            _ca = new Complex[Count]; _cb = new Complex[Count]; _cr = new Complex[Count];
            _p2a = new Pose2[Count]; _p2b = new Pose2[Count]; _p2r = new Pose2[Count];
            _p3a = new Pose3[Count]; _p3b = new Pose3[Count]; _p3r = new Pose3[Count];
            for (int i = 0; i < Count; i++)
            {
                float f = i * 0.01f;
                _ca[i] = Complex.CreateFromAngle(f);
                _cb[i] = Complex.CreateFromAngle(f * 0.5f + 0.3f);
                _p2a[i] = new Pose2(_ca[i], new Vector2(f, 2f));
                _p2b[i] = new Pose2(_cb[i], new Vector2(1f, f));
                _p3a[i] = new Pose3(Quaternion.CreateFromYawPitchRoll(f, 0.2f, 0.1f), new Vector3(f, 2f, 3f));
                _p3b[i] = new Pose3(Quaternion.CreateFromYawPitchRoll(0.3f, f, 0.1f), new Vector3(1f, f, 3f));
            }
        }

        [Benchmark]
        public void Complex_CreateFromAngle()
        {
            for (int i = 0; i < Count; i++) _cr[i] = Complex.CreateFromAngle(i * 0.01f);
        }

        [Benchmark]
        public void Complex_Multiply()
        {
            for (int i = 0; i < Count; i++) Complex.Multiply(ref _ca[i], ref _cb[i], out _cr[i]);
        }

        [Benchmark]
        public void Complex_Multiply_Operator()
        {
            for (int i = 0; i < Count; i++) _cr[i] = _ca[i] * _cb[i];
        }

        [Benchmark]
        public void Complex_Divide()
        {
            for (int i = 0; i < Count; i++) Complex.Divide(ref _ca[i], ref _cb[i], out _cr[i]);
        }

        [Benchmark]
        public void Complex_Conjugate()
        {
            for (int i = 0; i < Count; i++) Complex.Conjugate(ref _ca[i], out _cr[i]);
        }

        [Benchmark]
        public void Complex_Normalize()
        {
            for (int i = 0; i < Count; i++) Complex.Normalize(ref _ca[i], out _cr[i]);
        }

        [Benchmark]
        public float Complex_Phase()
        {
            float acc = 0;
            for (int i = 0; i < Count; i++) acc += _ca[i].Phase;
            return acc;
        }

        [Benchmark]
        public void Pose2_Multiply()
        {
            for (int i = 0; i < Count; i++) _p2r[i] = Pose2.Multiply(_p2a[i], _p2b[i]);
        }

        [Benchmark]
        public void Pose2_Multiply_Operator()
        {
            for (int i = 0; i < Count; i++) _p2r[i] = _p2a[i] * _p2b[i];
        }

        [Benchmark]
        public void Pose2_Inverse()
        {
            for (int i = 0; i < Count; i++) _p2r[i] = Pose2.Inverse(_p2a[i]);
        }

        [Benchmark]
        public void Pose3_Multiply()
        {
            for (int i = 0; i < Count; i++) _p3r[i] = Pose3.Multiply(_p3a[i], _p3b[i]);
        }

        [Benchmark]
        public void Pose3_Multiply_Operator()
        {
            for (int i = 0; i < Count; i++) _p3r[i] = _p3a[i] * _p3b[i];
        }

        [Benchmark]
        public void Pose3_Inverse()
        {
            for (int i = 0; i < Count; i++) _p3r[i] = Pose3.Inverse(_p3a[i]);
        }
    }
}
#endif
