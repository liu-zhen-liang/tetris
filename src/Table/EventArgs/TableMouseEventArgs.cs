using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsTableControl
{
    /// <summary>表格控件鼠标操作事件信息对象
    /// 
    /// </summary>
    public class TableMouseEventArgs : EventArgs
    {
        /// <summary>创建此事件并赋值
        /// 
        /// </summary>
        /// <param name="tr">触发事件的行对象，如果没有行对象触发此事件就为null</param>
        /// <param name="td">触发事件的单元格对象，如果没有单元格触发此事件就为null</param>
        /// <param name="location">触发此事件坐标位置</param>
        /// <param name="button">获得点击的按钮</param>
        /// <param name="clicks">获取按下并释放鼠标按钮的次数</param>
        /// <param name="delta">获取鼠标轮已转动的制动器数的有符号计数。制动器是鼠标轮的一个凹口</param>
        public TableMouseEventArgs(TR tr, TD td, Point location, MouseButtons button, int clicks, int delta)
        {
            //赋值
            this._tr = tr;
            this._td = td;
            this._location = location;
            this._button = button;
            this._clicks = clicks;
            this._delta = delta;
        }
        //变量
        //行对象
        private TR _tr;
        //单元格对象
        private TD _td;
        //坐标位置
        private Point _location;
        //点击的鼠标按钮
        private MouseButtons _button;
        //点击按钮的次数
        private int _clicks;
        //鼠标滑轮制动器数的有符号计数
        private int _delta;
        /// <summary>触发事件的行对象，如果没有行对象触发此事件就为null
        /// 
        /// </summary>
        public TR TR { get { return this._tr; } }
        /// <summary>触发事件的单元格对象，如果没有单元格触发此事件就为null
        /// 
        /// </summary>
        public TD TD { get { return this._td; } }
        /// <summary>触发此事件坐标位置
        /// 
        /// </summary>
        public Point Location { get { return this._location; } }
        /// <summary>获得点击的按钮
        /// 
        /// </summary>
        public MouseButtons Button { get { return this._button; } }
        /// <summary>获取按下并释放鼠标按钮的次数。
        /// 
        /// </summary>
        public int Clicks { get { return this._clicks; } }
        /// <summary>获取鼠标轮已转动的制动器数的有符号计数。制动器是鼠标轮的一个凹口。
        /// 
        /// </summary>
        public int Delta { get { return this._delta; } }
        /// <summary>点击的X轴坐标
        /// 
        /// </summary>
        public int X { get { return this._location.X; } }
        /// <summary>点击的Y轴坐标
        /// 
        /// </summary>
        public int Y { get { return this._location.Y; } }
    }
}
