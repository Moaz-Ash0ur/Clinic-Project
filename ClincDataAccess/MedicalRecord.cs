 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class MedicalRecord
    {

        public static bool FindMedicalRecord(int MedicalRecordID,ref string VisitDescription, 
            ref string Diagnosis, ref string AdditionalNotes)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MedicalRecordID = (int)reader[0];
                    VisitDescription = (string)reader[1];
                    Diagnosis = (string)reader[2];
                    AdditionalNotes = (string)reader[3];

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


        public static int AddMedicalRecord( string VisitDescription,
             string Diagnosis,  string AdditionalNotes)
        {


            int MedicalRecordID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO MedicalRecords
                               VALUES
                               (@VisitDescription, @Diagnosis, @AdditionalNotes);
                                    select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

         

            if (AdditionalNotes != "")
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalNotes", System.DBNull.Value);
            }


            if (VisitDescription != "")
            {
                cmd.Parameters.AddWithValue("@VisitDescription", VisitDescription);
            }
            else
            {
                cmd.Parameters.AddWithValue("@VisitDescription", System.DBNull.Value);
            }


            if (Diagnosis != "")
            {
                cmd.Parameters.AddWithValue("@Diagnosis", Diagnosis);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Diagnosis", System.DBNull.Value);
            }


            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    MedicalRecordID = InsertedID;

                }
                else
                {
                    MedicalRecordID = -1;
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

            return MedicalRecordID;

        }



        public static bool UpdateMedicalRecord(int MedicalRecordID, string VisitDescription,
             string Diagnosis, string AdditionalNotes)
        {
            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"UPDATE [MedicalRecords]
                             SET [VisitDescription] = @VisitDescription
                                ,[Diagnosis] = @Diagnosis
                                ,[AdditionalNotes] =@AdditionalNotes
                                 WHERE MedicalRecordID = @MedicalRecordID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);


            if (VisitDescription != "")
            {
                cmd.Parameters.AddWithValue("@VisitDescription", VisitDescription);
            }
            else
            {
                cmd.Parameters.AddWithValue("@VisitDescription", System.DBNull.Value);
            }


            if (Diagnosis != "")
            {
                cmd.Parameters.AddWithValue("@Diagnosis", Diagnosis);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Diagnosis", System.DBNull.Value);
            }


            if (AdditionalNotes!= "")
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


        public static bool DeleteMedicalRecord(int MedicalRecordID)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

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


        public static DataTable GetAllMedicalRecord()
        {
            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from MedicalRecords";

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


        public static bool IsMedicalRecordExist(int MedicalRecordID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select found=1 from MedicalRecords where MedicalRecordID = @MedicalRecordID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

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


        public static DataTable GetMedicalRecordIDNotAssignToAppoinment()
        {

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"SELECT MedicalRecordID FROM MedicalRecords m
                                 WHERE NOT EXISTS(
                                     SELECT 1
                                     FROM Appointments a
                                     WHERE a.MedicalRecordID = m.MedicalRecordID);";


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
