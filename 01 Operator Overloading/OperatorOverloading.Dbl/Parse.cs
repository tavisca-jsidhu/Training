using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OperatorOverloading.Dbl
{
    public class Parse
    {
        //-------------------Web Parsing--------------------//
        public string WebParse()
        {
            WebClient client = new WebClient();
            string str = client.DownloadString("http://www.apilayer.net/api/live?access_key=9f011e5b35e7990d360073da30a7f8f2");
            return str;
        }
        //-------------------File Parsing--------------------//
        public string FileParse()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\jsidhu\Desktop\Text.txt");
            return text;
        }

        public static string[] returnData;
        public static string[] dataSplit;
        //------------------Parsing Function------------------//
        public string[] Parsing()
        {
            string data = FileParse(); // We can use WebParse() function also

            data = data.Replace('}', '\0').Replace('\"', '\0').Replace("USD", "");
            dataSplit = data.Split('{');
            returnData = dataSplit[2].Split(',');

            return returnData;
        }
    }
}
