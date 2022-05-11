using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger.Models
{
    internal class NodeItem
    {
        public NodeItem(string header)
        {
            this.Header = header;
            this.PCs = new List<PCItem>();
        }
        public void AddPc(PCItem pc)
        {
            this.PCs.Add(pc);
        }

        public string Header { get; set; }
        //public PCItem[] PCs { get; private set; }
        public List<PCItem> PCs { get; set; }
    }
}
