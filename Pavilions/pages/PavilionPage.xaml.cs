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
    /// Логика взаимодействия для PavilionPage.xaml
    /// </summary>
    public partial class PavilionPage : Page
    {

        EditCenter main;
        string state = "Показать все";
        string floor = "Показать все";
        double fromNum = 0;
        double toNum = 99999;
        public PavilionPage(EditCenter main)
        {
            this.main = main;
            InitializeComponent();
            foreach (dataBase.Pavilions pav in main.center.center.Pavilions)
            {
                Pavilion record = new Pavilion();
                record.centerName = pav.centerName;
                record.centerState = main.center.center.state;
                record.floorNum = pav.floor.ToString();
                record.pavilionNum = pav.pavilionNum;
                record.square = pav.square.ToString();
                record.pavilionState = pav.state;
                record.priceCoefficient = pav.priceCoefficient.ToString();
                record.meterPrice = pav.meterPrice.ToString();
                record.pavilion = pav;
                pavilions.Items.Add(record);
            }


            foreach (dataBase.Pavilions floor in main.center.center.Pavilions)
            {
                bool check = true;
                foreach (ComboBoxItem i in floorFilter.Items)
                {
                    if (i.Content.ToString() == floor.floor.ToString())
                        check = false;
                }
                if (check)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = floor.floor.ToString();
                    floorFilter.Items.Add(item);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.main = main;
            pavilions.Items.Clear();
            state = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();

            foreach (dataBase.Pavilions pav in main.center.center.Pavilions)
            {
                if ((state == pav.state || state == "Показать все") && (floor == pav.floor.ToString() || floor == "Показать все")
                    && (fromNum < pav.square) && (toNum > pav.square))
                {
                    Pavilion record = new Pavilion();
                    record.centerName = pav.centerName;
                    record.centerState = main.center.center.state;
                    record.floorNum = pav.floor.ToString();
                    record.pavilionNum = pav.pavilionNum;
                    record.square = pav.square.ToString();
                    record.pavilionState = pav.state;
                    record.priceCoefficient = pav.priceCoefficient.ToString();
                    record.meterPrice = pav.meterPrice.ToString();
                    record.pavilion = pav;
                    pavilions.Items.Add(record);
                }
            }
        }

        private void CityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pavilions.Items.Clear();
            floor = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();

            foreach (dataBase.Pavilions pav in main.center.center.Pavilions)
            {
                if ((state == pav.state || state == "Показате все") && (floor == pav.floor.ToString() || floor == "Показать все")
                    && (fromNum < pav.square) && (toNum > pav.square))
                {
                    Pavilion record = new Pavilion();
                    record.centerName = pav.centerName;
                    record.centerState = main.center.center.state;
                    record.floorNum = pav.floor.ToString();
                    record.pavilionNum = pav.pavilionNum;
                    record.square = pav.square.ToString();
                    record.pavilionState = pav.state;
                    record.priceCoefficient = pav.priceCoefficient.ToString();
                    record.meterPrice = pav.meterPrice.ToString();
                    record.pavilion = pav;
                    pavilions.Items.Add(record);
                }
            }
        }

        private void FromSquare_TextChanged(object sender, TextChangedEventArgs e)
        {            
            bool check = true;
            try
            {
                fromNum = Convert.ToDouble(fromSquare.Text);
            }
            catch
            {
                check = false;
            }

            if (check)
            {
                pavilions.Items.Clear();
                foreach (dataBase.Pavilions pav in main.center.center.Pavilions)
                {
                    if ((state == pav.state || state == "Показать все") && (floor == pav.floor.ToString() || floor == "Показать все")
                        && (fromNum < pav.square) && (toNum > pav.square))
                    {
                        Pavilion record = new Pavilion();
                        record.centerName = pav.centerName;
                        record.centerState = main.center.center.state;
                        record.floorNum = pav.floor.ToString();
                        record.pavilionNum = pav.pavilionNum;
                        record.square = pav.square.ToString();
                        record.pavilionState = pav.state;
                        record.priceCoefficient = pav.priceCoefficient.ToString();
                        record.meterPrice = pav.meterPrice.ToString();
                        record.pavilion = pav;
                        pavilions.Items.Add(record);
                    }
                }
            }
        }

        private void FromFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool check = true;
            try
            {
                toNum = Convert.ToDouble(toSquare.Text);
            }
            catch
            {
                check = false;
            }

            if (check)
            {
                pavilions.Items.Clear();
                foreach (dataBase.Pavilions pav in main.center.center.Pavilions)
                {
                    if ((state == pav.state || state == "Показате все") && (floor == pav.floor.ToString() || floor == "Показать все")
                        && (fromNum < pav.square) && (toNum > pav.square))
                    {
                        Pavilion record = new Pavilion();
                        record.centerName = pav.centerName;
                        record.centerState = main.center.center.state;
                        record.floorNum = pav.floor.ToString();
                        record.pavilionNum = pav.pavilionNum;
                        record.square = pav.square.ToString();
                        record.pavilionState = pav.state;
                        record.priceCoefficient = pav.priceCoefficient.ToString();
                        record.meterPrice = pav.meterPrice.ToString();
                        record.pavilion = pav;
                        pavilions.Items.Add(record);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pavilions.SelectedIndex != -1)
            {
                main.main.main.db.Pavilions.Remove(((Pavilion)pavilions.SelectedItem).pavilion);
                pavilions.Items.Remove((Pavilion)pavilions.SelectedItem);
                main.main.main.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Ничего не выделено");
            }
        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            main.main.menedgerCFrame.Navigate(main);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pavilions.SelectedIndex == -1)
                MessageBox.Show("Элемент не выбран");
            else
            {
                main.main.menedgerCFrame.Navigate(new EditPavilion(main, (Pavilion)pavilions.SelectedItem));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            main.main.menedgerCFrame.Navigate(new EditPavilion(main));
        }
    }

    public class Pavilion
    {
        public string centerName { get; set; }
        public string centerState { get; set; }
        public string floorNum { get; set; }
        public string pavilionNum { get; set; }
        public string square { get; set; }
        public string pavilionState { get; set; }
        public string priceCoefficient { get; set; }
        public string meterPrice { get; set; }
        public dataBase.Pavilions pavilion { get; set; }

    }
}
