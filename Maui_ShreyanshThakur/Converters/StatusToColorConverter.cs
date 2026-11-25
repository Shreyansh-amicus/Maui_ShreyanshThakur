
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui_ShreyanshThakur.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        string status = value?.ToString()?.Trim().ToLowerInvariant() ?? string.Empty;

        return status switch
        {
            "completed" => Colors.Green,
            "pending" => Colors.Orange,
            "in progress" => Colors.DodgerBlue,
            "overdue" => Colors.Red,
            "cancelled" => Colors.Gray,
            _ => Colors.Black
        };
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
