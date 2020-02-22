using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static Form1 MainWindow;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             MainWindow = new Form1();
            Application.Run(MainWindow);
        }
    }
}
