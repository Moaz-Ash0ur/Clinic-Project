  using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using ClincDataAccess;

namespace ClincBussniesLayer
{
    public class clsPerson
    {
        //start coding class Peron to connect with data access layer
        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        public int PersonID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        private clsPerson(int PersonID, string Name, DateTime dateTime, string Gender, 
            string Phone, string Email, string Address)
        {


            this.PersonID = PersonID;
            this.Name = Name;
            this.PhoneNumber = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;

            Mode = enMode.UpdateMode;

        }


        //default con for add
        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = "";
            this.Gender = "";
            this.Email = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.PhoneNumber = "";

            Mode = enMode.AddNew;
        }


        //start get fun from DataAccess Layer

        private bool _AddNew()
        {
            //this mehtod always check the action use bool

             this.PersonID = ClincDataAccess.Person.AddPerson(this.Name,this.DateOfBirth,this.Gender,
                   this.PhoneNumber,this.Email,this.Address);

            return (this.PersonID != -1);

        }

        private bool _Update()
        {
             return ClincDataAccess.Person.UpdatePerson(this.PersonID,this.Name,this.DateOfBirth,this.Gender,
                this.PhoneNumber,this.Email,this.Address);
        } 

        public static clsPerson Find(int PersonID)
        {
            string Name = "", Gender = "", Phone = "", Email = "", Address = "";
            DateTime dateTime = DateTime.Now;

            if (ClincDataAccess.Person.FindPerson(PersonID,ref Name, ref dateTime, ref Gender, ref Phone, ref Email, ref Address))
            {
                return new clsPerson(PersonID,  Name,  dateTime,  Gender,  Phone,  Email, Address);
            }

            return null;

        }

        public static DataTable GetAllPersons()
        {
           return  ClincDataAccess.Person.GetAllPersons(); 
        }

        public static bool Delete(int PersonID)
        {
          return  ClincDataAccess.Person.DeletePerson(PersonID);
        }

        public static bool IsExists(int ID)
        {
            return ClincDataAccess.Person.IsPersonExist(ID);
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
