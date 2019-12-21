// <copyright file="Author.cs" company="PlaceholderCompany">
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

    public class Author
    {
        public int ID { get; set; }

        public string AuthorName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
        }

        public Author(string authorName, int ID = 0)
        {
            this.ID = ID;
            this.AuthorName = authorName;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "\n Author name: " + Helper.FirstCharToUpper(this.AuthorName);
        }
    }
}
