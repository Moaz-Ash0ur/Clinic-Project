using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public  class Payments
    {
        public static bool Find(int PaymentID, ref DateTime PaymentDate,
           ref string PaymentMethod, ref int AmountPaid,ref string AdditionalNotes)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Payments where PaymentID = @PaymentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PaymentID = (int)reader[0];
                    PaymentDate = (DateTime)reader[1];
                    PaymentMethod = (string)reader[2];
                    AmountPaid = (int)reader[3];
                    AdditionalNotes = (string)reader[4];
                }

                reader.Close();


            }
            catch (Exception)
            {
                IsFound = false;
                Console.WriteLine("TEST");
            }
            finally
            {
                Connect.Close();
            }

            return IsFound;
        }



        public static int Insert( DateTime PaymentDate,
            string PaymentMethod,  int AmountPaid,  string AdditionalNotes)
        {

            int PaymentID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Payments VALUES
                               (@PaymentDate, @PaymentMethod, @AmountPaid, @AdditionalNotes);
                                    select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
            cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid);


            if (AdditionalNotes != "")
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", System.DBNull.Value);
            }



            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    PaymentID = InsertedID;

                }
                else
                {
                    PaymentID = -1;
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

            return PaymentID;

        }



        public static bool Update(int PaymentID, DateTime PaymentDate,
            string PaymentMethod, int AmountPaid, string AdditionalNotes)
        {
            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"UPDATE [Payments]
                            SET [PaymentDate] = @PaymentDate
                               ,[PaymentMethod] = @PaymentMethod
                               ,[AmountPaid] =@AmountPaid
                               ,[AdditionalNotes] =@AdditionalNotes
                          WHERE PaymentID = @PaymentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
            cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
            cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid);


            if (AdditionalNotes != "")
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", System.DBNull.Value);
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


        public static bool Delete(int PaymentID)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Payments where PaymentID = @PaymentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PaymentID", PaymentID);

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


        public static DataTable GetAllPayments()
        {
            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Payments";

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
