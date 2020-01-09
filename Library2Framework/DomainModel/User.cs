// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.ServiceLayer;

    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Reader { get; set; }

        public bool Librarian { get; set; }

        public User(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public User(string firstName, string lastName, string address, string phoneNumber, string email, int iD = 0)
        {
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public User()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "\n First name: " + Helper.FirstCharToUpper(this.FirstName) +
                "\n Last name: " + Helper.FirstCharToUpper(this.LastName) +
                "\n Address: " + this.Address +
                "\n Phone number: " + this.PhoneNumber +
                "\n Email: " + this.Email +
                "\n Reader: " + this.Reader +
                "\n Librarian: " + this.Librarian;
        }
    }
}
