using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsTableControl;

namespace LZLTetris.Mode
{
    /// <summary>玩家对象
    /// 专门给模式对象用的，用于兼容合作模式这种游戏模式，需要两个玩家交互的效果对象中存储玩家参数
    /// </summary>
    public class Player
    {
        /// <summary>创建玩家对象并赋值
        /// 
        /// </summary>
        /// <param name="startIndex">玩家产生的方块模型起始位置</param>
        /// <param name="minTable">用于显示下一个要出来的方块形状的表格控件对象</param>
        /// <param name="customsPassLabel">存储显示关卡信息的标签对象【显示所在关卡】</param>
        /// <param name="fractionLabel">存储显示得分的标签对象</param>
        /// <param name="perishRowCountLabel">储存显示消灭的行数的标签对象</param>
        /// <param name="model">当前俄罗斯方块模型对象</param>
        /// <param name="modeBase">当前玩家对象所在的模式对象</param>
        /// <param name="diamondsCountLabel">显示下落的方块【形状】数量的标签对象</param>
        public Player(int startIndex, Table minTable, Label customsPassLabel, Label fractionLabel, Label perishRowCountLabel, TetrisItmeBase model, ModeBase modeBase, Label diamondsCountLabel)
        {
            //赋值
            this._startIndex = startIndex;
            this._minTable = minTable;
            this._customsPassLabel = customsPassLabel;
            this._fractionLabel = fractionLabel;
            this._perishRowCountLabel = perishRowCountLabel;
            this.Model = model;
            this._modeBase = modeBase;
            this._diamondsCountLabel = diamondsCountLabel;
            //调用生成下一个俄罗斯方块模型方法
            this.NextShape(false);
        }
        private int _startIndex;
        /// <summary>玩家产生的方块模型起始位置【只读】
        /// 
        /// </summary>
        public int StartIndex
        {
            get { return _startIndex; }
        }
        private TetrisItmeBase _model;
        /// <summary>当前玩家的活动俄罗斯方块形状对象
        /// 
        /// </summary>
        public TetrisItmeBase Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private TetrisItmeBase _nextModel;
        /// <summary>下一个玩家的活动模型
        /// 
        /// </summary>
        public TetrisItmeBase NextModel
        {
            get { return _nextModel; }
            set
            {
                //判断当前这个是否为空，如果不为空就将当前的模型赋值给活动的模型
                if (this._nextModel != null)
                {
                    //赋值
                    this.Model = this._nextModel;
                }
                //将活动模型赋值给自己
                this._nextModel = value;
                //显示缩略图
                this._minTable.ShowBreviaryIndexList(value);
            }
        }
        private Table _minTable;
        /// <summary>用于显示下一个要出来的方块形状的表格控件对象
        /// 
        /// </summary>
        public Table MinTable
        {
            get { return _minTable; }
        }
        private int _fraction;
        /// <summary>存储当前玩家分数的变量
        /// 
        /// </summary>
        public int Fraction
        {
            get { return _fraction; }
            set { _fraction = value; }
        }
        private int _perishRowCount;
        /// <summary>存储当前玩家消灭的行数量
        /// 
        /// </summary>
        public int PerishRowCount
        {
            get { return _perishRowCount; }
            set { _perishRowCount = value; }
        }
        private Label _customsPassLabel;
        /// <summary>存储显示关卡信息的标签对象【显示所在关卡】
        /// 
        /// </summary>
        public Label CustomsPassLabel
        {
            get { return _customsPassLabel; }
        }
        private Label _fractionLabel;
        /// <summary>存储显示得分的标签对象
        /// 【用于显示当前玩家信息，如果多人，显示【总得分/当前玩家得分】】
        /// </summary>
        public Label FractionLabel
        {
            get { return _fractionLabel; }
        }
        private Label _perishRowCountLabel;
        /// <summary>储存显示消灭的行数的标签对象
        /// 【用于显示当前玩家信息，如果多人，显示【总消灭行数/当前玩家消灭行数】】
        /// </summary>
        public Label PerishRowCountLabel
        {
            get { return _perishRowCountLabel; }
        }
        private ModeBase _modeBase;
        /// <summary>当前玩家对象所在的模式对象
        /// 
        /// </summary>
        public ModeBase ModeBase
        {
            get { return _modeBase; }
        }
        //默认一个
        private int _diamondsCount;
        /// <summary>简介：下落的方块【形状】数量
        /// 
        /// </summary>
        public int DiamondsCount
        {
            get { return _diamondsCount; }
            set { _diamondsCount = value; }
        }
        private Label _diamondsCountLabel;
        /// <summary>显示下落的方块【形状】数量标签对象
        /// 
        /// </summary>
        public Label DiamondsCountLabel
        {
            get { return _diamondsCountLabel; }
            set { _diamondsCountLabel = value; }
        }
        /// <summary>生成下一个形状的方法【如果为true就生成Boss形状false生成普通形状】
        /// 
        /// </summary>
        /// <param name="isBoss">如果为true就生成Boss形状false生成普通形状</param>
        public void NextShape(bool isBoss)
        {
            //调用模式对象的生成形状方法
            this.NextModel = this._modeBase.NextShape(this._startIndex, isBoss);
            //生成数量++
            this._diamondsCount++;
            //调用显示方法
            this._modeBase.Show();
        }
        /// <summary>重置方法
        /// 
        /// </summary>
        public virtual void Reset()
        {
            //重置玩家分数
            this._fraction = 0;
            //重置玩家消除行
            this._perishRowCount = 0;
            //清空下落方块数量
            this._diamondsCount = -1;
            //调用生成方法生成新形状【当前形状】
            this.NextShape(false);
            //调用生成方法生成下一个形状
            this.NextShape(false);
        }
    }
}
