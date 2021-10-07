using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>表格行对象
    /// 
    /// </summary>
    public class TR : TableControl, IDraw
    {
        /// <summary>创建行对象并设置初始值
        /// 
        /// </summary>
        /// <param name="table">父表格对象</param>
        /// <param name="tds">子单元格数组</param>
        /// <param name="rowIndex">当前行对象所在表格对象的行索引位置</param>
        /// <param name="backgroundColor">行对象背景颜色</param>
        /// <param name="backgroundBrush">行对象填充背景的画刷对象</param>
        /// <param name="backgroundPicture">行对象的背景图片</param>
        /// <param name="bounds">行对象范围</param>
        public TR(Table table, TD[] tds, int rowIndex, Color backgroundColor, Brush backgroundBrush, Image backgroundPicture, Rectangle bounds)
            : base(backgroundColor, backgroundBrush, backgroundPicture, bounds)
        {
            //赋值
            this._table = table;
            this.tds = tds;
            this._rowIndex = rowIndex;
        }
        /// <summary>【内部使用】设置当前行对象范围
        /// 
        /// </summary>
        /// <param name="bounds">行对象范围</param>
        internal void SetTR(Rectangle bounds)
        {
            //更改当前tr的范围
            base._bounds = bounds;
        }
        /// <summary>根据指定索引获取指定索引位置的单元格对象
        /// 
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <returns>单元格对象</returns>
        public TD this[int index]
        {
            get { return this.tds[index]; }
        }
        private Table _table;
        /// <summary>获取父表格对象
        /// 
        /// </summary>
        public Table Table
        {
            get { return _table; }
        }
        private TD[] tds;
        /// <summary>获取当前行对象的单元格数量
        /// 
        /// </summary>
        public int Length { get { return this.tds.Length; } }
        private int _rowIndex;
        /// <summary>获取当前行对象所在表格对象的行索引位置
        /// 
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
        }
        /// <summary>获取与设置当前行的背景颜色
        /// 
        /// </summary>
        public override Color BackgroundColor
        {
            get
            {
                return base.BackgroundColor;
            }
            set
            {
                base.BackgroundColor = value;
                //调用设置背景颜色的方法
                this.Draw(value, true);
            }
        }
        /// <summary>获取与设置当前行对象的填充背景画刷
        /// 
        /// </summary>
        public override Brush BackgroundBrush
        {
            get
            {
                return base.BackgroundBrush;
            }
            set
            {
                base.BackgroundBrush = value;
                //调用设置背景画刷的方法
                this.Draw(value, true);
            }
        }
        /// <summary>获取与设置当前行对象的背景图片
        /// 
        /// </summary>
        public override Image BackgroundPicture
        {
            get
            {
                return base.BackgroundPicture;
            }
            set
            {
                base.BackgroundPicture = value;
                //调用设置当前背景图片的方法
                this.Draw(value, true);
            }
        }
        /// <summary>得到指定位置的单元格对象
        /// 
        /// </summary>
        /// <param name="location">指定坐标位置</param>
        /// <returns>单元格对象</returns>
        public TD GetCoordinateTD(Point location)
        {
            //判断如果没有输入可行值的话就退出方法
            if (this.Table.TdSize.IsEmpty) return null;
            //判断当前索引位置是否在当前行对象范围中，如果没有就直接返回null
            if (!this.Contains(location)) return null;
            //得到【行对象认为的单元格宽度】【为了快速检索就将单元格左边的边框也认为是单元格的【但是单元格不认为是他的】】计算公式：【边框宽度+单元格宽度】
            int wide = this.Table.TdSize.Width + this.Table.BorderWide;
            //计算得到X轴位置的单元格对象的索引位置利用计算公式：【(X/(边框宽度+单元格宽度))-((X%(边框宽度+单元格宽度))==0?1:0)】
            int index = (location.X / wide) - (location.X % wide == 0 ? 1 : 0);
            //判断索引是否超过单元格数组范畴，如果超过就返回null
            if (index >= this.tds.Length || index < 0) return null;
            //调用指定单元格的判断范围方法，判断指定坐标是否在当前单元格内，如果不在就返回null，否则返回当前选中单元格
            if (this.tds[index].Contains(location))
            {
                //返回当前选中的单元格
                return this.tds[index];
            }
            else
            {
                //返回null
                return null;
            }
        }
        /// <summary>开始设置当前对象的背景颜色、绘制背景的画笔、背景图片
        /// 
        /// </summary>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(bool isRefresh)
        {
            //设置背景颜色
            this.Draw(this.BackgroundColor, isRefresh);
            //判断填充背景的画刷是否为空
            if (this.BackgroundBrush != null)
            {
                //调用设置填充背景画刷的方法
                this.Draw(this.BackgroundBrush, isRefresh);
            }
            //判断填充背景的图片是否为空
            if (this.BackgroundPicture != null)
            {
                //调用设置背景图片的方法
                this.Draw(this.BackgroundPicture, isRefresh);
            }
            //循环调用单元格的刷新方法
            for (int i = 0; i < this.tds.Length; i++)
            {
                //刷新颜色方法
                this.tds[i].Draw(isRefresh);
            }
        }
        /// <summary>绘制背景颜色
        /// 
        /// </summary>
        /// <param name="color">绘制的背景颜色</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Color color, bool isRefresh)
        {
            //循环调用当前行对象的所有单元格对象的设置背景颜色方法
            for (int i = 0; i < this.tds.Length; i++)
            {
                //设置背景颜色
                this.tds[i].Draw(color, isRefresh);
            }
            //循环调用单元格的刷新方法
            for (int i = 0; i < this.tds.Length; i++)
            {
                //刷新颜色方法
                this.tds[i].Draw(isRefresh);
            }
        }
        /// <summary>用画笔绘制背景
        /// 
        /// </summary>
        /// <param name="br">画笔对象</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Brush br, bool isRefresh)
        {
            //判断画刷是否为null，如果为null就退出
            if (br == null) return;
            //循环给当前行对象的所有单元格对象设置填充画刷
            for (int i = 0; i < this.tds.Length; i++)
            {
                //设置填充画刷
                this.tds[i].Draw(br, isRefresh);
            }
            //循环调用单元格的刷新方法
            for (int i = 0; i < this.tds.Length; i++)
            {
                //刷新颜色方法
                this.tds[i].Draw(isRefresh);
            }
        }
        /// <summary>绘制背景图片
        /// 
        /// </summary>
        /// <param name="image">背景图片</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Image image, bool isRefresh)
        {
            //判断背景图片是否为null如果为null就退出
            if (image == null) return;
            //设置当前行对象的所有单元格对象的背景图片
            for (int i = 0; i < this.tds.Length; i++)
            {
                //设置背景图片
                this.tds[i].Draw(image, isRefresh);
            }
            //循环调用单元格的刷新方法
            for (int i = 0; i < this.tds.Length; i++)
            {
                //刷新颜色方法
                this.tds[i].Draw(isRefresh);
            }
        }
        /// <summary>判断两个行对象是否一致
        /// 
        /// </summary>
        /// <param name="obj">判断的行对象</param>
        /// <returns>true为一致，false为不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入的对象是否为null
            if (obj == null) return false;
            //将对象转换成行对象
            TR tr = obj as TR;
            //判断是否转换成功
            if (tr == null) return false;
            //判断参数是否匹配
            return (
                tr._bounds == this._bounds &&
                tr._rowIndex == this._rowIndex &&
                object.ReferenceEquals(tr._table, this._table) &&
                tr.BackgroundBrush == this.BackgroundBrush &&
                tr.BackgroundColor == this.BackgroundColor &&
                tr.BackgroundPicture == this.BackgroundPicture &&
                tr.Length == this.Length &&
                tr.Size == this.Size &&
                tr.Tag == this.Tag
                );
        }
    }
}
