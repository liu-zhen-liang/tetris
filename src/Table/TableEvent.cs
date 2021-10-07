using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsTableControl
{
    public partial class Table
    {
        /// <summary>鼠标在控件上方移动事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableMouseEventArgs> MouseMove;
        /// <summary>鼠标在控件上方点击按钮触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableMouseEventArgs> MouseDown;
        /// <summary>鼠标在控件上方点击鼠标按钮触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableMouseEventArgs> MouseClick;
        /// <summary>鼠标在控件上方双击按钮触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableMouseEventArgs> MouseDoubleClick;
        /// <summary>单击控件触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableEventArgs> Click;
        /// <summary>双击控件触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableEventArgs> DoubleClick;
        /// <summary>鼠标在控件上方静止一段时间触发的事件
        /// 
        /// </summary>
        public new event TableDelegate<Table, TableEventArgs> MouseHover;

        /// <summary>通过鼠标事件对象来获取表格事件对象
        /// 
        /// </summary>
        /// <param name="e">鼠标事件对象</param>
        /// <returns>表格鼠标事件对象</returns>
        private TableMouseEventArgs GetTableMouseEventArgs(MouseEventArgs e)
        {
            //创建存储行对象与单元格对象
            TR tr = null;
            TD td = null;
            //获取当前坐标位置的行对象
            tr = this.GetCoordinateTR(e.Location);
            //判断当前位置是否有行对象，如果有就获取单元格对象否则不获取
            if (tr != null) td = tr.GetCoordinateTD(e.Location);
            //返回表格鼠标事件对象
            return new TableMouseEventArgs(tr, td, e.Location, e.Button, e.Clicks, e.Delta);
        }
        /// <summary>通过上次移动的坐标位置来获取表格事件对象
        /// 
        /// </summary>
        /// <returns>表格事件对象</returns>
        private TableEventArgs GetTableEventArgs()
        {
            //创建存储行对象、单元格对象的变量
            TR tr = null;
            TD td = null;
            //获取行对象
            tr = this.GetCoordinateTR(this.lastLocation);
            //判断是否获取到了行对象，如果获取到了就获取单元格对象
            if (tr != null) td = this.GetCoordinateTD(this.lastLocation);
            //返回表格数据对象
            return new TableEventArgs(tr, td, this.lastLocation);
        }
        /// <summary>存储上次移动的坐标位置的变量
        /// 
        /// </summary>
        private Point lastLocation = new Point(0, 0);
        /// <summary>鼠标在控件中移动触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前控件对象</param>
        /// <param name="e">事件对象</param>
        private void Table_MouseMove(object sender, MouseEventArgs e)
        {
            //记录当前移动的位置到上次移动位置的变量中
            this.lastLocation = e.Location;
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.MouseMove != null)
            {
                //触发鼠标在控件上方移动触发的事件，并调用获取表格事件对象来获取表格鼠标事件对象
                this.MouseMove(this, this.GetTableMouseEventArgs(e));
            }
        }
        /// <summary>鼠标在控件内按下鼠标按钮触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前Table控件</param>
        /// <param name="e">事件对象</param>
        private void Table_MouseDown(object sender, MouseEventArgs e)
        {
            //记录当前移动的位置到上次移动位置的变量中
            this.lastLocation = e.Location;
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.MouseDown != null)
            {
                //触发鼠标在控件上方按下按钮触发的事件，并调用获取表格事件对象来获取表格鼠标事件对象
                this.MouseDown(this, this.GetTableMouseEventArgs(e));
            }
        }
        /// <summary>鼠标在控件内单击按钮触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前Table对象</param>
        /// <param name="e">事件对象</param>
        private void Table_MouseClick(object sender, MouseEventArgs e)
        {
            //记录当前移动的位置到上次移动位置的变量中
            this.lastLocation = e.Location;
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.MouseClick != null)
            {
                //触发鼠标在控件上方点击鼠标按钮触发的事件，并调用获取表格事件对象来获取表格鼠标事件对象
                this.MouseClick(this, this.GetTableMouseEventArgs(e));
            }
        }
        /// <summary>鼠标在控件内双击鼠标按钮触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前表格对象</param>
        /// <param name="e">事件对象</param>
        private void Table_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //记录当前移动的位置到上次移动位置的变量中
            this.lastLocation = e.Location;
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.MouseDoubleClick != null)
            {
                //触发鼠标在控件上方双击按钮触发的事件，并调用获取表格事件对象来获取表格鼠标事件对象
                this.MouseDoubleClick(this, this.GetTableMouseEventArgs(e));
            }
        }
        /// <summary>单击控件触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前Table控件对象</param>
        /// <param name="e">事件对象</param>
        private void Table_Click(object sender, EventArgs e)
        {
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.Click != null)
            {
                //调用单击事件对象，并触发方法
                this.Click(this, this.GetTableEventArgs());
            }
        }
        /// <summary>双击控件触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前Table对象</param>
        /// <param name="e">事件对象</param>
        private void Table_DoubleClick(object sender, EventArgs e)
        {
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.DoubleClick != null)
            {
                //调用双击事件方法，并触发方法
                this.DoubleClick(this, this.GetTableEventArgs());
            }
        }
        /// <summary>鼠标停留在控件上方一段时间触发的事件
        /// 
        /// </summary>
        /// <param name="sender">当前触发事件的Table对象</param>
        /// <param name="e">事件对象</param>
        private void Table_MouseHover(object sender, EventArgs e)
        {
            //判断要触发的事件是否为空，不为空就触发事件
            if (this.MouseHover != null)
            {
                //触发鼠标在控件上方静止一段时间触发的事件
                this.MouseHover(this, this.GetTableEventArgs());
            }
        }
    }
}
