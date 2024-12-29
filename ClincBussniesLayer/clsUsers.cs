using ClincDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static ClincBussniesLayer.clsUsers;

namespace ClincBussniesLayer
{
    public class clsUsers
    {
        public enum enPermissions : int
        {
            eAll = -1, pManageDoctor = 1, pManagePateint = 2, pManageAppoinment = 4,
            pManagePayment = 8, pManageUser = 16
        };

        private enPermissions _permissions;

        private enum enMode { EmptyMode = 0, UpdateMode = 1, AddNew = 2 };

        private enMode Mode = enMode.UpdateMode;

        public int User_id { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }


        private clsUsers(int User_id1 , int PersonID1, string Username1, string Password1,
            int Permission1)
        {


            this.User_id = User_id1;
            this.PersonID = PersonID1;
            this.Username = Username1;
            this.Password = Password1;
            this.Permission = Permission1;
         //   _permissions =(enPermissions)Permission1;

            Mode = enMode.UpdateMode;

        }


        public clsUsers()
        {
            this.User_id = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.Permission = 0;

            Mode = enMode.AddNew;
        }

        //start fun in system
        private bool _AddNew()
        {
            //this mehtod always check the action use bool

            this.User_id = ClincDataAccess.Users.Insert(this.PersonID, this.Username, this.Password,
                  this.Permission);

            return (this.User_id != -1);

        }

        private bool _Update()
        {
            return ClincDataAccess.Users.Update(this.User_id, this.PersonID, this.Username, this.Password,
               this.Permission);
        }

        public static clsUsers Find(int UserID)
        {
            string userName = "", Password = ""; int Permmsin = 0, personid = -1 ;
         

            if (ClincDataAccess.Users.Find(UserID, ref personid, ref userName, ref Password, ref Permmsin))
            {
                return new clsUsers(UserID,  personid,  userName,  Password,  Permmsin);
            }

            return null;

        }

        public static DataTable GetAllUsers()
        {
            return ClincDataAccess.Users.GetAllUsers();
        }

        public static bool Delete(int UserID)
        {
            return ClincDataAccess.Users.Delete(UserID);
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

        public static clsUsers FindUserLogin(string userName,string password)
        {
               int Permmsin = 0, personid = -1 , id = -1;

            if (ClincDataAccess.Users.FindLoginUser(ref id, ref personid, userName, password, ref Permmsin))
            {
                return new clsUsers(id, personid, userName, password, Permmsin);
            }

            return null;
        }


        public bool CheckPermissions(enPermissions permissions)
        {
            if ((enPermissions)this.Permission == enPermissions.eAll)
                return true;

            return ((enPermissions)this.Permission & permissions) == permissions;
        }



    }
}
