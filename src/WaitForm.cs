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
    public partial class WaitForm : Form
    {
        /// <summary>构造函数
        /// 
        /// </summary>
        public WaitForm()
        {
            //加载控件
            InitializeComponent();
        }
        /// <summary>获取与设置显示内容
        /// 
        /// </summary>
        public string ShowText
        {
            get
            {
                return this.labelInformation.Text;
            }
            set
            {
                //设置值
                this.labelInformation.Text = value;
            }
        }
        /// <summary>获取与设置标题
        /// 
        /// </summary>
        public string Title
        {
            get
            {
                return this.labelTitle.Text;
            }
            set
            {
                //设置标题
                this.labelTitle.Text = value;
            }
        }
        /// <summary>获取与设置进度
        /// 
        /// </summary>
        public int ScheduleValue
        {
            get
            {
                return this.pbSchedule.Value;
            }
            set
            {
                //设置值
                this.pbSchedule.Value = value;
            }
        }
    }
}
