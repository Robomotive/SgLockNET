using System.Windows.Controls;
using System.Windows.Data;

namespace SgLockConfigurator;

/// <summary>
/// Provides a type converter to convert <see cref="DataGridRow"/> to the rows index.
/// </summary>
[ValueConversion(typeof(DataGridRow), typeof(uint))]
public class RowToIndexConvertor : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is DataGridRow row)
        {
            return row.GetIndex() + 1;
        }

        return -1;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotSupportedException();
}
