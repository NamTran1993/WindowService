using HNBackend.Global;
using HNBackend.Module.TThread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWService.TFunction.TExampleWriteLog
{
    public class TWrite : TThreadManager
    {
        private string _LOG_FILE = "TWrite.log";

        public TWrite(int timeInterval) : base(timeInterval)
        {

        }

        protected override void MainProcessing()
        {
            try
            {
                TGlobal.Log(_LOG_FILE, "[Doing running....]", HNBackend.Global.TYPE_LOGGER.DEBUG);
            }
            catch (Exception ex)
            {
                TGlobal.Log(_LOG_FILE, "[MainProcessing] Exception: " + ex.Message + "\r\n" + ex.StackTrace, HNBackend.Global.TYPE_LOGGER.ERROR);
            }
        }
    }
}
