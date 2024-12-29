using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClincDataAccess
{
    public class Appointments
    {

        public static bool FindAppointment(int AppointmentID, ref int pateintid,ref int doctorid,ref DateTime appointDate,
            ref string appointStatus,ref int MedicalRecord,ref int PaymentID)
        {
            bool IsFound = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Appointments where AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    AppointmentID = (int)reader[0];   
                    pateintid = (int)reader[1]; 
                    doctorid = (int)reader[2];
                    appointDate = (DateTime)reader[3];  
                    appointStatus = (string)reader[4];
                    MedicalRecord = (int)reader[5];
                    PaymentID = (int)reader[6];
                  

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


        public static int AddAppointment(int pateintid,  int doctorid,  DateTime appointDate,
             string appointStatus,  int MedicalRecord,  int PaymentID)
        {


            int AppointmentID = -1;


            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"INSERT INTO Appointments
                               VALUES
                               (@PatientID,@DoctorID,@AppointmentDateTime, @AppointmentStatus,@MedicalRecordID,@PaymentID)
                                    select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@PatientID", pateintid);
            cmd.Parameters.AddWithValue("@DoctorID", doctorid);
            cmd.Parameters.AddWithValue("@AppointmentDateTime", appointDate);
            cmd.Parameters.AddWithValue("@AppointmentStatus", appointStatus);


            if (MedicalRecord>0)
            {
                cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecord);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MedicalRecordID", System.DBNull.Value);
            }

            if (PaymentID>0)
            {
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);

            }
            else
            {
                cmd.Parameters.AddWithValue("@PaymentID", System.DBNull.Value);

            }


            try
            {
                Connect.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    AppointmentID = InsertedID;

                }
                else
                {
                    AppointmentID = -1;
                }

            }
            catch (Exception ex)
            {

              Console.WriteLine(ex.ToString()); 
            }
            finally
            {
                Connect.Close();
            }

            return AppointmentID;

        }


        public static bool UpdateAppointment(int AppointmentID, int pateintid, int doctorid, DateTime appointDate,
             string appointStatus, int MedicalRecord, int PaymentID)
        {
            bool Updated = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"UPDATE [Appointments]
                             SET [PatientID] = @PatientID
                                ,[DoctorID] = @DoctorID
                                ,[AppointmentDateTime] = @AppointmentDateTime
                                ,[AppointmentStatus] = @AppointmentStatus
                                ,[MedicalRecordID] = @MedicalRecordID
                                ,[PaymentID] = @PaymentID
                                 WHERE  AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
            cmd.Parameters.AddWithValue("@PatientID", pateintid);
            cmd.Parameters.AddWithValue("@DoctorID", doctorid);
            cmd.Parameters.AddWithValue("@AppointmentDateTime", appointDate);
            cmd.Parameters.AddWithValue("@AppointmentStatus", appointStatus);


            if (MedicalRecord>0)
            {
                cmd.Parameters.AddWithValue("@MedicalRecordID", MedicalRecord);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MedicalRecordID", System.DBNull.Value);
            }

            if (PaymentID>0)
            {
                cmd.Parameters.AddWithValue("@PaymentID", PaymentID);

            }
            else
            {
                cmd.Parameters.AddWithValue("@PaymentID", System.DBNull.Value);

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


        public static bool Delete(int AppointmentID)
        {

              bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @" delete from Appointments
            where AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

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

        public static DataTable GetAllAppointment()
        {

            DataTable DT = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select * from Appointments";

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

        public static bool IsAppointmentExist(int AppointmentID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"select found=1 from Appointments where AppointmentID = @AppointmentID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

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

        //get all pateintID and Dcotor ID 

        public static List<int> GetAllPateintID()
        {
               List<int> list = new List<int>();    

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = "select PatientID from Patients";

            SqlCommand cmd = new SqlCommand(query, Connect);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    list.Add((int)reader[0]);
                }


                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                Connect.Close();
            }
            return list;
        }

        public static List<int> GetDoctorID()
        {

            List<int> list = new List<int>();

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = "select DoctorID from Doctors";

            SqlCommand cmd = new SqlCommand(query, Connect);

            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    list.Add((int)reader[0]);
                }

                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                Connect.Close();
            }
            return list;
        }

        // Get name sepc for doctor
        public static DataTable GetDoctorInfo(int docID)
        {

            DataTable DT = new DataTable();

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = "select Name,Specialization from DoctorInfo2 where DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query,Connect);
            cmd.Parameters.AddWithValue("@DoctorID",docID);


            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

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
                Connect.Close();
            }

            return DT;
        }

        public static DataTable GetPateintInfo(int PatID)
        {
            DataTable DT = new DataTable();

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = "select Name, PhoneNumber from PatientsInfo where PatientID  = @PatientID";

            SqlCommand cmd = new SqlCommand(query, Connect);
            cmd.Parameters.AddWithValue("@PatientID", PatID);


            try
            {
                Connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();

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
                Connect.Close();
            }

            return DT;
        }

        public static bool IsAppointmentDateExists(DateTime appointmentDateTime1,int docID)
        {
            bool IsExists = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);

            string query = @"SELECT found=1 FROM Appointments 
            WHERE AppointmentDateTime = @AppointmentDateTime AND DoctorID = @DoctorID";

            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime1);
            cmd.Parameters.AddWithValue("@DoctorID", docID);



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
                
            }
            finally
            {
                Connect.Close();
            }

            return IsExists;



        }


        public static bool DeleteAppointmentAndMedicalRecord(int AppointmentID)
        {
            bool IsDeleted = false;

            SqlConnection Connect = new SqlConnection(clsDataAccessSetting.Connection);


                 string deletePrescription = @" DELETE FROM Prescriptions 
    WHERE MedicalRecordID IN (
        SELECT MedicalRecordID 
        FROM Appointments 
        WHERE AppointmentID = @AppointmentID AND MedicalRecordID IS NOT NULL)";

            SqlCommand cmdPrescription = new SqlCommand(deletePrescription,Connect);

            cmdPrescription.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            //after delete perscption want to delete medical record realter with

            string deleteMedicalRecordQuery = @"
DELETE FROM MedicalRecords
    WHERE MedicalRecordID = (
        SELECT MedicalRecordID 
        FROM Appointments 
        WHERE AppointmentID = @AppointmentID AND MedicalRecordID IS NOT NULL)";

            SqlCommand cmdMedicalRecord = new SqlCommand(deleteMedicalRecordQuery, Connect);

            cmdMedicalRecord.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            //after delete medical record depand appoinment id want to delete appoinment

            string query = @"delete from Appointments
            where AppointmentID = @AppointmentID";


            SqlCommand cmd = new SqlCommand(query, Connect);

            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);


            try
            {
                Connect.Open();

                int RowEffected3 = cmdPrescription.ExecuteNonQuery();//delete prescption
                int RowEffected2 = cmdMedicalRecord.ExecuteNonQuery();//them midcal record
                int RowEffected = cmd.ExecuteNonQuery();//ten appoinemnt in order should delete

                if ((RowEffected3 > 0 ) && (RowEffected2 > 0))
                {
                    IsDeleted = true;
                }
            }
            catch (Exception)
            {
                IsDeleted = false;
            }
            finally
            {
                Connect.Close();
            }

            return IsDeleted;
        }




    }
}
