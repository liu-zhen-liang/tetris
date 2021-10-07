using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>表格事件对象
    /// 
    /// </summary>
    public class TableEventArgs : EventArgs
    {
        /// <summary>创建当前事件对象并赋值
        /// 
        /// </summary>
        /// <param name="tr">触发事件的行对象</param>
        /// <param name="td">触发事件的单元格对象</param>
        /// <param name="location">触发事件的位置</param>
        public TableEventArgs(TR tr, TD td, Point location)
        {
            //赋值
            this._tr = tr;
            this._td = td;
            this._location = location;
        }
        //变量
        //行对象
        private TR _tr;
        //单元格对象
        private TD _td;
        //坐标位置
        private Point _location;
        /// <summary>触发事件的行对象，如果没有行对象触发此事件就为null
        /// 
        /// </summary>
        public TR TR { get { return this._tr; } }
        /// <summary>触发事件的单元格对象，如果没有单元格触发此事件就为null
        /// 
        /// </summary>
        public TD TD { get { return this._td; } }
        /// <summary>触发此事件上个坐标位置【不一定正确】
        /// 
        /// </summary>
        public Point Location { get { return this._location; } }
        /// <summary>触发此事件上个坐标位置【不一定正确】X轴坐标
        /// 
        /// </summary>
        public int X { get { return this._location.X; } }
        /// <summary>触发此事件上个坐标位置【不一定正确】Y轴坐标
        /// 
        /// </summary>
        public int Y { get { return this._location.Y; } }
    }
}
