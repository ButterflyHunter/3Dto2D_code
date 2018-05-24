using System;
using System.Windows.Forms;

namespace _3Dto2D
{
    static class Program
    {
        public static Main Form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Form = new Main());
            
        }
    }
}
