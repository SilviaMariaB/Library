using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
    public class Edition
    {
        public String Name { get; set; }

        public String PublishingHouseName { get; set; }

        public int PageNr { get; set; }

        public int PublicationYear { get; set; }

        public String Domain { get; set; }

        public int InitialStock { get; set; }

        public int BorrowedBooks { get; set; }

        public int ReadingRoomBooks { get; set; }

        public Edition()
        {

        }

        public Edition(String Name, String PublishingHouseName, int PageNr, int PublicationYear, String Domain, int InitialStock, int BorrowedBooks, int ReadingRoomBooks)
        {
            this.Name = Name;
            this.PublishingHouseName = PublishingHouseName;
            this.PageNr = PageNr;
            this.PublicationYear = PublicationYear;
            this.Domain = Domain;
            this.InitialStock = InitialStock;
            this.BorrowedBooks = BorrowedBooks;
            this.ReadingRoomBooks = ReadingRoomBooks;
        }

        public override string ToString()
        {
            return "\n Name: " + Name +
                "\n Publishing house name: " + this.PublishingHouseName +
                "\n Number of pages: " + this.PageNr +
                "\n Publication year: " + this.PublicationYear +
                "\n Domain: " + Domain +
                "\n Initial stock: " + this.InitialStock +
                "\n Borrowed books: " + this.BorrowedBooks +
                "\n Readingroom books: " + this.ReadingRoomBooks ;
        }
    }
}
