using LZLTetris.Static;
using LZLTetris.Static.DataObject;
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
    public partial class Help : Form
    {
        /// <summary>构造函数
        /// 
        /// </summary>
        public Help()
        {
            //加载键位
            InitializeComponent();
            //注册键位更改事件
            Data.RefreshKey += () =>
            {
                //刷新菜单键位
                this.txtSytem.Text = string.Format("菜单键：暂停游戏[{0}]、控制台[{1}]、打开菜单[{2}]", Data.StopGame.ToString(), Data.OpenDosKey.ToString(), Data.OpenMenuKey.ToString());
                //得到玩家一对象
                PlayerSet ps01 = Data.PlayerSetList[0];
                //得到玩家二对象
                PlayerSet ps02 = Data.PlayerSetList[1];
                //玩家一
                this.txtPlay01.Text = string.Format("旋转[{0}]、左移[{1}]、右移[{2}]、下移[{3}]、到底[{4}]", ps01.Spin.ToString(), ps01.LeftMove.ToString(), ps01.RighMove.ToString(), ps01.BelowMove.ToString(), ps01.MoveToTheEnd.ToString());
                //玩家二
                this.txtPlay02.Text = string.Format("旋转[{0}]、左移[{1}]、右移[{2}]、下移[{3}]、到底[{4}]", ps02.Spin.ToString(), ps02.LeftMove.ToString(), ps02.RighMove.ToString(), ps02.BelowMove.ToString(), ps02.MoveToTheEnd.ToString());
            };
        }
        /// <summary>窗体关闭事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            //隐藏窗体
            this.Hide();
            //取消事件
            e.Cancel = true;
        }
    }
}
