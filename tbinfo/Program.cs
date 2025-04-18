using System;
using System.Threading;
using System.Windows.Forms;

namespace TbInfo
{
    internal static class Program
    {
        /// <summary>  
        /// アプリケーションのメイン エントリ ポイントです。  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            // TODO 二重起動防止  

            const string appName = "tbinfo";
            bool created;

            using (var mutex = new Mutex(true, appName, out created))
            {
                if (!created)
                {
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
