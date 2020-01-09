// <copyright file="Domain.cs" company="PlaceholderCompany">
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

    public class Domain
    {
        public int ID { get; set; }

        public string DomainName { get; set; }

        public string ParentName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        /// <param name="DomainName">Numele domeniului.</param>
        /// <param name="ParentName">Numele parintelui.</param>
        /// <param name="ID">Id ul.</param>
        public Domain(string DomainName, string ParentName, int ID = 0)
        {
            this.ID = ID;
            this.DomainName = DomainName;
            this.ParentName = ParentName;
        }

        public Domain(string DomainName, int ID = 0)
        {
            this.ID = ID;
            this.DomainName = DomainName;
        }

        public Domain()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (ParentName != null)
            {
                return "\n Domain name: " + Helper.FirstCharToUpper(this.DomainName) +
                 "\n Parent name: " + Helper.FirstCharToUpper(this.ParentName);
            }
            else
            {
                return "\n Domain name: " + Helper.FirstCharToUpper(this.DomainName);
            }
        }
    }
}
