using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
    public class User
    {
        public int ID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Address { get; set; }

        public String PhoneNumber { get; set; }

        public String Email { get; set; }

        public Boolean Reader { get; set; }

        public Boolean Librarian { get; set; }

        public User(int ID, String FirstName, String LastName, String Address, String PhoneNumber, String Email, Boolean Reader, Boolean Librarian)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Reader = Reader;
            this.Librarian = Librarian;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return "( ID: " + this.ID + ", first name: " + this.FirstName + ", last name: " + this.LastName + ", address: " + this.Address + ", phone number: " + this.PhoneNumber + ", email: " + this.Email + ", reader: " + this.Reader + ", librarian: " + this.Librarian + ")";
        }

    }
}
