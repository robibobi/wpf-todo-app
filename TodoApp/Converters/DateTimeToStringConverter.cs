using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoApp.Converters
{
    class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime dt)
            {
                return dt.ToString("dddd, HH:mm:ss", new CultureInfo("de-DE"));
            } else
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
