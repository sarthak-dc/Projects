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

namespace LRCH_DBAS_Group_Project
{
    /// <summary>
    /// Interaction logic for RoomUtilizationDashboard.xaml
    /// </summary>
    public partial class RoomUtilizationDashboard : Window
    {
        public RoomUtilizationDashboard()
        {
            InitializeComponent();
        }

        //When logout button is clicked
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            //
            MainWindow nextWPFWindow = new MainWindow();
            this.Hide();
            nextWPFWindow.Show();

        }

        //When exit button is clicked
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Displays a message box prompting the user for confirmation on closing the app
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }


        }

        private void btnPhysicianPatientDashboard_Click(object sender, RoutedEventArgs e)
        {

            //Show dashboard login in modal mode
            PhysicianLogin nextWPFWindow = new PhysicianLogin();
            nextWPFWindow.ShowDialog();

        }



        //When Add Physician button is clicked
        private void btnAddPhysician_Click(object sender, RoutedEventArgs e)
        {

            AddPhysician nextWPFWindow = new AddPhysician();
            nextWPFWindow.ShowDialog();

        }

        //When Daily Revenue Report button is clicked
        private void btnDailyRevenue_Click(object sender, RoutedEventArgs e)
        {

        }

        //When Revenue Analysis button is clicked
        private void btnRevenueAnalysis_Click(object sender, RoutedEventArgs e)
        {

        }

        //When Patient Bill button is clicked
        private void btnPatientBill_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
