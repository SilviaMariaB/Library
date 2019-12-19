namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataLayer;
    using Library2Framework.DomainLayer;

    public class UserServices
    {
        public void AddLibrarian()
        {
            string firstName = Helper.ReadString("\nInsert first name: ");
            string lastName = Helper.ReadString("\nInsert last name: ");
            string address = Helper.ReadString("\nInsert address: ");
            string phone = Helper.ReadString("\nInsert phone number: ");
            string email = Helper.ReadString("\nInsert email:");

            User user = new User(firstName, lastName, address, phone, email, false, true);

            UserDAL.AddLibrarian(user);

            Console.WriteLine("\n Operation completed succesfully!");

        }

        public void AddReader()
        {
            string firstName = Helper.ReadString("\nInsert first name: ");
            string lastName = Helper.ReadString("\nInsert last name: ");
            string address = Helper.ReadString("\nInsert address: ");
            string phone = Helper.ReadString("\nInsert phone number: ");
            string email = Helper.ReadString("\nInsert email:");

            User user = new User(firstName, lastName, address, phone, email, false, true);

            UserDAL.AddReader(user);

            Console.WriteLine("\n Operation completed succesfully!");

        }
    }
}
