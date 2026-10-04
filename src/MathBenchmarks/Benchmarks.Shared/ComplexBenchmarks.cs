#if KNI
using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace Benchmarks
{
    // Complex exists only in KNI.
    [MemoryDiagnoser]
    public class ComplexBenchmarks
    {
        const int Count = 1024;

        Complex[] _ca, _cb, _cr;

        [GlobalSetup]
        public void Setup()
        {
            _ca = new Complex[Count]; _cb = new Complex[Count]; _cr = new Complex[Count];
            for (int i = 0; i < Count; i++)
            {
                float f = i * 0.01f;
                _ca[i] = Complex.CreateFromAngle(f);
                _cb[i] = Complex.CreateFromAngle(f * 0.5f + 0.3f);
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
    }
}
#endif
