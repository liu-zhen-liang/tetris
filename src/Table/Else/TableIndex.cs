using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>指示在表格的指定单元格索引位置
    /// 
    /// </summary>
    public struct TableIndex : IEquatable<TableIndex>, IComparable<TableIndex>
    {
        /// <summary>创建此结构并赋值
        /// 
        /// </summary>
        /// <param name="rowIndex">所在行索引</param>
        /// <param name="cellIndex">所在列索引</param>
        public TableIndex(int rowIndex, int cellIndex)
        {
            //赋值
            this._rowIndex = rowIndex;
            this._cellIndex = cellIndex;
        }
        private int _rowIndex;
        /// <summary>所在行索引
        /// 
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }
        private int _cellIndex;
        /// <summary>所在列索引
        /// 
        /// </summary>
        public int CellIndex
        {
            get { return _cellIndex; }
            set { _cellIndex = value; }
        }
        /// <summary>将当前对象转换成字符串副本
        /// 
        /// </summary>
        /// <returns>当前对象的字符串副本</returns>
        public override string ToString()
        {
            return "[RowIndex=" + this._rowIndex.ToString() + ",CellIndex=" + this._cellIndex.ToString() + "]";
        }
        /// <summary>比较两个对象是否一致方法
        /// 
        /// </summary>
        /// <param name="other">用于比较的对象</param>
        /// <returns>true代表一致，false代表不一致</returns>
        public bool Equals(TableIndex other)
        {
            return this._cellIndex == other._rowIndex && this._cellIndex == other._cellIndex;
        }
        /// <summary>判断两个对象是否一致
        /// 
        /// </summary>
        /// <param name="obj">用于比较的对象</param>
        /// <returns>true代表一致，false代表不一致</returns>
        public override bool Equals(object obj)
        {
            //判断比较的对象是否为null
            if (obj == null) return false;
            //判断比较的对象是否可以转换成当前对象
            if (!(obj is TableIndex)) return false;
            //将用于比较的对象转换成当前对象
            TableIndex ti = (TableIndex)obj;
            //进行判断是否一致
            return ti._cellIndex == this._cellIndex && ti._rowIndex == this._rowIndex;
        }
        /// <summary>将当前对象转换成哈希值
        /// 
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            return this._cellIndex ^ this._rowIndex;
        }
        /// <summary>排序方法
        /// 
        /// </summary>
        /// <param name="other">用于比较的对象</param>
        /// <returns>一个值，指示要比较的对象的相对顺序。返回值的含义如下：值含义小于零此对象小于 other 参数。零此对象等于 other。大于零此对象大于 other。</returns>
        public int CompareTo(TableIndex other)
        {
            //先比较行大小
            int r = this._rowIndex - other._rowIndex;
            //判断是否不等于0，如果不等于0表示已经见分晓了，如果等于0就判断列大小
            if (r != 0) return r;
            //判断列大小
            return this._cellIndex - other._cellIndex;
        }
        /// <summary>判断两个表格索引对象是否不一致
        /// 
        /// </summary>
        /// <param name="ti1">对象1</param>
        /// <param name="ti2">对象2</param>
        /// <returns>判断结果，true为不一致，false为一致</returns>
        public static bool operator !=(TableIndex ti1, TableIndex ti2)
        {
            //返回判断结果
            return ti1._cellIndex != ti2._cellIndex || ti1._rowIndex != ti2._rowIndex;
        }
        /// <summary>判断两个表格索引对象是否一致
        /// 
        /// </summary>
        /// <param name="ti1">对象1</param>
        /// <param name="ti2">对象2</param>
        /// <returns>true为一致，false为不一致</returns>
        public static bool operator ==(TableIndex ti1, TableIndex ti2)
        {
            //判断是否一致
            return ti1._rowIndex == ti2._rowIndex && ti1._cellIndex == ti2._cellIndex;
        }
    }
}
