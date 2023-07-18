using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VisualCOM.ValueConvert
{
    public class DataUtilConvert : IValueConverter
    {
        // value ->viewmodel property parameter->view
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        //value ->view bindingProperty parameter->view
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return parameter;
            return Binding.DoNothing;
        }
    }
}
