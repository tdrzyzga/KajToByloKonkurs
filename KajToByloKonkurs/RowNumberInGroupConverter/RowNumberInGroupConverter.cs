using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace KajToBylo
{
    class RowNumberInGroupConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int ordinal = 0;
            QuestionAnswers question = values[1] as QuestionAnswers;
            IEnumerable<object> ob = values[0] as IEnumerable<object>;
            List<object> groupItems = new List<object>();

            foreach (var i in ob)
                groupItems.Add(i);

            ordinal = groupItems.IndexOf(question) + 1;
            return ordinal.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            // This converter does not provide conversion back from ordinal position to list view item
            throw new System.InvalidOperationException();
        }
    }
}
