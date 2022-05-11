using System;
using System.Security;
using System.Windows.Forms;

namespace EisChanger.Models
{
    internal class SetEnvironment
    {
        /// <summary>
        /// Halcon環境変数の設定
        /// </summary>
        /// <param name="pc"></param>
        public void Set(PCItem pc)
        {
            try
            {
                if (pc.HalconVer == HalconInfo.ver11)
                {
                    Environment.SetEnvironmentVariable("HALCONROOT", HalconInfo.halcon11_32bit.hRoot, EnvironmentVariableTarget.Machine);
                    Environment.SetEnvironmentVariable("HALCONARCH", HalconInfo.halcon11_32bit.hArch, EnvironmentVariableTarget.Machine);
                }
                else if (pc.HalconVer == HalconInfo.ver18)
                {
                    Environment.SetEnvironmentVariable("HALCONROOT", HalconInfo.halcon1811Steady_64bit.hRoot, EnvironmentVariableTarget.Machine);
                    Environment.SetEnvironmentVariable("HALCONARCH", HalconInfo.halcon1811Steady_64bit.hArch, EnvironmentVariableTarget.Machine);
                }
                else
                {
                    MessageBox.Show("halconバージョンが正しくありません");
                }
            }catch(SecurityException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
