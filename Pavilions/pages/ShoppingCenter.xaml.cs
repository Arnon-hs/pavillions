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
using Pavilions;

namespace Pavilions.pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCenter.xaml
    /// </summary>
    public partial class ShoppingCenter : Page
    {
        MenegerC main;
        string state = "Показать все";
        string city = "Показать все";

        public ShoppingCenter(MenegerC main)
        {
            this.main = main;            
            InitializeComponent();

            centers.SelectedIndex = 0;

            var c = main.main.db.ShoppingCenter
                        .OrderBy(p => p.city)
                        .ThenBy(p => p.state);

            

            foreach (dataBase.ShoppingCenter center in c)
            {
                Record record = new Record();
                record.name = center.centerName;
                record.state = center.state;
                record.pavilionsQuantity = center.pavilionsQuantity.ToString();
                record.city = center.city;
                record.price = center.price.ToString();
                record.floors = center.floors.ToString();
                record.priceCoefficient = center.priceCoefficient.ToString();
                record.center = center;
                centers.Items.Add(record);
            }

            foreach (dataBase.ShoppingCenter city in main.main.db.ShoppingCenter){
                bool check = true;
                foreach (ComboBoxItem i in cityFilter.Items)
                {
                    if (i.Content.ToString() == city.city)
                        check = false;
                }
                if (check) {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = city.city;
                    cityFilter.Items.Add(item);
                }
            }

            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            centers.Items.Clear();
            state = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();

            var c = main.main.db.ShoppingCenter
            .OrderBy(p => p.city)
            .ThenBy(p => p.state);



            foreach (dataBase.ShoppingCenter center in c)
            {
                if ((center.state == state || state == "Показать все") && (center.city == city || city == "Показать все"))
                {
                    Record record = new Record();
                    record.name = center.centerName;
                    record.state = center.state;
                    record.pavilionsQuantity = center.pavilionsQuantity.ToString();
                    record.city = center.city;
                    record.price = center.price.ToString();
                    record.floors = center.floors.ToString();
                    record.priceCoefficient = center.priceCoefficient.ToString();
                    record.center = center;
                    centers.Items.Add(record);
                }
            }
        }

        private void CityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            centers.Items.Clear();
            city = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();

            var c = main.main.db.ShoppingCenter
            .OrderBy(p => p.city)
            .ThenBy(p => p.state);



            foreach (dataBase.ShoppingCenter center in c)
            {
                if ((center.state == state || state == "Показать все") && (center.city == city || city == "Показать все"))
                {
                    Record record = new Record();
                    record.name = center.centerName;
                    record.state = center.state;
                    record.pavilionsQuantity = center.pavilionsQuantity.ToString();
                    record.city = center.city;
                    record.price = center.price.ToString();
                    record.floors = center.floors.ToString();
                    record.priceCoefficient = center.priceCoefficient.ToString();
                    record.center = center;
                    centers.Items.Add(record);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (centers.SelectedIndex != -1)
            {
                main.main.db.ShoppingCenter.Remove(((Record)centers.SelectedItem).center);
                centers.Items.Remove((Record)centers.SelectedItem);
                main.main.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Ничего не выделено");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (centers.SelectedIndex == -1)
                MessageBox.Show("Элемент не выбран");
            else
            {
                main.menedgerCFrame.Navigate(new EditCenter(main, (Record)centers.SelectedItem));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            main.menedgerCFrame.Navigate(new EditCenter(main));
        }
    }

    public class Record
    {
        public string name { get; set; }
        public string state { get; set; }
        public string pavilionsQuantity { get; set; }
        public string city { get; set; }
        public string price { get; set; }
        public string floors { get; set; }
        public string priceCoefficient { get; set; }
        public dataBase.ShoppingCenter center { get; set; }
    }
}
