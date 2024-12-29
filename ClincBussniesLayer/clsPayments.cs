using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincBussniesLayer
{
    public class clsPayments
    {

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;


        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int AmountPaid { get; set; }
        public string AdditionalNotes { get; set; }



       private clsPayments(int PaymentID1, DateTime PaymentDate1,
            string PaymentMethod1, int AmountPaid1, string AdditionalNotes1)
        {
            this.PaymentID  = PaymentID1;    
            this.PaymentDate = PaymentDate1;
            this.PaymentMethod = PaymentMethod1;
            this.AmountPaid = AmountPaid1;
            this.AdditionalNotes = AdditionalNotes1;

            Mode  =enMode.UpdateMode;
        }

        
        public clsPayments()
        {
            this.PaymentID = -1;
            this.PaymentDate = DateTime.Now;
            this.PaymentMethod = "";
            this.AmountPaid = 0;
            this.AdditionalNotes = "";

            Mode = enMode.AddNew;
        }


        private bool _AddNew()
        {

            this.PaymentID = ClincDataAccess.Payments.Insert(this.PaymentDate, this.PaymentMethod,
                this.AmountPaid,this.AdditionalNotes);

            return (this.PaymentID != -1);

        }

        private bool _Update()
        {
            return ClincDataAccess.Payments.Update(this.PaymentID, this.PaymentDate, this.PaymentMethod,
                this.AmountPaid,this.AdditionalNotes);
        }

        public static clsPayments Find(int PaymentID1)
        {
            DateTime PayDate = DateTime.Now; string PayMethod = "";int payAmount = 0;
            string AddNote = "";


            if (ClincDataAccess.Payments.Find(PaymentID1, ref PayDate, ref PayMethod, ref payAmount,ref AddNote))
            {
                return new clsPayments(PaymentID1, PayDate, PayMethod, payAmount, AddNote);
            }

            return null;

        }

        public static bool Delete(int ID)
        {
            return ClincDataAccess.Payments.Delete(ID);
        }

        public static DataTable GetAllPayments()
        {
            return ClincDataAccess.Payments.GetAllPayments();
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
