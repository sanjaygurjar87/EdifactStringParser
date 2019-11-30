using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdifactMessageParser
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            List<string> results = new List<string>();
            string edifact = @"UNA:+.? '
UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'
UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
LOC+17+IT044100'
LOC+18+SOL'
LOC+35+SE'
LOC+36+TZ'
LOC+116+SE003033'
DTM+9:20090527:102'
DTM+268:20090626:102'
DTM+182:20090527:102'";


            try
            {
                // split with LOC+ 
                string[] LocSegments = edifact.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(line => line.StartsWith("LOC+")).ToArray();

                foreach (string readbylines in LocSegments)
                {

                    string trimmedLine = readbylines.Substring(0, readbylines.IndexOf('\''));


                    string[] index = trimmedLine.Split('+').ToArray();

                    // add items 1 and 2 to the results list 

                    var author = new Tuple<string, string>(index[1], index[2]);
                    results.Add(author.ToString());

                }
                //Write result on Console application
                Console.WriteLine("[{0}]", string.Join(", ", results));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
