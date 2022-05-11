using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger.ViewModels
{
    class LogViewModel : NotificationObject
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LogViewModel()
        {

        }
        private string _inputLog;
        /// <summary>
        /// logを取得します。
        /// </summary>
        public string InputLog
        {
            get { return this._inputLog; }
            set { SetProperty(ref this._inputLog, value); }
        }

    }
}
