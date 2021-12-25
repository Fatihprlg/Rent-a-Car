using Rent_a_Car.Commons.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Commons.Conceretes.Loggers
{
    internal class EventLogger : LogBase
    {

        public override void Log(string message, bool isError)
        {
            lock (lockObj)
            {
                EventLog m_EventLog = new EventLog();
                m_EventLog.Source = "AracLazimEventLog";
                m_EventLog.WriteEntry(message);
            }
        }
    }
}
