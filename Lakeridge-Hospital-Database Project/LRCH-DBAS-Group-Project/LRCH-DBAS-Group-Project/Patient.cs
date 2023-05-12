using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LRCH_DBAS_Group_Project
{
    public class Patient
    {
        #region PROPERTIES

        private int id;
        private string name;
        private string phoneNumber;
        private string city;
        private string province;
        private string postalCode;
        private string address;
        private string sex;
        private string hcn;
        private int physicianId;

        public static readonly int ID_LENGTH = 9;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Parameterized constructor creates an object of the patient class with data members
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="speciality"></param>
        public Patient(string id, string name, string phoneNumber, string address, string city, string province, string postalCode, string sex, string hcn, string physicianId)
        {
            setId(id);
            setName(name);
            setNumber(phoneNumber);
            setAddress(address);
            setCity(city);
            setProvince(province);
            setPostalCode(postalCode);
            setSex(sex);
            setHcn(hcn);
            setPhysicianId(physicianId);
        }

        /// <summary>
        /// Base constructor which initializes all instance values to default
        /// </summary>
        public Patient()
        {
            this.id = 0;
            this.name = "";
            this.phoneNumber = "";
            this.address = "";
            this.city = "";
            this.province = "";
            this.postalCode = "";
            this.sex = "";
            this.hcn = "";
            this.physicianId = 0;
        }

        #endregion

        #region GETTERS

        /// <summary>
        /// Gets the Id of Patient
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Gets the Name of Patient
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Gets the Number of Patient
        /// </summary>
        /// <returns></returns>
        public string getNumber()
        {
            return phoneNumber;
        }

        /// <summary>
        /// Gets the Address of Patient
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            return address;
        }

        /// <summary>
        /// Gets the City of Patient
        /// </summary>
        /// <returns></returns>
        public string getCity()
        {
            return city;
        }

        /// <summary>
        /// Gets the Province of Patient
        /// </summary>
        /// <returns></returns>
        public string getProvince()
        {
            return province;
        }

        /// <summary>
        /// Gets the Postal Code of Patient
        /// </summary>
        /// <returns></returns>
        public string getPostalCode()
        {
            return postalCode;
        }

        /// <summary>
        /// Gets the Sex of Patient
        /// </summary>
        /// <returns></returns>
        public string getSex()
        {
            return sex;
        }

        /// <summary>
        /// Gets the Hcn of Patient
        /// </summary>
        /// <returns></returns>
        public string getHcn()
        {
            return hcn;
        }

        /// <summary>
        /// Gets the Id of Physician in charge of Patient
        /// </summary>
        /// <returns></returns>
        public int getPhysicianId()
        {
            return physicianId;
        }


        #endregion

        #region SETTERS

        /// <summary>
        /// Sets the Id of Patient
        /// </summary>
        /// <returns></returns>
        public bool setId(string id)
        {
            if (int.TryParse(id, out int newId))
            {
                this.id = newId;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Name of Patient
        /// </summary>
        /// <returns></returns>
        public bool setName(string newName)
        {
            if (newName != "")
            {
                this.name = newName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Number of Patient
        /// </summary>
        /// <returns></returns>
        public bool setNumber(string newNumber)
        {
            if (newNumber != "")
            {
                this.phoneNumber = newNumber;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Address of Patient
        /// </summary>
        /// <returns></returns>
        public bool setAddress(string newAddress)
        {
            if (newAddress != "")
            {
                this.address = newAddress;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the City of Patient
        /// </summary>
        /// <returns></returns>
        public bool setCity(string newCity)
        {
            if (newCity != "")
            {
                this.city = newCity;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Province of Patient
        /// </summary>
        /// <returns></returns>
        public bool setProvince(string newProvince)
        {
            if (newProvince != "")
            {
                this.province = newProvince;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Postal Code of Patient
        /// </summary>
        /// <returns></returns>
        public bool setPostalCode(string newPostalCode)
        {
            if (newPostalCode != "")
            {
                this.postalCode = newPostalCode;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Sex of Patient
        /// </summary>
        /// <returns></returns>
        public bool setSex(string newSex)
        {
            if (newSex != "")
            {
                this.sex = newSex;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Hcn of Patient
        /// </summary>
        /// <returns></returns>
        public bool setHcn(string newSex)
        {
            if (newSex != "")
            {
                this.hcn = newSex;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the Id of Physician in charge of the patient
        /// </summary>
        /// <returns></returns>
        public bool setPhysicianId(string id)
        {
            if (int.TryParse(id, out int newId))
            {
                this.physicianId = newId;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Returns true and all patients record matches the physician id given else returns false
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataSet returnPatients(int physicianId)
        {
            SqlConnection conn = Database.conn;
            conn.Open();

            string statement = $"SELECT * FROM patients WHERE physician_id = {physicianId} ";
            SqlDataAdapter adapter = new SqlDataAdapter(statement, conn);
            DataSet patients = new System.Data.DataSet();
            adapter.Fill(patients);
            conn.Close();

            return patients;

        }

        /// <summary>
        /// Adds Patient to Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <param name="postalCode"></param>
        /// <param name="sex"></param>
        /// <param name="hcn"></param>
        /// <param name="physicianId"></param>
        public static void addPatient(Patient newPatient)
        {
            SqlConnection conn = Database.conn;
            conn.Open();

            string statement = $"INSERT INTO patients(patient_id, name, address, phone_number, sex, hcn, physician_id) VALUES (@id, @value1, @value2, @value3, @value4, @value5, @value6)";
            SqlCommand cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@value1", newPatient.getName());
            cmd.Parameters.AddWithValue("@value2", newPatient.getAddress());
            cmd.Parameters.AddWithValue("@value3", newPatient.getNumber());
            cmd.Parameters.AddWithValue("@value4", newPatient.getSex());
            cmd.Parameters.AddWithValue("@value5", newPatient.getHcn());
            cmd.Parameters.AddWithValue("@value6", newPatient.getPhysicianId());
            cmd.Parameters.AddWithValue("@id", newPatient.getId());
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();

            statement = $"INSERT INTO patient_address(patient_id, city, province, postal_code) VALUES (@id, @value1, @value2, @value3)";
            cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@value1", newPatient.getCity());
            cmd.Parameters.AddWithValue("@value2", newPatient.getProvince());
            cmd.Parameters.AddWithValue("@value3", newPatient.getPostalCode());
            cmd.Parameters.AddWithValue("@id", newPatient.getId());
            SqlDataReader reader2 = cmd.ExecuteReader();

            reader2.Close();
            conn.Close();
        }

        #endregion

    }
}
