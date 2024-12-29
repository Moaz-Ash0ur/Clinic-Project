using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClincDataAccess
{
    public class Doctors
    {

        //Add Doctors | can add data from doctor to person add doctor
        public static int AddDoctor(int PersonID, string Specialization)
        {


            int DoctorID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Doctors (PersonID, Specialization)
                          VALUES 
                          (@PersonID,@Specialization);
                    select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            if (Specialization != "")
            {
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Specialization", System.DBNull.Value);
            }


            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    DoctorID = InsertedID;

                }
                else
                {
                    DoctorID = -1;
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

            return DoctorID;

        }

        //2) Find Doctor

        public static bool FindDoctor(int DoctorID,ref int PersonID, ref string Specialization)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Doctors where DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;
                    DoctorID = (int)reader[0];
                    PersonID = (int)reader[1];

                  //  if (Specialization != "")
                  //  {
                  //      cmd.Parameters.AddWithValue("@Specialization", Specialization);
                  //  }
                  //  else
                  ///  {
                        cmd.Parameters.AddWithValue("@Specialization", System.DBNull.Value);
                  //  }
                    Specialization = (string)reader[2];
                    
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


        //3) Update Doctor

        public static bool UpdateDoctor(int DoctorID,  int PersonID,  string Specialization)
        {

            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"update Doctors
                                set PersonID = @PersonID,
                                Specialization = @Specialization
                                where DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query, Connect);


            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            if (Specialization != "")
            {
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Specialization", System.DBNull.Value);
            }

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

        //4 Delete Doctor
        public static bool DeleteDoctor(int DoctorID)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Doctors 
                             where DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

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

        public static DataTable GetAllDoctors()
        {

            //get all record as array = datatable have row and column

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Doctors";

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

        public static bool IsDoctorExist(int DoctorID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select found=1 from Doctors where DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

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

        public static DataTable GetPersonIDNotRelated()
        {

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

        public static DataTable GetAllPersonsDoctors()
        {

            //get all record as array = datatable have row and column

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"SELECT        Doctors.DoctorID, Persons.Name, Persons.DateOfBirth, Persons.Gender, Persons.PhoneNumber, Persons.Email, Persons.Address, Doctors.Specialization
FROM            Persons INNER JOIN
                         Doctors ON Persons.PersonID = Doctors.PersonID";

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
