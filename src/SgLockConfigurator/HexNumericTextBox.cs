using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SgLockConfigurator;

/// <summary>
/// A textbox that only accepts numbers.
/// </summary>
public class HexNumericTextBox : TextBox
{
    /// <inheritdoc/>
    protected override void OnDragOver(DragEventArgs e)
    {
        if (!IsDataValid(e.Data))
        {
            e.Handled = true;
            e.Effects = DragDropEffects.None;
        }

        OnDragEnter(e);
    }

    /// <inheritdoc/>
    protected override void OnDrop(DragEventArgs e)
    {
        e.Handled = !IsDataValid(e.Data);
        base.OnDrop(e);
    }

    /// <inheritdoc/>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key is (< Key.D0 or > Key.D9)
            and (< Key.NumPad0 or > Key.NumPad9)
            and not Key.A
            and not Key.B
            and not Key.C
            and not Key.D
            and not Key.E
            and not Key.F
            and not Key.Back // key is not backspace
            and not Key.Tab
            and not Key.Enter
            and not Key.Escape)
        {
            e.Handled = true;
        }
    }

    private static bool IsDataValid(IDataObject data)
    {
        if (data == null)
        {
            return false;
        }

        var text = data.GetData(DataFormats.Text) as string;
        if (string.IsNullOrEmpty(text?.Trim()))
        {
            return false;
        }

        if (int.TryParse(text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out _))
        {
            return true;
        }

        return false;
    }
}
