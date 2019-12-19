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
                string domainName = Helper.ReadString("Introduce the new domain: ");

                if (DomainDAL.CheckDomain(domainName))
                {
                    int size = BookDAL.GetDomainsForBook(bookName).Count;
                    int DOM = Helper.GetConfigData()["DOM"];
                    if (size < DOM)
                    {
                        BookDAL.AddDomainForBook(domainName, bookName);
                        Console.WriteLine("\n Operation completed succesfully!");
                    }
                    else
                    {
                        Helper.DisplayError("\nA book can belong to " + DOM + " domains. (DOM = " + DOM +" )");
                    }
                }
                else
                {
                    Helper.DisplayError("\n Domain doesn't exist!");
                }
            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");
            }
        }
    }
}
