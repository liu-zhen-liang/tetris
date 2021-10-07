using LZLTetris.Enum;
using LZLTetris.Game;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsTableControl;
using System.Drawing;

namespace LZLTetris.Mode.ModeObject
{
    /// <summary>生死转换模式
    ///简介：对抗专用！
    ///玩法：和普通模式类似，但是玩家一旦消除一行就向对手上方最上面加一层方块【颜色为一列最上面那个方块的颜色】
    /// </summary>
    public class TransitionMode : ModeBase, ITopAddDiamonds
    {
        /// <summary>创建生死转换模式对象并设置初始值
        /// 
        /// </summary>
        /// <param name="game">游戏方式对象</param>
        /// <param name="table">显示数据的表格对象</param>
        /// <param name="seed">随机的种子</param>
        /// <param name="id">当前模式所在的游戏方式对象的集合索引位置</param>
        public TransitionMode(GameBase game, Table table, int seed, int id)
            : base(game, table, seed, id)
        {
            //设置当前关卡为1
            base.CustomsPass = 1;
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
                return "生死转换模式";
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
        /// <summary>移动到底触发的方法【播放音效、检索是否有块可以被消除】
        /// 
        /// </summary>
        /// <param name="play">移动到底的玩家对象</param>
        public override void MoveToTheEnd(Player play)
        {
            //调用父方法【大体上一致】
            base.MoveToTheEnd(play);
            //通过消除行数来设置关卡
            //得到现在消除的行数所对应的关卡【每20行一个关卡】【一般是不出BUG但是有可能调用循序出错会出：不能除以零的错误，现在没有这个需要就没有判断，以后有在判断】
            int customsPass = (base.PerishRowCount / 20) + (base.PerishRowCount % 20 == 0 ? 0 : 1);
            //判断如果结果等于0就设置为1【因为至少一关】
            if (customsPass == 0) customsPass = 1;
            //判断关卡是否对应，如果对应就不设置
            if (base._customsPass != customsPass)
            {
                //设置新关卡并设置速度
                base.CustomsPass = customsPass;
            }
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
            else//生成下一个形状
            {
                //调用玩家对象的生成下一个形状方法
                play.NextShape(false);
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
            }
            //调用显示数据方法
            this.Show();
            //调用清除BUG方法
            this.CloseBUGCell();
        }
        /// <summary>如果有消除就播放音效、检索是否有块可以被消除等
        /// 【和移动到底去不就是不生成下一个形状】
        /// </summary>
        /// <param name="play">触发的玩家对象</param>
        private void Retrieval(Player play)
        {
            //调用父方法【大体上一致】
            base.MoveToTheEnd(play);
            //通过消除行数来设置关卡
            //得到现在消除的行数所对应的关卡【每20行一个关卡】【一般是不出BUG但是有可能调用循序出错会出：不能除以零的错误，现在没有这个需要就没有判断，以后有在判断】
            int customsPass = (base.PerishRowCount / 20) + (base.PerishRowCount % 20 == 0 ? 0 : 1);
            //判断如果结果等于0就设置为1【因为至少一关】
            if (customsPass == 0) customsPass = 1;
            //判断关卡是否对应，如果对应就不设置
            if (base._customsPass != customsPass)
            {
                //设置新关卡并设置速度
                base.CustomsPass = customsPass;
            }
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
            //调用显示数据方法
            this.Show();
            //调用清除BUG方法
            this.CloseBUGCell();
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
                sb.Append("下落方块数量：" + base.PlayerList[0].DiamondsCount.ToString());
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
                    sb.Append("\t\t下落方块数量：" + base.PlayerList[i].DiamondsCount.ToString());
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
        /// <summary>向显示表格上方添加指定行数的方块
        /// 
        /// </summary>
        /// <param name="play">触发的玩家对象</param>
        /// <param name="addRowCount">要进行添加的行数量</param>
        public void TopAddDiamonds(Player play, int addRowCount)
        {
            //存储变量指示是否可以容纳【默认为可以容纳】
            bool isAccommodate = true;
            //创建存储最上面一层的索引位置数组,和附加信息
            KeyValuePair<CellInformation, int>[] topIndexList = new KeyValuePair<CellInformation, int>[this.Table.CellCount];

            #region 得到最上一个单元格索引，并判断是否可以容纳
            //循环列得到列的最上面一个索引
            for (int i = 0; i < this.Table.CellCount; i++)
            {
                //得到指定列数组
                TD[] tds = this.Table.GetCell(i);
                //存储索引
                int j;
                //循环遍历得到最上面的一个固定方块位置
                for (j = 0; j < tds.Length; j++)
                {
                    //得到当前单元格对象的信息对象
                    CellInformation cellInf = tds[j].Tag;
                    //判断当前信息对象是否被选中并且是固定单元格
                    if (cellInf.IsSelect && !cellInf.IsActive)
                    {
                        //退出列循环
                        break;
                    }
                }
                //判断j是否等于tds.Length
                if (j == tds.Length)
                {
                    //记录信息
                    topIndexList[i] = new KeyValuePair<CellInformation, int>(new CellInformation(true, false, Color.Red, null), j);
                    //开始扫描是否可以进行容纳【如果小于零就代表容纳不了】
                    if (j - addRowCount < 0)
                    {
                        //设置为不能容纳
                        isAccommodate = false;
                    }
                }
                else
                {
                    //记录信息
                    topIndexList[i] = new KeyValuePair<CellInformation, int>(tds[j].Tag, j);
                    //开始扫描是否可以进行容纳【如果小于零就代表容纳不了】
                    if (j - addRowCount < 0)
                    {
                        //设置为不能容纳
                        isAccommodate = false;
                    }
                }
            }
            #endregion

            //判断是否可以进行容纳
            if (isAccommodate)//可以容纳
            {
                #region 添加数据
                //循环开始添加元素
                for (int i = 1; i < topIndexList.Length; i++)
                {
                    //得到索引位置【得到第一个要添加的索引位置】【行索引位置】
                    int index = topIndexList[i].Value - 1;
                    //得到要进行设置的附加信息对象
                    CellInformation cellInf = topIndexList[i].Key;
                    //循环开始设置表格的单元格
                    for (int j = 0; j < addRowCount; j++)
                    {
                        //得到指定位置的单元格
                        TD td = this.Table[index, i];
                        //设置单元格显示的颜色
                        td.BackgroundColor = cellInf.ShowColor;
                        //设置附加数据
                        td.Tag = cellInf;
                        //行索引位置--往上推移一格
                        index--;
                    }
                }
                //调用检索方法，并消除一些行
                this.Retrieval(play);
                #endregion
            }
            else//不可以进行容纳
            {
                #region 触发失败
                //触发停止计时器
                this._timer.Enabled = false;
                //记录日期
                this._endDateTime = DateTime.Now;
                //设置状态为：输了
                this.State = GameState.LoseEnd;
                //循环开始添加元素
                for (int i = 0; i < topIndexList.Length; i++)
                {
                    //得到索引位置【得到第一个要添加的索引位置】【行索引位置】
                    int index = topIndexList[i].Value - 1;
                    //得到要进行设置的附加信息对象
                    CellInformation cellInf = topIndexList[i].Key;
                    //开始循环倒序能添加多少是多少
                    for (int j = index; j >= 0; j--)
                    {
                        //得到指定位置的单元格
                        TD td = this.Table[j, i];
                        //设置单元格背景颜色
                        td.BackgroundColor = cellInf.ShowColor;
                        //设置附加信息
                        td.Tag = cellInf;
                    }
                }
                //设置表格为结束
                this.OverUpdateTable();
                //部署失败代表已经碰顶，触发游戏方式对象的游戏结束方法
                this.Game.GameOver(this);
                #endregion
            }
        }
        /// <summary>清除BUG单元格方法
        /// 
        /// </summary>
        public void CloseBUGCell()
        {
            //循环遍历单元格
            for (int i = 0; i < this.Table.RowCount; i++)
            {
                for (int j = 0; j < this.Table.CellCount; j++)
                {
                    //得到单元格对象
                    TD td = this.Table[i, j];
                    //判断是否被选中
                    if (td.Tag.IsSelect)
                    {
                        //判断如果表格显示的颜色为透明的【A通道等于0】就设置当前单元格为不选中
                        if (td.BackgroundColor.A == 0)
                        {
                            //设置附加数据为默认状态
                            td.Tag = new CellInformation();
                        }
                    }
                }
            }
        }
    }
}
