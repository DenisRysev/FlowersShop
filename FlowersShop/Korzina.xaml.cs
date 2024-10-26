using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Window
    {
        System.Windows.Controls.TextBox labelName;
        System.Windows.Controls.Label labelName2;
        System.Windows.Controls.Image imge;
        List<Корзина> zivotnie;
        Корзина selectedBook;
        RegistrationEntities1 db = new RegistrationEntities1();
        int kol;
        double vsesumm;
        int КодПосетителяя;
        private ObservableCollection<BitmapImage> images = new ObservableCollection<BitmapImage>();
        public Korzina( double vsesumm)
        {
            InitializeComponent();
            this.vsesumm = vsesumm;
            korzinaаa.Content = "Оформить (" + vsesumm + "р.)";
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

        private void nazad(object sender, RoutedEventArgs e)
        {
            Main edsfsf = new Main();
            edsfsf.Show();
            this.Close();
        }

        private void korzinaа_Click(object sender, RoutedEventArgs e)
        {
            zakaz edsfsf = new zakaz();
            edsfsf.Show();
            this.Close();
        }
        List<Корзина> korzinaa;
        Корзина selectedTovar;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            using (var db = new RegistrationEntities1())
            {
                var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                КодПосетителяя = (int)(последнийПосетитель?.Код_клиента);
                // Теперь переменная КодПосетителя содержит ID последнего посетителя
            }

            List<Корзина> korzinaa = db.Корзина.Where(x => x.Код_клиента == КодПосетителяя).ToList();

            for (int i = 0; i < korzinaa.Count; i++)
            {
                WrapPanel wp = new WrapPanel();
                imge = new System.Windows.Controls.Image();
                labelName = new System.Windows.Controls.TextBox();
                labelName2 = new System.Windows.Controls.Label();
                Button button1 = new Button();
                Button button2 = new Button();

                // Установка размеров и цвета фона для WrapPanel
                wp.Height = 300;
                wp.Width = 550;
                wp.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6D6B8"));

                button1.Height = 20;
                button1.Width = 15;
                button1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF498C51"));
                button1.Margin = new Thickness(-240, 160, 0, 0);

                button2.Height = 20;
                button2.Width = 15;
                button2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF498C51"));
                button2.Margin = new Thickness(0, 160, 0, 0);

                //button1.Click += new RoutedEventHandler(Button1_Click);
                //button2.Click += new RoutedEventHandler(Button2_Click);

                button1.FontSize = 12;
                button2.FontSize = 12;
                button1.Foreground = new SolidColorBrush(Colors.White);
                button2.Foreground = new SolidColorBrush(Colors.White);
                labelName.Height = 30;
                labelName.Width = 80;
                labelName.Margin = new Thickness(-110, 160, 0, 0);


                // Установка текста для TextBox
                labelName.Text = korzinaa[i].Количество.ToString();

                // Загрузка изображения
                string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                savePath = savePath + "\\" + korzinaa[i].Фото + "";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(savePath);
                bitmap.EndInit();
                imge.Source = bitmap;

                imge.Height = 150;
                imge.Width = 100;
                imge.Margin = new Thickness(50, 10, 0, 10);
                // Установка Uid для изображения
                imge.Uid = korzinaa[i].Код_корзины.ToString();

                // Добавление изображения и TextBox в WrapPanel


                kol = (int)korzinaa[i].Количество;
                // Создание и добавление кнопок в WrapPanel

                button1.Content = "+";
                button2.Content = "-";

                wp.Children.Add(imge);

                wp.Children.Add(button1);
                wp.Children.Add(labelName);
                wp.Children.Add(button2);

                // Добавление WrapPanel в listView
                listView.Items.Add(wp);

            }

        }
    }
}
