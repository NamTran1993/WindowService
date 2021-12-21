using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TWService.TFunction.TExampleWriteLog;

namespace TWService
{
    partial class TMainService : ServiceBase
    {
        private string _LOG_FILE = "TMainService.log";

        private static void Main(string[] args)
        {
#if(!DEBUG)
            {
                ServiceBase.Run(new TMainService());
            }
#else
            {
                TMainService service = new TMainService();
                service.OnStart(null);
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            }
#endif
        }

        public TMainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // -----
            HNBackend.Global.TGlobal.InitFolderLog(AppDomain.CurrentDomain.BaseDirectory);

            // -----
            HNBackend.Global.TGlobal.Log(_LOG_FILE, "On Start Service!", HNBackend.Global.TYPE_LOGGER.NORMAL);

            #region READ CONFIG INI
            #endregion


            #region START FUNTION
            TExamWriteLog examWriteLog = new TExamWriteLog(5);
            #endregion
        }

        protected override void OnStop()
        {
            // -----
            HNBackend.Global.TGlobal.Log(_LOG_FILE, "On Stop Service!", HNBackend.Global.TYPE_LOGGER.NORMAL);
        }
    }
}
