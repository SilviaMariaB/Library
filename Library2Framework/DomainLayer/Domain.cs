using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
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
        public Domain()
        {

        }
        public override string ToString()
        {
            return "\n Domain name: " + this.DomainName + 
                "\n Parent name: " + this.ParentName ;
        }
    }
}
