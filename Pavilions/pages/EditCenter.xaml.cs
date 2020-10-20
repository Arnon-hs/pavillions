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
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Pavilions.dataBase;

namespace Pavilions.pages
{
    /// <summary>
    /// Логика взаимодействия для EditCenter.xaml
    /// </summary>
    public partial class EditCenter : Page
    {
        public MenegerC main;
        public Record center;
        System.Drawing.Image picture;
        public EditCenter(MenegerC main, Record center = null)
        {
            this.main = main;
            this.center = center;
            InitializeComponent();

            if (center != null)
            {
                name.Text = center.name;
                coeff.Text = center.priceCoefficient;
                price.Text = center.price;
                city.Text = center.city;
                floors.Text = center.floors;
                pavilionsQuantity.Text = center.pavilionsQuantity;
                foreach (ComboBoxItem item in state.Items)
                {
                    if (item.Content.ToString() == center.state)
                        state.SelectedItem = item;
                }
                if (center.center.image != null)
                {
                    System.Drawing.Image img = ByteArrayToImage(center.center.image);
                    image.Source = GetImageStream(img);
                    picture = img;
                }
            }

        }


        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = System.Drawing.Image.FromStream(ms);

                return returnImage;
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                return ms.ToArray();
            }
        }

        public BitmapSource GetImageStream(System.Drawing.Image myImage)
        {
            var bitmap = new Bitmap(myImage);
            IntPtr bmpPt = bitmap.GetHbitmap();
            BitmapSource bitmapSource =
             System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmpPt,
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());


            return bitmapSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picture = System.Drawing.Image.FromFile(dialog.FileName);
                image.Source = GetImageStream(picture);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataBase.ShoppingCenter shop;
            if (center == null) shop = new dataBase.ShoppingCenter();
            else shop = center.center;
            bool isPlan = true;
            try
            {
                foreach (dataBase.Pavilions pavilion in center.center.Pavilions)
                {
                    if (pavilion.state.ToLower() == "Забронирован") isPlan = false;
                }
            }
            catch
            {

            }

            try
            {
                if ((name.Text != "") && (Convert.ToDouble(coeff.Text) >= 0.1) && (Convert.ToDouble(price.Text) > 0) && (city.Text != "") && 
                    (Convert.ToInt32(floors.Text) > 0) && (Convert.ToInt32(pavilionsQuantity.Text) > 0) && (isPlan || ((ComboBoxItem)state.SelectedValue).Content.ToString() != "План"))
                {
                    shop.centerName = name.Text;
                    shop.priceCoefficient = Convert.ToDouble(coeff.Text);
                    shop.state = ((ComboBoxItem)state.SelectedValue).Content.ToString();
                    shop.price = Convert.ToDouble(price.Text);
                    shop.city = city.Text;
                    shop.floors = Convert.ToInt32(floors.Text);
                    shop.pavilionsQuantity = Convert.ToInt32(pavilionsQuantity.Text);

                    if (picture != null)
                    {
                        shop.image = ImageToByteArray(picture);
                    }
                    if (center == null)
                    {
                        main.main.db.ShoppingCenter.Add(shop);
                    }
                    main.main.db.SaveChanges();
                    main.menedgerCFrame.Navigate(new ShoppingCenter(main));

                }
                else
                {
                    System.Windows.MessageBox.Show("Данные неккоректны. Все поля должны быть заполнены, цифры должны превышать 0, а коэффициент >= 0.1. Так же нельзя изменить состояние на 'План', если есть забронированные павилионы");
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Данные введены неккоректно, проверьте правильность написания цифр");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            main.menedgerCFrame.Navigate(new PavilionPage(this));
        }
    }
}
