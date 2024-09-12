using System.Globalization;
using System.Windows.Data;

namespace SgLockConfigurator;

/// <summary>
/// Provides a type converter to convert hex <see cref="string"/> objects to and from number types.
/// </summary>
[ValueConversion(typeof(string), typeof(uint))]
internal class HexValueConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(string))
        {
            return value;
        }

        if (value is not uint number)
        {
            return value;
        }

        var hexNumber = string.Format(culture, "0x{0:X8}", number);
        return hexNumber;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(uint))
        {
            return value;
        }

        if (value is not string hexString)
        {
            return value;
        }

        var span = hexString.AsSpan();

        // strip the leading 0x
        if (span.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
        {
            span = span[2..];
        }

        return uint.Parse(span, NumberStyles.HexNumber, culture);
    }
}
