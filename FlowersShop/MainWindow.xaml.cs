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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowersShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Log h = new Log();
            h.Show();
            this.Hide();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Log2 lg = new Log2();
            lg.Show(); this.Hide();
        }
    }
}
