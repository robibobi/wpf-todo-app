using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoApp.Converters
{
    class TodoNameToBrushConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter, 
            CultureInfo culture)
        {
            var todoItemName = value.ToString();

            if(todoItemName.Length > 5)
            {
                return Brushes.Red;
            } else
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
