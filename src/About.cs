using LZLTetris.Static;
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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        /// <summary>存储QQ号与微信群点击事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //得到点击的标签对象
            LinkLabel ll = sender as LinkLabel;
            //将内容复制
            Clipboard.SetText(ll.Text);
            //弹出提示
            Tool.ShowRemindBox(ll.Tag.ToString());
        }
        /// <summary>窗体关闭事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            //隐藏窗体
            this.Hide();
            //停止关闭事件
            e.Cancel = true;
        }
    }
}
