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

namespace Pavilions.pages
{
    /// <summary>
    /// Логика взаимодействия для EditPavilion.xaml
    /// </summary>
    public partial class EditPavilion : Page
    {
        public EditCenter main;
        public Pavilion pavilion;
        System.Drawing.Image picture;
        public EditPavilion(EditCenter main, Pavilion pavilion = null)
        {
            this.main = main;
            this.pavilion = pavilion;

            InitializeComponent();

            if (pavilion != null)
            {
                floorNum.Text = pavilion.floorNum.ToString();
                pavNum.Text = pavilion.pavilionNum;
                square.Text = pavilion.square;
                coeff.Text = pavilion.priceCoefficient;
                price.Text = pavilion.meterPrice;
                foreach (ComboBoxItem item in state.Items)
                {
                    if (item.Content.ToString() == pavilion.pavilionState)
                        state.SelectedItem = item;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataBase.Pavilions pav;
            if (pavilion == null) pav = new dataBase.Pavilions();
            else pav = pavilion.pavilion;

            try
            {
                if ((pavNum.Text != "") && (Convert.ToDouble(coeff.Text) >= 0.1) && (Convert.ToDouble(price.Text) > 0) &&
                    (Convert.ToInt32(square.Text) > 0) && (Convert.ToInt32(floorNum.Text) > 0))
                {
                    pav.floor = Convert.ToInt32(floorNum.Text);
                    pav.pavilionNum = pavNum.Text;
                    pav.square = Convert.ToDouble(square.Text);
                    pav.priceCoefficient = Convert.ToDouble(coeff.Text);
                    pav.meterPrice = Convert.ToDouble(price.Text);
                    pav.state = ((ComboBoxItem)state.SelectedValue).Content.ToString();
                    pav.centerName = main.center.center.centerName;


                    if (pavilion == null)
                    {
                        main.main.main.db.Pavilions.Add(pav);
                    }
                    //main.main.main.db.SaveChanges();
                    main.main.menedgerCFrame.Navigate(new PavilionPage(main));
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
    }
}
