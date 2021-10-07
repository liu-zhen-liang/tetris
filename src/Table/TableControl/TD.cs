using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>表格单元格对象
    /// 
    /// </summary>
    public class TD : TableControl, IDraw
    {
        /// <summary>创建此单元格对象并设置初始值
        /// 
        /// </summary>
        /// <param name="table">爷爷表格对象</param>
        /// <param name="tr">父行对象</param>
        /// <param name="tableIndex">当前单元格所在表格的索引位置</param>
        /// <param name="backgroundColor">单元格背景颜色</param>
        /// <param name="backgroundBrush">单元格填充背景画刷</param>
        /// <param name="backgroundPicture">单元格背景图片</param>
        /// <param name="bounds">当前单元格有效范围</param>
        public TD(Table table, TR tr, TableIndex tableIndex, Color backgroundColor, Brush backgroundBrush, Image backgroundPicture, Rectangle bounds)
            : base(backgroundColor, backgroundBrush, backgroundPicture, bounds)
        {
            //赋值
            this._table = table;
            this._tr = tr;
            this._tableIndex = tableIndex;
        }
        /// <summary>【内部使用】更改当前单元格范围
        /// 
        /// </summary>
        /// <param name="bounds">单元格范围</param>
        internal void SetTD(Rectangle bounds)
        {
            //设置当前单元格范围
            base._bounds = bounds;
        }
        private Table _table;
        /// <summary>当前单元格的爷爷表格对象
        /// 
        /// </summary>
        public Table Table
        {
            get { return _table; }
            set { _table = value; }
        }
        private TR _tr;
        /// <summary>当前单元格的父行对象
        /// 
        /// </summary>
        public TR TR
        {
            get { return _tr; }
        }
        private TableIndex _tableIndex;
        /// <summary>获取当前单元格在表格的索引位置
        /// 
        /// </summary>
        public TableIndex TableIndex
        {
            get { return _tableIndex; }
        }
        /// <summary>获取与设置单元格背景颜色
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
                //调用设置背景颜色方法
                this.Draw(value, true);
            }
        }
        /// <summary>获取与设置单元格填充画笔
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
                //调用设置画刷方法
                this.Draw(value, true);
            }
        }
        /// <summary>获取与设置单元格背景图片
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
                //调用设置图片方法
                this.Draw(value, true);
            }
        }
        /// <summary>刷新背景方法
        /// 
        /// </summary>
        public void Reset()
        {
            //先填充背景颜色
            this.Table.GDI.FillRectangle(new SolidBrush(this.Table.BackColor), this.Bounds);
            //判断是否有图像
            if (this.Table.TheOriginalBackgroundImage != null)
            {
                //得到边框宽度
                int b = this.Table.BorderWide;
                //得到图像宽度
                int wide = this.Table.TheOriginalBackgroundImage.Width;
                int heig = this.Table.TheOriginalBackgroundImage.Height;
                //得到坐标// + ((this._tableIndex.CellIndex + 1) * this.Table.BorderWide))//+ ((this._tableIndex.RowIndex + 1) * this.Table.BorderWide))
                Point p = new Point(this._bounds.X - b % wide, this._bounds.Y - b % heig);
                //得到大小
                Size s = new Size((this._bounds.Width + b) % wide, (this._bounds.Height + b) % heig);
                //得到盒子
                Rectangle rg = new Rectangle(p, s);
                //得到图片盒子大小
                Rectangle imageRt;
                //判断盒子是否在图片中如果不在就更改盒子
                if (!(imageRt = new Rectangle(new Point(0, 0), this.Table.TheOriginalBackgroundImage.Size)).Contains(rg))
                {
                    //更改x与y轴位置
                    int x = wide - s.Width;
                    int y = heig - s.Height;
                    //判断x或y是否小于0
                    if (x < 0 || y < 0)
                    {
                        //更改盒子为图片大小
                        rg = imageRt;
                    }
                    else
                    {
                        //更改盒子的x与y轴
                        rg.X = x;
                        rg.Y = y;
                    }
                }
                //显示指定位置的图片【因为图片有可能会小于当前图片所以用%来防止出现BUG】
                Bitmap bp = this.Table.TheOriginalBackgroundImage.Clone(rg, this.Table.TheOriginalBackgroundImage.PixelFormat);
                //填充为默认图片信息
                this.Table.GDI.FillRectangle(new TextureBrush(bp), this.Bounds);
            }
        }
        /// <summary>开始设置当前对象的背景颜色、绘制背景的画笔、背景图片
        /// 
        /// </summary>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(bool isRefresh)
        {
            //调用填充颜色方法
            this.Draw(this.BackgroundColor, isRefresh);
            //判断画刷对象是否为null
            if (this.BackgroundBrush != null)
            {
                //调用设置背景颜色为画刷的方法
                this.Draw(this.BackgroundBrush, isRefresh);
            }
            //判断图片是否为空
            if (this.BackgroundPicture != null)
            {
                //调用设置背景图片的方法
                this.Draw(this.BackgroundPicture, isRefresh);
            }
        }
        /// <summary>绘制背景颜色
        /// 
        /// </summary>
        /// <param name="color">绘制的背景颜色</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Color color, bool isRefresh)
        {
            ////得到显示当前表格的背景颜色信息
            //Bitmap bp = this.Table.TableShowBitmap.Clone(this._bounds, this.Table.TableShowBitmap.PixelFormat);
            ////填充为默认图片信息
            //this.Table.GDI.FillRectangle(new TextureBrush(bp), this.Bounds);
            //判断是否需要刷新背景
            if (isRefresh)
                //调用刷新方法
                this.Reset();
            //调用父类的GDI对象的填充方法
            this.Table.GDI.FillRectangle(new SolidBrush(color), this.Bounds);
        }
        /// <summary>用画笔绘制背景
        /// 
        /// </summary>
        /// <param name="br">画笔对象</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Brush br, bool isRefresh)
        {
            //判断画刷对象是否为null
            if (br == null) return;
            //判断是否需要刷新背景
            if (isRefresh)
                //调用刷新方法
                this.Reset();
            //调用表格对象的填充方法
            this.Table.GDI.FillRectangle(br, this.Bounds);
        }
        /// <summary>绘制背景图片
        /// 
        /// </summary>
        /// <param name="image">背景图片</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        public void Draw(Image image, bool isRefresh)
        {
            //判断传入对象是否为null，如果为null就退出
            if (image == null) return;
            //判断是否需要刷新背景
            if (isRefresh)
                //调用刷新方法
                this.Reset();
            //调用表格的对象的GDI+对象的填充方法
            this.Table.GDI.FillRectangle(new TextureBrush(new Bitmap(image, this.Size)), this.Bounds);
        }
        /// <summary>判断两个对象是否一致方法
        /// 
        /// </summary>
        /// <param name="obj">判断的对象</param>
        /// <returns>true表示匹配，false代表不匹配</returns>
        public override bool Equals(object obj)
        {
            //判断传入的判断对象是否为null
            if (obj == null) return false;
            //将对象转换成当前对象
            TD td = obj as TD;
            //判断是否转换成功
            if (td == null) return false;
            //判断两个对象的所在单元格索引是否一致
            return td._tableIndex == this._tableIndex &&
                td._bounds == this._bounds &&
                td.BackgroundColor == this.BackgroundColor &&
                td.Size == this.Size &&
                object.ReferenceEquals(td._table, this._table) &&
                object.ReferenceEquals(td._tr, this._tr) &&
                td.BackgroundBrush == this.BackgroundBrush &&
                td.BackgroundPicture == this.BackgroundPicture &&
                td.Tag == td.Tag;
        }
    }
}
