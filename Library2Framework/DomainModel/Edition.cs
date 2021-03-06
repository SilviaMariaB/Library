﻿// <copyright file="Edition.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.ServiceLayer;

    public class Edition
    {
        public string Name { get; set; }

        public string PublishingHouseName { get; set; }

        public int PageNr { get; set; }

        public int PublicationYear { get; set; }

        public string BookType { get; set; }

        public int InitialStock { get; set; }

        public int CurrentStock { get; set; }

        public int BorrowedBooks { get; set; }

        public int ReadingRoomBooks { get; set; }

        public Edition()
        {
        }

        public Edition(string name, string publishingHouseName, int pageNr, string bookType, int publicationYear, int initialStock, int borrowedBooks = 0, int readingRoomBooks = 0)
        {
            this.Name = name;
            this.PublishingHouseName = publishingHouseName;
            this.PageNr = pageNr;
            this.PublicationYear = publicationYear;
            this.BookType = bookType;
            this.InitialStock = initialStock;
            this.CurrentStock = initialStock;
            this.BorrowedBooks = borrowedBooks;
            this.ReadingRoomBooks = readingRoomBooks;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "\n Book name: " + this.Name +
                "\n Publishing house name: " + Helper.FirstCharToUpper(this.PublishingHouseName) +
                "\n Number of pages: " + this.PageNr +
                "\n Publication year: " + this.PublicationYear +
                "\n Book type: " + Helper.FirstCharToUpper(this.BookType) +
                "\n Initial stock: " + this.InitialStock +
                "\n Current stock: " + this.CurrentStock +
                "\n Borrowed books: " + this.BorrowedBooks +
                "\n Readingroom books: " + this.ReadingRoomBooks;
        }
    }
}
