namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;

    class DomainServices
    {
        public void AddSubdomain()
        {
            string domainName = Helper.ReadString("\n Insert subdomain name: ");

            while (DomainDAL.CheckDomain(domainName))
            {
                Helper.DisplayError("\n " + Helper.FirstCharToUpper(domainName) + " already exist!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                domainName = Helper.ReadString("\n Reintroduce subdomain name: ");
            }

            string parentName = Helper.ReadString("\n Insert domain(parent) name: ");
            while (!DomainDAL.CheckDomain(parentName))
            {
                Helper.DisplayError("\n Wrong parent name!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                parentName = Helper.ReadString("\n Reintroduce domain(parent) name: ");
            }
            Domain domain = new Domain(domainName, parentName);
            DomainDAL.AddSubdomain(domain);
            Console.WriteLine("\n Operation completed succesfully!");

        }
        public void AddDomain()
        {
            string domainName = Helper.ReadString("\n Insert domain name: ");
            while (DomainDAL.CheckDomain(domainName))
            {
                Helper.DisplayError("\n Domain already exist!");
                domainName = Helper.ReadString("\n Reintroduce domain name: ");
            }

            Domain domain = new Domain(domainName);
            DomainDAL.AddDomain(domain);
            Console.WriteLine("\n Operation completed succesfully!");
        }
    }
}
