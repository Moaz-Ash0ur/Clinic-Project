using ClincBussniesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClincConsolTest
{
    internal class Program
    {

        //test find 
      
        public static void testAdd()
        {
            clsUsers p = new clsUsers();

            p.PersonID = 133;
            p.Username = "khalil_KH";
            p.Password = "khalil12";
            p.Permission = -1;


            if (p.Save())
            {
                Console.WriteLine("User Added Succedfully Wiht ID: " + p.User_id);
            }
            else
            {
                Console.WriteLine("User Faild Added :( ");

            }
        }

      
    
        static void Main(string[] args)
        {
            testAdd();
            Console.ReadKey();

        }
    }
}
