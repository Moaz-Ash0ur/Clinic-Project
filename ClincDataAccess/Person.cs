using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class Person
    {
        // start for connection excute CRUD Opertions( Insert ,Update , Select ,Delete for each Table )

        //1) Insert Record in table Perons

        //because the ID is Auto increment will return it when add record

       public static int AddPerson(string Name,DateTime DateOfBirth,string Gender,string PhoneNumber,
           string Email,string Address)

        {

            int PeronsID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Persons VALUES 
                   (@Name,@DateOfBirth, @Gender, @PhoneNumber, @Email, @Address);
                    select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);   

            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Address", Address);

            //for email address date of borh  allow null 

           // if (ImagePath != "")
           // {
             //   command.Parameters.AddWithValue("@ImagePath", ImagePath);
           // }
          //  else
          //  {
              //  command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
          //  }


            try
            {
                Connect.Open();
                //to excute query then return ID 

                object result = cmd.ExecuteScalar(); 
                
                if (result != null  && int.TryParse(result.ToString(),out int InsertedID) ) {

                    PeronsID = InsertedID;

                }
                else
                {
                    PeronsID = -1;
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

            return PeronsID;

        }


        //2) Find Person

        public static bool FindPerson(int PersonID,ref string Name, ref DateTime DateOfBirth, ref string Gender,
            ref string PhoneNumber,ref string Email, ref string Address)
        {
            bool IsFound  = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Persons where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader(); 

                if(reader.Read()) {

                   IsFound = true;

                    PersonID = (int) reader[0];
                   Name = (string)reader[1];
                   DateOfBirth = (DateTime)reader[2];
                   Gender = (string)reader[3];
                   PhoneNumber = (string)reader[4];
                   Email = (string)reader[5];
                   Address = (string)reader[6];

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


        //3) Update Person

        public static bool UpdatePerson(int PersonID,string Name, DateTime DateOfBirth, string Gender, string PhoneNumber,
           string Email, string Address)
        {

            bool Updated = false; 
            
            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"UPDATE Persons
                              SET Name = @Name, 
                                  DateOfBirth = @DateOfBirth,
                                  Gender = @Gender,
                                  PhoneNumber = @PhoneNumber,
                                  Email = @Email,
                                  Address = @Address
                                  WHERE  PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Address", Address);

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


        //4 Delete 
        public static bool DeletePerson(int PersonID) 
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Persons 
                             where PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static DataTable GetAllPersons()
        {

            //get all record as array = datatable have row and column

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Persons";

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


        public static bool IsPersonExist(int PersonID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select found=1 from Persons where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

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

       


    }
}
