using Microsoft.Office.Interop.Word;
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
    /// Логика взаимодействия для Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : System.Windows.Window
    {
        RegistrationEntities1 db = new RegistrationEntities1();
        Пользователь user;
        Паспорт paspo;
        public Sotrudnik(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            
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

        private void Foto_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                Пользователь selectedUser = db.Пользователь.FirstOrDefault(u => u.Код_пользователя == user.Код_пользователя);
                paspo = db.Паспорт.Where(x => x.Код_паспорта == selectedUser.Код_пользователя).FirstOrDefault();
                if (selectedUser != null)
                {
                    selectedUser.Имя = name.Text;
                    selectedUser.Фамилия = familia.Text;
                    selectedUser.Отчество = otcestvo.Text;
                    paspo.Серия = seria.Text;
                    paspo.Номер = nomerpas.Text;
                    selectedUser.Телефон = nomer.Text;
                    selectedUser.Почта = pocta.Text;
                    selectedUser.Логин = login.Text;
                    selectedUser.Пароль = password.Text;

                    db.SaveChanges();
                    MessageBox.Show("Данные Сотрудника обновлены!");
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RegistrationEntities1())
            {
                if (user != null)
                {
                    paspo = db.Паспорт.Where(x => x.Код_паспорта == user.Код_пользователя).FirstOrDefault();
                    name.Text = user.Имя;
                    familia.Text = user.Фамилия;
                    otcestvo.Text = user.Отчество;
                    seria.Text = paspo.Серия;
                    nomerpas.Text = paspo.Номер;
                    nomer.Text = user.Телефон;
                    pocta.Text = user.Почта;
                    login.Text = user.Логин;
                    password.Text = user.Пароль;

                    string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                    savePath = savePath + "\\" + user.Фото + "";
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();

                    bitmap.UriSource = new Uri(savePath);
                    bitmap.EndInit();
                    foto2.Source = bitmap;



                    foto2.Height = 250;
                    foto2.Width = 200;

                    foto2.Uid = user.Код_пользователя.ToString();


                }
                else
                {
                    MessageBox.Show("Сотрудник с такими логином и паролем не найден.");
                }
            }
        }

        private void Foto_Click2(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                Пользователь selected = db.Пользователь.FirstOrDefault(u => u.Код_пользователя == user.Код_пользователя);
                Паспорт pasp = db.Паспорт.Where(x => x.Код_паспорта == selected.Код_пользователя).FirstOrDefault();
                if (selected != null)
                {
                    name.Text = selected.Имя;
                    familia.Text = selected.Фамилия;
                    otcestvo.Text = selected.Отчество;
                    seria.Text = pasp.Серия;
                    nomerpas.Text = pasp.Номер;
                    nomer.Text = selected.Телефон;
                    pocta.Text = selected.Почта;
                    login.Text = selected.Логин;
                    password.Text = selected.Пароль;
                }
            }
        }
    }
}
