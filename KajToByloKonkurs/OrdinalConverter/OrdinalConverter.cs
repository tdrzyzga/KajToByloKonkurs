using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace KajToBylo
{
    public class OrdinalConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            ListViewItem listViewItem = value as ListViewItem;
            int ordinal = 0;

            if (listViewItem != null)
            {
                ListView listView = ItemsControl.ItemsControlFromItemContainer(listViewItem) as ListView;
                ordinal = listView.ItemContainerGenerator.IndexFromContainer(listViewItem) + 1;
            }

            return ordinal;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This converter does not provide conversion back from ordinal position to list view item
            throw new System.InvalidOperationException();
        }
    }
}

