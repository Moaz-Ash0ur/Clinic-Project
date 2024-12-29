using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincBussniesLayer
{
    public class clsAppointments
    {
        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        public int AppoimentID {  get; set; }
         public int pateintid { get; set; }
        public int doctorid { get; set; }
        public DateTime appointDate { get; set; }
        public string appointStatus { get; set; }
        public int MedicalRecord { get; set; }
        public int PaymentID { get; set; }


        private clsAppointments(int AppoimentID, int pateintid, int doctorid, DateTime appointDate,
             string appointStatus, int MedicalRecord, int PaymentID) {
        
            this.AppoimentID = AppoimentID;
            this.pateintid = pateintid;
            this.doctorid = doctorid;   
            this.appointDate = appointDate; 
            this.appointStatus = appointStatus; 
            this.MedicalRecord = MedicalRecord; 
            this.PaymentID = PaymentID;

             this.Mode = enMode.UpdateMode;


        }

        public clsAppointments()
        {

            this.doctorid = 0;
            this.pateintid= 0;
            this.appointDate = new DateTime();
            this.appointStatus = "";
            this.MedicalRecord = 0;
            this.PaymentID= 0;
            this.AppoimentID = -1;
            this.Mode = enMode.AddNew;


        }


        private bool _AddNew()
        {

            this.AppoimentID = ClincDataAccess.Appointments.AddAppointment(this.pateintid, this.doctorid, this.appointDate,
                  this.appointStatus, this.MedicalRecord, this.PaymentID);

            return (this.AppoimentID != -1);

        }


        private bool _Update()
        {
            return  ClincDataAccess.Appointments.UpdateAppointment(this.AppoimentID,this.pateintid, this.doctorid, this.appointDate,
                 this.appointStatus, this.MedicalRecord, this.PaymentID);
        }


        public static clsAppointments Find(int AppoimentID)
        {
            int pateintid  = 0; 
            int doctorid = 0; 
            DateTime appointDate = DateTime.Now;
            string appointStatus = "";  
            int MedicalRecord = 0; 
            int PaymentID = 0;


            if (ClincDataAccess.Appointments.FindAppointment(AppoimentID, ref pateintid, ref doctorid, ref appointDate, 
                ref appointStatus, ref  MedicalRecord, ref PaymentID))
            {
                return new clsAppointments(AppoimentID,  pateintid,  doctorid, appointDate,
                 appointStatus,  MedicalRecord,  PaymentID);
            }

            return null;

        }


        public static DataTable GetAllAppoinments()
        {
            return ClincDataAccess.Appointments.GetAllAppointment();
        }

        public static bool Delete(int Appoiment)
        {
            return ClincDataAccess.Appointments.Delete(Appoiment);
        }

        //more fun for project reqiurment
        public static List<int> GetDoctorID()
        {
            return ClincDataAccess.Appointments.GetDoctorID();
        }

        public static List<int> GetAllPateintID()
        {
            return ClincDataAccess.Appointments.GetAllPateintID();
        }

        public static DataTable GetDoctorInfo(int docID)
        {
            return ClincDataAccess.Appointments.GetDoctorInfo(docID);
        }
        public static DataTable GetPateintInfo(int PatID)
        {
            return ClincDataAccess.Appointments.GetPateintInfo(PatID);
        }

        public static bool IsAppointmentDateExists(DateTime appointmentDateTime,int docID)
        {
            return ClincDataAccess.Appointments.IsAppointmentDateExists(appointmentDateTime,docID);
        }

        public static bool DeleteFullAppoinment(int appointmentID)
        {
            return ClincDataAccess.Appointments.DeleteAppointmentAndMedicalRecord(appointmentID);   
        }

        //Save and excute the CRUD Opertion
        public bool Save()
        {
            switch (Mode)
            {

                case enMode.UpdateMode:

                    return _Update();

                case enMode.AddNew:

                    if (_AddNew())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    break;
            }
            return true;
        }




    }



}
