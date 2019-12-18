using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.Utils
{
    class Helper
    {

        public static void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        public static String ReadString(string message)
        {
            Console.Write(message);
            String str = Console.ReadLine();
            str = str.ToLower();
            str = str.Trim();
            return str;
        }

        public static int ReadYear(string message)
        {

            String str = null;

            bool ok = false;
            int value = 0;
            while (ok == false)
            {
                Console.Write(message);
                str = Console.ReadLine();
                ok = Int32.TryParse(str, out value);
                if (value < 868 || value > DateTime.Now.Year) ok = false;
            }


            return value;
        }
    }
}
