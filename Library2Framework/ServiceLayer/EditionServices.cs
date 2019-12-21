// <copyright file="EditionServices.cs" company="PlaceholderCompany">
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
    using Library2Framework.Utils;
    using static Library2Framework.DataMapper.EditionDAL;

    public class EditionServices
    {
        public List<Author> GetAuthorsForEdition()
        {
            string bookName = Helper.ReadString("Introduce the name of the book:");

            while (!BookDAL.CheckBook(bookName))
            {
                Helper.DisplayError("\n Wrong book name!");
                Console.ForegroundColor = ConsoleColor.Red;
                bookName = Helper.ReadString("Reintroduce the name of the book:");
            }

            List<Author> authors = null;

            int PublicationYear = Helper.ReadYear("Introduce the year of publishing:");
            string PublishingHouseName = Helper.ReadString("Introduce publishing house name:");

            while (!EditionDAL.CheckEdition(bookName, PublishingHouseName, PublicationYear))
            {
                Helper.DisplayError("\n Edition doesn't exist!");
                Console.ForegroundColor = ConsoleColor.Red;
                PublicationYear = Helper.ReadYear("Reintroduce the year of publishing:");
                PublishingHouseName = Helper.ReadString("Reintroduce publishing house name:");
            }

            authors = AuthorDAL.GetAuthorsForBook(bookName, PublicationYear, PublishingHouseName);
            return authors;
        }

        public void AddEdition()
        {
            string bookName = Helper.ReadString("\nInsert book name: ");
            string domain;

            if (BookDAL.CheckBook(bookName))
            {
                domain = string.Empty;
                ContinueAddEdition(bookName, domain);
            }
            else
            {
                domain = Helper.ReadString("\nIntroduce domain name: ");
                while (!DomainDAL.CheckDomain(domain))
                {
                    Helper.DisplayError("\n Inserted domain doesn't exist!");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    domain = Helper.ReadString("\nReintroduce domain name: ");
                }

                ContinueAddEdition(bookName, domain);
            }
        }

        public void AddAuthorForEdition()
        {
            string bookName = Helper.ReadString("Introduce the name of the book: ");

            while (!BookDAL.CheckBook(bookName))
            {
                Helper.DisplayError("\n Wrong book name!");
                Console.ForegroundColor = ConsoleColor.Red;
                bookName = Helper.ReadString("\nReintroduce the name of the book: ");
            }

            int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");
            string publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

            while (!EditionDAL.CheckEdition(bookName, publishingHouseName, publicationYear))
            {
                Helper.DisplayError("\n Edition doesn't exist!");
                Console.ForegroundColor = ConsoleColor.Red;
                publicationYear = Helper.ReadYear("Introduce the year of publishing: ");
                publishingHouseName = Helper.ReadString("Introduce publishing house name: ");
            }

            string authorName = Helper.ReadString("Introduce the name of the author: ");

            Author author = new Author(authorName);

            Edition edition = new Edition()
            {
                PublicationYear = publicationYear,
                PublishingHouseName = publishingHouseName,
                Name = bookName,
            };
            EditionDAL.AddAuthorForEdition(author, edition);
            Console.WriteLine("\n Operation completed succesfully!");
        }

        public void BorrowEdition()
        {
            string email = Helper.ReadString("Introduce user's email: ");

            while (!UserDAL.CheckUser(email))
            {
                Helper.DisplayError("\n User not found!");
                Console.ForegroundColor = ConsoleColor.Red;
                email = Helper.ReadString("\nReintroduce email: ");
            }

            string bookName = Helper.ReadString("Introduce the name of the book: ");

            while (!BookDAL.CheckBook(bookName))
            {
                Helper.DisplayError("\n Book not found!");
                Console.ForegroundColor = ConsoleColor.Red;
                bookName = Helper.ReadString("Introduce the name of the book: ");
            }

            int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");
            string publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

            while (!EditionDAL.CheckEdition(bookName, publishingHouseName, publicationYear))
            {
                Helper.DisplayError("\n Edition not found!");
                Console.ForegroundColor = ConsoleColor.Red;
                publicationYear = Helper.ReadYear("Introduce the year of publishing: ");
                publishingHouseName = Helper.ReadString("Introduce publishing house name: ");
            }

            string authorName = Helper.ReadString("Introduce the name of the author: ");
            Author author = new Author(authorName);

            while (!AuthorDAL.CheckAuthor(author))
            {
                Helper.DisplayError("\n Wrong author!");
                Console.ForegroundColor = ConsoleColor.Red;
                authorName = Helper.ReadString("Introduce the name of the author: ");
                author = new Author(authorName);
            }

            if (ValidBorrow(email, bookName, publishingHouseName, publicationYear))
            {
                Edition edition = new Edition()
                {
                    PublicationYear = publicationYear,
                    PublishingHouseName = publishingHouseName,
                    Name = bookName,
                };

                int daysLeft = Helper.ReadInteger("Introduce the number of days of the borrow: ");

                DateTime endDate = DateTime.Now.AddDays(daysLeft);

                EditionDAL.BorrowEdition(email, edition, author, endDate);
                Console.WriteLine("\n Operation completed succesfully!");
            }
        }

        private bool ValidBorrow(string email, string bookName, string publishingHouse, int publicationYear)
        {
            Inventory inventory = EditionDAL.GetEditionInventory(bookName, publishingHouse, publicationYear);
            if (inventory.CurrentStock <= 0.1 * inventory.InitialStock)
            {
                Helper.DisplayError("\n There are no books available for borrow.");
                return false;
            }

            int NMC = Helper.GetConfigData()["NMC"];
            int PER = Helper.GetConfigData()["PER"];
            List<Borrow> borrows = BorrowDAL.GetBorrowsForUser(email);

            borrows.RemoveAll(d => d.EndDate < DateTime.Today);

            if (borrows.Count >= NMC)
            {
                Borrow firstBorrow = borrows[borrows.Count - NMC];
                Borrow lastBorrow = borrows[borrows.Count - 1];

                if (DateTime.Today >= lastBorrow.StartDate && DateTime.Today < firstBorrow.StartDate.AddDays(PER * 7))
                {
                    Helper.DisplayError("\n You can't borrow another book. Come again on " + firstBorrow.StartDate.AddDays(PER * 7));
                    return false;
                }
            }

            return true;
        }

        private void ContinueAddEdition(string bookName, string domain)
        {
            string publishingHouse = Helper.ReadString("\nInsert publishing house: ");
            int publicationYear = Helper.ReadYear("\nInsert publication year: ");

            while (EditionDAL.CheckEdition(bookName, publishingHouse, publicationYear))
            {
                Helper.DisplayError("\n Edition already exist!");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                publishingHouse = Helper.ReadString("\nReintroduce publishing house: ");
                publicationYear = Helper.ReadYear("\nReintroduce publication year: ");
            }

            string authorName = Helper.ReadString("\nInsert author name: ");
            int pageNr = Helper.ReadInteger("\nInsert page number:");
            string bookType = Helper.ReadString("\nInsert book type: ");
            int initialStock = Helper.ReadInteger("\nInsert initial stock:");

            Edition edition = new Edition(bookName, publishingHouse, pageNr, bookType, publicationYear, initialStock);
            Author author = new Author(authorName);

            EditionDAL.AddEdition(edition, author, domain);

            Console.WriteLine("\n Operation completed succesfully!");
        }
    }
}
