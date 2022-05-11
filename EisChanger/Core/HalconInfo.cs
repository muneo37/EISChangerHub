namespace EisChanger
{
    class HalconInfo
    {
        public struct EnvValue
        {
            public string hRoot;
            public string hArch;
        }

        //環境変数パス
        public static EnvValue halcon11_32bit = new EnvValue() { hRoot = "C:\\Program Files\\MVTec\\HALCON-11.0", hArch = "x86sse2-win32" };
        public static EnvValue halcon1811Steady_64bit = new EnvValue() { hRoot = "C:\\Program Files\\MVTec\\HALCON-18.11-Steady", hArch = "x64-win64" };

        //configファイル　バージョン名
        public static string ver11 = "11.0.4 32bit";
        public static string ver18 = "18.11steady 64bit";
    }

}
