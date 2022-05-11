using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger.Models
{
    internal class Log
    {
        /// <summary>
        /// ログファイルを書き込みます。
        /// </summary>>
        /// <param name="fileName">ログファイルのパスを指定します｡</param>
        /// 
        public void writeLogFile(string fileName, string log)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
                sw.Write(log);
        }

        /// <summary>
        /// ログファイルを読み込みます。
        /// </summary>>
        /// <param name="fileName">ログファイルのパスを指定します｡</param>
        /// 
        public string ReadLogFile(string fileName)
        {
            string log="";
            if (File.Exists(fileName))
            {
            using (StreamReader sr = new StreamReader(fileName))
                log = sr.ReadToEnd();
            }else
            {
                //System.Windows.Forms.MessageBox.Show(fileName + "が存在しません");
            }
            return (log);
        }
    }
}
