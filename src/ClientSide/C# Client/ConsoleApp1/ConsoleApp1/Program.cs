using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectConsole
{
    public class Program
    {
        public static void Main()
        {
            string returnedData = null;

            //set the data
            Program p = new Program();
            returnedData = p.getWebData();

            //process the data
            if (returnedData == null)
            {
                Console.WriteLine("No data found");
                Console.Read();
            }
            else
            {

                //Display the output

                char proceed;
                do
                {
                    char choice;
                    Console.WriteLine("Choose an option :\n1->Get All Records\n2->Get Last 'N' records\n");
                    //choice=Console.Read();
                    choice= Console.ReadKey().KeyChar;
                    switch (choice)
                    {
                        case '1':p.getAllScannedRecords(returnedData);
                            break;
                        case '2':p.getLastNrecords(returnedData);
                            break;
                        default:
                            Console.WriteLine("Enter valid choice\n");
                            break;
                    }
                    Console.WriteLine("Do you want to continue : (Y/N)");
                    proceed= Console.ReadKey().KeyChar;

                } while (proceed == 'Y' || proceed == 'y');

                //p.displayJSON(returnedData);
            }
        }

        public void getAllScannedRecords(string barcodeData)
        {
            try
            {
                var data = JArray.Parse(barcodeData);

                foreach (var item in data)
                {
                    Console.WriteLine(item.First + "  " + item.Last);

                }



                //Console.WriteLine(data);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
        }

        public void getLastNrecords(string barcodeData)
        {
           
            try
            {
                var data =JArray.Parse(barcodeData);
                int total_records=data.Count;
                Console.WriteLine("Enter number of recent records to get : ");
                int records_to_display= Convert.ToInt32(Console.ReadKey().KeyChar-'0');
                for (int i = (total_records- records_to_display) ; i<total_records;i++)
                {
                    var item = data[i];
                    Console.WriteLine(item.First+"  "+item.Last);

                }



//              Console.WriteLine(data);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }

        }

        public string getWebData()
        {
            string webData = null;
            string urlAddress = "http://192.168.225.188/jsonBarcode.php";

            //try the URI, fail out if not successful 
            HttpWebRequest request;
            HttpWebResponse response;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(urlAddress);
                response = (HttpWebResponse)request.GetResponse();

            }

            catch (Exception e)
            {
                //this could be modified for specific responses if needed
                Console.Write(e);
                return null;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                webData = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return webData;
        }
    }
}
