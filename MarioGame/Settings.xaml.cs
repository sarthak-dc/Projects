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
using System.Windows.Shapes;

namespace MarioGame
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void TurnOn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TurnOff_Click(object sender, RoutedEventArgs e)
        {

        }
        // New addition
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu();
            // Handle the Closing event of the current window

            this.Closing += (s, eventArgs) =>
            {
                // Set the Cancel property to false to allow the window to close
                eventArgs.Cancel = false;
            };


           
            this.Close();
        }
        // New addition
        private void Controls_Click(object sender, RoutedEventArgs e)
        {
            Controls window = new Controls();
            // Handle the Closing event of the current window

            this.Closing += (s, eventArgs) =>
            {
                // Set the Cancel property to false to allow the window to close
                eventArgs.Cancel = false;
            };


            window.Show();
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
               Menu Menu = new Menu();

            Menu.Show();

            this.Close();
        }

        private void btnControls_Click(object sender, RoutedEventArgs e)
        {
            Controls Controls = new Controls();

            Controls.Show();

            this.Close();
        }
    }
}
