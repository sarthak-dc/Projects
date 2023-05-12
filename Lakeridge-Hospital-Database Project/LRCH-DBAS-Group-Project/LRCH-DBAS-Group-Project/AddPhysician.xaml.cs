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
    /// Interaction logic for AddPhysician.xaml
    /// </summary>
    public partial class AddPhysician : Window
    {
        public AddPhysician()
        {
            InitializeComponent();
            inputPhysicianID.IsReadOnly = false;
        }

        //When add button is clicked
        private void btnPhysicianAdd_Click(object sender, RoutedEventArgs e)
        {

            //Validate user input info and then attempt to add physician to database
            Physician newPhysician = new Physician();
            if(newPhysician.setId(inputPhysicianID.Text) && newPhysician.setName(inputPhysicianName.Text) && newPhysician.setNumber(inputPhysicianPhone.Text) && newPhysician.setSpeciality(inputSpecialty.Text))
            {
                Physician.addPhysician(newPhysician);
                MessageBox.Show("Creation Successful", "Notification", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Creation Failed", "Notification", MessageBoxButton.OK);
            }

        }

        //When close button is clicked
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }
    }
}
