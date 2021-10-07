using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LZLTetris.Static.DataObject
{
    /// <summary>存储LZ俄罗斯方块的背景图片类
    /// 
    /// </summary>
    [Serializable]
    public class Img 
    {
        /// <summary>创建当前对象并进行赋值
        /// 
        /// </summary>
        /// <param name="commonImage">默认背景</param>
        /// <param name="menuValue">模糊的值</param>
        /// <param name="name">当前背景的名称</param>
        public Img(Image commonImage, float menuValue, string name)
        {
            //赋值
            this._commonImage = commonImage;
            //判断是否需要进行模糊处理
            if (menuValue != 0f)
            {
                //进行模糊处理
                this._menuImage = (Image)Gaussian.FilterProcessImage((double)menuValue, new Bitmap(commonImage));
            }
            else
            {
                //直接赋值
                this._menuImage = commonImage;
            }
            this._menuValue = menuValue;
            this._name = name;
        }
        /// <summary>创建当前对象并进行赋值
        /// 
        /// </summary>
        /// <param name="commonImage">没有进行模糊触发的图片</param>
        /// <param name="menuImage">菜单的背景【有可能进行模糊处理】</param>
        /// <param name="menuValue">模糊的值</param>
        /// <param name="name">当前背景的名称</param>
        public Img(Image commonImage, Image menuImage, float menuValue, string name)
        {
            //赋值
            this._commonImage = commonImage;
            this._menuImage = menuImage;
            this._menuValue = menuValue;
            this._name = name;
        }
        private Image _commonImage;
        /// <summary>用于存储默认显示的没有进行模糊的图片
        /// 
        /// </summary>
        public Image CommonImage
        {
            get { return _commonImage; }
            set { _commonImage = value; }
        }
        private Image _menuImage;
        /// <summary>用于存储菜单的背景，有可能进行模糊处理了
        /// 
        /// </summary>
        public Image MenuImage
        {
            get { return _menuImage; }
            set { _menuImage = value; }
        }
        private float _menuValue;
        /// <summary>模糊的值
        /// 
        /// </summary>
        public float MenuValue
        {
            get { return _menuValue; }
            set
            {
                //判断值是否是新值
                if (this._menuValue != value)
                {
                    //赋值
                    this._menuValue = value;
                    //判断模糊程度是否为0，如果为0就不需要进行模糊了
                    if (value == 0f)
                    {
                        //直接赋值
                        this._menuImage = this._commonImage;
                    }
                    else
                    {
                        //进行高斯模糊处理
                        this._menuImage = (Image)Gaussian.FilterProcessImage((double)value, new Bitmap(this._commonImage));
                    }
                }
            }
        }
        private string _name;
        /// <summary>当前背景的名称
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>判断两个对象是否一致
        /// 
        /// </summary>
        /// <param name="obj">要进行判断的对象</param>
        /// <returns>true代表一致false代表不一致</returns>
        public override bool Equals(object obj)
        {
            //判断用于比较的对象是否为null
            if (obj == null) return false;
            //将对象转换成当前类型的对象
            Img img = obj as Img;
            //判断是否转换成功如果转换失败就返回null
            if (img == null) return false;
            //开始匹配
            return this._commonImage == img._commonImage
                && this._menuImage == img._menuImage
                && this._menuValue == img._menuValue
                && this._name == img._name;
        }
    }
}
