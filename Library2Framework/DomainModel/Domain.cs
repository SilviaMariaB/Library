﻿namespace Library2Framework.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.ServiceLayer;

    public class Domain
    {
        public int ID { get; set; }

        public string DomainName { get; set; }

        public string ParentName { get; set; }

        public Domain(string DomainName, string ParentName, int ID =0)
        {
            this.ID = ID;
            this.DomainName = DomainName;
            this.ParentName = ParentName;           
        }

        public Domain(string DomainName, int ID = 0)
        {
            this.ID = ID;
            this.DomainName = DomainName;
        }
        public Domain()
        {

        }
        public override string ToString()
        {
            if(this.ParentName != null)
            {
                return "\n Domain name: " + Helper.FirstCharToUpper(this.DomainName) +
                 "\n Parent name: " + Helper.FirstCharToUpper(this.ParentName);
            }
            else
            {
                return "\n Domain name: " + Helper.FirstCharToUpper(this.DomainName);
            }
        }
    }
}
