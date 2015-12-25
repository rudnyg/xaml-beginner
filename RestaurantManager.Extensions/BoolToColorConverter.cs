using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color returnValue = Colors.Transparent;
            if (value is bool)
            {
                returnValue = (bool) value ? Colors.Red : Colors.Transparent;
            }

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var  returnValue = default(bool);
            if (value is Color)
            {
                if ((Color) value == Colors.Red)
                {
                    returnValue = true;
                }
                else if((Color)value == Colors.Green)
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }
    }
}
