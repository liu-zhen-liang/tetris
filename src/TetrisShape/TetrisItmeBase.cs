using LZLTetris.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris
{
    /// <summary>俄罗斯方块形状父对象
    /// 
    /// </summary>
    public class TetrisItmeBase
    {
        /// <summary>创建对象【私有构造函数，防止创建当前对象】
        /// 
        /// </summary>
        protected TetrisItmeBase()
        {

        }
        protected int _form;
        /// <summary>当前俄罗斯方块的所在形态【从0开始】
        /// 
        /// </summary>
        public int Form
        {
            get { return this._form; }
        }
        protected int _formCount;
        /// <summary>存储当前俄罗斯方块对象的形态数量
        /// 
        /// </summary>
        public int FormCount
        {
            get { return this._formCount; }
        }
        protected Table _containerTable;
        /// <summary>容器表格控件对象
        /// 
        /// </summary>
        public Table ContainerTable
        {
            get { return _containerTable; }
            set { _containerTable = value; }
        }
        protected TableIndex[] _tetrisItmeTable;
        /// <summary>当前形状在容器表格控件的各个块的索引位置数组
        /// 
        /// </summary>
        public TableIndex[] TetrisItmeTable
        {
            get { return this._tetrisItmeTable; }
        }
        protected TableIndex[] _breviary;
        /// <summary>当前对象的缩略索引【4*4】的表格中的位置
        /// 
        /// </summary>
        public TableIndex[] Breviary
        {
            get { return _breviary; }
        }
        //每次生成一个GUID来保证唯一
        private Guid _id = Guid.NewGuid();
        /// <summary>存储当前形状的ID【GUID】变量
        /// 
        /// </summary>
        public Guid ID
        {
            get { return this._id; }
        }
        protected Color _showColor;
        /// <summary>当前形状显示的颜色
        /// 
        /// </summary>
        public Color ShowColor
        {
            get { return _showColor; }
        }

        /// <summary>将当前形状进行旋转
        /// 
        /// </summary>
        /// <returns>简介：如果返回true代表旋转成功，如果返回的是false代表旋转失败【碰到边，或者遇到其他的方块无法进行旋转了】，旋转失败是不会进行更改，显示结果的方块</returns>
        public virtual bool Spin()
        {
            throw new Exception("未实现！");
        }
        /// <summary>将当前形状左右移动
        /// 
        /// </summary>
        /// <param name="direction">如果值为true，向左移动一格，如果为false向右移动一格</param>
        /// <returns>返回true就代表移动成功，返回false就代表移动失败，并且不更改移动结果</returns>
        public bool Move(bool direction)
        {
            //拷贝当前形状位置的索引数组
            TableIndex[] ti = this._tetrisItmeTable.ToArray();
            //判断是向那边移动
            if (direction)//向左移动
            {
                //循环列--
                for (int i = 0; i < ti.Length; i++)
                {
                    //列--
                    ti[i].CellIndex--;
                }
            }
            else//向右移动
            {
                //循环列++
                for (int i = 0; i < ti.Length; i++)
                {
                    //列++
                    ti[i].CellIndex++;
                }
            }
            //调用方法判断是否移动成功
            if (this.IsEffective(ti))
            {
                //调用设置新位置的方法
                this.SetShapeNewIndex(ti);
                //返回设置成功
                return true;
            }
            else
            {
                //返回false代表移动失败
                return false;
            }
        }
        /// <summary>将当前形状下移一格或者下移到底
        /// 
        /// </summary>
        /// <param name="moveMode">如果值为true，向下移动一格，如果为false直接移动到底【无法在继续往下移动为止】</param>
        /// <returns>如果返回为true就代表向下移动成功，返回false就代表已经到底了！</returns>
        public MoveResult BelowMove(bool moveMode)
        {
            //拷贝当前形状位置的索引数组
            TableIndex[] ti = this._tetrisItmeTable.ToArray();
            //判断是向下移动一格还是移动到底
            if (moveMode)
            {
                //循环将行向下移动一格
                for (int i = 0; i < ti.Length; i++)
                {
                    //行向下移动一格
                    ti[i].RowIndex++;
                }
                //得到移动结果
                MoveResult mr = this.IsMoveEffective(ti);
                //判断是否移动成功
                if (mr == MoveResult.MoveSucceed)
                {
                    //调用设置新位置的方法
                    this.SetShapeNewIndex(ti);
                }
                //返回移动结果
                return mr;
            }
            else
            {
                //每次移动信息
                MoveResult mr;
                //循环刷新直到碰底
                do
                {
                    //循环将行向下移动一格
                    for (int i = 0; i < ti.Length; i++)
                    {
                        //行向下移动一格
                        ti[i].RowIndex++;
                    }
                } while ((mr = this.IsMoveEffective(ti)) == MoveResult.MoveSucceed);//判断是否移动成功如果移动成功继续移动否则退出
                //循环向上移动一格【因为循环结束必须是已经超过了，所以需要向上一格来保持合法】
                for (int i = 0; i < ti.Length; i++)
                {
                    //行向上移动一格
                    ti[i].RowIndex--;
                }
                //调用设置新位置的方法
                this.SetShapeNewIndex(ti);
                //返回移动结果
                return mr;
            }
        }
        /// <summary>指定形状的索引是否合法【就是是否在表格的范畴中，并且没有和其他方块重复】
        /// 
        /// </summary>
        /// <param name="indexList">进行验证的形状索引数组</param>
        /// <returns>true代表合法，false代表不合法</returns>
        public bool IsEffective(TableIndex[] indexList)
        {
            //得到表格的行数量与列数量
            int rowCount = this._containerTable.RowCount, lineCount = this._containerTable.CellCount;
            //判断传入的数组是否为null,或者形状索引数组中没有元素，就抛出异常
            if (indexList == null || indexList.Length == 0) throw new Exception("形状索引数组不能为空！");
            //循环判断是否合法
            for (int i = 0; i < indexList.Length; i++)
            {
                //得到当前索引对象
                TableIndex ti = indexList[i];
                //判断当前索引是否超过了表格的维度【小于0，大于等于行或列数量】，如果超过范围就返回false
                if (ti.RowIndex < 0 || ti.RowIndex >= rowCount || ti.CellIndex < 0 || ti.CellIndex >= lineCount) return false;
                //创建存储单元格的状态
                CellInformation ci = this._containerTable[ti].Tag;
                //判断单元格状态，是否被选中？
                if (ci.IsSelect)
                {
                    //判断是固定选中还是活动选中【活动选中，代表的是下落的方块所占用的显示单元格】
                    if (ci.IsActive)
                    {
                        //判断包裹当前单元格的对象的ID[GUID]是否和当前对象的ID[GUID]是否一致，如果一致就代表是当前对象的单元格，否则为合作对象的单元格对象，如果为对手的就返回false
                        if (ci.ShapeObject.ID != this.ID) return false;
                    }
                    else
                    {
                        //返回不合法
                        return false;
                    }
                }
            }
            //返回匹配
            return true;
        }
        /// <summary>指定形状的索引是否合法【就是是否在表格的范畴中，并且没有和其他方块重复】
        /// 
        /// </summary>
        /// <param name="indexList">进行验证的形状索引数组</param>
        /// <returns>简介：如果返回MoveSucceed移动成功MoveNotSucceed无法移动但是未移动失败返回MoveFail移动失败</returns>
        public MoveResult IsMoveEffective(TableIndex[] indexList)
        {
            //得到表格的行数量与列数量
            int rowCount = this._containerTable.RowCount, lineCount = this._containerTable.CellCount;
            //判断传入的数组是否为null,或者形状索引数组中没有元素，就抛出异常
            if (indexList == null || indexList.Length == 0) throw new Exception("形状索引数组不能为空！");
            //循环判断是否合法
            for (int i = 0; i < indexList.Length; i++)
            {
                //得到当前索引对象
                TableIndex ti = indexList[i];
                //判断当前索引是否超过了表格的维度【小于0，大于等于行或列数量】，如果超过范围就返回-1
                if (ti.RowIndex < 0 || ti.RowIndex >= rowCount || ti.CellIndex < 0 || ti.CellIndex >= lineCount) return MoveResult.MoveFail;
                //创建存储单元格的状态
                CellInformation ci = this._containerTable[ti].Tag;
                //判断单元格状态，是否被选中？
                if (ci.IsSelect)
                {
                    //判断是固定选中还是活动选中【活动选中，代表的是下落的方块所占用的显示单元格】
                    if (ci.IsActive)
                    {
                        //判断包裹当前单元格的对象的ID[GUID]是否和当前对象的ID[GUID]是否一致，如果一致就代表是当前对象的单元格，否则为合作对象的单元格对象，如果为对手的就返回0不移动但是
                        if (ci.ShapeObject.ID != this.ID) return MoveResult.MoveNotSucceed;
                    }
                    else
                    {
                        //返回不合法
                        return MoveResult.MoveFail;
                    }
                }
            }
            //返回匹配
            return MoveResult.MoveSucceed;
        }
        /// <summary>部署方法，将当前形状部署在表格中，如果部署成功返回true，否则返回false
        /// 
        /// </summary>
        /// <returns>部署成功返回true否则返回false</returns>
        public virtual bool Deploy()
        {
            //得到验证部署的结果
            bool boo = this.IsEffective(this._tetrisItmeTable);
            //将当前形状添加到表格控件中
            for (int i = 0; i < this._tetrisItmeTable.Length; i++)
            {
                //更改颜色
                this._containerTable[this._tetrisItmeTable[i]].BackgroundColor = this._showColor;
            }
            //返回验证结果
            return boo;
        }
        /// <summary>设置当前形状为新的坐标位置
        /// 
        /// </summary>
        /// <param name="ti">新的坐标位置数组</param>
        protected virtual void SetShapeNewIndex(TableIndex[] ti)
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
                //设置单元格背景颜色
                td.BackgroundColor = this._showColor;
                //设置属性值
                td.Tag = new CellInformation(true, true, this._showColor, this);
            }
            //设置当前的索引坐标数组位置
            this._tetrisItmeTable = ti;
        }
        /// <summary>设置当前形状所在索引位置为固定单元格【确定位置了】
        /// 
        /// </summary>
        public void SetFixedCell()
        {
            //开始循环设置为固定单元格
            for (int i = 0; i < this._tetrisItmeTable.Length; i++)
            {
                //开始设置为固定单元格
                this._containerTable[this._tetrisItmeTable[i]].Tag = new CellInformation(true, false, this._showColor, this);
            }
        }
    }
}
