using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LRCH_DBAS_Group_Project
{
    public class Physician
    {
        #region PROPERTIES

        private int id;
        private string name;
        private string phoneNumber;
        private string speciality;
        
        public static readonly int ID_LENGTH = 9;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Parameterized constructor creates an object of the physician class with data members
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="speciality"></param>
        public Physician(string id, string name, string phoneNumber, string speciality)
        {
            setId(id);
            setName(name);
            setNumber(phoneNumber);
            setSpeciality(speciality);
        }

        /// <summary>
        /// Base constructor which initializes all instance values to default
        /// </summary>
        public Physician()
        {
            this.id = 0;
            this.name = "";
            this.phoneNumber = "";
            this.speciality = "";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// This method takes a string and returns true if the string is is present and of valid length
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool isIdValid(string id)
        {
            if(id == "")
            {
                return false;
            }
            else if(id.Length != ID_LENGTH)
            {
                return false;
            }
            else if(!int.TryParse(id, out int result))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns true and the physician's record if a record matches the id given else returns false
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool returnPhysician(string id, out Physician p)
        {
            SqlConnection conn = Database.conn;
            conn.Open();

            string statement = $"SELECT * FROM physicians WHERE physician_id = @id ";
            SqlCommand cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
           
            if (reader.Read())
            {
                Physician currentPhysician = new Physician(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                p = currentPhysician;
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                p = new Physician();
                reader.Close();
                conn.Close();
                return false;
            }

        }

        /// <summary>
        /// Updates the current Physician's record
        /// </summary>
        /// <param name="currentPhysician"></param>
        public static void updatePhysician(Physician currentPhysician)
        {
            SqlConnection conn = Database.conn;
            conn.Open();

            string statement = $"UPDATE physicians SET name = @value1, phone_number = @value2, speciality = @value3 WHERE physician_id = @id ";
            SqlCommand cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@value1", currentPhysician.getName());
            cmd.Parameters.AddWithValue("@value2", currentPhysician.getNumber());
            cmd.Parameters.AddWithValue("@value3", currentPhysician.getSpeciality());
            cmd.Parameters.AddWithValue("@id", currentPhysician.getId());
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        /// <summary>
        /// Adds another physician to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <param name="speciality"></param>
        public static void addPhysician(Physician newPhysician)
        {
            SqlConnection conn = Database.conn;
            conn.Open();

            string statement = $"INSERT INTO physicians(physician_id, name, phone_number, speciality) VALUES (@id, @value1, @value2, @value3)";
            SqlCommand cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@value1", newPhysician.getName());
            cmd.Parameters.AddWithValue("@value2", newPhysician.getNumber());
            cmd.Parameters.AddWithValue("@value3", newPhysician.getSpeciality());
            cmd.Parameters.AddWithValue("@id", newPhysician.getId());
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        #endregion

        #region GETTERS

        /// <summary>
        /// Gets the Id of Physician
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Gets the Name of Physician
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Gets the Number of Physician
        /// </summary>
        /// <returns></returns>
        public string getNumber()
        {
            return phoneNumber;
        }

        /// <summary>
        /// Gets the Speciality of Physician
        /// </summary>
        /// <returns></returns>
        public string getSpeciality()
        {
            return speciality;
        }


        #endregion

        #region SETTERS

        /// <summary>
        /// Sets the Id of Physician
        /// </summary>
        /// <returns></returns>
        public bool setId(string id)
        {
            if(int.TryParse(id, out int newId))
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
        /// Sets the Name of Physician
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
        /// Sets the Number of Physician
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
        /// Sets the Speciality of Physician
        /// </summary>
        /// <returns></returns>
        public bool setSpeciality(string newSpeciality)
        {
            if (newSpeciality != "")
            {
                this.speciality = newSpeciality;
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

    }
}
