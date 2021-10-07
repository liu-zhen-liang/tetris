using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LZLTetris
{
    static class Program
    {
        /// <summary>存储显示游戏的窗体对象
        /// 
        /// </summary>
        public static Form1 GameForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //创建Dos命令控制台窗体
            Static.Dos.DosForm = new DosForm();
            //创建窗体
            Application.Run(Program.GameForm = new Form1());
        }
    }
}
