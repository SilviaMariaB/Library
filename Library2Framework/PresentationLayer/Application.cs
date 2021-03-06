﻿// <copyright file="Application.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;
    using Library2Framework.ServiceLayer;

    public class Application
    {
        private const int Exit = 17;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Application));

        private EditionServices _editionServices;
        private UserServices _userServices;
        private DomainServices _domainServices;
        private BookServices _bookServices;
        private BorrowServices _borrowServices;

        public Application()
        {
            _editionServices = new EditionServices();
            _userServices = new UserServices();
            _domainServices = new DomainServices();
            _bookServices = new BookServices();
            _borrowServices = new BorrowServices();
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                int choice = ReadChoice();

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        _userServices.AddReader();
                        ScreenPause();
                        log.Info("A new reader has been added.");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        _userServices.AddLibrarian();
                        ScreenPause();
                        log.Info("A new librarian has been added.");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        _domainServices.AddDomain();
                        ScreenPause();
                        log.Info("A new domain has been added.");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        _domainServices.AddSubdomain();
                        ScreenPause();
                        log.Info("A new subdomain has been added.");
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        _editionServices.AddEdition();
                        ScreenPause();
                        log.Info("A new edition has been added.");
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        _editionServices.AddAuthorForEdition();
                        ScreenPause();
                        log.Info("A new author has been added for an edition.");
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Red;
                        _bookServices.AddDomainForBook();
                        ScreenPause();
                        log.Info("A book has been added in a new domain.");
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Red;
                        _editionServices.BorrowEdition();
                        ScreenPause();
                        log.Info("An edition has been borrowed.");
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        List<Edition> books = _editionServices.GetEditionsAlphabetical();
                        Display(books);
                        ScreenPause();
                        log.Info("All editions have been displayed alphabeticaly.");
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        List<Edition> borrowedBooks = _editionServices.GetBorrowedEditionsAlphabetical();
                        Display(borrowedBooks);
                        ScreenPause();
                        log.Info("All borrowed editions have been displayed alphabeticaly.");
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        List<Author> authors = _editionServices.GetAuthorsForEdition();
                        if (authors != null)
                        {
                            Display(authors);
                        }

                        ScreenPause();
                        log.Info("All authors for an edition have been displayed.");
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        List<User> librarians = _userServices.GetLibrarians();
                        Display(librarians);
                        ScreenPause();
                        log.Info("All librarians have been displayed.");
                        break;
                    case 13:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        List<User> readers = _userServices.GetReaders();
                        Display(readers);
                        ScreenPause();
                        log.Info("All readers have been displayed.");
                        break;
                    case 14:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        List<Domain> domains = _domainServices.GetDomains();
                        Display(domains);
                        ScreenPause();
                        log.Info("All domains have been displayed.");
                        break;
                    case 15:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        List<Domain> domainsForBook = _bookServices.GetDomainsForBook();
                        if (domainsForBook != null)
                        {
                            Display(domainsForBook);
                        }

                        log.Info("All domains for one book have been displayed.");
                        ScreenPause();
                        break;
                    case 16:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        List<Borrow> borrows = _borrowServices.GetBorrowsForUser();
                        if (borrows != null)
                        {
                            Display(borrows);
                        }

                        log.Info("All borrowed edition for one user have been displayed.");
                        ScreenPause();
                        break;
                    case Exit:
                        Console.WriteLine("\n Bye-bye! :)");
                        return;
                }
            }
        }

        private void ScreenPause()
        {
            Console.ResetColor();
            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(1) Add new reader");
            Console.WriteLine("(2) Add new librarian");
            Console.WriteLine("(3) Add new domain");
            Console.WriteLine("(4) Add new subdomain");
            Console.WriteLine("(5) Add new edition");
            Console.WriteLine("(6) Add new author for one edition");
            Console.WriteLine("(7) Add new domain for one book");
            Console.WriteLine("(8) Borrow edition");
            Console.WriteLine("(9) List all books alphabetically");
            Console.WriteLine("(10) List all borrowed books alphabetically");
            Console.WriteLine("(11) List all authors for one book");
            Console.WriteLine("(12) List librarians");
            Console.WriteLine("(13) List readers");
            Console.WriteLine("(14) List domains");
            Console.WriteLine("(15) List domains for one book");
            Console.WriteLine("(16) List borrows for one user");
            Console.WriteLine("(17) Exit application");
            Console.ResetColor();
        }

        private int ReadChoice()
        {
            bool ok = false;
            int choice = 0;
            while (ok == false)
            {
                Console.Write("\nInsert option:");
                string str = Console.ReadLine();
                ok = int.TryParse(str, out choice);
                if (choice < 0 || choice > Exit)
                {
                    ok = false;
                }
            }

            return choice;
        }

        private void Display<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nThere are no items!");
            }
            else
            {
                foreach (T obj in list)
                {
                    Console.WriteLine("\n" + (list.IndexOf(obj) + 1) + ". " + obj);
                }
            }
        }
    }
}
