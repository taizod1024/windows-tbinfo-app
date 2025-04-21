using System;
using System.Threading;
using System.Windows.Forms;

namespace TbInfo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
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
