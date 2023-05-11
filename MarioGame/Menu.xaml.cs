/* 
 Author: Praveen JM
 Date: 
This is the Cs file for the main menu
 
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window


    {
        // thes keeps track of the clicks
        int click_counter = 0;
       

        /// <summary>
        /// 
        /// </summary>
        public object NavigationService { get; private set; }

        public Menu()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer(@"C:\Users\isuru\OneDrive\Desktop\MarioGame\Music\MainMenu.wav");
            player.Load();
          
            player.Play();

        }
        /// <summary>
        /// Makes the window dragable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// This minimizes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// This closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// This opens up the game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            level window = new level();
            // Handle the Closing event of the current window

            this.Closing += (s, eventArgs) =>
            {
                // Set the Cancel property to false to allow the window to close
                eventArgs.Cancel = false;
            };


            window.Show();
            this.Close();
        }



        /// <summary>
        /// This opens up the Mario flap game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlap_Click(object sender, RoutedEventArgs e)
        {
            MarioFlap window = new MarioFlap();
            // Handle the Closing event of the current window

            this.Closing += (s, eventArgs) =>
            {
                // Set the Cancel property to false to allow the window to close
                eventArgs.Cancel = false;
            };


            window.Show();
            this.Close();
        }
        /// <summary>
        /// This open ups the settings window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            Settings window = new Settings();
            // Handle the Closing event of the current window

            this.Closing += (s, eventArgs) =>
            {
                // Set the Cancel property to false to allow the window to close
                eventArgs.Cancel = false;
            };


            window.Show();
            this.Close();

        }

        /// <summary>
        /// This turns the sound off 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            // New addition
            SoundPlayer player = new SoundPlayer(@"C:\Users\isuru\OneDrive\Desktop\MarioGame\Music\MainMenu.wav");
            player.Load();
            player.Stop();
        }

        /// <summary>
        /// this opens up the high score windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighscore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
