using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LZLTetris;
using LZLTetris.Mode;
using LZLTetris.TetrisShape;

namespace WindowsTableControl
{
    /// <summary>表格控件
    /// 
    /// </summary>
    public partial class Table : UserControl
    {
        /// <summary>创建表格对象并设置初始值
        /// 
        /// </summary>
        public Table()
        {
            //加载控件
            InitializeComponent();
            //创建GDI对象
            this._GDI = this.CreateGraphics();
            //事件
            //创建鼠标移动事件
            base.MouseMove += Table_MouseMove;
            //创建鼠标在控件内点击鼠标按钮触发的事件
            base.MouseDown += Table_MouseDown;
            //创建点击事件
            base.Click += Table_Click;
            //双击控件触发的事件
            base.DoubleClick += Table_DoubleClick;
            //在控件中静止一段时间触发的事件
            base.MouseHover += Table_MouseHover;
            //鼠标单击控件触发的事件
            base.MouseClick += Table_MouseClick;
            //鼠标双击控件触发的事件
            base.MouseDoubleClick += Table_MouseDoubleClick;
            //调用创建表格内容方法
            this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
        }
        /// <summary>获取指定行索引位置的行对象
        /// 
        /// </summary>
        /// <param name="rowIndex">指定行索引位置</param>
        /// <returns>行对象</returns>
        public TR this[int rowIndex]
        {
            get { return this.trs[rowIndex]; }
        }
        /// <summary>获取指定表格索引位置的单元格对象
        /// 
        /// </summary>
        /// <param name="tdIndex">表格索引</param>
        /// <returns>表格对象</returns>
        public TD this[TableIndex tdIndex]
        {
            get { return this.tds[tdIndex.RowIndex, tdIndex.CellIndex]; }
        }
        /// <summary>获取当前表格指定位置的第单元格对象
        /// 
        /// </summary>
        /// <param name="rowIndex">行索引位置</param>
        /// <param name="cellIndex">列索引位置</param>
        /// <returns>指定索引位置的单元格对象</returns>
        public TD this[int rowIndex, int cellIndex]
        {
            get { return this.tds[rowIndex, cellIndex]; }
        }
        /// <summary>获取当前表格对象的行对象集合
        /// 
        /// </summary>
        private TR[] trs;
        /// <summary>获取当前表格对象的单元格对象集合
        /// 
        /// </summary>
        private TD[,] tds;
        /// <summary>当前表格对象的行对象数量
        /// 
        /// </summary>
        [Browsable(false)]
        public int Length { get { return this.trs.Length; } }
        private int _rowCount = 3;
        /// <summary>获取与设置行数量
        /// 
        /// </summary>
        [Description("表格行数量"), Category("表格格式"), DefaultValue(3)]
        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = value;
                //判断行数量与列数量和单元格大小是否符合要求
                if (this._rowCount > 0 && !this._tdSize.IsEmpty && this._cellCount > 0)
                {
                    //调用创建表格内容方法
                    this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
                }
            }
        }
        private int _cellCount = 3;
        /// <summary>获取与设置列数量
        /// 
        /// </summary>
        [Description("表格列数量"), Category("表格格式"), DefaultValue(3)]
        public int CellCount
        {
            get { return _cellCount; }
            set
            {
                _cellCount = value;
                //判断行数量与列数量和单元格大小是否符合要求
                if (this._rowCount > 0 && !this._tdSize.IsEmpty && this._cellCount > 0)
                {
                    //调用创建表格内容方法
                    this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
                }
            }
        }
        private Graphics _GDI;
        /// <summary>获取当前表格的GDI+对象
        /// 
        /// </summary>
        [Browsable(false)]
        public Graphics GDI
        {
            get { return _GDI; }
        }
        private Size _tdSize = new Size(32, 32);
        /// <summary>获取与设置单元格大小
        /// 
        /// </summary>
        [Description("表格单元格大小"), Category("表格格式"), DefaultValue(typeof(Size), "32,32")]
        public Size TdSize
        {
            get { return _tdSize; }
            set
            {
                _tdSize = value;
                //判断行数量与列数量和单元格大小是否符合要求
                if (this._rowCount > 0 && !this._tdSize.IsEmpty && this._cellCount > 0)
                {
                    //判断表格是否创建了，如果没有创建就创建表格
                    if (this.tds == null)
                    {
                        //调用创建表格内容方法
                        this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
                    }
                    else
                    {
                        //调用表格的设置新参数方法
                        this.SetTable(this._tdSize, this._borderWide, this._borderColor);
                    }
                }
            }
        }
        private int _borderWide = 1;
        /// <summary>获取与设置边框宽度
        /// 
        /// </summary>
        [Description("表格边框宽度"), Category("表格格式"), DefaultValue(1)]
        public int BorderWide
        {
            get { return _borderWide; }
            set
            {
                _borderWide = value;
                //判断行数量与列数量和单元格大小是否符合要求
                if (this._rowCount > 0 && !this._tdSize.IsEmpty && this._cellCount > 0)
                {
                    //判断表格是否创建了，如果没有创建就创建表格
                    if (this.tds == null)
                    {
                        //调用创建表格内容方法
                        this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
                    }
                    else
                    {
                        //调用表格的设置新参数方法
                        this.SetTable(this._tdSize, this._borderWide, this._borderColor);
                    }
                }
            }
        }
        private Color _borderColor = Color.Black;
        /// <summary>获取与设置边框颜色
        /// 
        /// </summary>
        [Description("表格边框颜色"), Category("表格格式"), DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                //判断行数量与列数量和单元格大小是否符合要求
                if (this._rowCount > 0 && !this._tdSize.IsEmpty && this._cellCount > 0)
                {
                    //判断表格是否创建了，如果没有创建就创建表格
                    if (this.tds == null)
                    {
                        //调用创建表格内容方法
                        this.CreateTable(this._rowCount, this._cellCount, this._tdSize, this._borderWide, this._borderColor);
                    }
                    else
                    {
                        //调用表格的设置新参数方法
                        this.SetTable(this._tdSize, this._borderWide, this._borderColor);
                    }
                }
            }
        }
        private Size _tableSize;
        /// <summary>当前表格控件的有效表格内容范围
        /// 
        /// </summary>
        [Browsable(false)]
        public Size TableSize
        {
            get { return _tableSize; }
        }
        private bool _isAutomaticChangeTableSize = true;
        /// <summary>是否自动按照表格实际内容大小来更改表格控件大小
        /// 
        /// </summary>
        [Description("是否自动按照表格实际内容大小来更改表格控件大小"), Category("表格格式"), DefaultValue(true)]
        public bool IsAutomaticChangeTableSize
        {
            get { return _isAutomaticChangeTableSize; }
            set
            {
                _isAutomaticChangeTableSize = value;
                //判断是否要自动更改为表格内容大小，如果要更改就更改
                if (this._isAutomaticChangeTableSize)
                {
                    //设置控件大小为实际大小
                    this.SetControlForTableSize();
                }
            }
        }
        /// <summary>设置创建表格的各个参数，行数量、列数量、单元格大小、边框宽度、边框颜色，将覆盖原来的所有行与单元格对象
        /// 
        /// </summary>
        /// <param name="rowCount">行数量</param>
        /// <param name="cellCount">列数量</param>
        /// <param name="tdSize">单元格大小</param>
        /// <param name="borderWide">边框宽度</param>
        /// <param name="borderColor">边框颜色</param>
        public void CreateTable(int rowCount, int cellCount, Size tdSize, int borderWide, Color borderColor)
        {
            #region 判断参数是否符合要求
            //判断行数量是否符合要求【大于等于1】
            if (rowCount < 1) throw new Exception("行数量至少为一行！");
            //判断列数量是否符合要求【大于等于1】
            if (cellCount < 1) throw new Exception("列数量至少为一行！");
            //判断边框宽度是否符合要求
            if (borderWide < 0) throw new Exception("边框宽度不能小于零！");
            #endregion
            //设置行数量变量
            this._rowCount = rowCount;
            //设置列数量
            this._cellCount = cellCount;
            //设置单元格大小
            this._tdSize = tdSize;
            //设置边框宽度
            this._borderWide = borderWide;
            //设置边框颜色
            this._borderColor = borderColor;
            //创建存储行对象的数组
            this.trs = new TR[rowCount];
            //创建存储单元格的数组
            this.tds = new TD[rowCount, cellCount];
            //得到行对象大小                
            /*计算行对象大小
                 *  宽：(列数量*单元格宽度)+((列数量-1)*边框宽度)
                 *  高：单元格高度*/
            Size trSize = new Size(((cellCount * tdSize.Width) + ((cellCount - 1) * borderWide)), tdSize.Height);
            //循环开始创建行对象
            for (int i = 0; i < rowCount; i++)
            {
                //创建存储当前行的单元格数组
                TD[] tdList = new TD[cellCount];
                //得到Y坐标位置【行对象与单元格对象通用】计算公式：【((i+1)*边框宽度)+(i*单元格高度)】【第一行有1个顶上的边框，而第二行有两个顶上边框，和一个上面一行的宽度，第三行有三个上面的边框和上面两个的单元格高度】
                int Y = ((i + 1) * borderWide) + (i * tdSize.Height);
                //创建行对象
                TR tr = new TR(this, tdList, i, Color.Transparent, null, null, new Rectangle(new Point(borderWide, Y), trSize));
                //将行对象存入表格数组中
                this.trs[i] = tr;
                //循环开始创建单元格对象
                for (int j = 0; j < cellCount; j++)
                {
                    //创建单元格对象
                    /*计算坐标
                     * 计算X坐标：(j*单元格宽度)+((j+1)*边框宽度)
                     * Y轴已经计算完毕
                     */
                    TD td = new TD(this, tr, new TableIndex(i, j), Color.Transparent, null, null, new Rectangle(new Point(((j * tdSize.Width) + ((j + 1) * borderWide)), Y), tdSize));
                    //将TD存入TR数组中
                    tdList[j] = td;
                    //将td存入表格数组中
                    this.tds[i, j] = td;
                }
            }
            //调用绘制边框方法
            this.DrawBorder();
            //调用刷新GDI方法
            this.Refresh();
            //调用获取表格内容实际大小的方法
            this.CalculateTableSize();
            //判断是否要自动更改为表格内容大小，如果要更改就更改
            if (this._isAutomaticChangeTableSize)
            {
                //设置控件大小为实际大小
                this.SetControlForTableSize();
            }
        }
        /// <summary>设置表格对象的属性
        /// 
        /// </summary>
        /// <param name="tdSize">设置单元格大小</param>
        /// <param name="borderWide">设置边框宽度</param>
        /// <param name="borderColor">设置边框颜色</param>
        public void SetTable(Size tdSize, int borderWide, Color borderColor)
        {
            //判断是否创建了表格，如果没有创建就退出
            if (this.trs == null) return;
            #region 判断参数是否符合要求
            //判断边框宽度是否符合要求
            if (borderWide < 0) throw new Exception("边框宽度不能小于零！");
            #endregion
            //设置单元格大小
            this._tdSize = tdSize;
            //设置边框宽度
            this._borderWide = borderWide;
            //设置边框颜色
            this._borderColor = borderColor;
            //得到行对象大小                
            /*计算行对象大小
                 *  宽：(列数量*单元格宽度)+((列数量-1)*边框宽度)
                 *  高：单元格高度*/
            Size trSize = new Size(((this._cellCount * tdSize.Width) + ((this._cellCount - 1) * borderWide)), tdSize.Height);
            //循环开始创建行对象
            for (int i = 0; i < this._rowCount; i++)
            {
                //得到Y坐标位置【行对象与单元格对象通用】计算公式：【((i+1)*边框宽度)+(i*单元格高度)】【第一行有1个顶上的边框，而第二行有两个顶上边框，和一个上面一行的宽度，第三行有三个上面的边框和上面两个的单元格高度】
                int Y = ((i + 1) * borderWide) + (i * tdSize.Height);
                //得到行对象
                TR tr = this.trs[i];
                //设置行对象新的范围
                tr.SetTR(new Rectangle(new Point(borderWide, Y), trSize));
                //循环开始创建单元格对象
                for (int j = 0; j < this._cellCount; j++)
                {
                    //得到单元格对象，并设置他的新范围
                    /*计算坐标
                     * 计算X坐标：(j*单元格宽度)+((j+1)*边框宽度)
                     * Y轴已经计算完毕
                     */
                    tr[j].SetTD(new Rectangle(new Point(((j * tdSize.Width) + ((j + 1) * borderWide)), Y), tdSize));
                }
            }
            //调用绘制边框方法
            this.DrawBorder();
            //调用刷新GDI方法
            this.Refresh();
            //调用获取表格内容实际大小的方法
            this.CalculateTableSize();
            //判断是否要自动更改为表格内容大小，如果要更改就更改
            if (this._isAutomaticChangeTableSize)
            {
                //设置控件大小为实际大小
                this.SetControlForTableSize();
            }
        }
        /// <summary>计算当前表格对象的内容实际大小
        /// 
        /// </summary>
        private void CalculateTableSize()
        {
            //判断如果单元格大小为零就退出方法
            if (this._tdSize.IsEmpty) return;
            //得到宽度，计算公式：【(单元格宽度*列数量)+((列数量+1)*边框宽度)】
            int width = (this._tdSize.Width * this._cellCount) + ((this._cellCount + 1) * this._borderWide);
            //得到高度，计算公式：【(单元格高度*行数量)+((行数量+1)*边框宽度)】
            int height = (this._tdSize.Height * this._rowCount) + ((this._rowCount + 1) * this._borderWide);
            //更改存储表格内容实际大小的变量
            this._tableSize = new Size(width, height);
        }
        /// <summary>设置控件大小为当前表格实际内容的大小
        /// 
        /// </summary>  
        public void SetControlForTableSize()
        {
            //判断当前是否设置了样式
            if (this.BorderStyle == System.Windows.Forms.BorderStyle.None)
            {
                //设置控件大小
                this.Size = this._tableSize;
            }
            else if (this.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)//单行边框占2像素
            {
                //设置控件大小【设置大小+2】
                this.Size = new Size(this._tableSize.Width + 2, this._tableSize.Height + 2);
            }
            else//三维边框占4像素
            {
                //设置控件大【设置大小+4】
                this.Size = new Size(this._tableSize.Width + 4, this._tableSize.Height + 4);
            }
        }
        /// <summary>绘制边框方法
        /// 
        /// </summary>
        public void DrawBorder()
        {
            //判断如果边框小于零就退出
            if (this._borderWide <= 0) return;
            //GDI+画直线不是左上角而是中间，所以需要一个补位的值
            int diff = this._borderWide / 2;
            //创建画笔对象
            Pen pen = new Pen(this._borderColor, this._borderWide);
            //得到行的第二个坐标的X轴位置，X坐标为：【(列数量*单元格宽)+((列数量+1)*边框宽度)】【解决边框为1的BUG，就是边框为一时减一即可】
            int rowX = ((this._cellCount * this._tdSize.Width) + ((this._cellCount + 1) * this._borderWide)) - (this._borderWide == 1 ? 1 : 0);
            //绘制行【绘制数量：行数量+1】
            for (int i = 0; i <= this._rowCount; i++)
            {
                //得到Y坐标
                int Y = (i * (this._tdSize.Height + this._borderWide));
                //创建开始坐标，X坐标为：0 Y坐标为：【当前绘制线条数量*(单元格高度+边框宽度)】
                Point pt1 = new Point(0, Y + diff);
                //创建结束坐标，Y已经有了
                Point pt2 = new Point(rowX, Y + diff);
                //开始绘制线条
                this.GDI.DrawLine(pen, pt1, pt2);
            }
            //得到列的第二个坐标的Y坐标位置：【(行数量*单元格高度)+((行数量+1)*边框宽度)】【解决边框为1的BUG，就是边框为一时减一即可】
            int cellY = (this._rowCount * this._tdSize.Height) + ((this._rowCount + 1) * this._borderWide) - (this._borderWide == 1 ? 1 : 0);
            //绘制列【绘制数量：列数量+1】
            for (int i = 0; i <= this._cellCount; i++)
            {
                //得到X坐标：【(i*(边框宽度+单元格宽度))】
                int X = i * (this._borderWide + this._tdSize.Width);
                //得到一个坐标Y坐标为0
                Point pt1 = new Point(X + diff, 0);
                //得到第二个坐标
                Point pt2 = new Point(X + diff, cellY);
                //开始绘制线条
                this.GDI.DrawLine(pen, pt1, pt2);
            }
        }
        /// <summary>重置背景【重置背景颜色、背景图片】
        /// 
        /// </summary>
        public void RefreshBackground()
        {
            //设置控件内部填充背景颜色
            this.GDI.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            //判断是否有背景图片
            if (this.BackgroundImage != null)
            {
                //填充背景图片
                this.GDI.FillRectangle(new TextureBrush(this.BackgroundImage), this.ClientRectangle);
            }
            //绘制线条
            this.DrawBorder();
        }
        /// <summary>得到指定索引列的所有单元格对象
        /// 
        /// </summary>
        /// <param name="cellIndex">指定索引列</param>
        /// <returns>单元格数组</returns>
        public TD[] GetCell(int cellIndex)
        {
            //判断索引列是否超过元素范围
            if (cellIndex >= this._cellCount) throw new Exception("指定索引超出列数组范畴");
            //创建存储列元素的数组【数量为行数量】
            TD[] tdList = new TD[this._rowCount];
            //循环开始获取指定索引位置的列单元格
            for (int i = 0; i < this._rowCount; i++)
            {
                //将指定位置的单元格存入数组
                tdList[i] = this.tds[i, cellIndex];
            }
            //返回获取的单元格数组
            return tdList;
        }
        /// <summary>得到指定坐标轴位置的行对象
        /// 
        /// </summary>
        /// <param name="location">指定坐标轴位置</param>
        /// <returns>行对象，如果没有获取到行对象就返回null</returns>
        public TR GetCoordinateTR(Point location)
        {
            //判断如果没有输入可行值的话就退出方法
            if (this._tdSize.IsEmpty) return null;
            //得到【表格认定的行高】【因为为了能够快速检索，所以就将行的行高与边框宽加起来】计算公式：【单元格高+边框宽】
            int high = this._tdSize.Height + this._borderWide;
            //计算行的索引位置，计算公式：【(Y/(单元格高+边框宽))-((Y%(单元格高+边框宽))==0?1:0)】
            int index = (location.Y / high) - ((location.Y % high) == 0 ? 1 : 0);
            //判断索引是否超过行对象数组范畴，如果超过就返回null
            if (index >= this._rowCount || index < 0) return null;
            //判断指定索引位置的行对象是否包裹了这个坐标，如果包裹了就返回当前选中的行对象
            if (this.trs[index].Contains(location))
            {
                //返回当前行对象
                return this.trs[index];
            }
            else
            {
                //返回null
                return null;
            }
        }
        /// <summary>得到指定坐标位置的单元格对象
        /// 
        /// </summary>
        /// <param name="location">指定坐标</param>
        /// <returns>如果得到单元格对象就返回，得到的单元格对象，否则就返回null</returns>
        public TD GetCoordinateTD(Point location)
        {
            //判断如果没有输入可行值的话就退出方法
            if (this._tdSize.IsEmpty) return null;
            //得到【表格认定的行高】【因为为了能够快速检索，所以就将行的行高与边框宽加起来】计算公式：【单元格高+边框宽】
            int high = this._tdSize.Height + this._borderWide;
            //计算行的索引位置，计算公式：【(Y/(单元格高+边框宽))-((Y%(单元格高+边框宽))==0?1:0)】
            int rowIndex = (location.Y / high) - ((location.Y % high) == 0 ? 1 : 0);
            //判断索引是否超过行对象数组范畴，如果超过就返回null
            if (rowIndex >= this._rowCount || rowIndex < 0) return null;
            //判断指定索引位置的行对象是否包裹了这个坐标
            if (this.trs[rowIndex].Contains(location))
            {
                //得到选中的行对象
                TR tr = this.trs[rowIndex];
                //判断当前索引位置是否在当前行对象范围中，如果没有就直接返回null
                if (!tr.Contains(location)) return null;
                //得到【行对象认为的单元格宽度】【为了快速检索就将单元格左边的边框也认为是单元格的【但是单元格不认为是他的】】计算公式：【边框宽度+单元格宽度】
                int wide = this._tdSize.Width + this._borderWide;
                //计算得到X轴位置的单元格对象的索引位置利用计算公式：【(X/(边框宽度+单元格宽度))-((X%(边框宽度+单元格宽度))==0?1:0)】
                int cellIndex = (location.X / wide) - (location.X % wide == 0 ? 1 : 0);
                //判断获取的指定索引是否超过了列数组范畴，如果超过就返回null
                if (cellIndex >= this._cellCount || cellIndex < 0) return null;
                //判断指定行指定列的单元格对象是否包含当前坐标，如果包含就返回当前选中的单元格对象，否则返回null
                if (this.tds[rowIndex, cellIndex].Contains(location))
                {
                    //返回选中的单元格对象
                    return this.tds[rowIndex, cellIndex];
                }
                else
                {
                    //返回null
                    return null;
                }
            }
            else
            {
                //返回null
                return null;
            }
        }
        /// <summary>表格刷新事件
        /// 
        /// </summary>
        /// <param name="sender">表格对象</param>
        /// <param name="e">事件对象</param>
        private void Table_Paint(object sender, PaintEventArgs e)
        {
            //创建新的GDI对象
            this._GDI = this.CreateGraphics();
            //判断是否有信息，有信息在进行刷新
            if (this.trs != null)
            {
                //循环调用行对象的刷新方法
                for (int i = 0; i < this._rowCount; i++)
                {
                    //调用行对象的刷新方法
                    this.trs[i].Draw(false);
                }
                //调用刷新边框方法
                this.DrawBorder();
            }
        }
        /// <summary>显示指定坐标集合的元素，并按照指定颜色显示
        /// 
        /// </summary>
        /// <param name="tab">显示的坐标</param>
        /// <param name="showColor">显示的颜色</param>
        public void ShowIndexList(TableIndex[] tab, Color showColor)
        {
            //重置背景
            this.RefreshTable();
            //循环开始显示
            for (int i = 0; i < tab.Length; i++)
            {
                //开始显示
                this.tds[tab[i].RowIndex, tab[i].CellIndex].BackgroundColor = showColor;
            }
        }
        /// <summary>显示缩略图
        /// 
        /// </summary>
        /// <param name="tib">要显示的形状</param>
        public void ShowBreviaryIndexList(TetrisItmeBase tib)
        {
            //判断形状是否为空
            if (tib == null) throw new Exception("俄罗斯方块模型对象不能为空！");
            //将当前对象转换成Boss父对象
            TetrisItmeBossBase tibb = tib as TetrisItmeBossBase;
            //判断是否转换成功
            if (tibb == null)
            {
                //得到要显示的颜色和要显示的缩略图
                this.ShowIndexList(tib.Breviary, tib.ShowColor);
            }
            else
            {
                //重置背景
                this.RefreshTable();
                //得到要显示的索引集合
                TableIndex[] tab = tibb.Breviary;
                //得到设置是固定颜色还是活动颜色的对象
                bool[] fixedColorList = tibb.IsFixedColorList;
                //循环开始显示
                for (int i = 0; i < tab.Length; i++)
                {
                    //开始显示，并判断显示固定颜色还是活动颜色
                    this.tds[tab[i].RowIndex, tab[i].CellIndex].BackgroundColor = fixedColorList[i] ? tibb.FixedColor : tibb.ShowColor;
                }
            }
        }
        /// <summary>验证是否有行可以被消除
        /// 
        /// </summary>
        /// <returns>返回可以被消除的行索引数组，如果返回数量为零就代表没有行可以被消除</returns>
        public int[] EliminateRow()
        {
            //创建存储要被消除的行索引集合
            List<int> indexList = new List<int>();
            //循环开始查找所有可以被消除的行索引
            for (int i = 0; i < this._rowCount; i++)
            {
                //创建变量确定当前行的单元格是否全部都是非活动单元格
                bool isCorrect = true;
                //行内循环
                for (int j = 0; j < this._cellCount; j++)
                {
                    //得到当前单元格的标签对象
                    CellInformation ci = this.tds[i, j].Tag;
                    //判断是否没被选择，或者为活动的单元格
                    if (!ci.IsSelect || ci.IsActive)
                    {
                        //设置为false
                        isCorrect = false;
                        //退出列循环
                        break;
                    }
                }
                //判断是否可以被消除，如果可以就存入行索引
                if (isCorrect) indexList.Add(i);
            }
            //返回被选中，可以消除的行索引集合
            return indexList.ToArray();
        }
        /// <summary>移动行固定单元格信息方法【不移动活动单元格和空单元格】index2移动到index1
        /// 
        /// </summary>
        /// <param name="index1">索引一</param>
        /// <param name="index2">索引二</param>
        /// <returns>返回true代表移动成功，并且移动的那一行不是空行【如果一行都是空的单元格或者只有活动单元格就是空行】，反之返回false</returns>
        public bool MoveTR(int index1, int index2)
        {
            //得到index1行对象调用移动方法，在得到index2位置的行对象
            return this.trs[index1].MoveTR(this.trs[index2]);
        }
        //private Bitmap _theOriginalBackgroundImage;
        ///// <summary>显示的背景图片
        ///// 
        ///// </summary>
        //public Bitmap TheOriginalBackgroundImage
        //{
        //    get { return _theOriginalBackgroundImage; }
        //}
        /// <summary>更改显示的背景图片触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_BackgroundImageChanged(object sender, EventArgs e)
        {
            //判断是否有图片
            if (this.BackgroundImage != null)
            {
                //得到图片
                Bitmap bp = new Bitmap(this.BackgroundImage);
                //循环刷新单元格的底图
                for (int i = 0; i < this._rowCount; i++)
                {
                    for (int j = 0; j < this._cellCount; j++)
                    {
                        //刷新底图
                        this.tds[i, j].GetBottomImage(bp);
                    }
                }
            }
            else
            {
                ////更改背景图片为null
                //this._theOriginalBackgroundImage = null;
                //循环刷新单元格的底图为null
                for (int i = 0; i < this._rowCount; i++)
                {
                    for (int j = 0; j < this._cellCount; j++)
                    {
                        //刷新底图为null
                        this.tds[i, j].GetBottomImage(null);
                    }
                }
            }
        }
        /// <summary>刷新整个表格的方法
        /// 
        /// </summary>
        public void RefreshTable()
        {
            //循环刷新整个表格的单元格
            for (int i = 0; i < this._rowCount; i++)
            {
                for (int j = 0; j < this._cellCount; j++)
                {
                    //开始刷新颜色为透明
                    this.tds[i, j].BackgroundColor = new Color();
                    //刷新Tag内存储的信息
                    this.tds[i, j].Tag = new CellInformation();
                }
            }
        }
        /// <summary>向左偏移一格方法
        /// 
        /// </summary>
        /// <param name="index">刷新行索引</param>
        public void LeftExcursion(int index)
        {
            //判断行是否超过索引范围
            if (index >= this.RowCount)
            {
                //抛出异常
                throw new Exception("索引必须在行数组范围之内");
            }
            //得到指定索引行调用向左偏移行
            this.trs[index].LeftExcursion();
        }
    }
}
