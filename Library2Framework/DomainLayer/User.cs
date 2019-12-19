using Library2Framework.ServiceLayer;
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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Boolean Reader { get; set; }

        public Boolean Librarian { get; set; }

        public User(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public User(string FirstName, string LastName, string Address, string PhoneNumber, string Email, Boolean Reader, Boolean Librarian, int ID = 0)
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
            return  "\n First name: " + Helper.FirstCharToUpper(this.FirstName) + 
                "\n Last name: " + Helper.FirstCharToUpper(this.LastName) +
                "\n Address: " + this.Address + 
                "\n Phone number: " + this.PhoneNumber + 
                "\n Email: " + this.Email + 
                "\n Reader: " + this.Reader + 
                "\n Librarian: " + this.Librarian ;
        }
    }
}
