using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FlowersShop
{
    /// <summary>
    /// Логика взаимодействия для AdminIstiria.xaml
    /// </summary>
    public partial class AdminIstiria : Window
    {
        RegistrationEntities1 db;

        public AdminIstiria()
        {
            InitializeComponent();

            db = new RegistrationEntities1();
            usl.ItemsSource = db.История.ToList();
        }
        private void login_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(usl.ItemsSource);
            if (view != null)
            {
                view.SortDescriptions.Clear(); // очистить текущие сортировки
                view.SortDescriptions.Add(new SortDescription("Логин", ListSortDirection.Ascending)); // сортировка по возрастанию логина
            }
        }

        private void data2_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(usl.ItemsSource);
            if (view != null)
            {
                view.SortDescriptions.Clear(); // очистить текущие сортировки
                view.SortDescriptions.Add(new SortDescription("Время", ListSortDirection.Descending)); // сортировка по убыванию даты
            }
        }

        private void data_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(usl.ItemsSource);
            if (view != null)
            {
                view.SortDescriptions.Clear(); // очистить текущие сортировки
                view.SortDescriptions.Add(new SortDescription("Время", ListSortDirection.Ascending)); // сортировка по возрастанию даты
            }
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            var IzmenaAdmin = new Admin();
            IzmenaAdmin.Show();
            this.Close();
        }

        private void nazad_Click2(object sender, RoutedEventArgs e)
        {

        }
    }
}
