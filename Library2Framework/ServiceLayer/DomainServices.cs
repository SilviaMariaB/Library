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
        public void AddSubdomain()
        {
            string domainName = Helper.ReadString("\n Insert subdomain name: ");

            if (DomainDAL.CheckDomain(domainName))
            {
                Helper.DisplayError("\n " + Helper.FirstCharToUpper(domainName) + " already exist!");
            }
            else
            {
                string parentName = Helper.ReadString("\n Insert domain(parent) name: ");

                if (DomainDAL.CheckDomain(parentName))
                {
                    Domain domain = new Domain(domainName, parentName);
                    DomainDAL.AddSubdomain(domain);
                    Console.WriteLine("\n Operation completed succesfully!");
                }
                else
                {
                    Helper.DisplayError("\n Wrong parent name!");
                }

                
            }



            

            
        }

        public void AddDomain()
        {
            string domainName = Helper.ReadString("\n Insert domain name: ");

            

            if (DomainDAL.CheckDomain(domainName))
            {
                Helper.DisplayError("\n Domain already exist!");
            }
            else
            {
                Domain domain = new Domain(domainName);
                DomainDAL.AddDomain(domain);
                Console.WriteLine("\n Operation completed succesfully!");
            }

           
            
        }
    }
}
