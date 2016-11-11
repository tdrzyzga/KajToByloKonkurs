using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.ComponentModel;

namespace KajToBylo
{
    class RowNumberInGroupConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int ordinal = 0;
            ListViewItem item = values[0] as ListViewItem;
            

            ListView group = values[1] as ListView;

            ordinal = group.ItemContainerGenerator.IndexFromContainer(item)+1;

            

            //ordinal = groupItems.FindName(item.Name);

          /*if (groupName == MainWindow.NameCategory[(int)MainWindow.IndexCategory.MusicPL])
            {            
                    ++indexMusicPL;
                    ordinal = indexMusicPL;
            }
            else if (groupName == MainWindow.NameCategory[(int)MainWindow.IndexCategory.MusicSL])
            {
                ++indexMusicSL;
                ordinal = indexMusicSL;
            }
            else if (groupName == MainWindow.NameCategory[(int)MainWindow.IndexCategory.Movie])
            {
                ++indexMovie;
                ordinal = indexMovie;
            }
            else if (groupName == MainWindow.NameCategory[(int)MainWindow.IndexCategory.Book])
            {
                ++indexBook;
                ordinal = indexBook;
            }*/
            

            return ordinal;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            // This converter does not provide conversion back from ordinal position to list view item
            throw new System.InvalidOperationException();
        }
    }
}
