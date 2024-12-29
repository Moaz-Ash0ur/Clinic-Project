using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class Users
    {

        public static int Insert(int PersonID, string Username, string Password,
          int Permission)

        {

            int UserID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Users VALUES 
                             (@PersonID,@Username,@Password,@Permission);
                              select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Permission", Permission);

            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    UserID = InsertedID;

                }
                else
                {
                    UserID = -1;
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

            return UserID;

        }


        public static bool Find(int User_id,ref int PersonID,ref string Username,ref string Password,
         ref int Permission)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Users where User_id = @User_id";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@User_id", User_id);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    User_id = (int)reader[0];
                    PersonID = (int)reader[1];
                    Username = (String)reader[2];
                    Password = (string)reader[3];
                    Permission = (int)reader[4];
                 

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


        public static bool Update(int User_id, int PersonID, string Username, string Password,
          int Permission)
        {

            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @" UPDATE [Users]
                               SET [PersonID] = @PersonID
                                  ,[Username] = @Username
                                  ,[Password] = @Password
                                  ,[Permission] = @Permission
                             WHERE User_id = @User_id";

            SqlCommand cmd = new SqlCommand(query, Connect);


            cmd.Parameters.AddWithValue("@User_id", User_id);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Permission", Permission);


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


        public static bool Delete(int User_id)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Users 
                             where User_id = @User_id;";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@User_id", User_id);

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

      

        public static DataTable GetAllUsers()
        {

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from UserInfo";

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


        //Find for login

        public static bool FindLoginUser(ref int User_id, ref int PersonID,  string Username,  string Password,
       ref int Permission)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Users where Username = @Username and Password = @Password";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);


            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    User_id = (int)reader[0];
                    PersonID = (int)reader[1];
                    Username = (String)reader[2];
                    Password = (string)reader[3];
                    Permission = (int)reader[4];


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




    }
}
