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
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient()
        {
            InitializeComponent();
            inputPatientID.IsReadOnly = false;
        }

        //When add button is clicked
        private void btnPatientAdd_Click(object sender, RoutedEventArgs e)
        {

            //Validate user input info and then attempt to add patient to database
            Patient newPatient = new Patient();
            if (newPatient.setId(inputPatientID.Text) && newPatient.setName(inputPatientName.Text) && newPatient.setNumber(inputPatientPhone.Text) && newPatient.setAddress(inputPatientStreet.Text) && newPatient.setCity(inputPatientCity.Text) && newPatient.setProvince(inputPatientProvince.Text) && newPatient.setPostalCode(inputPatientPostalCode.Text) && newPatient.setSex(inputPatientSex.Text) && newPatient.setHcn(inputPatientHCN.Text) && newPatient.setPhysicianId(inputPhysicianID.Text))
            {
                Patient.addPatient(newPatient);
                MessageBox.Show("Creation Successful", "Notification", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Creation Failed", "Notification", MessageBoxButton.OK);
            }
        }

        //When the close button is clicked
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }
    }
}
