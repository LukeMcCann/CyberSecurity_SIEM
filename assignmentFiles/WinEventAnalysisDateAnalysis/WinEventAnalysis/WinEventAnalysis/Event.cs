using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEventAnalysis
{
    class Event
    {
        DateTime generatedTime;
        String machineName;
        String source;
        long eventType;

        public Event(DateTime generatedTimed, String machineName, String source, long eventType)
        {
            this.generatedTime = generatedTimed;
            this.machineName = machineName;
            this.source = source;
            this.eventType = eventType;
        }

        public override String ToString()
        {
           return this.generatedTime.ToShortTimeString()+" , "+this.machineName + " , " + this.source+ " , " + this.eventType;
        }

        public DateTime getDate()
        {
            return generatedTime;
        }

        public String getMachineName()
        {
            return machineName;
        }

        public String getSource()
        {
            return source;
        }

        public long getEventType()
        {
            return eventType;
        }
    }
}
