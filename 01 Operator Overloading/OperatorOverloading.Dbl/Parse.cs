using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;

namespace OperatorOverloading.Dbl
{
    public class Parse
    {
        //-------------------Web Parsing--------------------//
        public string WebParse()
        {
            WebClient client = new WebClient();
            string str = client.DownloadString(ConfigurationManager.AppSettings["webURL"]);
            return str;
        }
        //-------------------File Parsing--------------------//
        public string FileParse()
        {
            string text = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["baseURL"]);
            return text;
        }

        public static string referenceCurrency;
        //------------------Parsing Function------------------//
        public string[] Parsing()
        {
            string[] returnData;
            string[] dataSplit;
            string[] dataSource;
            string[] source;
            string data =  FileParse();
            bool isFileValid;

            dataSplit = data.Split('{');
            dataSource = dataSplit[1].Split(',');
            if (dataSource.Length == 0 || dataSplit.Length == 0)
            {
                isFileValid = false;
            }
            else
            {
                isFileValid = true;
            }
            if (isFileValid == false)
            {
                throw new System.Exception(Exception.InvalidFileFormat);
            }
            dataSource[4] = dataSource[4].Replace("\"", "");
            source = dataSource[4].Split(':');
            referenceCurrency = source[1]; // fetching reference currency from string
            data = data.Replace('}', '\0').Replace('\"', '\0').Replace(source[1], "");
            returnData = dataSplit[2].Split(',');

            return returnData;
        }

        //-------------------------------------------//
        public double CurrencyRate(string currency) // getting currency rate with respect to reference currency
        {
            bool isPresent = false;
            int iterate;
            double multiplier;
            bool isFileValid;
            string[] seperatedData = Parsing();
            if (currency == referenceCurrency) // 'referenceCurrency' variable getting reference currency from text file
            {
                return 1; // if one of the currency entered is reference currency
            }
            else
            {
                for (iterate = 0; iterate < seperatedData.Length; iterate++) // iteration to check if currency is present
                {
                    if (seperatedData[iterate].Contains(currency))
                    {
                        isPresent = true;
                        break;
                    }
                }
                if (isPresent == false) // if currency is not present
                {
                    throw new System.Exception(Exception.CurrencyNotPresent);
                }
                string[] finalSplit = seperatedData[iterate].Split(':');
                if (finalSplit.Length == 0)
                {
                    isFileValid = false;
                }
                else
                {
                    isFileValid = true;
                }
                if (isFileValid == false)
                {
                    throw new System.Exception(Exception.InvalidFileFormat);
                }
                Double.TryParse(finalSplit[1], out multiplier);
                return multiplier;
            }
        }
    }
}
