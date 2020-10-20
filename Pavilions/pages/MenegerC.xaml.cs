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
    /// Логика взаимодействия для MenegerC.xaml
    /// </summary>
    public partial class MenegerC : Page
    {
        public MainWindow main;
        public MenegerC(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menedgerCFrame.Navigate(new ShoppingCenter(this));
        }
    }
}
