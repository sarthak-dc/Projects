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

using System.Data;

namespace LRCH_DBAS_Group_Project
{
    /// <summary>
    /// Interaction logic for PhysicianPatientView.xaml
    /// </summary>
    public partial class PhysicianPatientView : Window
    {
        Physician currentPhysician = new Physician();

        //Runs on window load
        public PhysicianPatientView(Physician currentPhysician)
        {
            InitializeComponent();

            //Code to populate physician info and patient info from DB goes here
            this.currentPhysician = currentPhysician;
            populatePhysicianInfo(currentPhysician);
            populatePatientsInfo(Patient.returnPatients(currentPhysician.getId()));

        }

        //When physician Update button is clicked
        private void btnPhysicianUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            //Code to update the physician in the database goes here
            if(currentPhysician.setName(inputPhysicianName.Text) && currentPhysician.setNumber(inputPhysicianPhone.Text) && currentPhysician.setSpeciality(inputSpecialty.Text)) 
            {
                Physician.updatePhysician(currentPhysician);
                MessageBox.Show("Update Successful", "Notification", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Update Failed", "Notification", MessageBoxButton.OK);
            }

        }

        //When Back To Main button is clicked
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {

            //Re-open main window
            /*MainWindow nextWPFWindow = new MainWindow();
            nextWPFWindow.Show();*/
            this.Hide();

        }

        //When Exit button is clicked
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Show confirmation dialogue
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application? Data may not be saved.", "Confirm Application Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //If user clicks yes, exit
            if (result == MessageBoxResult.Yes)
            {
                //Exit the program
                Application.Current.Shutdown(0);
            }
        }

        //When Add Patient button is clicked
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {

            AddPatient nextWPFWindow = new AddPatient();
            nextWPFWindow.ShowDialog();

        }

        /// <summary>
        /// Populates the current Physician info inside the textboxes
        /// </summary>
        /// <param name="currentPhysician"></param>
        private void populatePhysicianInfo(Physician currentPhysician)
        {
            inputPhysicianID.Text = currentPhysician.getId().ToString();
            inputPhysicianName.Text = currentPhysician.getName();
            inputPhysicianPhone.Text = currentPhysician.getNumber();
            inputSpecialty.Text = currentPhysician.getSpeciality();
        }

        /// <summary>
        /// Populates the data grid with all patients who are under the care of the current Physician
        /// </summary>
        /// <param name="results"></param>
        private void populatePatientsInfo(DataSet results)
        {
            dtaPatients.ItemsSource = results.Tables[0].DefaultView;
        }

        //When the SeeTreatments button is clicked
        private void btnSeeTreatments_Click(object sender, RoutedEventArgs e)
        {

            //This window will need to be created, but a window should pop up showing the date and the treatment
            //given for as many treatments can be found for the patient in the treatments table (not yet made,
            //I don't have the updated SQL file to modify/work from)

        }

        //When SeeNotes Button is clicked
        private void btnSeeNotes_Click(object sender, RoutedEventArgs e)
        {

            //This is another window that will need to be created, doing pretty much the same thing as btnSeeTreatments,
            //but for notes and an accompanying Notes table (that also doesn't exist yet)


        }
    }
}
