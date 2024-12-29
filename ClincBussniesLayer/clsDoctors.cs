using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClincDataAccess;

namespace ClincBussniesLayer
{
    public class clsDoctors
    {

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        //attribute won doctor and another attribute from Person

        public int DoctorID { get; set; }
        public int PersonIDD { get; set; }
        public string Specialization { get; set; }


       private clsDoctors(int doctorID, int personid,string specialization)
        {
            this.DoctorID = doctorID;
            this.Specialization = specialization;
            this.PersonIDD = personid;
            Mode = enMode.UpdateMode;
        }

        public clsDoctors()
        {
            this.DoctorID = -1;
            this.PersonIDD = 0;
            this.Specialization = "";

            Mode = enMode.AddNew;
        }


        //start get fun from DataAccess Layer

        private bool _AddNew()
        {

            this.DoctorID = ClincDataAccess.Doctors.AddDoctor(this.PersonIDD, this.Specialization);

            return (this.DoctorID != -1);

        }

        private bool _Update()
        {
            return ClincDataAccess.Doctors.UpdateDoctor(this.DoctorID, this.PersonIDD, this.Specialization);
        }

        public static clsDoctors Find(int DoctorID)
        {
            string Specialization = "";
            int personidd = 0;

            if (ClincDataAccess.Doctors.FindDoctor(DoctorID, ref personidd, ref Specialization))
            {
                return new clsDoctors(DoctorID,  personidd, Specialization);
            }

            return null;

        }

        public static DataTable GetAllDoctors()
        {
            return ClincDataAccess.Doctors.GetAllDoctors();
        }

        public static bool Delete(int DoctorID)
        {
            return ClincDataAccess.Doctors.DeleteDoctor(DoctorID);
        }

        public static bool IsExists(int DoctorID)
        {
            return ClincDataAccess.Doctors.IsDoctorExist(DoctorID);
        }

        public static DataTable GetAllPersonDoctors()
        {
            return ClincDataAccess.Doctors.GetAllPersonsDoctors();
        }

        //Function Save Connect With Presetion Layer with Access Layer

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
