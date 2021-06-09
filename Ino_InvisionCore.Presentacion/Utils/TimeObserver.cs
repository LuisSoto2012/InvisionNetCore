using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Utils
{
    public class TimeObserver
    {
        public DateTime StartProcess;
        public DateTime? EndProcess;
        public string Mensaje;

        public TimeObserver(string mensaje)
        {
            Mensaje = mensaje;

        }
        public TimeObserver Start()
        {
            StartProcess = DateTime.Now;
            return this;
        }

        public void Finish()
        {
            EndProcess = DateTime.Now;

        }

        public string Show()
        {
            return "";

        }
        public double Diff()
        {
            return CalcElapsed().TotalSeconds;
        }

        private TimeSpan CalcElapsed()
        {
            DateTime endProcess = EndProcess ?? DateTime.Now;
            return endProcess.Subtract(StartProcess);
        }


        public void LogElapsedAndReset(string message2, string messageTail = "")
        {
            Finish();
            string info = string.Format("{0} {1} took {2} {3}", Mensaje, message2, CalcElapsedStr(), messageTail);
            Log.Debug(info);
            Start();
        }


        public void LogElapsedAndFinish(string message2, string messageTail = "")
        {
            Finish();
            Log.Debug($"{Mensaje} {message2} took {CalcElapsedStr()} {messageTail}");
        }

        public object CalcElapsedStr()
        {
            var elapsed = CalcElapsed();
            if (elapsed.TotalMilliseconds < 1000) return string.Format("{0} milis", elapsed.TotalMilliseconds);
            else if (elapsed.TotalSeconds < 60) return string.Format("{0} segs", elapsed.TotalSeconds);
            else if (elapsed.TotalMinutes < 60) return string.Format("{0:0.0} mins", elapsed.TotalMinutes);
            else if (elapsed.TotalHours < 24) return string.Format("{0:0.0} hrs", elapsed.TotalHours);
            else return string.Format("{0:0.0} days", elapsed.TotalDays);
        }
    }
}
