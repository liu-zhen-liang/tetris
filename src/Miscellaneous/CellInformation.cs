using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LZLTetris
{
    /// <summary>存储当前单元格的信息：是否被选择bool，是否是活动单元格，单元格显示颜色
    /// 
    /// </summary>
    public struct CellInformation
    {
        /// <summary>创建当前对象并赋值初始值
        /// 
        /// </summary>
        /// <param name="isSelect">是否被选中</param>
        /// <param name="isActive">判断是否为活动的单元格</param>
        /// <param name="showColor">表格显示的颜色</param>
        /// <param name="shapeObject">包含他的形状对象</param>
        public CellInformation(bool isSelect, bool isActive, Color showColor, TetrisItmeBase shapeObject)
        {
            //赋值
            this._isSelect = isSelect;
            this._isActive = isActive;
            this._showColor = showColor;
            this._shapeObject = shapeObject;
        }
        private bool _isSelect;
        /// <summary>是否被选中
        /// 
        /// </summary>
        public bool IsSelect
        {
            get { return _isSelect; }
            set { _isSelect = value; }
        }
        private bool _isActive;
        /// <summary>判断是否为活动的单元格【活动的单元格代表，正在移动的形状，就是活动的单元格】
        /// 
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private Color _showColor;
        /// <summary>表格显示的颜色【隐形模式中有用】
        /// 
        /// </summary>
        public Color ShowColor
        {
            get { return _showColor; }
            set { _showColor = value; }
        }
        private TetrisItmeBase _shapeObject;
        /// <summary>存储当前单元格包括在那个形状对象中
        /// 
        /// </summary>
        public TetrisItmeBase ShapeObject
        {
            get { return _shapeObject; }
            set { _shapeObject = value; }
        }
        /// <summary>将当前对象重置为默认状态
        /// 
        /// </summary>
        public void Reset()
        {
            //设置当前值为默认状态
            this._isActive = false;
            this._isSelect = false;
            this._shapeObject = null;
            this._showColor = Color.Transparent;
        }
        /// <summary>设置属性值方法
        /// 
        /// </summary>
        /// <param name="isSelect">是否被选中</param>
        /// <param name="isActive">判断是否为活动的单元格</param>
        /// <param name="showColor">表格显示的颜色</param>
        /// <param name="shapeObject">包含他的形状对象</param>
        public void SetAttribute(bool isSelect, bool isActive, Color showColor, TetrisItmeBase shapeObject)
        {
            //赋值
            this._isSelect = isSelect;
            this._isActive = isActive;
            this._showColor = showColor;
            this._shapeObject = shapeObject;
        }
        /// <summary>强当前对象转换成字符串形式
        /// 
        /// </summary>
        /// <returns>当前对象字符串副本</returns>
        public override string ToString()
        {
            //返回字符串副本
            return "[" +
                (this._isSelect ? "被选中" : "没有被选中")
                + "," +
                (this._isActive ? "是活动的单元格" : "不是活动的单元格")
                + ",[" +
                this._shapeObject.ID.ToString()
                + "]," +
                this._showColor.ToString()
                + "]";
        }
    }
}
