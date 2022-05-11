using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EisChanger.Models
{
    internal class ChangeFolder
    {
        /// <summary>
        /// フォルダ・ファイルを入れ替えます。
        /// </summary>
        /// <param name="currentPath">入れ替え前のフルパスを指定します。</param>
        /// <param name="newPath">入れ替え先のフルパスを指定します。</param>
        public bool Change(string currentPath, string newPath)
        {
            try
            {
                //入れ替え前と入れ替え先のパスが同じ場合何もしない。
                if (currentPath == newPath)
                    return (true);

                //移動先フォルダが存在する場合は削除する！
                if (Directory.Exists(newPath))
                {
                    Directory.Delete(newPath, true);
                }

                //移動元フォルダを移動先へ
                if (Directory.Exists(currentPath))
                {
                    //Directory.CreateDirectory(newPath);
                    Directory.Move(currentPath, newPath);
                }
                else
                {
                    MessageBox.Show("移動元のフォルダがありません");
                    return (false);
                }
            }catch( IOException Exception)
            {
                MessageBox.Show(Exception.Message);
                return (false);
            }
            return (true);
        }

        /// <summary>
        /// フォルダをコピーしてリネームします。
        /// </summary>
        /// <param name="currentPath">コピー元フォルダ</param>
        /// <param name="newPath">コピー先フォルダ</param>
        /// <returns></returns>
        public bool FolderCopy(string currentPath, string newPath)
        {
            try
            {
                DirectoryInfo src_info = new DirectoryInfo(currentPath);

                // コピー元の存在チェック
                if (!src_info.Exists)
                {
                    return (false);
                }

                // コピー先のフォルダ作成
                Directory.CreateDirectory(newPath);

                // コピー元のフォルダとファイル情報を取得
                DirectoryInfo[] src_folders = src_info.GetDirectories();
                FileInfo[] src_files = src_info.GetFiles();

                // コピー元のファイルを全てコピー先のフォルダに上書きコピー
                foreach (FileInfo file in src_files)
                {
                    string path = Path.Combine(newPath, file.Name);
                    file.CopyTo(path, true);
                }

                // 再起呼び出しによりコピー元のフォルダを全てコピー先のフォルダにコピー
                foreach (DirectoryInfo subfolder in src_folders)
                {
                    string path = Path.Combine(newPath, subfolder.Name);
                    FolderCopy(subfolder.FullName, path);
                }
            }
            catch (IOException Exception)
            {
                MessageBox.Show(Exception.Message);
                return (false);
            }
            return (true);
        }
        
        /// <summary>
        /// 指定したフォルダとフォルダ内のファイルすべて削除
        /// </summary>
        /// <param name="targetDirectoryPath">削除対象フォルダ</param>
        /// <returns></returns>
        public bool Delete(string targetDirectoryPath)
        {
            if (!Directory.Exists(targetDirectoryPath))
            {
                return(false);
            }

            //ディレクトリ以外の全ファイルを削除
            string[] filePaths = Directory.GetFiles(targetDirectoryPath);
            foreach (string filePath in filePaths)
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }

            //ディレクトリの中のディレクトリも再帰的に削除
            string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
            foreach (string directoryPath in directoryPaths)
            {
                Delete(directoryPath);
            }

            //中が空になったらディレクトリ自身も削除
            Directory.Delete(targetDirectoryPath, false);

            return (true);
        }
    }
}
