// <copyright file="Helper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Helper
    {
        public static void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" [ERROR]: " + error);
            Console.ResetColor();
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            string str = Console.ReadLine();

            while (string.IsNullOrEmpty(str))
            {
                Console.WriteLine(" Empty input!");
                Console.Write(message);
                str = Console.ReadLine();
            }

            str = str.ToLower();
            str = str.Trim();
            return str;
        }

        public static int ReadYear(string message)
        {
            string str = null;

            bool ok = false;
            int value = 0;
            while (ok == false)
            {
                Console.Write(message);
                str = Console.ReadLine();
                ok = int.TryParse(str, out value);
                if (value < 868 || value > DateTime.Now.Year)
                {
                    ok = false;
                }
            }

            return value;
        }

        public static int ReadInteger(string message)
        {
            string str = null;

            bool ok = false;
            int value = 0;
            while (ok == false)
            {
                Console.Write(message);
                str = Console.ReadLine();
                ok = int.TryParse(str, out value);
                if (value < 0)
                {
                    ok = false;
                }
            }

            return value;
        }

        public static Dictionary<string, int> GetConfigData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            // bloc de resurse
            using (StreamReader reader = File.OpenText("E:/BIBLIOTECA/Library2Framework/Library2Framework/Resources/Config.txt"))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] array = line.Split('=');

                    // verifica daca poate sa faca conversia de la string la int si o face in value
                    if (int.TryParse(array[1], out int value))
                    {
                        data.Add(array[0], value);
                    }
                }
            }

            return data;
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
