using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace FlowersShop
{
    /// <summary>
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    public partial class zakaz : Window
    {
        private string Nomer;
        private string summa1;
        private string summa2;
        private string summa3;
        private string summa4;
        public zakaz()
        {
            InitializeComponent();

            using (var db = new RegistrationEntities1())
            {
                user = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();

                if (user != null)
                {
                    dom.Text = user.Дом;
                    yli.Text = user.Улица;
                    kv.Text = user.Комната;
                    pod.Text = user.Подъезд;
                    tag.Text = user.Этаж;
                    tel.Text = user.Телефон;
                }
            }

            using (var db = new RegistrationEntities1())
            {
                var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                КодПосетителяя = (int)(последнийПосетитель?.Код_клиента);
                // Теперь переменная КодПосетителя содержит ID последнего посетителя
            }

            List<Корзина> кор = db.Корзина.Where(x => x.Код_клиента == КодПосетителяя).ToList();
            for (int i = 0; i < кор.Count; i++)
            {
                sum += (Convert.ToInt32(кор[i].Товар.Цена) * кор[i].Количество).Value;
            }

            summ.Content = "Стоимость " + sum + "р.";
            sukidka.Content = "Скидка 0р ";
            itog.Content = "Итого " + sum + "р.";


        }
        double sum = 0;
        int КодПосетителяя;
        RegistrationEntities1 db = new RegistrationEntities1();

        Клиент user;
        private void nazad(object sender, RoutedEventArgs e)
        {
            Korzina edsfsf = new Korzina( sum);
            edsfsf.Show();
            this.Close();
        }

        private void korzina_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Repwo(string subToReplace, string text, Word.Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: subToReplace, ReplaceWith: text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (im.Text != "" && fam.Text != "" && otc.Text != "" && poc.Text != "" && tel.Text != "" && yli.Text != "" && tag.Text != "" && pod.Text != "" && kv.Text != "" && dom.Text != "")
            {
                var WordApp = new Word.Application();
                WordApp.Visible = false;
                //все эти переменные были в ворде до сохранения чека
                var Worddoc = WordApp.Documents.Open(Environment.CurrentDirectory + @"\boo.docx");
                Repwo("{sum}", sum.ToString(), Worddoc);
                string data = DateTime.Now.ToString();
                Repwo("{data}", data, Worddoc);
                Repwo("{nomer}", "12", Worddoc);
                Repwo("{nom}", tel.Text, Worddoc);
                Repwo("{fio}", fam.Text + " " + im.Text + " " + otc.Text, Worddoc);
                Worddoc.SaveAs2(Environment.CurrentDirectory + @"\boo.docx");
                Worddoc.Close();
                WordApp.Quit();
                MessageBox.Show("Чек сохранен!");
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void ins(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/teddyflowers_perm/") { UseShellExecute = true });
        }

        private void tg(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://web.telegram.org/") { UseShellExecute = true });
        }

        private void vk(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/syrprizko") { UseShellExecute = true });
        }

        private void Vozrat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show(); this.Close();
        }
    }
}
