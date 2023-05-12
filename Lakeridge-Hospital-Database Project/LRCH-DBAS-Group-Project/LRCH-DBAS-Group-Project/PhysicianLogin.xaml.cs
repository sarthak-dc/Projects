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
    /// Interaction logic for PhysicianLogin.xaml
    /// </summary>
    public partial class PhysicianLogin : Window
    {
        public PhysicianLogin()
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

            //Database code here
            if (Physician.isIdValid(inputUsername.Text) == true)
            {
                Physician currentPhysician = new Physician();

                if (Physician.returnPhysician(inputUsername.Text, out currentPhysician))
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
            }
        }

        /// <summary>
        /// Closes the program if the user enteres the word yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


        }

    }
}
