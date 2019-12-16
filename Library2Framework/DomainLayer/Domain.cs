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

        public Domain ParentId { get; set; }

        public Domain(int ID, String DomainName, Domain ParentId)
        {
            this.ID = ID;
            this.DomainName = DomainName;
            this.ParentId = ParentId;
            
        }

        public override string ToString()
        {
            return "( ID: " + this.ID + " domain name: " + this.DomainName + " parent id: " + this.ParentId + ")";
        }
    }
}
