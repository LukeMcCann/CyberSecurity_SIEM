using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WinEventAnalysis
{
    class Extractor
    {
        private List<Event> extractedEvents = new List<Event>();
        public Extractor()
        {
        }

        /// <summary>
        /// Extracts all the events from the Host operating systems and stores them in a List.
        /// Note that we only extract a few details - time, machinename, source, ID.
        /// Exceptions are common due to read/write privilege  issues.
        /// </summary>
        public void Extract()
        {
            EventLog[] eventLogs = EventLog.GetEventLogs();
            foreach (EventLog e in eventLogs)
            {
                try
                {   // Note that you need to be running as Administrator to view "Security" events
                    if (e.LogDisplayName.Equals("Application"))
                    {
                        foreach (EventLogEntry entry in e.Entries)
                        {
                            extractedEvents.Add(new WinEventAnalysis.Event(entry.TimeGenerated, entry.MachineName, entry.Source, entry.InstanceId));
                        }
                    }
                }   
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        public List<Event> getAcquiredEvents()
        {
            return extractedEvents;
        }


        /// <summary>
        /// Print out all the extracted events in the order thgat they are stored in the array
        /// </summary>
        public void printAllExtractedEvents()
        {
            for(int i=0;i< extractedEvents.Count;i++)
            {
                Console.WriteLine(extractedEvents[i]);
            }
        }
    }
}
