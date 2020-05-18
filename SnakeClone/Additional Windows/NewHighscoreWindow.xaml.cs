using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeClone
{
    /// <summary>
    /// Interaction logic for NewHighscoreWindow.xaml
    /// </summary>
    public partial class NewHighscoreWindow : Window
    {
        public NewHighscoreWindow()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string GetName()
        {
            return textBoxName.Text;
        }
    }
}
