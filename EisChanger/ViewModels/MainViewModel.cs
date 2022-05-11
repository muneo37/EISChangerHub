using System.Linq;
using System.Text;

namespace EisChanger.ViewModels
{
    using EisChanger.Models;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    //using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;


    class MainViewModel : NotificationObject
    {
        #region フィールド
        private PCItem _selectedPC;
        private NodeItems _items = new NodeItems();
        private ChangeFolder _changeFld = new ChangeFolder();
        private Log _log = new Log();
        private NodeItem _currentNode;
        private string _displog;
        private string _inputLog;
        private BitmapSource _iconImage;
        private SetEnvironment _setEnviroment = new SetEnvironment();

        #endregion

        #region プロパティ

        /// <summary>
        /// 選択されている PC 情報を取得します。
        /// </summary>
        public PCItem SelectedPC
        {
            get { return this._selectedPC; }
            private set
            {
                if (this._selectedPC != value)
                {
                    this._selectedPC = value;
                    RaisePropertyChanged("SelectedPC");
                    RaisePropertyChanged("SelectedNode");
                    RaisePropertyChanged("ChangeDestinationPC");
                }
            }
        }

        /// <summary>
        /// 選択されているノードを取得します。
        /// </summary>
        public NodeItem SelectedNode
        {
            get { return this._items.GetParent(this.SelectedPC); }
        }

        /// <summary>
        /// 全ノード配列を取得します。
        /// </summary>
        public List<NodeItem> NodeItems { get { return this._items.Nodes; } }

        /// <summary>
        /// 変更先 PC を取得します。
        /// </summary>
        public PCItem ChangeDestinationPC
        {
            get
            {
                if (this._selectedPC == null) return this._selectedPC;

                PCItem dispPC = new PCItem("", "", "", "");

                if (this._selectedPC.Name == "") return this._selectedPC;

                dispPC.Name = this._selectedPC.Name + "]";
                dispPC.ExePath = "実行ファイルパス：" + this._selectedPC.ExePath;
                dispPC.ParamPath = "パラメータパス：" + this._selectedPC.ParamPath;
                dispPC.HalconVer = "Halcon Ver：" + this._selectedPC.HalconVer;

                return dispPC;
            }
        }

        /// <summary>
        /// 現在の実行環境 PC 情報を取得します。
        /// </summary>
        public PCItem CurrentPC
        {
            get { return this._currentNode.PCs[0]; }
        }

        /// <summary>
        /// 選択されているノードを取得します。
        /// </summary>
        public NodeItem CurrentNode
        {
            get { return this._currentNode; }
            private set
            {
                if (this._currentNode != value)
                {
                    this._currentNode = value;
                    RaisePropertyChanged("CurrentNode");
                    RaisePropertyChanged("CurrentPC");
                }
            }
        }

        /// <summary>
        /// logを取得します。
        /// </summary>
        public string Log
        {
            get { return this._displog; }
            set { SetProperty(ref this._displog, value); }
        }

        /// <summary>
        /// logを取得します。
        /// </summary>
        public string InputLog
        {
            get { return this._inputLog; }
            set { SetProperty(ref this._inputLog, value); }
        }

