namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCpuFlags
{
    None = 0,

    /// <summary>
    /// force usage of selected flags (OR)
    /// </summary>
    AV_CPU_FLAG_FORCE = unchecked((int)0x80000000),

    // lower 16 bits - CPU features
    /// <summary>
    /// standard MMX
    /// </summary>
    AV_CPU_FLAG_MMX = 0x0001,

    /// <summary>
    /// SSE integer functions or AMD MMX ext
    /// </summary>
    AV_CPU_FLAG_MMXEXT = 0x0002,

    /// <summary>
    /// SSE integer functions or AMD MMX ext
    /// </summary>
    AV_CPU_FLAG_MMX2 = 0x0002,

    /// <summary>
    /// AMD 3DNOW
    /// </summary>
    AV_CPU_FLAG_3DNOW = 0x0004,

    /// <summary>
    /// SSE functions
    /// </summary>
    AV_CPU_FLAG_SSE = 0x0008,

    /// <summary>
    /// PIV SSE2 functions
    /// </summary>
    AV_CPU_FLAG_SSE2 = 0x0010,

    /// <summary>
    /// SSE2 supported, but usually not faster than regular MMX/SSE (e.g. Core1)
    /// </summary>
    AV_CPU_FLAG_SSE2SLOW = 0x40000000,

    /// <summary>
    /// AMD 3DNowExt
    /// </summary>
    AV_CPU_FLAG_3DNOWEXT = 0x0020,

    /// <summary>
    /// Prescott SSE3 functions
    /// </summary>
    AV_CPU_FLAG_SSE3 = 0x0040,

    /// <summary>
    /// SSE3 supported, but usually not faster than regular MMX/SSE (e.g. Core1)
    /// </summary>
    AV_CPU_FLAG_SSE3SLOW = 0x20000000,

    /// <summary>
    /// Conroe SSSE3 functions
    /// </summary>
    AV_CPU_FLAG_SSSE3 = 0x0080,

    /// <summary>
    /// SSSE3 supported, but usually not faster
    /// </summary>
    AV_CPU_FLAG_SSSE3SLOW = 0x4000000,

    /// <summary>
    /// Atom processor, some SSSE3 instructions are slower
    /// </summary>
    AV_CPU_FLAG_ATOM = 0x10000000,

    /// <summary>
    /// Penryn SSE4.1 functions
    /// </summary>
    AV_CPU_FLAG_SSE4 = 0x0100,

    /// <summary>
    /// Nehalem SSE4.2 functions
    /// </summary>
    AV_CPU_FLAG_SSE42 = 0x0200,

    /// <summary>
    /// Advanced Encryption Standard functions
    /// </summary>
    AV_CPU_FLAG_AESNI = 0x80000,

    /// <summary>
    /// AVX functions: requires OS support even if YMM registers aren't used
    /// </summary>
    AV_CPU_FLAG_AVX = 0x4000,

    /// <summary>
    /// AVX supported, but slow when using YMM registers (e.g. Bulldozer)
    /// </summary>
    AV_CPU_FLAG_AVXSLOW = 0x8000000,

    /// <summary>
    /// Bulldozer XOP functions
    /// </summary>
    AV_CPU_FLAG_XOP = 0x0400,

    /// <summary>
    /// Bulldozer FMA4 functions
    /// </summary>
    AV_CPU_FLAG_FMA4 = 0x0800,

    /// <summary>
    /// supports cmov instruction
    /// </summary>
    AV_CPU_FLAG_CMOV = 0x1000,

    /// <summary>
    /// AVX2 functions: requires OS support even if YMM registers aren't used
    /// </summary>
    AV_CPU_FLAG_AVX2 = 0x8000,

    /// <summary>
    /// Haswell FMA3 functions
    /// </summary>
    AV_CPU_FLAG_FMA3 = 0x10000,

    /// <summary>
    /// Bit Manipulation Instruction Set 1
    /// </summary>
    AV_CPU_FLAG_BMI1 = 0x20000,

    /// <summary>
    /// Bit Manipulation Instruction Set 2
    /// </summary>
    AV_CPU_FLAG_BMI2 = 0x40000,

    /// <summary>
    /// AVX-512 functions: requires OS support even if YMM/ZMM registers aren't used
    /// </summary>
    AV_CPU_FLAG_AVX512 = 0x100000,

    /// <summary>
    /// CPU has slow gathers.
    /// </summary>
    AV_CPU_FLAG_SLOW_GATHER = 0x2000000,

    /// <summary>
    /// standard
    /// </summary>
    AV_CPU_FLAG_ALTIVEC = 0x0001,

    /// <summary>
    /// ISA 2.06
    /// </summary>
    AV_CPU_FLAG_VSX = 0x0002,

    /// <summary>
    /// ISA 2.07
    /// </summary>
    AV_CPU_FLAG_POWER8 = 0x0004,

    AV_CPU_FLAG_ARMV5TE = 1 << 0,
    AV_CPU_FLAG_ARMV6 = 1 << 1,
    AV_CPU_FLAG_ARMV6T2 = 1 << 2,
    AV_CPU_FLAG_VFP = 1 << 3,
    AV_CPU_FLAG_VFPV3 = 1 << 4,
    AV_CPU_FLAG_NEON = 1 << 5,
    AV_CPU_FLAG_ARMV8 = 1 << 6,

    /// <summary>
    /// VFPv2 vector mode, deprecated in ARMv7-A and unavailable in various CPUs implementations
    /// </summary>
    AV_CPU_FLAG_VFP_VM = 1 << 7,
    AV_CPU_FLAG_SETEND = 1 << 16,

    AV_CPU_FLAG_MMI = 1 << 0,
    AV_CPU_FLAG_MSA = 1 << 1,

    /// <summary>
    /// Loongarch SIMD extension.
    /// </summary>
    AV_CPU_FLAG_LSX = 1 << 0,
    AV_CPU_FLAG_LASX = 1 << 1,
}
