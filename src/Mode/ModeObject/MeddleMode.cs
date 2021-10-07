﻿using LZLTetris.Enum;
using LZLTetris.Game;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris.Mode.ModeObject
{
    /// <summary>大杂烩模式
    /// 总共有24关，每关速度随机【1-24】，也有可能这关是隐形关卡，每关结束有可能出现Boss、也有可能是普通关卡
    /// </summary>
    public class MeddleMode : ModeBase, IHideMode
    {
        /// <summary>创建大杂烩模式对象并设置初始值
        /// 
        /// </summary>
        /// <param name="game">游戏方式对象</param>
        /// <param name="table">显示数据的表格对象</param>
        /// <param name="seed">随机的种子</param>
        /// <param name="id">当前模式所在的游戏方式对象的集合索引位置</param>
        public MeddleMode(GameBase game, Table table, int seed, int id)
            : base(game, table, seed, id)
        {
            //设置当前关卡为1
            base._customsPass = 1;
            //设置新关卡速度【随机】
            this.SetRandomVelocity();
            //设置每隔一段时间触发的事件
            base._timer.Tick += TimerEvent;
        }
        /// <summary>获取模式的名称
        /// 
        /// </summary>
        public override string ModeName
        {
            get
            {
                return "大杂烩模式";
            }
        }
        /// <summary>计时器触发的事件
        /// 
        /// </summary>
        /// <param name="sender">计时器对象</param>
        /// <param name="e">事件对象</param>
        private void TimerEvent(object sender, EventArgs e)
        {
            //循环将每个玩家对象的形状对象下移一格
            for (int i = 0; i < base.PlayerList.Length; i++)
            {
                //调用他们的形状对象的下移一步方法并判断是否移动失败，如果移动失败触发移动到底方法
                if (base.PlayerList[i].Model.BelowMove(true) == MoveResult.MoveFail)
                {
                    //移动失败触发到底方法
                    this.MoveToTheEnd(base.PlayerList[i]);
                }
            }
        }
        private bool _isHide;
        /// <summary>获取与设置是否隐藏固定方块
        /// 
        /// </summary>
        public bool IsHide
        {
            get
            {
                //返回值
                return this._isHide;
            }
            set
            {
                //判断新值是否与老值不一致，如果不一致就赋值并设置，否则不予以设置并且状态不能是输了或者赢了
                if (this._isHide != value && (this.State != GameState.LoseEnd && this.State != GameState.WinEnd))
                {
                    //赋值
                    this._isHide = value;
                    //判断是隐藏还是显示固定方块
                    if (value)//隐藏固定方块
                    {
                        //循环隐藏固定方块
                        for (int row = 0; row < this.Table.RowCount; row++)
                        {
                            for (int line = 0; line < this.Table.CellCount; line++)
                            {
                                //得到指定单元格
                                TD td = this.Table[row, line];
                                //得到单元格附加数据对象
                                CellInformation cf = td.Tag;
                                //判断附加数据是否为被单元格占领并是固定单元格
                                if (cf.IsSelect && !cf.IsActive)
                                {
                                    //判断单元格颜色是否为A通道为0，如果为0就代表透明，就不进行设置否则进行设置指定颜色
                                    if (td.BackgroundColor.A != 0)
                                    {
                                        //设置为透明颜色
                                        td.BackgroundColor = Color.Transparent;
                                    }
                                }
                            }
                        }
                    }
                    else//显示固定方块颜色
                    {
                        //循环显示固定方块
                        for (int row = 0; row < this.Table.RowCount; row++)
                        {
                            for (int line = 0; line < this.Table.CellCount; line++)
                            {
                                //得到指定单元格
                                TD td = this.Table[row, line];
                                //得到单元格附加数据对象
                                CellInformation cf = td.Tag;
                                //判断附加数据是否为被单元格占领并是固定单元格
                                if (cf.IsSelect && !cf.IsActive)
                                {
                                    //判断显示颜色是否与保存颜色一致，不一致就更改颜色
                                    if (td.BackgroundColor != cf.ShowColor)
                                    {
                                        //更改颜色
                                        td.BackgroundColor = cf.ShowColor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>开始方法
        /// 
        /// </summary>
        public override void Start()
        {
            //调用父类
            base.Start();
            //判断开始时间年份是否等于1如果等于1就代表是没有开始记录开始时间
            if (base._beginDateTime.Year == 1)
            {
                //设置为当前时间
                base._beginDateTime = DateTime.Now;
            }
            //判断当前状态是否不为：输了、赢了就继续游戏【打开计时器】否则就不打开计时器
            if (base.State != GameState.LoseEnd && base.State != GameState.WinEnd)
            {
                //设置开始计时器
                base._timer.Enabled = true;
                //设置状态：正在运行
                base.State = GameState.BeInMotion;
            }
        }
        /// <summary>暂停方法
        /// 
        /// </summary>
        public override void Stop()
        {
            //设置暂停计时器
            base._timer.Enabled = false;
            //判断当前状态是否不为：输了、赢了【输了赢了暂停就不设置状态为暂停了】
            if (base.State != GameState.LoseEnd && base.State != GameState.WinEnd)
            {
                //设置状态为暂停
                base.State = GameState.Stop;
            }
        }
        /// <summary>保存当前游戏记录方法
        /// 
        /// </summary>
        public override GameHistoryInformation Save()
        {
            //创建存储备注信息的StringBuilder对象
            StringBuilder sb = new StringBuilder();
            //判断是否有多玩家
            if (base.IsOnePlayer)
            {
                //存入下落方块数量
                sb.Append("下落方块数量：" + base.PlayerList[0].DiamondsCount.ToString() + "\r\n");
                //存入速度
                sb.Append("\t速度集合：" + Tool.ShowVelocityList(this.thisVelocityList));
            }
            else
            {
                //存入【游戏方式】+" "+【游戏模式】+"统计结果："
                sb.Append(base.Game.GameWayName + " " + this.ModeName + "统计结果：");
                //开始循环存入信息
                for (int i = 0; i < base.PlayerList.Length; i++)
                {
                    //存入玩家几【i+1，i从0开始，玩家从一开始】
                    sb.Append("\r\n\t玩家" + Static.Tool.FigureToChinses(i + 1) + "：\r\n");
                    //存入分数
                    sb.Append("\t\t得分：" + base.PlayerList[i].Fraction.ToString() + "\r\n");
                    //存储消灭行数
                    sb.Append("\t\t消灭行数：" + base.PlayerList[i].PerishRowCount.ToString() + "\r\n");
                    //存储下落方块数量
                    sb.Append("\t\t下落方块数量：" + base.PlayerList[i].DiamondsCount.ToString() + "\r\n");
                    //存入速度
                    sb.Append("\t\t\t速度集合：" + Tool.ShowVelocityList(this.thisVelocityList));
                }
            }
            //创建要进行返回的游戏历史信息对象并返回
            return new GameHistoryInformation(
                //返回游戏方式
                base.Game.GameWayName,
                //返回游戏模式
                this.ModeName,
                //返回游戏关卡
                base._customsPass,
                //返回消灭行数
                base.PerishRowCount,
                //返回游戏时长【结束时间-开始时间】
                (base._endDateTime - base._beginDateTime),
                //返回游戏得分
                 base.Fraction,
                //返回开始日期
                 base._beginDateTime,
                //返回备注信息
              sb.ToString(),
                //是否成功
              this.State == GameState.WinEnd
            );
        }
        /// <summary>存储当前速度的属性
        /// 
        /// </summary>
        private int thisVelocity;
        /// <summary>存储历史关卡速度
        /// 
        /// </summary>
        private List<int> thisVelocityList = new List<int>();
        /// <summary>随机生成速度并设置方法
        /// 
        /// </summary>
        private void SetRandomVelocity()
        {
            //得到随机速度
            this.thisVelocity = base._random.Next(1, 25);
            //将随机速度存入
            this.thisVelocityList.Add(this.thisVelocity);
            //随机设置速度
            this._timer.Interval = Tetris.GetCustomsPassCorrespondingTime(this.thisVelocity);
        }
        /// <summary>移动到底触发的方法【播放音效、检索是否有块可以被消除】
        /// 
        /// </summary>
        /// <param name="play">移动到底的玩家对象</param>
        public override void MoveToTheEnd(Player play)
        {
            //调用父方法【大体上一致】
            base.MoveToTheEnd(play);
            //判断是否要隐藏方块
            if (this.IsHide)//进入代表隐藏方块
            {
                #region 隐藏方块
                //得到当前方块的索引位置数组
                TableIndex[] tiList = play.Model.TetrisItmeTable;
                //得到表格对象
                Table tab = play.Model.ContainerTable;
                //循环开始隐藏方块
                for (int i = 0; i < tiList.Length; i++)
                {
                    //设置颜色为透明【Transparent】
                    tab[tiList[i]].BackgroundColor = Color.Transparent;
                }
                #endregion
            }
            //通过消除行数来设置关卡
            //得到现在消除的行数所对应的关卡【每20行一个关卡】【一般是不出BUG但是有可能调用循序出错会出：不能除以零的错误，现在没有这个需要就没有判断，以后有在判断】
            int customsPass = (base.PerishRowCount / 20) + (base.PerishRowCount % 20 == 0 ? 0 : 1);
            //判断如果结果等于0就设置为1【因为至少一关】
            if (customsPass == 0) customsPass = 1;
            //判断消除的行数是否大于等于
            if (base.PerishRowCount >= 480)
            {
                //设置模式状态为：赢了
                base.State = GameState.WinEnd;
                //记录日期
                this._endDateTime = DateTime.Now;
                //停止计时器
                base._timer.Enabled = false;
                //调用结束方法
                base.Game.GameOver(this);
            }
            else
            {
                //创建变量设置下一个是产生Boss还是普通方块，默认是普通方块
                bool isBoss = false;
                //判断关卡是否对应，如果对应就不设置
                if (base._customsPass != customsPass)
                {
                    //设置新关卡
                    base._customsPass = customsPass;
                    //设置新关卡速度【随机】
                    this.SetRandomVelocity();
                    //判断是否生成Boss
                    if (this._random.Next(2) == 1)//随机判断是否生成Boss
                    {
                        //设置为生成Boss
                        isBoss = true;
                    }
                    //判断Dos命令是否固定就是要显示单元格，如果是就不随机否则就随机
                    if (!Dos.IsShowCell)
                    {
                        //设置是否为隐形关卡
                        this.IsHide = this._random.Next(2) == 1;
                    }
                }
                //调用玩家对象的生成下一个形状方法
                play.NextShape(isBoss);
                //调用部署形状方法并判断是否部署成功，如果失败就调用游戏结束方法
                if (!play.Model.Deploy())
                {
                    //触发停止计时器
                    this._timer.Enabled = false;
                    //记录日期
                    this._endDateTime = DateTime.Now;
                    //设置状态为：输了
                    this.State = GameState.LoseEnd;
                    //设置表格为结束
                    this.OverUpdateTable();
                    //部署失败代表已经碰顶，触发游戏方式对象的游戏结束方法
                    this.Game.GameOver(this);
                }
                //调用显示数据方法
                this.Show();
            }
        }
        /// <summary>显示获得的分数、当前关卡等信息
        /// 
        /// </summary>
        public override void Show()
        {
            //判断存储玩家对象是否为空，如果为空就退出方法
            if (base._playerList == null) return;
            //循环调用玩家对象集合显示数据
            for (int i = 0; i < base._playerList.Length; i++)
            {
                //得到玩家信息对象
                Player play = base._playerList[i];
                //显示关卡信息
                play.CustomsPassLabel.Text = "当前关卡：" + this._customsPass.ToString() + "速度：" + this.thisVelocity.ToString();
                //判断是多个玩家还是一个玩家
                if (this.IsOnePlayer)
                {
                    //显示得分信息
                    play.FractionLabel.Text = "当前得分：" + play.Fraction.ToString();
                    //显示消除行的数量
                    play.PerishRowCountLabel.Text = "消除行数：" + play.PerishRowCount.ToString();
                }
                else
                {
                    //显示得分信息【总得分/自得分】
                    play.FractionLabel.Text = "当前得分：" + this._fraction.ToString() + "/" + play.Fraction.ToString();
                    //显示消除行的数量【总消灭行/自消灭行】
                    play.PerishRowCountLabel.Text = "消除行数：" + this._perishRowCount.ToString() + "/" + play.PerishRowCount.ToString();
                }
                //显示下落方块的数量
                play.DiamondsCountLabel.Text = "下落方块数量：" + this._playerList[i].DiamondsCount.ToString();
            }
        }
    }
}
