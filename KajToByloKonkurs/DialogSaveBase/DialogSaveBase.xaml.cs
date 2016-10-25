using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KajToBylo
{
    /// <summary>
    /// Interaction logic for DialogSaveBase.xaml
    /// </summary>
    public partial class DialogSaveBase : Window
    {
        public bool DialogSaveBaseResult { get; private set; }

        public DialogSaveBase()
        {
            InitializeComponent();
        }

        private void dialogSaveBaseOk_Click(object sender, RoutedEventArgs e)
        {
            DialogSaveBaseResult = true;
            this.Hide();
        }

        private void dialogSaveBaseCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
