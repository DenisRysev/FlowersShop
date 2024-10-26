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

namespace FlowersShop
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        
        public Admin()
        {
            InitializeComponent();
            sotrudniki.Items.Clear();
            sotrudniki.ItemsSource = db.Пользователь.ToList<Пользователь>();
        }
        public RegistrationEntities1 db = new RegistrationEntities1();
        Пользователь sotr;
        Паспорт paspo;
        private void sotrudniki_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            sotr = db.Пользователь.Where(x => x.Код_пользователя == x.Код_пользователя).FirstOrDefault();
            paspo = db.Паспорт.Where(x => x.Код_паспорта == sotr.Код_пользователя).FirstOrDefault();
            if (sotrudniki.SelectedItem != null)
            {
                // Сохраняем выбранный объект Person
                sotr = (Пользователь)sotrudniki.SelectedItem;
                name.Text = sotr.Имя;
                familia.Text = sotr.Фамилия;
                otcestvo.Text = sotr.Отчество;
                seria.Text = paspo.Серия;
                nomerpas.Text = paspo.Номер;
                nomer.Text = sotr.Телефон;
                pocta.Text = sotr.Почта;
                login.Text = sotr.Логин;
                password.Text = sotr.Пароль;
            }
        }

        private void Foto_Click(object sender, RoutedEventArgs e)
        {
            if (sotr != null)
            {
                sotr.Имя = name.Text;
                sotr.Фамилия = familia.Text;
                sotr.Отчество = otcestvo.Text;
                paspo.Серия = seria.Text;
                paspo.Номер = nomerpas.Text;
                sotr.Телефон = nomer.Text;
                sotr.Почта = pocta.Text;
                sotr.Логин = login.Text;
                sotr.Пароль = password.Text;
                // Обновляем информацию в ListView
                sotrudniki.Items.Refresh();
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Данные Сотрудника обновлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}");
                }
            }
        }
        private string originalPassword = "";

        private void sk_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text.Contains("*"))
            {
                password.Text = originalPassword;
            }
            else
            {
                originalPassword = password.Text;
                password.Text = new string('*', password.Text.Length);
            }
        }

        private void Foto_Click2(object sender, RoutedEventArgs e)
        {
            var IzmenaAdmin = new MainWindow();
            IzmenaAdmin.Show();
            this.Close();
        }

        private void perehi_Click(object sender, RoutedEventArgs e)
        {
            AdminIstiria adm = new AdminIstiria();
            adm.Show(); this.Close();
        }
    }
}
