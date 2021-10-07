using LZLTetris.Enum;
using LZLTetris.Game;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris.Mode.ModeObject
{
    /// <summary>大乱斗模式
    /// 和普通模式极其类似只是方块中夹杂着Boss方块和普通方块，Boss出现的几率是每出现40个普通方块出现两个Boss
    /// </summary>
    public class BigChaosFight : ModeBase
    {
        /// <summary>创建大乱斗模式对象并设置初始值
        /// 
        /// </summary>
        /// <param name="game">游戏方式对象</param>
        /// <param name="table">显示数据的表格对象</param>
        /// <param name="seed">随机的种子</param>
        /// <param name="id">当前模式所在的游戏方式对象的集合索引位置</param>
        public BigChaosFight(GameBase game, Table table, int seed, int id)
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
                return "大乱斗模式";
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
        /// <summary>Boss剩余数量
        /// 
        /// </summary>
        private int BossSurplus = 2;//因为每20个出现一次会让人感觉很少，40个同时出现两个的几率大些，而20个得第一个在最后一个第二个在第一个才行几率太小
        /// <summary>小兵剩余数量
        /// 
        /// </summary>
        private int ArmsSurplus = 40;
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
                //创建变量确定出现Boss还是小兵
                bool isBoss;
                //判断是否还剩余小兵，和剩余Boss
                if (this.ArmsSurplus > 0 && this.BossSurplus > 0)
                {
                    //得到结果
                    isBoss = this._random.Next(8) == 7;//结果又8个只有一个【7】就生成Boss模型其他都生成普通模型;
                }
                //是否剩余小兵
                else if (this.ArmsSurplus > 0)
                {
                    //设置为小兵
                    isBoss = false;
                }
                    //判断是否剩余Boss
                else if (this.BossSurplus > 0)
                {
                    //设置为Boss
                    isBoss = true;
                }
                else
                {
                    //重置剩余小兵数量与剩余Boss数量
                    //剩余小兵
                    this.ArmsSurplus = 40;
                    //剩余Boss
                    this.BossSurplus = 2;
                    //设置为小兵默认开始就小兵
                    isBoss = false;
                }
                //设置是减少小兵数量还是减少Boss数量
                if (isBoss)
                {
                    //Boss数量--
                    this.BossSurplus--;
                }
                else
                {
                    //小兵数量--
                    this.ArmsSurplus--;
                }
                //判断
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
            }
            //调用显示数据方法
            this.Show();
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
    }
}
