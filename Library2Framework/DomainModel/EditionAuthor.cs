// <copyright file="EditionAuthor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EditionAuthor
    {
        public int EditionId { get; set; }

        public int AuthorId { get; set; }

        public EditionAuthor(int editionId, int authorId)
        {
            this.EditionId = editionId;
            this.AuthorId = authorId;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "( Edition id: " + this.EditionId + " author id: " + this.AuthorId + ")";
        }
    }
}
