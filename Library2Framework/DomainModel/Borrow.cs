// <copyright file="Borrow.cs" company="Transilvania University of Brasov">
// Copyright (c) Brassoi Silvia Maria. All rights reserved.
// </copyright>

namespace Library2Framework.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.ServiceLayer;

    public class Borrow
    {
        public string BookName { get; set; }

        public string PublishingHouseName { get; set; }

        public int PublicationYear { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Period { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Borrow"/> class.
        /// </summary>
        /// <param name="bookName">numele cartii.</param>
        /// <param name="publishingHouseName">numele editurii care a publicat cartea.</param>
        /// <param name="publicationYear">anul publicarii.</param>
        /// <param name="start">data de inceput a imprimutului.</param>
        /// <param name="end">data de final a imprumutului.</param>
        /// <param name="period">perioada imprumutului.</param>
        ///
        public Borrow(string bookName, string publishingHouseName, int publicationYear, DateTime start, DateTime end, int period)
        {
            this.BookName = bookName;
            this.PublishingHouseName = publishingHouseName;
            this.PublicationYear = publicationYear;
            this.StartDate = start;
            this.EndDate = end;
            this.Period = period;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Borrow"/> class.
        /// </summary>
        public Borrow()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "\n Book name: " + Helper.FirstCharToUpper(BookName) +
                "\n Publishing house name: " + Helper.FirstCharToUpper(this.PublishingHouseName) +
                "\n Publication year: " + this.PublicationYear +
                "\n Start date: " + this.StartDate.ToString("dd-MM-yyy") +
                "\n End date: " + this.EndDate.ToString("dd-MM-yyy") +
                "\n Period of the borrow (days): " + this.Period;
        }
    }
}
