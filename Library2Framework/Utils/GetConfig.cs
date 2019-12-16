using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.Utils
{
    public class GetConfig
    {
       
       public Dictionary<String, int> GetConfigData()
        {
            Dictionary<String, int> data = new Dictionary<String, int>();
            using (StreamReader reader = File.OpenText("E:/BIBLIOTECA/Library2Framework/Library2Framework/Resources/Config.txt")) //bloc de resurse
            {
                String line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] array = line.Split('=');
                    //verifica daca poate sa faca conversia de la string la int si o face in value
                    if (Int32.TryParse(array[1], out int value)) 
                    {
                        data.Add(array[0], value);
                    }
                   
                }
            }

            return data;
        }

    }
}
