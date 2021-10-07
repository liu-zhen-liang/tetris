using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZLTetris
{
    /// <summary>控件组类【将一些控件逻辑绑定在一起】
    /// 
    /// </summary>
    public class ControlGroup : List<Control>
    {
        /// <summary>创建当前控件组对象并设置名称
        /// 
        /// </summary>
        /// <param name="name">名称</param>
        public ControlGroup(string name)
        {
            //赋值
            this._name = name;
        }
        /// <summary>创建当前对象并进行赋值
        /// 
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="tag">数据</param>
        public ControlGroup(string name, object tag)
            : this(name)
        {
            //赋值
            this._tag = tag;
        }
        private BrothersControlGroup _brothersControlGroup = new BrothersControlGroup();
        /// <summary>得到当前控件组类的兄弟【同级】控件组类的对象
        /// 
        /// </summary>
        public BrothersControlGroup BrothersControlGroups
        {
            get { return _brothersControlGroup; }
            set { _brothersControlGroup = value; }
        }
        /// <summary>将所有控件的坐标偏移方法
        /// 
        /// </summary>
        /// <param name="x">偏移x轴量</param>
        /// <param name="y">偏移y轴量</param>
        public void CoordinateExcursion(int x, int y)
        {
            //循环进行偏移
            for (int i = 0; i < this.Count; i++)
            {
                //将坐标进行偏移
                this[i].Location.Offset(x, y);
            }
        }
        /// <summary>设置是否显示所有控件
        /// 
        /// </summary>
        public bool Visible
        {
            set
            {
                //循环进行设置
                for (int i = 0; i < this.Count; i++)
                {
                    //开始设置
                    this[i].Visible = value;
                }
            }
        }
        private string _name;
        /// <summary>获取或者设置当前控件组的名称
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private object _tag;
        /// <summary>用户自定义数据
        /// 
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        /// <summary>将当前对象转换成字符串形式
        /// 
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            return "[ Name = "
                + this._name +
                ",Count = "
                + this.Count.ToString() +
                "]";
        }
        /// <summary>设置背景图片
        /// 
        /// </summary>
        /// <param name="image">背景图片</param>
        public void SetImage(Image image)
        {
            //得到图片对象
            Bitmap bp = new Bitmap(image);
            //循环开始截取图片
            foreach (Control item in this)
            {
                //截取图片
                item.BackgroundImage = bp.Clone(new Rectangle(item.Location, item.Size), bp.PixelFormat);
            }
        }
        /// <summary>当前控件组类的兄弟控件组类集合
        /// 
        /// </summary>
        public class BrothersControlGroup : List<ControlGroup>
        {
            /// <summary>将所有控件的坐标偏移方法
            /// 
            /// </summary>
            /// <param name="x">偏移x轴量</param>
            /// <param name="y">偏移y轴量</param>
            public void CoordinateExcursion(int x, int y)
            {
                //循环进行偏移
                for (int i = 0; i < this.Count; i++)
                {
                    //调用控件组类的偏移方法
                    this[i].CoordinateExcursion(x, y);
                }
            }
            /// <summary>设置是否显示所有控件
            /// 
            /// </summary>
            public bool Visible
            {
                set
                {
                    //循环进行设置
                    for (int i = 0; i < this.Count; i++)
                    {
                        //开始设置
                        this[i].Visible = value;
                    }
                }
            }
        }
    }
}
