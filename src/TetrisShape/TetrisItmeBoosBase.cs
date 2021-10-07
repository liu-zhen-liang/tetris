using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris.TetrisShape
{
    /// <summary>俄罗斯方块Boss形状父对象
    /// 
    /// </summary>
    public class TetrisItmeBossBase : TetrisItmeBase
    {
        protected bool[] _isFixedColorList;
        /// <summary>颜色是固定颜色还是活动颜色集合
        /// 
        /// </summary>
        public bool[] IsFixedColorList
        {
            get { return _isFixedColorList; }
            set { _isFixedColorList = value; }
        }
        protected Color _fixedColor;
        /// <summary>固定颜色
        /// 
        /// </summary>
        public Color FixedColor
        {
            get { return _fixedColor; }
            set { _fixedColor = value; }
        }
        /// <summary>设置新位置方法
        /// 
        /// </summary>
        /// <param name="ti">新位置</param>
        protected override void SetShapeNewIndex(WindowsTableControl.TableIndex[] ti)
        {
            //将原来形状的各个索引位置元素重置
            for (int i = 0; i < this._tetrisItmeTable.Length; i++)
            {
                int j;
                //内层循环中找是否有重复项如果有就不重置属性
                for (j = 0; j < ti.Length; j++)
                {
                    //判断是否匹配
                    if (this._tetrisItmeTable[i] == ti[j])
                    {
                        //退出循环
                        break;
                    }
                }
                //判断要是否要重置属性【j等于这个代表已经循环完成最后一个了】
                if (j == ti.Length)
                {
                    //重置属性
                    this._containerTable[this._tetrisItmeTable[i]].ResetAttribute();
                }
            }
            //设置当前形状索引位置的元素设置为指定属性与颜色信息
            for (int i = 0; i < ti.Length; i++)
            {
                //得到单元格对象
                TD td = this._containerTable[ti[i]];
                //按照是否为固定颜色设置颜色
                if (this._isFixedColorList[i])//固定颜色
                {
                    //设置单元格背景颜色
                    td.BackgroundColor = this._fixedColor;
                    //设置属性值
                    td.Tag = new CellInformation(true, true, this._fixedColor, this);
                }
                else//活动颜色
                {
                    //设置单元格背景颜色
                    td.BackgroundColor = this._showColor;
                    //设置属性值
                    td.Tag = new CellInformation(true, true, this._showColor, this);
                }
            }
            //设置当前的索引坐标数组位置
            this._tetrisItmeTable = ti;
        }
        /// <summary>部署方法，将当前形状部署在表格中，如果部署成功返回true，否则返回false
        /// 
        /// </summary>
        /// <returns>部署成功返回true否则返回false</returns>
        public override bool Deploy()
        {
            //得到验证部署的结果
            bool boo = this.IsEffective(this._tetrisItmeTable);
            //将当前形状添加到表格控件中
            for (int i = 0; i < this._tetrisItmeTable.Length; i++)
            {
                //更改颜色
                this._containerTable[this._tetrisItmeTable[i]].BackgroundColor = this._isFixedColorList[i] ? this._fixedColor : this._showColor;
            }
            //返回验证结果
            return boo;
        }
    }
}
