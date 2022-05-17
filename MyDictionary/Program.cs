using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDictionary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            // https://ภาษาอังกฤษออนไลน์.com/คำศัพท์ภาษาอังกฤษ/
            // https://www.shorteng.com/คำศัพท์ที่ได้ใช้ใน3500-คำ/
        }
    }
}
