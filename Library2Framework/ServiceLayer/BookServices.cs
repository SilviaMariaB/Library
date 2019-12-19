namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;

    public class BookServices
    {
        public List<Domain> GetDomainsForBook()
        {
            string bookName = Helper.ReadString("Introduce the name of the book:");

            List<Domain> authors = null;

            if (BookDAL.CheckBook(bookName))
            {
                authors = BookDAL.GetDomainsForBook(bookName);               
            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");
            }
            return authors;
        }

        public void AddDomainForBook()
        {
            string bookName = Helper.ReadString("Introduce the name of the book: ");

            if (BookDAL.CheckBook(bookName))
            {
                string newDomainName = Helper.ReadString("Introduce the new domain: ");

                //aici verific ca noul domeniu sa nu contina deja cartea
                bool ok = true;
                foreach(Domain domain in BookDAL.GetDomainsForBook(bookName))
                {
                    if(newDomainName.Equals(domain.DomainName))
                    {
                        ok = false;
                        break;
                    }
                }

                if (DomainDAL.CheckDomain(newDomainName) && ok)
                {
                    int size = BookDAL.GetDomainsForBook(bookName).Count;
                    int DOM = Helper.GetConfigData()["DOM"];
                    if (size < DOM)
                    {

                        if(validDomain(bookName,newDomainName))
                        {
                            BookDAL.AddDomainForBook(newDomainName, bookName);
                            Console.WriteLine("\n Operation completed succesfully!");
                        }
                        else
                        {
                            Helper.DisplayError("\n The new domain is an ascendent of one of the existing domains of the book!");
                        }      
                    }
                    else
                    {
                        Helper.DisplayError("\nA book can belong to " + DOM + " domains. (DOM = " + DOM +" )");
                    }
                }
                else
                {
                    Helper.DisplayError("\n Invalid domain!");
                }
            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");
            }
        }

        //functia verifica daca noul domeniu este sau nu intr-o relatie stramos-descendent
        //cu domeniile actuale ale cartii
        private bool validDomain(string bookName, string newDomainName)
        {
            List<Domain> curentDomains = BookDAL.GetDomainsForBook(bookName);

            HashSet<string> family = new HashSet<string>();
            foreach (Domain domain in curentDomains)
            {
                HashSet<string> ascendants = GetAscendansForDomain(domain.DomainName);
                foreach(string ascendant in ascendants)
                {
                    family.Add(ascendant);
                }
            }
            
            if(family.Contains(newDomainName))
            {
                return false;
            }

            return true;
        }

        private HashSet<string> GetAscendansForDomain(string domainName)
        {
            HashSet<string> ascendants = new HashSet<string>();

            string current = domainName;
            string parent = DomainDAL.GetParentForDomain(domainName);

            while(parent!=null)
            {
                ascendants.Add(parent);
                parent = DomainDAL.GetParentForDomain(parent);
            }

            return ascendants;
        }
        
    }
}
