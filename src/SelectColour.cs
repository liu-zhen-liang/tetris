using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZLTetris
{
    public partial class SelectColour : UserControl
    {
        /// <summary>创建当前对象
        /// 
        /// </summary>
        public SelectColour()
        {
            //加载控件
            InitializeComponent();
        }
        /// <summary>当前控件被点击触发的事件【选择新颜色】
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectColour_Click(object sender, EventArgs e)
        {
            //创建选择颜色对象
            ColorDialog cd = new ColorDialog();
            //设置默认选择的颜色
            cd.Color = this.BackColor;
            //显示选择颜色对话框
            cd.ShowDialog();
            //设置颜色
            this.SelectColor = cd.Color;
        }
        /// <summary>获取与设置当前显示的颜色
        /// 
        /// </summary>
        public Color SelectColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                //判断输入的颜色是否不同于上一个颜色
                if (this.BackColor != value)
                {
                    //判断选择新颜色触发的事件对象是否为空，如果不为空就触发事件
                    if (this.SelectNewColor != null)
                    {
                        //调用方法
                        this.SelectNewColor(value);
                    }
                    //设置新颜色
                    this.BackColor = value;
                }
            }
        }
        /// <summary>选择新颜色触发的事件
        /// 
        /// </summary>
        public Action<Color> SelectNewColor;
    }
}
