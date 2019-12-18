using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
    public class Author
    {
        public int ID { get; set; }

        public String AuthorName { get; set; }

        public Author()
        {

        }
       
        public Author(int ID, String AuthorName)
        {
            this.ID = ID;
            this.AuthorName = AuthorName;

        }

        public override string ToString()
        {
            return "( ID: " + this.ID + " author name: " + this.AuthorName + ")";
        }
    }
}
