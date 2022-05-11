using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger.Models
{
    internal class PCItem
    {
        public PCItem(string name, string exePath, string paramPath, string ver)
        {
            this.Name = name;
            this.ExePath = exePath;
            this.ParamPath = paramPath;
            this.HalconVer = ver;
        }

        public string Name { get; set; }
        public string ExePath { get; set; }
        public string ParamPath { get; set; }
        public string HalconVer { get; set; }
    }
}
