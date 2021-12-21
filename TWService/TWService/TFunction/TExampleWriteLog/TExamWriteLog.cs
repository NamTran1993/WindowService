using HNBackend.Global;
using HNBackend.Module.TTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TWService.TFunction.TExampleWriteLog
{
    public class TExamWriteLog : TTimer
    {
        private string _LOG_FILE = "TExamWriteLog.log";
        private int _interval = 0;

        private TWrite _tWrite = null;


        public TExamWriteLog(int interval) : base(interval)
        {
            _interval = interval;
        }

        public override void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                if (_tmrTimer != null)
                    _tmrTimer.Stop();

                if (_tWrite == null)
                {
                    _tWrite = new TWrite(_interval);
                    _tWrite.StartChecking();
                }
            }
            catch (Exception ex)
            {
                TGlobal.Log(_LOG_FILE, "[Timer_Elapsed] Exception: " + ex.Message + "\r\n" + ex.StackTrace, HNBackend.Global.TYPE_LOGGER.ERROR);
            }
        }
    }
}
