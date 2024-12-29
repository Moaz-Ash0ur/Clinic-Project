using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincBussniesLayer
{
    public class clsPrescription
    {

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;



        public int PrescriptionID { get; set; }
        public int MedicalRecordID { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialInstructions { get; set; }


         private clsPrescription(int PrescriptionID1, int MedicalRecordID1,string MedicationName1, string Dosage1, string Frequency1,
           DateTime StartDate1, DateTime EndDate1, string SpecialInstructions1) { 
        
            this.StartDate = StartDate1;
            this.EndDate = EndDate1; 
            this.SpecialInstructions = SpecialInstructions1;
            this.Frequency = Frequency1;
            this.Dosage = Dosage1;
            this.MedicalRecordID = MedicalRecordID1;
            this.PrescriptionID = PrescriptionID1;
            this.MedicationName = MedicationName1;

             Mode = enMode.UpdateMode;

        }


        public clsPrescription()
        {
            this.PrescriptionID = -1;
            this.MedicalRecordID = -1;
            this.MedicationName = "";
            this.Dosage = "";
            this.Frequency = "";
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.SpecialInstructions = "";


            this.Mode = enMode.AddNew;

        }


        private bool _AddNew()
        {

            this.PrescriptionID = ClincDataAccess.Prescriptions.Insert(this.MedicalRecordID, this.MedicationName, this.Dosage,
                this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);

            return (this.PrescriptionID != -1);

        }


        private bool _Update()
        {
            return ClincDataAccess.Prescriptions.Update(this.PrescriptionID, this.MedicalRecordID, this.MedicationName, this.Dosage,
                this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);
        }

        public static clsPrescription Find(int PrescriptionID)
        {

            int MedicalRec = 0;
            string MedcaName = "";
            DateTime StartDate = DateTime.Now;
            string Dosag = "";
            string Frequnecy = "";
            DateTime EndDate = DateTime.Now;
            string SpeciaNote = "";



            if (ClincDataAccess.Prescriptions.Find(PrescriptionID, ref MedicalRec, ref MedcaName, ref Dosag,
                ref Frequnecy, ref StartDate, ref EndDate,ref SpeciaNote))
            {
                return new clsPrescription(PrescriptionID,  MedicalRec,  MedcaName,  Dosag,
                 Frequnecy,  StartDate,  EndDate,  SpeciaNote);
            }

            return null;

        }

        public static DataTable GetAllPrescription()
        {
            return ClincDataAccess.Prescriptions.GetAllPrescription();
        }

        public static bool Delete(int PrescriptionID)
        {
            return ClincDataAccess.Prescriptions.Delete(PrescriptionID);
        }


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
