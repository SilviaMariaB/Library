// <copyright file="UserServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;

    public class UserServices
    {
        public void AddLibrarian()
        {
            string firstName = Helper.ReadString("\nInsert first name: ");
            string lastName = Helper.ReadString("\nInsert last name: ");
            string address = Helper.ReadString("\nInsert address: ");
            string phone = Helper.ReadString("\nInsert phone number: ");
            string email = Helper.ReadString("\nInsert email:");

            while (UserDAL.CheckUser(email))
            {
                Helper.DisplayError("Email address already used!");
                Console.ForegroundColor = ConsoleColor.Blue;
                email = Helper.ReadString("\nReintroduce email:");
            }

            User user = new User(firstName, lastName, address, phone, email);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n Do you want to be a reader too?\n 1. yes\n 2. no");
            bool ok = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int choice = Helper.ReadInteger("\n Insert option: ");
                switch (choice)
                {
                    case 1:
                        UserDAL.AddLibrarian(user, true);
                        ok = false;
                        break;
                    case 2:
                        UserDAL.AddLibrarian(user, false);
                        ok = false;
                        break;
                    default:
                        ok = true;
                        break;
                }
            }
            while (ok);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Operation completed succesfully!");
        }

        public void AddReader()
        {
            string firstName = Helper.ReadString("\nInsert first name: ");
            string lastName = Helper.ReadString("\nInsert last name: ");
            string address = Helper.ReadString("\nInsert address: ");
            string phone = Helper.ReadString("\nInsert phone number: ");
            string email = Helper.ReadString("\nInsert email:");

            while (UserDAL.CheckUser(email))
            {
                Helper.DisplayError("Email address already used!");
                Console.ForegroundColor = ConsoleColor.Blue;
                email = Helper.ReadString("\nReintroduce email:");
            }

            User user = new User(firstName, lastName, address, phone, email);
            UserDAL.AddReader(user);
            Console.WriteLine("\n Operation completed succesfully!");
        }

        public List<User> GetLibrarians()
        {
            return UserDAL.GetLibrarians();
        }

        public List<User> GetReaders()
        {
            return UserDAL.GetReaders();
        }
    }
}
