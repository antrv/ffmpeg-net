using System.Globalization;

namespace Antrv.FFMpeg.Interop;

public struct AVRational: IComparable<AVRational>
{
    private readonly int _numerator;
    private readonly int _denominator;

    public AVRational(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public readonly int Numerator => _numerator;
    public readonly int Denominator => _denominator;

    public int CompareTo(AVRational other)
    {
        if (_denominator == other._denominator)
            return _numerator.CompareTo(other._numerator);

        return (_numerator * (long)other._denominator).CompareTo(other._numerator * (long)_denominator);
    }

    public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _numerator, _denominator);
}
