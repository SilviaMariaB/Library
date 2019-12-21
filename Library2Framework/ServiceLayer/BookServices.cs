// <copyright file="BookServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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

            while (!BookDAL.CheckBook(bookName))
            {
                Helper.DisplayError("\n Wrong book name!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                bookName = Helper.ReadString("Reintroduce the name of the book:");
            }

            authors = BookDAL.GetDomainsForBook(bookName);

            return authors;
        }

        public void AddDomainForBook()
        {
            string bookName = Helper.ReadString("Introduce the name of the book: ");

            while (!BookDAL.CheckBook(bookName))
            {
                Helper.DisplayError("\n Wrong book name!");
                Console.ForegroundColor = ConsoleColor.Red;
                bookName = Helper.ReadString("Reintroduce the name of the book: ");
            }

            string newDomainName = Helper.ReadString("Introduce the new domain: ");

            // aici verific ca noul domeniu sa nu contina deja cartea
            bool ok = true;
            foreach (Domain domain in BookDAL.GetDomainsForBook(bookName))
            {
                if (newDomainName.Equals(domain.DomainName))
                {
                    ok = false;
                    break;
                }
            }

            while (!DomainDAL.CheckDomain(newDomainName) || !ok || !ValidDomain(bookName, newDomainName))
            {
                if (!ValidDomain(bookName, newDomainName))
                {
                    Helper.DisplayError("\n The new domain is an ascendent of one of the existing domains of the book!");
                }
                else
                {
                    Helper.DisplayError("\n Invalid domain!");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                newDomainName = Helper.ReadString("Reintroduce the new domain: ");

                ok = true;
                foreach (Domain domain in BookDAL.GetDomainsForBook(bookName))
                {
                    if (newDomainName.Equals(domain.DomainName))
                    {
                        ok = false;
                        break;
                    }
                }
            }

            int size = BookDAL.GetDomainsForBook(bookName).Count;
            int DOM = Helper.GetConfigData()["DOM"];
            if (size < DOM)
            {
                BookDAL.AddDomainForBook(newDomainName, bookName);
                Console.WriteLine("\n Operation completed succesfully!");
            }
            else
            {
                Helper.DisplayError("\nA book can belong to " + DOM + " domains. (DOM = " + DOM + " )");
            }
        }

        // functia verifica daca noul domeniu este sau nu intr-o relatie stramos-descendent
        // cu domeniile actuale ale cartii
        private bool ValidDomain(string bookName, string newDomainName)
        {
            List<Domain> curentDomains = BookDAL.GetDomainsForBook(bookName);

            HashSet<string> family = new HashSet<string>();
            foreach (Domain domain in curentDomains)
            {
                HashSet<string> ascendants = GetAscendansForDomain(domain.DomainName);
                foreach (string ascendant in ascendants)
                {
                    family.Add(ascendant);
                }
            }

            if (family.Contains(newDomainName))
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

            while (parent != null)
            {
                ascendants.Add(parent);
                parent = DomainDAL.GetParentForDomain(parent);
            }

            return ascendants;
        }
    }
}
