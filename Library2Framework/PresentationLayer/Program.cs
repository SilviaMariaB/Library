using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library2Framework.DataMapper;
using Library2Framework.DomainModel;
using Library2Framework.Utils;
using log4net;

namespace Library2Framework
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            WorkFlow wf = new WorkFlow();
            wf.Run();
        }

    }

}
