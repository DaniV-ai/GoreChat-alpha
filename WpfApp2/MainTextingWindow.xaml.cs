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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainTextingWindow.xaml
    /// </summary>
    public partial class MainTextingWindow : Window
    {
        public MainTextingWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double height = this.ActualHeight-450;
             double width = 800- this.ActualWidth;
            //  MessageBox.Show($"{height}, {width}");
            if (height >= 0 && width<=0)
            {
            Thickness thickness = new Thickness(height, 0, 0, 0);
            Stripts.Margin = thickness;
            }
        }
    }
}
