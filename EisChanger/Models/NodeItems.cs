using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisChanger.Models
{
    internal class NodeItems
    {
        /// <summary>
        /// CSV ファイルを読み込んで初期化をおこないます。
        /// </summary>
        /// <param name="filePath">CSV ファイルのフルパスを指定します。</param>
        /// <param name="currentPath">現在の環境のCSV ファイルのフルパスを指定します。</param>
        /// <returns>現在の実行環境</returns>
        public NodeItem InitializationFromCsvFile(string filePath, string currentPath)
        {
            StreamReader sr;
            string line;
            NodeItem currentItem = new NodeItem("");

            if (File.Exists(filePath))
            {//ファイルがある場合
                //選択する候補の取得
                sr = new StreamReader(filePath/*, Encoding.GetEncoding("Shift_JIS")*/);

                this.Nodes = new List<NodeItem>();
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    string[] arr = line.Split(',');

                    //同じ客先名があるかチェック
                    bool exist = false;
                    PCItem pc = new PCItem(arr[1], arr[2], arr[3], arr[4]);
                    foreach (NodeItem Node in this.Nodes)
                    {
                        if (Node.Header == arr[0])//同じ客先名がある
                        {
                            Node.PCs.Add(pc);
                            exist = true;
                        }
                    }

                    if (!exist)//同じ客先名がない
                    {
                        NodeItem nodeItem = new NodeItem(arr[0]);
                        this.Nodes.Add(nodeItem);
                        this.Nodes[Nodes.Count - 1].PCs.Add(pc);
                    }
                }
            }else
            {
                System.Windows.Forms.MessageBox.Show(filePath + "が存在しません");
                return (currentItem);
            }

            if (File.Exists(currentPath))
            {//ファイルがある場合
             //現在の環境を取得
                sr = new StreamReader(currentPath/*, Encoding.GetEncoding("Shift_JIS")*/);
                line = sr.ReadLine();
                string[] array = line.Split(',');


                currentItem = new NodeItem(array[0]);
                PCItem currentPC = new PCItem(array[1], array[2], array[3], array[4]);
                currentItem.PCs.Add(currentPC);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(currentPath + "が存在しません");
            }

            return (currentItem);
        }

        /// <summary>
        /// ノード情報をCSVファイルに保存します。
        /// </summary>
        /// <param name="currentPath">CSVファイルパスを指定します。</param>
        /// <param name="node">ノード情報を指定します。</param>
        public void CurrentNodeToCsvFile( string currentPath, NodeItem node)
        {
            string txt = node.Header + ',' + node.PCs[0].Name
                                     + ',' + node.PCs[0].ExePath
                                     + ',' + node.PCs[0].ParamPath
                                     + ',' + node.PCs[0].HalconVer;

            File.WriteAllText(currentPath, txt);
        }
        //public NodeItem[] Nodes { get; private set; }
        public List<NodeItem> Nodes { get; private set; }

        /// <summary>
        /// 指定された PC 情報を持つ親要素を取得します。
        /// </summary>
        /// <param name="pc">PC 情報を指定します。</param>
        /// <returns>親要素である <c>EisSelectorSample.Models.NodeItem</c> クラスインスタンスを返します。</returns>
        public NodeItem GetParent(PCItem pc)
        {
            return this.Nodes.Where(x => x.PCs.Any(y => y == pc)).FirstOrDefault();
        }
    }
}
