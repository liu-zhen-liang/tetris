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
    public partial class GameInteractiveForm : Form
    {
        /// <summary>创建当前对象
        /// 
        /// </summary>
        public GameInteractiveForm()
        {
            //加载控件
            InitializeComponent();
            #region 加载Tag属性
            //创建单人模式存储控件的对象，并将结果存入页面一的Tag中
            this.tabPage1.Tag = new Control[][]{
                //存入一个玩家
                new Control[]{
                    //存入显示数据的表格
                    this.table1,
                    //存入显示下一个形状的表格
                    this.table2,
                    //存入显示当前关卡的label
                    this.label1,
                    //存入显示消灭行数的label
                    this.label2,
                    //存入显示当前分数的label
                    this.label3,
                    //存入显示下落方块的label
                    this.label4
                }
            };
            //双人合作
            this.tabPage2.Tag = new Control[][]{
                //玩家一
                new Control[]{
                    //存入显示数据的表格
                    this.table3,
                    //存入显示下一个的表格
                    this.table5,
                    //存入显示当前关卡的label
                    this.label11,
                    //存入显示消灭行数的label
                    this.label12,
                    //存入显示分数的label
                    this.label10,
                    //存入显示下落方块数量的label
                    this.label9
                },
                //玩家二
                new Control[]{
                    //存入显示数据的表格
                    this.table3,
                    //存入显示下一个的表格
                    this.table4,
                    //存入显示当前关卡的label
                    this.label7,
                    //存入显示消灭行数的label
                    this.label8,
                    //存入显示分数的label
                    this.label6,
                    //存入显示下落方块数量的label
                    this.label5
                }
            };
            //将双人对抗存入页面3的Tag中
            this.tabPage3.Tag = new Control[][]{
                //玩家一
                new Control[]{
                    //存入显示数据的表格
                    this.table7,
                    //存入显示下一个的表格
                    this.table6,
                    //存入显示当前关卡的label
                    this.label15,
                    //存入显示消灭行数的label
                    this.label16,
                    //存入显示分数的label
                    this.label14,
                    //存入显示下落方块数量的label
                    this.label13
                },
                //玩家二
                new Control[]{
                    //存入显示数据的表格
                    this.table9,
                    //存入显示下一个的表格
                    this.table8,
                    //存入显示当前关卡的label
                    this.label19,
                    //存入显示消灭行数的label
                    this.label20,
                    //存入显示分数的label
                    this.label18,
                    //存入显示下落方块数量的label
                    this.label17
                }
            };
            #endregion
        }
        /// <summary>焦点取消事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_Leave(object sender, EventArgs e)
        {
            //判断是否暂停了
            if (!Program.GameForm.IsStop)
            {
                //焦点回来
                (sender as Control).Focus();
            }
        }
        /// <summary>点击键位触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //调用操作方法
            Program.GameForm.GB.Exec(Static.Tetris.GetInstallOrder(e.KeyCode));
        }
    }
}
