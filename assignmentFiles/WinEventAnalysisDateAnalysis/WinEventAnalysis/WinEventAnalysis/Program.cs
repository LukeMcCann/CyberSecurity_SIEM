using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEventAnalysis
{
    class Program
    {
        static int Main(string[] args)
        {
            //Step 1. Extract the logs
            Extractor e = new Extractor();
            e.Extract();
            //e.printAllExtractedEvents();

            //Step 2. Perform some analysis
            Analysis a = new Analysis(e.getAcquiredEvents());
            //      a.calculateFrequencyOfInsance();
            //       a.printFrequencies();

            a.calculateFrequencyPerDay();
            a.printDateFrequencies();
            Console.ReadKey();//pause and wait for a key to be pressed before closing
            return 0;
        }

    }

}

