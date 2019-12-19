﻿namespace Library2Framework.DomainModel
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

        public EditionAuthor(int EditionId, int AuthorId)
        {
            this.EditionId = EditionId;
            this.AuthorId = AuthorId;
        }

        public override string ToString()
        {
            return "( Edition id: " + this.EditionId + " author id: " + this.AuthorId + ")";
        }
    }
}
