using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.ServiceLayer
{
    class DomainServices
    {
        public void AddDomain()
        {
            string domainName = Helper.ReadString("\n Insert domain name: ");
            string parentName = Helper.ReadString("\n Insert parent name: ");


            Domain domain = new Domain(domainName, parentName);

            if(DomainDAL.CheckDomain(parentName))
            {
                DomainDAL.AddDomain(domain);
                Console.WriteLine("\n Operation completed succesfully!");
            }
            else
            {
                Helper.DisplayError("\n Wrong parent name!");
            }


        }
    }
}
