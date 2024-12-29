using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClincDataAccess;
namespace ClincBussniesLayer
{
    public class clsMedicalRecord
    {

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        public int MedicalRecordID { get; set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }


        private clsMedicalRecord(int MedRecordID, string VisitDescri, string Diagno,
            string AddNotes)
        {

            this.MedicalRecordID = MedRecordID;
            this.VisitDescription = VisitDescri;
            this.Diagnosis = Diagno;
            this.AdditionalNotes = AddNotes;

            this.Mode = enMode.UpdateMode;

        }

        public clsMedicalRecord()
        {

            this.MedicalRecordID = -1;
            this.VisitDescription = "";
            this.Diagnosis = "";
            this.AdditionalNotes = "";

            this.Mode = enMode.AddNew;

        }



        private bool _AddNew()
        {

            this.MedicalRecordID = ClincDataAccess.MedicalRecord.AddMedicalRecord(this.VisitDescription,this.Diagnosis,
                this.AdditionalNotes);

            return (this.MedicalRecordID != -1);

        }


        private bool _Update()
        {
            return ClincDataAccess.MedicalRecord.UpdateMedicalRecord(this.MedicalRecordID,this.VisitDescription, this.Diagnosis,
                this.AdditionalNotes);
        }


        public static clsMedicalRecord Find(int MedRecordID)
        {
            string VisitDescri = ""; string Diagno = "";
            string AddNote = "";


            if (ClincDataAccess.MedicalRecord.FindMedicalRecord(MedRecordID, ref VisitDescri, ref Diagno, ref AddNote))
            {
                return new clsMedicalRecord(MedRecordID, VisitDescri, Diagno, AddNote);
            }

            return null;

        }

        public static DataTable GetAllMedicalRecord()
        {
            return ClincDataAccess.MedicalRecord.GetAllMedicalRecord();
        }

        public static bool Delete(int ID)
        {
            return ClincDataAccess.MedicalRecord.DeleteMedicalRecord(ID);
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


        //more fun test
        public static DataTable GetMedicalRecordNotRelated()
        {
            return ClincDataAccess.MedicalRecord.GetMedicalRecordIDNotAssignToAppoinment();
        }

    }
}
