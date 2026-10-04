#if KNI
using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    // Pose2 exists only in KNI.
    [MemoryDiagnoser]
    public class Pose2Benchmarks
    {
        const int Count = 1024;

        Pose2[] _p2a, _p2b, _p2r;

        [GlobalSetup]
        public void Setup()
        {
            _p2a = new Pose2[Count]; _p2b = new Pose2[Count]; _p2r = new Pose2[Count];
            for (int i = 0; i < Count; i++)
            {
                float f = i * 0.01f;
                _p2a[i] = new Pose2(Complex.CreateFromAngle(f), new Vector2(f, 2f));
                _p2b[i] = new Pose2(Complex.CreateFromAngle(f * 0.5f + 0.3f), new Vector2(1f, f));
            }
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
    }
}
#endif
