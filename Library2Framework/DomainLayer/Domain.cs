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

        public String DomainName { get; set; }

        public String ParentName { get; set; }

        public Domain(String DomainName, String ParentName, int ID =0)
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
