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
using Pavilions.dataBase;

namespace Pavilions.pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        int attempt = 0;
        MainWindow main;
        public Authorization(MainWindow main)
        {

            this.main = main;
            InitializeComponent();
            capchaText.Visibility = Visibility.Hidden;
            capchaLabel.Visibility = Visibility.Hidden;
            capcha.Visibility = Visibility.Hidden;
            generate();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            attempt++;
            //if (attempt >= 3) {
                capchaText.Visibility = Visibility.Visible;
                capchaLabel.Visibility = Visibility.Visible;
                capcha.Visibility = Visibility.Visible;
            //}
            if (capchaText.Text == capcha.Text )
            {
                foreach (Staff user in main.db.Staff)
                {
                    if (user.login.ToLower() == login.Text.ToLower() && user.password == password.Password)
                    {
                        main.hasEntered = true;
                        main.user = user;
                        //if (user.role.ToLower() == "Менеджер С".ToLower())
                        //{
                            main.Title = user.role;
                            main.MainFrame.Navigate(new MenegerC(main));
                        //}
                        //else {
                          //  MessageBox.Show("не менеджер но зашел");
                        //}

                    }
                }
                if (!main.hasEntered)
                {
                    MessageBox.Show("Введены неверные данные. Попробуйте снова");
                }
            }
            else
            {
                generate();
                MessageBox.Show("Неправильная капча");
            }
        }

        private void generate()
        {
            capcha.Text = "";
            string simbols = "qwertyuiopasdfghjklzxcvbnm1234567890";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                capcha.Text += simbols[random.Next(0, simbols.Length - 1)];
            }
        }
    }
}
