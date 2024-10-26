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
using ClassLibrary1;

namespace FlowersShop
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public RegistrationEntities1 db = new RegistrationEntities1();
        string fam, name, otch, tel, ser, num, potch, log, pass, pass2;

        

        List<Должность> dolon;
        List<Подразделение> podraz;
        public Log()
        {
            InitializeComponent();
            dolon = db.Должность.ToList();
            podraz = db.Подразделение.ToList();
            for (int i = 0; i < dolon.Count; i++)
            {
                cb1.Items.Add(dolon[i].Наименование);
            }
            for (int i = 0; i < podraz.Count; i++)
            {
                cb2.Items.Add(podraz[i].Наименование);
            }
        }
        int n = 1;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fam = textBox1.Text;
            name = textBox2.Text;
            otch = textBox7.Text;
            potch = textBox3.Text;
            tel = textBox8.Text;
            ser = textBox9.Text;
            num = textBox10.Text;
            log = textBox4.Text;
            pass = textBox5.Text;
            pass2 = textBox6.Text;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && cb1.Text != null && cb2.Text != null)
            {
                if (Class1.CheckMail(potch))
                {
                    if (Class1.CheckPassword(pass))
                    {

                        if (pass == pass2)
                        {
                            Должность dol = db.Должность.FirstOrDefault(x => x.Наименование == cb1.Text);
                            Подразделение pod = db.Подразделение.FirstOrDefault(x => x.Наименование == cb2.Text);
                            Паспорт pa = new Паспорт
                            {
                                Серия = ser,
                                Номер = num
                            };
                            db.Паспорт.Add(pa);
                            db.SaveChanges();
                            Пользователь registr = new Пользователь
                            {
                                Фамилия = fam,
                                Имя = name,
                                Отчество = otch,
                                Телефон = tel,
                                Логин = log,
                                Почта = potch,
                                Пароль = pass,
                                Код_пользователя = n,
                                Код_должности = dol.Код_должности,
                                Код_подразделения = pod.Код_подразделения,
                                Код_паспорта = pa.Код_паспорта
                            };
                            n++;
                            db.Пользователь.Add(registr);
                            db.SaveChanges();
                            MessageBox.Show("Пользователь добавлен!");
                        }
                        else
                        {
                            MessageBox.Show("пароли не совпадают!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не соответствует условиям сложности.");
                    }

                }
                else
                {
                    MessageBox.Show("Некорректный формат почты.");
                }


            }
            else
            {
                MessageBox.Show("Не все данные введены!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome();
            wel.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();
            textBox6.Text = "";
            textBox6.Clear();
            textBox7.Text = "";
            textBox7.Clear();
            textBox8.Text = "";
            textBox8.Clear();
            textBox9.Text = "";
            textBox9.Clear();
            textBox10.Text = "";
            textBox10.Clear();
        }
        private void knop_Click(object sender, RoutedEventArgs e)
        {
            if (n != 2)
            {
                n++;
                textBox6.FontFamily = new System.Windows.Media.FontFamily("Segoe UI");
            }
            else
            {
                n--;
                textBox6.FontFamily = new System.Windows.Media.FontFamily("Wingdings");
            }
        }

        private void Butpar_Click_1(object sender, RoutedEventArgs e)
        {
            if (n != 2)
            {
                n++;
                textBox5.FontFamily = new System.Windows.Media.FontFamily("Segoe UI");
            }
            else
            {
                n--;
                textBox5.FontFamily = new System.Windows.Media.FontFamily("Wingdings");
            }
        }
    }
}
