using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClincDataAccess;

namespace ClincBussniesLayer
{
    public class clsPateints
    {

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        //attribute won doctor and another attribute from Person

        public int PersonIDP { get; set; }
        public int PatientID { get; set; }

        private clsPateints(int pateintid,int personid)
        {
            this.PersonIDP = personid;
            this.PatientID = pateintid;
            Mode = enMode.UpdateMode;
        }

        public clsPateints()
        {
            this.PatientID = -1;
            this.PersonIDP = 0;

            Mode = enMode.AddNew;
        }


        //start get fun from DataAccess Layer

        private bool _AddNew()
        {

            this.PatientID = ClincDataAccess.Patients.AddPatient(this.PersonIDP);

            return (this.PatientID != -1);

        }

        private bool _Update()
        {
            return ClincDataAccess.Patients.UpdatePatient(this.PatientID, this.PersonIDP);
        }

        public static clsPateints Find(int PatientID)
        {
            int personidd = 0;

            if (ClincDataAccess.Patients.FindPatient(PatientID, ref personidd))
            {
                return new clsPateints(PatientID, personidd);
            }
            return null;    
        }

        public static DataTable GetAllPatients()
        {
            return ClincDataAccess.Patients.GetAllPatients();
        }

        public static DataTable GetPersoNotRelated()
        {
            return ClincDataAccess.Patients.GetPersonIDNotRelated();
        }

        public static bool Delete(int PatientID)
        {
            return ClincDataAccess.Patients.DeletePatient(PatientID);
        }

        public static bool IsExists(int PatientID)
        {
            return ClincDataAccess.Patients.IsPatientExist(PatientID);
        }

        public static DataTable GetAllPersonsPatients()
        {
            return ClincDataAccess.Patients.GetAllPersonsPatients();
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
