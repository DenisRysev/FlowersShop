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
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public RegistrationEntities1 db = new RegistrationEntities1();
        int stat = 0;
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var puser = db.Клиент.FirstOrDefault(x => x.Логин == textBox7.Text && x.Пароль == textBox8.Text);
            var user = db.Пользователь.FirstOrDefault(x => x.Логин == textBox7.Text && x.Пароль == textBox8.Text);
            if (user != null)
            {
                История ds = new История()
                {
                    Логин = user.Логин,
                    Код_пользователя = user.Код_пользователя,
                    Статус = true

                };
                db.История.Add(ds);
                db.SaveChanges();
                int doc = user.Код_пользователя; // Код сотрудника
                var usering = db.Пользователь.FirstOrDefault(x => x.Код_пользователя == doc); // Поиск сотрудника по коду
                if (stat == 0)
                {
                    usering.Статус = true; // Установка статуса в true
                }
                else
                {
                    usering.Статус = false; // Установка статуса в false
                }
                db.SaveChanges();
                if (user.Код_должности == 1)
                {
                    MessageBox.Show("Авторизация успешна");
                    Sotrudnik usr = new Sotrudnik(user);
                    usr.Show(); this.Hide();
                }
                else if (user.Код_должности == 2)
                {
                    MessageBox.Show("Авторизация успешна");
                    Admin usr = new Admin();
                    usr.Show(); this.Hide();
                }
            }
            else if(puser != null)
            {
                    MessageBox.Show("Авторизация успешна");
                    Main ur = new Main();
                    ur.Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Log j = new Log();
            j.Show(); this.Hide();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fd = new MainWindow();
            fd.Show(); this.Hide();
        }
    }
}
