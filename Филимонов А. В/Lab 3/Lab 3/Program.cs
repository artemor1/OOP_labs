using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab_3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine($"[Program.Main] Start. machine={Environment.MachineName}, user={Environment.UserName}");
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Debug.WriteLine("[Program.Main] Launching Form1.");
                Application.Run(new Form1());
                Debug.WriteLine("[Program.Main] Completed.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Program.Main] Failure. {ex}");
                throw;
            }
        }
    }
}
