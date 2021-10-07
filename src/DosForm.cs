using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZLTetris
{
    public partial class DosForm : Form
    {
        /// <summary>构造函数
        /// 
        /// </summary>
        public DosForm()
        {
            //加载控件
            InitializeComponent();
        }
        /// <summary>点击执行命令方法
        /// 
        /// </summary>
        /// <param name="sender">按钮对象</param>
        /// <param name="e">事件对象</param>
        private void buttExecOrder_Click(object sender, EventArgs e)
        {
            //调用执行命令方法
            this.ExecOredr();
        }
        /// <summary>点击按键触发的事件
        /// 
        /// </summary>
        /// <param name="sender">文本框对象</param>
        /// <param name="e">事件对象</param>
        private void txtWrileOreder_KeyDown(object sender, KeyEventArgs e)
        {
            //判断点击的是否为换行键
            if (e.KeyCode == Keys.Enter)
            {
                //调用执行命令方法
                this.ExecOredr();
            }
        }
        /// <summary>执行命令方法
        /// 
        /// </summary>
        private void ExecOredr()
        {
            //调用控制台的Wrile方法，来执行命令
            Static.Dos.Wrile(this.txtWrileOreder.Text);
            //清空输入命令文本框
            this.txtWrileOreder.Clear();
        }
        /// <summary>关闭窗体触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //隐藏当前窗体并停止关闭窗体
            this.Hide();
            //停止关闭窗体
            e.Cancel = true;
        }
        /// <summary>向控制台显示的信息
        /// 
        /// </summary>
        /// <param name="text">要显示的信息</param>
        public void ConsoleAddInformation(string text)
        {
            //追加信息
            this.txtShowDosOrder.AppendText(text);
        }
        /// <summary>向控制台显示的信息并换行
        /// 
        /// </summary>
        /// <param name="text">要显示的信息</param>
        public void ConsoleAddInformationLine(string text)
        {
            //追加信息
            this.txtShowDosOrder.AppendText(text + "\r\n");
        }
        /// <summary>重写显示方法
        /// 
        /// </summary>
        public new void Show()
        {
            //显示窗体
            base.Show();
            //设置焦点给输入文本框
            this.txtWrileOreder.Focus();
        }
    }
}
