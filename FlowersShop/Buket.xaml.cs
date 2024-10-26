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
    /// Логика взаимодействия для Buket.xaml
    /// </summary>
    public partial class Buket : Window
    {
        public static class OrderManager
        {
            public static int TotalOrderSum { get; set; } = 0;
        }

        int kol;
        int kol2;
        int kol3;
        int kol4;
        int КодПосетителяя;
        public double sum;
        public Buket(double sum)
        {
            InitializeComponent();
            UpdateValue();
            UpdateValue2();
            UpdateValue3();
            UpdateValue4();
            this.sum = sum;
            using (var db = new RegistrationEntities1())
            {
                var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                КодПосетителяя = (int)(последнийПосетитель?.Код_клиента);
                // Теперь переменная КодПосетителя содержит ID последнего посетителя
            }
            ctet1.IsEnabled = false;
            ctet2.IsEnabled = false;
            ctet3.IsEnabled = false;
            ctet4.IsEnabled = false;
            //int sumic = summa1 + summa2 + summa3 + summa4;
            korzina.Content = "Корзина (" + sum + "р.)";

            List<Корзина> кор = db.Корзина.Where(x => x.Код_товара == 5 && x.Код_клиента == КодПосетителяя).ToList();
            for (int i = 0; i < кор.Count; i++)
            {
                kol = (int)кор[i].Количество;
            }

            List<Корзина> кор2 = db.Корзина.Where(x => x.Код_товара == 6 && x.Код_клиента == КодПосетителяя).ToList();
            for (int i = 0; i < кор2.Count; i++)
            {
                kol2 = (int)кор2[i].Количество;
            }

            List<Корзина> кор3 = db.Корзина.Where(x => x.Код_товара == 7 && x.Код_клиента == КодПосетителяя).ToList();
            for (int i = 0; i < кор3.Count; i++)
            {
                kol3 = (int)кор3[i].Количество;
            }

            List<Корзина> кор4 = db.Корзина.Where(x => x.Код_товара == 8 && x.Код_клиента == КодПосетителяя).ToList();
            for (int i = 0; i < кор4.Count; i++)
            {
                kol4 = (int)кор4[i].Количество;
            }



            ctet1.Text = kol.ToString();
            ctet2.Text = kol2.ToString();
            ctet3.Text = kol3.ToString();
            ctet4.Text = kol4.ToString();
            using (var db = new RegistrationEntities1())
            {
                товары = db.Товар.ToList();
                if (товары != null)
                {
                    for (int i = 0; i < товары.Count; i++)
                    {
                        if (товары[i].Код_раздела == 2)
                        {
                            if (товары[i].Цена == "3000")
                            {
                                string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                                savePath = savePath + "\\" + товары[i].Фото + "";
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();

                                bitmap.UriSource = new Uri(savePath);
                                bitmap.EndInit();
                                buket1.Source = bitmap;

                                price1.Content = товары[i].Цена + " руб.";




                            }
                            else if (товары[i].Цена == "2000")
                            {
                                string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                                savePath = savePath + "\\" + товары[i].Фото + "";
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();

                                bitmap.UriSource = new Uri(savePath);
                                bitmap.EndInit();
                                buket2.Source = bitmap;

                                price2.Content = товары[i].Цена + " руб.";

                            }
                            else if (товары[i].Цена == "1000")
                            {
                                string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                                savePath = savePath + "\\" + товары[i].Фото + "";
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();

                                bitmap.UriSource = new Uri(savePath);
                                bitmap.EndInit();
                                buket3.Source = bitmap;

                                price3.Content = товары[i].Цена + " руб.";

                            }
                            else if (товары[i].Цена == "1500")
                            {
                                string savePath = System.IO.Path.GetFullPath(@"..\..\img");
                                savePath = savePath + "\\" + товары[i].Фото + "";
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();

                                bitmap.UriSource = new Uri(savePath);
                                bitmap.EndInit();
                                buket4.Source = bitmap;

                                price4.Content = товары[i].Цена + " руб.";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка в базе данных. Изображения и цены не найдены. попробуйте позже.");
                }
            }
        }

        RegistrationEntities1 db = new RegistrationEntities1();
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
        //для кнопок + и -
        private int _value = 0;
        private int _value2 = 0;
        private int _value3 = 0;
        private int _value4 = 0;

        //для суммы корзины
        private int summ1 = 0;
        private int summ2 = 0;
        private int summ3 = 0;
        private int summ4 = 0;

        private void UpdateValue()
        {
            ctet1.Text = kol.ToString();

        }
        private void UpdateValue2()
        {
            ctet2.Text = kol2.ToString();

        }
        private void UpdateValue3()
        {
            ctet3.Text = kol3.ToString();

        }
        private void UpdateValue4()
        {
            ctet4.Text = kol4.ToString();

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
            var glav = new Main();
            glav.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (kol < 10)
            {
                summ1 += 3000;
                kol++;
                UpdateValue();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + " р.)";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 5 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        // Товар уже есть в корзине, увеличиваем количество
                        товарВКорзине.Количество += 1;
                    }
                    else
                    {
                        // Товара нет в корзине, добавляем новый товар
                        товарВКорзине = new Корзина
                        {
                            Код_товара = 5, // Замените 5 на актуальный код товара
                            Код_клиента = кодПосетителя,
                            Количество = 1,
                            Фото = "buket1.jpg"
                        };
                        db.Корзина.Add(товарВКорзине);
                    }
                    db.SaveChanges();
                }
            }


        }
        int vsesumm;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (kol > 0)
            {
                summ1 -= 3000;
                kol--;
                UpdateValue();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 5 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {

                        if (kol != 0)
                        {
                            // Товар уже есть в корзине, увеличиваем количество
                            товарВКорзине.Количество -= 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Корзина.Remove(товарВКорзине);
                            db.SaveChanges();
                        }
                    }
                }
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (kol2 < 10)
            {
                summ2 += 2000;
                kol2++;
                UpdateValue2();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 6 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        // Товар уже есть в корзине, увеличиваем количество
                        товарВКорзине.Количество += 1;
                    }
                    else
                    {
                        // Товара нет в корзине, добавляем новый товар
                        товарВКорзине = new Корзина
                        {
                            Код_товара = 6, // Замените 5 на актуальный код товара
                            Код_клиента = кодПосетителя,
                            Количество = 1,
                            Фото = "buket2.jpg"
                        };
                        db.Корзина.Add(товарВКорзине);
                    }
                    db.SaveChanges();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (kol2 > 0)
            {
                summ2 -= 2000;
                kol2--;
                UpdateValue2();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 6 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        if (kol2 != 0)
                        {
                            // Товар уже есть в корзине, увеличиваем количество
                            товарВКорзине.Количество -= 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Корзина.Remove(товарВКорзине);
                            db.SaveChanges();
                        }
                    }

                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (kol3 < 10)
            {
                summ3 += 1000;
                kol3++;
                UpdateValue3();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 7 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        // Товар уже есть в корзине, увеличиваем количество
                        товарВКорзине.Количество += 1;
                    }
                    else
                    {
                        // Товара нет в корзине, добавляем новый товар
                        товарВКорзине = new Корзина
                        {
                            Код_товара = 7, // Замените 5 на актуальный код товара
                            Код_клиента = кодПосетителя,
                            Количество = 1,
                            Фото = "buket3.jpg"
                        };
                        db.Корзина.Add(товарВКорзине);
                    }
                    db.SaveChanges();
                }

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (kol3 > 0)
            {
                summ3 -= 1000;
                kol3--;
                UpdateValue3();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 7 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        if (kol3 != 0)
                        {
                            // Товар уже есть в корзине, увеличиваем количество
                            товарВКорзине.Количество -= 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Корзина.Remove(товарВКорзине);
                            db.SaveChanges();
                        }
                    }

                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (kol4 < 10)
            {
                summ4 += 1500;
                kol4++;
                UpdateValue4();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 8 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        // Товар уже есть в корзине, увеличиваем количество
                        товарВКорзине.Количество += 1;
                    }
                    else
                    {
                        // Товара нет в корзине, добавляем новый товар
                        товарВКорзине = new Корзина
                        {
                            Код_товара = 8, // Замените 5 на актуальный код товара
                            Код_клиента = кодПосетителя,
                            Количество = 1,
                            Фото = "buket4.png"
                        };
                        db.Корзина.Add(товарВКорзине);
                    }
                    db.SaveChanges();
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (kol4 > 0)
            {
                summ4 -= 1500;
                kol4--;
                UpdateValue4();
                vsesumm = (int)sum + (int)summ1 + (int)summ2 + (int)summ3 + (int)summ4;
                korzina.Content = "Корзина(" + vsesumm + ")";
                int кодПосетителя;
                using (var db = new RegistrationEntities1())
                {
                    var последнийПосетитель = db.Клиент.OrderByDescending(p => p.Код_клиента).FirstOrDefault();
                    кодПосетителя = последнийПосетитель?.Код_клиента ?? 0;
                }

                using (var db = new RegistrationEntities1())
                {
                    var товарВКорзине = db.Корзина.FirstOrDefault(k => k.Код_товара == 8 && k.Код_клиента == кодПосетителя);
                    if (товарВКорзине != null)
                    {
                        if (kol != 0)
                        {
                            // Товар уже есть в корзине, увеличиваем количество
                            товарВКорзине.Количество -= 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Корзина.Remove(товарВКорзине);
                            db.SaveChanges();
                        }
                    }

                }
            }
        }
        List<Товар> товары;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



        }

        private void korzina_Click(object sender, RoutedEventArgs e)
        {
            Korzina edsfsf = new Korzina(vsesumm);
            edsfsf.Show();
            this.Close();
        }
    }
}

