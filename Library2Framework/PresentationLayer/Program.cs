﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;
    using Library2Framework.Utils;
    using log4net;

    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            Application wf = new Application();
            wf.Run();
        }
    }
}
