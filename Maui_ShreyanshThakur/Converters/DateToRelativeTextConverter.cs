
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Maui_ShreyanshThakur.Converters;

public class DateToRelativeTextConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        DateTime date;

        if (value is DateTime dateTime)
        {
            date = dateTime;
        }
        else if (value is DateTimeOffset dateTimeOffset)
        {
            date = dateTimeOffset.LocalDateTime;
        }
        else
        {
            return string.Empty;
        }

        if (date == DateTime.MinValue)
            return string.Empty;

        TimeSpan difference = DateTime.Now - date;
        bool isFuture = difference < TimeSpan.Zero;

        TimeSpan elapsed = difference.Duration();

        string relativeText;

        if (elapsed.TotalSeconds < 60)
        {
            relativeText = "just now";
        }
        else if (elapsed.TotalMinutes < 60)
        {
            int minutes = (int)elapsed.TotalMinutes;
            relativeText = FormatUnit(minutes, "minute");
        }
        else if (elapsed.TotalHours < 24)
        {
            int hours = (int)elapsed.TotalHours;
            relativeText = FormatUnit(hours, "hour");
        }
        else if (elapsed.TotalDays < 7)
        {
            int days = (int)elapsed.TotalDays;
            relativeText = FormatUnit(days, "day");
        }
        else if (elapsed.TotalDays < 30)
        {
            int weeks = (int)(elapsed.TotalDays / 7);
            relativeText = FormatUnit(weeks, "week");
        }
        else if (elapsed.TotalDays < 365)
        {
            int months = (int)(elapsed.TotalDays / 30);
            relativeText = FormatUnit(months, "month");
        }
        else
        {
            int years = (int)(elapsed.TotalDays / 365);
            relativeText = FormatUnit(years, "year");
        }

        if (isFuture && relativeText != "just now")
            return $"in {relativeText}";

        return isFuture ? "just now" : $"{relativeText} ago";
    }

    private static string FormatUnit(int value, string unit)
    {
        return $"{value} {unit}{(value == 1 ? string.Empty : "s")}";
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
