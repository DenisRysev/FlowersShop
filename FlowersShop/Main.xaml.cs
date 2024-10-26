using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public RegistrationEntities1 db = new RegistrationEntities1();
        
        public Main()
        {
            InitializeComponent();
            



            using (var db = new RegistrationEntities1())
            {
                var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                Клиенты = (int)(последнийПосетитель?.Код_клиента);
                // Теперь переменная КодПосетителя содержит ID последнего посетителя
            }

            List<Корзина> кор = db.Корзина.Where(x => x.Код_клиента == Клиенты).ToList();
            for (int i = 0; i < кор.Count; i++)
            {
                sum += (Convert.ToInt32(кор[i].Товар.Цена) * кор[i].Количество).Value;
            }

            korzina.Content = "Корзина (" + sum + "р.)";
        }
        double sum = 0;

        int Клиенты;
        private void highlightCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            highlightCanvas.Background = new SolidColorBrush(Colors.LightBlue); // Цвет подсветки при наведении
        }

        private void highlightCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            highlightCanvas.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6D6B8"));
        }
        private void highlightCanvas1_MouseEnter(object sender, MouseEventArgs e)
        {
            highlightCanvas1.Background = new SolidColorBrush(Colors.LightBlue); // Цвет подсветки при наведении
        }

        private void highlightCanvas1_MouseLeave(object sender, MouseEventArgs e)
        {
            highlightCanvas1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6D6B8"));
        }
        private void highlightCanvas2_MouseEnter(object sender, MouseEventArgs e)
        {
            highlightCanvas2.Background = new SolidColorBrush(Colors.LightBlue); // Цвет подсветки при наведении
        }

        private void highlightCanvas2_MouseLeave(object sender, MouseEventArgs e)
        {
            highlightCanvas2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6D6B8"));
        }
        private void highlightCanvas3_MouseEnter(object sender, MouseEventArgs e)
        {
            highlightCanvas3.Background = new SolidColorBrush(Colors.LightBlue); // Цвет подсветки при наведении
        }

        private void highlightCanvas3_MouseLeave(object sender, MouseEventArgs e)
        {
            highlightCanvas3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6D6B8"));
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



        private void korzina_Click(object sender, RoutedEventArgs e)
        {
            Korzina edsfsf = new Korzina( sum);
            edsfsf.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void flowers2(object sender, MouseButtonEventArgs e)
        {
            var buket = new Buket(sum);
            buket.Show();
            this.Close();
        }

        private void flowers4(object sender, MouseButtonEventArgs e)
        {
            var rassada = new Rassada(sum);
            rassada.Show();
            this.Close();
        }

        private void flowers3(object sender, MouseButtonEventArgs e)
        {
            var komnata = new Komnata(sum);
            komnata.Show();
            this.Close();
        }

        private void flowers1(object sender, MouseButtonEventArgs e)
        {
            var svegie = new Svegie(sum);
            svegie.Show();
            this.Close();
        }
    }
}
