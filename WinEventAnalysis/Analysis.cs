using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEventAnalysis
{
    class Analysis
    {
        private List<Event> extractedEvents = new List<Event>();
        private List<InstanceCounter> instances = new List<InstanceCounter>();
        private List<DateCounter> dateInstances = new List<DateCounter>();

        public Analysis(List<Event> extractedEvents)
        {
            this.extractedEvents = extractedEvents;

        }

        public void calculateFrequencyOfInsance()
        {
            //loop over all the extracted events
            //inspect the Event Instance ID and accumulate the frquency of their occrances
            for (int i = 0; i < extractedEvents.Count; i++)
            {
                int index = findInstanceIndex(extractedEvents[i].getEventType());
                if (index == -1)//not previous seen, create a new Instance Counter object
                    instances.Add(new InstanceCounter(extractedEvents[i].getEventType(), 1));
                else
                    instances[index].increment();
            }
        }

        public void calculateFrequencyPerDay()
        {
            for (int i = 0; i < extractedEvents.Count; i++)
            {
                int index = findDateIndex(extractedEvents[i].getDate().ToShortDateString());
                if (index == -1)//not previous seen, create a new Instance Counter object
                    dateInstances.Add(new DateCounter(extractedEvents[i].getDate().ToShortDateString(), 1));
                else
                    dateInstances[index].increment();
            }
        }

        //finds the array position of a counter object in the date list.
        //-1 means no current counter object exists
        public int findDateIndex(String date)
        {
            for (int i = 0; i < dateInstances.Count; i++)
            {
                if (dateInstances[i].Date.Equals(date))
                    return i;
            }
            return -1;
        }

        //finds the array position of a counter object in the instance list.
        //-1 means no current counter object exists
        public int findInstanceIndex(long id)
        {
            for (int i = 0; i < instances.Count; i++)
            {
                if (instances[i].InstanceID == id)
                    return i;
            }
            return -1;
        }

        public void printDateFrequencies()
        {
          
            List<DateCounter> SortedList = dateInstances.OrderBy(o => o.Number).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                Console.WriteLine(SortedList[i]);
            }
        }

        /// <summary>
        /// prints out the number of times each Log ID appears in the system's event history
        /// </summary>
        public void printFrequencies()
        {
            List<InstanceCounter> SortedList = instances.OrderBy(o => o.Number).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                Console.WriteLine(SortedList[i]);
            }
        }


        class DateCounter
        {
            String date;
            int number;

            public DateCounter(String date, int number)
            {
                this.date = date;
                this.number = number;
            }

            public void increment()
            {
                number++;
            }

            public string Date
            {
                get
                {
                    return date;
                }

                set
                {
                    date = value;
                }
            }

            public int Number
            {
                get
                {
                    return number;
                }

                set
                {
                    number = value;
                }
            }
            public override String ToString()
            {
                return  date + ", Occurance: " + number;
            }
        }


        /// <summary>
        /// The below class is used to keep track of how many occrancess of each Event ID have been identified.
        /// The majority of the below code is purely house keeping stuff
        /// </summary>
        class InstanceCounter
        {
            long instanceID;
            int number;
            public InstanceCounter(long instanceID, int number)
            {
                this.instanceID = instanceID;
                this.number = number;
            }
            public void increment()
            {
                number++;
            }
            public long InstanceID
            {
                get
                {
                    return instanceID;
                }

                set
                {
                    instanceID = value;
                }
            }

            public int Number
            {
                get
                {
                    return number;
                }

                set
                {
                    number = value;
                }
            }

            public override String ToString()
            {
                return "Log ID: " + instanceID + ", Occurance: " + number;
            }
        }
    }
}
