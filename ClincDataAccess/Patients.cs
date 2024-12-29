using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class Patients
    {
        
        public static int AddPatient(int PersonID)
        {

            int PatientID = -1;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Patients (PersonID) VALUES(@PersonID);
                                select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);



            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    PatientID = InsertedID;

                }
                else
                {
                    PatientID = -1;
                }

            }
            catch (Exception ex)
            {

                // throw;
            }
            finally
            {
                Connect.Close();
            }

            return PatientID;

        }

        public static bool FindPatient(int PatientID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Patients where PatientID = @PatientID ;";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    PatientID = (int)reader[0];
                    PersonID = (int)reader[1];
                   

                }

                reader.Close();


            }
            catch (Exception)
            {
                // IsFound = false;
                Console.WriteLine("TEST");
            }
            finally
            {
                Connect.Close();
            }

            return IsFound;
        }

        public static bool UpdatePatient(int PatientID, int PersonID)
        {

            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"update Patients
                                set PersonID = @PersonID
                                where PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, Connect);


            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

          
            try
            {
                Connect.Open();

                int RowEffected = cmd.ExecuteNonQuery();

                if (RowEffected > 0)
                {

                    Updated = true;

                }

            }
            catch (Exception ex)
            {
                Updated = false;
                Console.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                Connect.Close();
            }

            return Updated;

        }

        public static bool DeletePatient(int PatientID)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Patients 
                             where PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connect.Open();

                int RowEffected = cmd.ExecuteNonQuery();

                if (RowEffected > 0)
                {

                    IsDeleted = true;

                }

            }
            catch (Exception)
            {
                IsDeleted = false;
                //  throw;
            }
            finally
            {
                Connect.Close();
            }

            return IsDeleted;


        }

        public static DataTable GetAllPatients()
        {

            //get all record as array = datatable have row and column

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Patients";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConnection.Close();
            }

            return DT;

        }

        public static bool IsPatientExist(int PatientID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select found=1 from Patients where PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {

                    IsExists = true;

                }

            }
            catch (Exception ex)
            {
                IsExists = false;
                // Console.WriteLine(ex.Message);
                //throw;
            }
            finally
            {
                Connect.Close();
            }

            return IsExists;

        }

        //when you want to  related Pateint wiht person just show ID that not realteed wiht Doctor and pateint
        public static DataTable GetPersonIDNotRelated() {

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"SELECT PersonID FROM Persons 
                             WHERE PersonID NOT IN
                            (SELECT PersonID FROM Patients)and
                             PersonID NOT IN (SELECT PersonID FROM Doctors);";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConnection.Close();
            }

            return DT;

        }

        public static DataTable GetAllPersonsPatients()
        {

            //get all record as array = datatable have row and column

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"SELECT        Patients.PatientID, Persons.Name, Persons.DateOfBirth, Persons.Gender, Persons.PhoneNumber, Persons.Email, Persons.Address
FROM            Persons INNER JOIN
                         Patients ON Persons.PersonID = Patients.PersonID";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                sqlConnection.Close();
            }

            return DT;

        }




    }
}
