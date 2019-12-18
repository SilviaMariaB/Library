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

        public User(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public User(String FirstName, String LastName, String Address, String PhoneNumber, String Email, Boolean Reader, Boolean Librarian, int ID = 0)
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
            return  "\n First name: " + this.FirstName + 
                "\n Last name: " + this.LastName +
                "\n Address: " + this.Address + 
                "\n Phone number: " + this.PhoneNumber + 
                "\n Email: " + this.Email + 
                "\n Reader: " + this.Reader + 
                "\n Librarian: " + this.Librarian ;
        }

    }
}
