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
using System.Data.SqlClient;

namespace LRCH_DBAS_Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This sends user to view page if the Physician Id is within our system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //Validate inputs aren't empty

            //Hash password

            //Old commented out database code here, was moved to PhysicianLogin.xaml.cs file
            //Nasean, replace this with the new database code
            /*if(Physician.isIdValid(inputPhysicianID.Text) == true)
            {
                Physician currentPhysician = new Physician();

                if(Physician.returnPhysician(inputPhysicianID.Text, out currentPhysician))
                {
                    //Open physician patient view
                    PhysicianPatientView nextWPFWindow = new PhysicianPatientView(currentPhysician);
                    this.Hide();
                    nextWPFWindow.Show();
                }
                else
                {
                    MessageBox.Show("Physician ID is not in our database, please try again.", "Absent Physician", MessageBoxButton.OK);
                }

            }
            else
            {
                MessageBox.Show("Physician ID is not valid, please try again.", "Invalid ID", MessageBoxButton.OK);
            }*/

            //Open room utilization dashboard
            RoomUtilizationDashboard nextWPFWindow = new RoomUtilizationDashboard();
            this.Hide();
            nextWPFWindow.Show();

        }

        /// <summary>
        /// Closes the program if the user enteres the word yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Displays a message box prompting the user for confirmation on closing the app
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }


        }

    }
}
