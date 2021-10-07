using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>表格控件的子控件父类
    /// 
    /// </summary>
    public class TableControl
    {
        /// <summary>创建对象并给当前对象的所有属性赋值
        /// 
        /// </summary>
        /// <param name="backgroundColor">控件背景颜色</param>
        /// <param name="backgroundBrush">填充控件背景的画刷对象</param>
        /// <param name="backgroundPicture">填充控件的背景图片</param>
        /// <param name="bounds">控件的有效范围</param>
        public TableControl(Color backgroundColor, Brush backgroundBrush, Image backgroundPicture, Rectangle bounds)
        {
            //赋值
            this._backgroundColor = backgroundColor;
            this._backgroundBrush = backgroundBrush;
            this._backgroundPicture = backgroundPicture;
            this._bounds = bounds;
            this._size = bounds.Size;
        }
        /// <summary>创建对象并给当前对象的所有属性赋值
        /// 
        /// </summary>
        /// <param name="backgroundColor">控件背景颜色</param>
        /// <param name="backgroundBrush">填充控件背景的画刷对象</param>
        /// <param name="backgroundPicture">填充控件的背景图片</param>
        /// <param name="bounds">控件的有效范围</param>
        /// <param name="tag">控件包含的数据</param>
        public TableControl(Color backgroundColor, Brush backgroundBrush, Image backgroundPicture, Rectangle bounds, object tag)
        {
            //赋值
            this._backgroundColor = backgroundColor;
            this._backgroundBrush = backgroundBrush;
            this._backgroundPicture = backgroundPicture;
            this._bounds = bounds;
            this._size = bounds.Size;
            this._tag = tag;
        }
        private Color _backgroundColor;
        /// <summary>获取与设置控件背景颜色
        /// 
        /// </summary>
        public virtual Color BackgroundColor
        {
            get
            {
                return this._backgroundColor;
            }
            set
            {
                this._backgroundColor = value;
            }
        }
        private Brush _backgroundBrush;
        /// <summary>获取与设置填充背景的画刷对象
        /// 
        /// </summary>
        public virtual Brush BackgroundBrush
        {
            get
            {
                return this._backgroundBrush;
            }
            set
            {
                this._backgroundBrush = value;
            }
        }
        private Image _backgroundPicture;
        /// <summary>获取与设置背景图片
        /// 
        /// </summary>
        public virtual Image BackgroundPicture
        {
            get
            {
                return this._backgroundPicture;
            }
            set
            {
                this._backgroundPicture = value; ;
            }
        }
        protected Rectangle _bounds;
        /// <summary>获取控件的有效范围属性
        /// 
        /// </summary>
        public Rectangle Bounds
        {
            get { return this._bounds; }
        }
        private Size _size;
        /// <summary>获取控件的范围
        /// 
        /// </summary>
        public Size Size
        {
            get { return this._size; }
        }
        private object _tag;
        /// <summary>获取与设置存储包含控件数据的对象
        /// 
        /// </summary>
        public object Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
            }
        }
        /// <summary>判断指定范围【矩形范围】是否在此对象中
        /// 
        /// </summary>
        /// <param name="rect">判断的矩形范围</param>
        /// <returns>true代表在当前控件范围内部，false代表不在当前控件内部</returns>
        public bool Contains(Rectangle rect)
        {
            //调用存储当前控件范围的矩形框对象的判断方法
            return this._bounds.Contains(rect);
        }
        /// <summary>判断指定坐标是否在此控件内部
        /// 
        /// </summary>
        /// <param name="pt">判断的坐标对象</param>
        /// <returns>true代表在此控件内部，false代表不在当前控件内部</returns>
        public bool Contains(Point pt)
        {
            //调用存储当前控件范围的矩形框对象的判断范围方法
            return this._bounds.Contains(pt);
        }
        /// <summary>判断指定坐标是否在此控件内部
        /// 
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <returns>true代表在此控件内部，false代表不在当前控件内部</returns>
        public bool Contains(int x, int y)
        {
            //调用存储当前控件范围的矩形框对象的判断方法
            return this._bounds.Contains(x, y);
        }
    }
}
