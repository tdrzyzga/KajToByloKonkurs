using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;

namespace KajToBylo
{
    class RowNumberInGroupConverter : IMultiValueConverter
    {
        public static int indexMusicPL = 0;
        public static int indexMusicSL = 0;
        public static int indexMovie = 0;
        public static int indexBook = 0;

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            ListViewItem item = values[0] as ListViewItem;
            
            

            
            int ordinal = 0;
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