        /// <summary>
        /// IconImageを取得します。
        /// </summary>
        public BitmapSource IconImage
        {
            get { return this._iconImage; }
            set { SetProperty(ref this._iconImage, value); }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public MainViewModel()
        {
            string dir = Directory.GetCurrentDirectory();
            string csvFile = dir + "\\conf.txt";
            string currentFile = dir + "\\currentConf.txt";
            string exe = dir + "\\EisChanger.exe";


            //exeアイコンを表示
            var path = @exe;
            var icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
            IconImage = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());


            CurrentNode = this._items.InitializationFromCsvFile(csvFile, currentFile);

            string logFileName = dir + "\\" + CurrentNode.Header + ".txt";
            Log = _log.ReadLogFile(logFileName);

            if (CurrentNode.Header == "")
            {
                //ソフト終了
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        /// 適用処理をおこないます。
        /// </summary>
        /// <param name="node">ノード情報を指定します。</param>
        /// <param name="pc">PC 情報を指定します。</param>
        private void Apply(NodeItem node, PCItem pc)
        {
            string eisExe = "C:\\EIS";
            string eisParam = "D:\\EISParam";
            string eisMcdata = "C:\\EIS\\Mdata";

            //各フォルダが存在するかチェック　TODO
            if (!Directory.Exists(eisExe))
            {
                MessageBox.Show(eisExe + "が存在しません");
                return;
            }
            if (!Directory.Exists(eisParam))
            {
                MessageBox.Show(eisParam + "が存在しません");
                return;
            }
            if (CurrentNode.PCs[0].ExePath != SelectedPC.ExePath)
            {
                if (!Directory.Exists(SelectedPC.ExePath))
                {
                    MessageBox.Show(SelectedPC.ExePath + "が存在しません");
                    return;
                }
                //ExeフォルダがカレントNodeと違う場合
                if (CurrentNode.PCs[0].Name != SelectedPC.Name)
                {
                    if (!Directory.Exists(SelectedPC.ExePath + "\\Mdata" + SelectedPC.Name))
                    {
                        MessageBox.Show(SelectedPC.ExePath + "\\Mdata" + SelectedPC.Name + "が存在しません");
                        return;
                    }
                }
            }
            else
            {
                //ExeフォルダがカレントNodeと同じ場合
                if (CurrentNode.PCs[0].Name != SelectedPC.Name)
                {
                    if (!Directory.Exists(eisExe + "\\Mdata" + SelectedPC.Name))
                    {
                        MessageBox.Show(eisExe + "\\Mdata" + SelectedPC.Name + "が存在しません");
                        return;
                    }
                }

            }
            if (CurrentNode.PCs[0].ParamPath != SelectedPC.ParamPath)
            {
                if (!Directory.Exists(SelectedPC.ParamPath))
                {
                    MessageBox.Show(SelectedPC.ParamPath + "が存在しません");
                    return;
                }
            }

            if (CurrentNode.PCs[0].ExePath != SelectedPC.ExePath)
            {//Exeファイルを移動

                //Mcdataフォルダを削除
                this._changeFld.Delete(eisMcdata);

                //現在の実行ファイルを保守側フォルダへ移動
                if (!this._changeFld.Change(eisExe, CurrentNode.PCs[0].ExePath)) return;
                //保守側のフォルダから実行パスへ移動
                if (!this._changeFld.Change(SelectedPC.ExePath, eisExe)) return;

                //Mcdataフォルダをコピー
                if (!this._changeFld.FolderCopy(eisMcdata + SelectedPC.Name, eisMcdata)) return;

            }
            else if (CurrentNode.PCs[0].Name != SelectedPC.Name)
            {//Exeファイルは同じでPC名は異なる場合
                //Mcdataフォルダを削除
                this._changeFld.Delete(eisMcdata);
                //Mcdataフォルダをコピー
                if (!this._changeFld.FolderCopy(eisMcdata + SelectedPC.Name, eisMcdata)) return;
            }

            if (CurrentNode.PCs[0].ParamPath != SelectedPC.ParamPath)
            {//パラメータファイルを移動
                //現在の実行ファイルを保守側のフォルダへ移動
                if (!this._changeFld.Change(eisParam, CurrentNode.PCs[0].ParamPath)) return;
                //保守側のフォルダから実行パスへ移動
                if (!this._changeFld.Change(SelectedPC.ParamPath, eisParam)) return;
            }

            //切り替えた環境をCurrentNodeへ
            NodeItem tmp = new NodeItem(node.Header);
            tmp.PCs.Add(pc);
            CurrentNode = tmp;

            //切り替えた環境のパスをConfigファイルへ保存
            string dir = Directory.GetCurrentDirectory();
            string currentFile = dir + "\\currentConf.txt";
            this._items.CurrentNodeToCsvFile(currentFile, CurrentNode);

            //選択PCクリア
            PCItem clearPC = new PCItem("", "", "", "");
            SelectedPC = clearPC;

            //Log読み込み・表示
            string logFileName = dir + "\\" + CurrentNode.Header + ".txt";
            Log = _log.ReadLogFile(logFileName);

            //環境変数設定
            _setEnviroment.Set(CurrentPC);

        }

        /// <summary>
        /// LOG登録処理をおこないます。
        /// </summary>
        private void CommitLog()
        {
            //日付追加
            string time = System.DateTime.Now.ToString();
            string addString;
            if (string.IsNullOrEmpty(Log))
            {
                addString = time + "\r\n" + InputLog;
            }
            else
            {
                addString = "\r\n\r\n" + time + "\r\n" + InputLog;
            }

            //
            Log = Log + addString;
            InputLog = "";

            string dir = Directory.GetCurrentDirectory();
            string fileName = dir + "\\" + CurrentNode.Header + ".txt";
            _log.writeLogFile(fileName, Log);

        }

        /// <summary>
        /// EISを起動します。
        /// </summary>
        private void StartEIS()
        {
            if(CurrentPC.HalconVer == HalconInfo.ver11)
            {
                Process.Start("startEIS_1132.bat");
            }
            else if(CurrentPC.HalconVer == HalconInfo.ver18)
            {
                Process.Start("startEIS_1864.bat");
            }
            else
            {
                MessageBox.Show("ハルコンパージョンが正しくありません");
            }
        }
        #endregion

        #region コマンド
        private DelegateCommand _selectPCCommand;
        /// <summary>
        /// PC 情報選択コマンドを取得します。
        /// </summary>
        public DelegateCommand SelectPCCommand
        {
            get
            {
                return this._selectPCCommand ?? (this._selectPCCommand = new DelegateCommand(
                p =>
                {
                    this.SelectedPC = p as PCItem;
                }));
            }
        }

        private DelegateCommand _applyCommand;
        /// <summary>
        /// 適用コマンドを取得します。
        /// </summary>
        public DelegateCommand ApplyCommand
        {
            get
            {
                return this._applyCommand ?? (this._applyCommand = new DelegateCommand(_ =>
                {
                    Apply(this.SelectedNode, this.SelectedPC);
                }));
            }
        }

        private DelegateCommand _EISCommand;
        /// <summary>
        /// EIS起動コマンドを取得します。
        /// </summary>
        public DelegateCommand EISCommand
        {
            get
            {
                return this._EISCommand ?? (this._EISCommand = new DelegateCommand(_ =>
                {
                    StartEIS();
                }));
            }
        }

        private DelegateCommand _commitLogCommand;
        /// <summary>
        /// コミットLOGコマンドを取得します。
        /// </summary>
        public DelegateCommand CommitLogCommand
        {
            get
            {
                return this._commitLogCommand ?? (this._commitLogCommand = new DelegateCommand(_ =>
                {
                    CommitLog();
                }));
            }
        }

        private DelegateCommand _closeCommand;
        /// <summary>
        /// 適用コマンドを取得します。
        /// </summary>
        public DelegateCommand CloseCommand
        {
            get
            {
                return this._closeCommand ?? (this._closeCommand = new DelegateCommand(_ =>
                {
                    Application.Exit();
                }));
            }
        }

    }


    #endregion


}
