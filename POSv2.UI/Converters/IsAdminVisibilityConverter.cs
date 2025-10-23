using Avalonia.Data.Converters;
using Avalonia.Controls;
using System;
using System.Globalization;

public class IsAdminVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null && value.ToString() == "Administrador" ? Avalonia.Controls.Visibility.Visible : Avalonia.Controls.Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}