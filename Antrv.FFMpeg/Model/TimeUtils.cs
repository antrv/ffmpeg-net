using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model;

internal static class TimeUtils
{
    internal static TimeSpan ToTimeSpan(long time, AVRational timeBase)
    {
        if (time == 0)
            return TimeSpan.Zero;
        
        if (time == long.MinValue)
            return TimeSpan.MinValue;

        if (timeBase.Numerator < 0 || timeBase.Denominator < 0)
            throw new ArgumentException("Time base must be positive");

        bool isNegative = time < 0;

        ulong a = (ulong)Math.Abs(time);
        ulong b = (ulong)TimeSpan.TicksPerSecond * (uint)timeBase.Numerator; // never overflow
        ulong high = Math.BigMul(a, b, out ulong low);

        long ticks;
        if (high == 0)
        {
            ticks = (long)(low / (uint)timeBase.Denominator);
        }
        else
        {
            // long division
            ulong mid = ((high % (uint)timeBase.Denominator) << 32) | (low >> 32);
            high /= (uint)timeBase.Denominator;
            low = ((mid % (uint)timeBase.Denominator) << 32) | (low & uint.MaxValue);
            mid /= (uint)timeBase.Denominator;
            low /= (uint)timeBase.Denominator;

            if (high != 0)
                throw new OverflowException();

            ticks = (long)((mid << 32) | low);
        }

        if (isNegative)
            ticks = -ticks;

        return TimeSpan.FromTicks(ticks);
    }
}
