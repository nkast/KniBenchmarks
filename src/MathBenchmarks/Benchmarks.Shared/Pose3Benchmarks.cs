#if KNI
using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    // Pose3 exists only in KNI.
    [MemoryDiagnoser]
    public class Pose3Benchmarks
    {
        const int Count = 1024;

        Pose3[] _p3a, _p3b, _p3r;

        [GlobalSetup]
        public void Setup()
        {
            _p3a = new Pose3[Count]; _p3b = new Pose3[Count]; _p3r = new Pose3[Count];
            for (int i = 0; i < Count; i++)
            {
                float f = i * 0.01f;
                _p3a[i] = new Pose3(Quaternion.CreateFromYawPitchRoll(f, 0.2f, 0.1f), new Vector3(f, 2f, 3f));
                _p3b[i] = new Pose3(Quaternion.CreateFromYawPitchRoll(0.3f, f, 0.1f), new Vector3(1f, f, 3f));
            }
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
