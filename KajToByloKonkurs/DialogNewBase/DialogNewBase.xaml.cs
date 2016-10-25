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
    /// Interaction logic for DialogNewBase.xaml
    /// </summary>
    public partial class DialogNewBase : Window
    {
        public string NameBase { get; private set; }
        public bool DialogNewBaseResult { get; private set; }


        public DialogNewBase()
        {
            InitializeComponent();
        }

        private void dialogNewBaseOk_Click(object sender, RoutedEventArgs e)
        {
           NameBase = dialogNameBase.Text;
            DialogNewBaseResult = true;
            this.Hide();
        }

        private void dialogNewBaseCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
