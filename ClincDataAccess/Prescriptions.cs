using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class Prescriptions
    {

        public static bool Find(int PrescriptionID, ref int MedicalRecordID,
          ref string MedicationName, ref string Dosage,ref string Frequency,
          ref DateTime StartDate,ref DateTime EndDate,ref string SpecialInstructions)
        {

            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Prescriptions where PrescriptionID = @PrescriptionID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PrescriptionID = (int)reader[0];
                    MedicalRecordID = (int)reader[1];
                    MedicationName = (string)reader[2];
                    Dosage = (string)reader[3];
                    Frequency = (string)reader[4];
                    StartDate = (DateTime)reader[5];
                    EndDate = (DateTime)reader[6];
                    SpecialInstructions = (string)reader[7];
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

        public static int Insert(int MedicalRecordID,
           string MedicationName,  string Dosage, string Frequency,
           DateTime StartDate,  DateTime EndDate,  string SpecialInstructions)
        {


            int PrescriptionID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Prescriptions VALUES
               (@MedicalRecordID,@MedicationName, @Dosage, @Frequency, @StartDate, @EndDate, @SpecialInstructions);
                            select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            cmd.Parameters.AddWithValue("@MedicationName", MedicationName);
            cmd.Parameters.AddWithValue("@Dosage", Dosage);
            cmd.Parameters.AddWithValue("@Frequency", Frequency);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);




            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    PrescriptionID = InsertedID;

                }
                else
                {
                    PrescriptionID = -1;
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

            return PrescriptionID;

        }


        public static bool Update(int PrescriptionID, int MedicalRecordID,
           string MedicationName, string Dosage, string Frequency,
           DateTime StartDate, DateTime EndDate, string SpecialInstructions)
        {
            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"UPDATE [Prescriptions]
                           SET [MedicalRecordID] = @MedicalRecordID
                              ,[MedicationName] = @MedicationName
                              ,[Dosage] =@Dosage
                              ,[Frequency] = @Frequency
                              ,[StartDate] = @StartDate
                              ,[EndDate] = @EndDate
                              ,[SpecialInstructions] = @SpecialInstructions
                         WHERE  PrescriptionID = @PrescriptionID";

            SqlCommand cmd = new SqlCommand(query, Connect);


            cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            cmd.Parameters.AddWithValue("@MedicationName", MedicationName);
            cmd.Parameters.AddWithValue("@Dosage", Dosage);
            cmd.Parameters.AddWithValue("@Frequency", Frequency);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);


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


        public static bool Delete(int PrescriptionID)
        {

            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"delete from Prescriptions where PrescriptionID = @PrescriptionID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

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


        public static DataTable GetAllPrescription()
        {
            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Prescriptions";

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
