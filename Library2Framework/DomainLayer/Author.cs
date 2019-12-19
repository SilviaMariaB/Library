﻿using Library2Framework.ServiceLayer;
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

        public string AuthorName { get; set; }

        public Author()
        {

        }
       
        public Author(string AuthorName, int ID=0)
        {
            this.ID = ID;
            this.AuthorName = AuthorName;

        }

        public override string ToString()
        {
            return "\n Author name: " + Helper.FirstCharToUpper(this.AuthorName) ;
        }
    }
}
