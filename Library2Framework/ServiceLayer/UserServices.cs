using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.ServiceLayer
{
    public class UserServices
    {
        public void AddLibrarian()
        {
            String firstName = Helper.ReadString("\nInsert first name: ");
            String lastName = Helper.ReadString("\nInsert last name: ");
            String address = Helper.ReadString("\nInsert address: ");
            String phone = Helper.ReadString("\nInsert phone number: ");
            String email = Helper.ReadString("\nInsert email:");

            User user = new User(firstName, lastName, address, phone, email, false, true);

            UserDAL.AddLibrarian(user);

            Console.WriteLine("\n Operation completed succesfully!");

        }
        public void AddReader()
        {
            String firstName = Helper.ReadString("\nInsert first name: ");
            String lastName = Helper.ReadString("\nInsert last name: ");
            String address = Helper.ReadString("\nInsert address: ");
            String phone = Helper.ReadString("\nInsert phone number: ");
            String email = Helper.ReadString("\nInsert email:");

            User user = new User(firstName, lastName, address, phone, email, false, true);

            UserDAL.AddReader(user);

            Console.WriteLine("\n Operation completed succesfully!");

        }
    }
}
