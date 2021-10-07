using LZLTetris.Enum;
using LZLTetris.Mode;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZLTetris.Game.GameObject
{
    /// <summary>单人游戏对象
    /// 
    /// </summary>
    public class OnePersonGame : GameBase
    {
        /// <summary>创建单人游戏对象
        /// 
        /// </summary>
        public OnePersonGame()
        {
            //调用重置方法
            Static.Tetris.Reset("单人模式");
        }
        /// <summary>游戏方式名称
        /// 
        /// </summary>
        public override string GameWayName
        {
            get { return "单人游戏"; }
        }
        private ModeBase[] _modeList;
        /// <summary>存储当前游戏方式的所有子游戏模式对象
        /// 
        /// </summary>
        public override ModeBase[] ModeList
        {
            get { return this._modeList; }
            set { this._modeList = value; }
        }
        /// <summary>按照指定命令和触发命令的对象来执行命令
        /// 
        /// </summary>
        /// <param name="order">执行命令的玩家、执行的命令、键</param>
        public override void Exec(OrderValue order)
        {
            //判定命令是不是为系统的命令
            if (order.Player == Enum.PlayerInformation.System)
            {
                //判断是什么命令
                switch (order.Order)
                {
                    case LZLTetris.Enum.Order.None:
                    case LZLTetris.Enum.Order.Spin:
                    case LZLTetris.Enum.Order.LeftMove:
                    case LZLTetris.Enum.Order.RightMove:
                    case LZLTetris.Enum.Order.BelowMove:
                    case LZLTetris.Enum.Order.MoveToTheEnd:
                        break;
                    case LZLTetris.Enum.Order.Stop:
                        //暂停还是继续取反
                        Program.GameForm.IsStop = !Program.GameForm.IsStop;
                        break;
                    case LZLTetris.Enum.Order.Chat:
                        //向控制台输出文本框【单人游戏下不能打开聊天窗口！】
                        Static.Dos.WrileText("单人游戏下不能打开聊天窗口！");
                        break;
                    case LZLTetris.Enum.Order.OpenDosOrder:
                    case LZLTetris.Enum.Order.CloseDosOredr:
                        //打开或者关闭Dos命令窗口
                        Static.Tetris.OpenOrCloseDosOrder();
                        break;
                    case LZLTetris.Enum.Order.OpenMenu:
                    case LZLTetris.Enum.Order.CloseMenu:
                        //调用打开或者关闭菜单的方法
                        Static.Tetris.OpenOrCloseStopMenu();
                        break;
                    default:
                        break;
                }
            }
            //判断是否为玩家一或者玩家二
            else if (order.Player == Enum.PlayerInformation.P1 || order.Player == Enum.PlayerInformation.P2)
            {
                //调用玩家一的执行命令方法
                this._modeList[0].Exec(order);
            }
        }
        /// <summary>用于结束游戏方法
        /// 
        /// </summary>
        /// <param name="mode">输了或者赢了的模式对象</param>
        public override void GameOver(ModeBase mode)
        {            //判断游戏是否已经结束了如果结束了就不触发了
            if (!this._isGameOver)
            {
                //设置已经触发结束了
                this._isGameOver = true;
                //得到记录信息对象
                GameHistoryInformation chi = mode.Save();
                //判断是赢了还是输了
                if (mode.State == GameState.WinEnd)
                {
                    //触发胜利音效
                    Music.EndMusic("胜利音效");
                    //弹出赢了的提示
                    Tool.ShowRemindBox(string.Format("闯关胜利！游戏模式为：“{0}”{1}关全通过大神请收下我的膝盖！\r\n游戏参数：↓\r\n游戏关卡：{1} 消灭行数：{2} 游戏得分：{3} 游戏时长：{4} 游戏开始日期：{5}。",
                        //游戏模式
                        chi.GameMode,
                        //关卡数量
                        chi.GameCustomsPass.ToString(),
                        //消灭行数
                        chi.PerishRowCount.ToString(),
                        //游戏得分
                        chi.GameScore.ToString(),
                        //游戏时长
                        Tool.TimeSpanToString(chi.GameTime),
                        //游戏开始日期
                        Tool.DateTimeToChinese(chi.GameDateTime)
                    ));
                }
                else
                {
                    //触发输的音效
                    Music.EndMusic("输的音效");
                    //弹出输了的提示
                    Tool.ShowRemindBox(string.Format("闯关失败！游戏模式为：“{0}”{1}\r\n游戏参数：↓\r\n游戏关卡：{2} 消灭行数：{3} 游戏得分：{4} 游戏时长：{5} 游戏开始日期：{6}。",
                        //游戏模式
                        chi.GameMode,
                        //鼓励话语
                        //判断关数
                        (chi.GameCustomsPass >= 6 ?
                        //大于等于6关
                            string.Format("您一共闯到了第 {0} 关非常不错再接再厉！下次争取通关O(∩_∩)O~~！", chi.GameCustomsPass) :
                        //小于6关
                            string.Format("您一共闯到了第 {0} 关，虽然离成功有些距离，但是只要坚持就不怕有办不成的事！", chi.GameCustomsPass)),
                        //游戏关卡
                        chi.GameCustomsPass.ToString(),
                        //消灭行数
                        chi.PerishRowCount.ToString(),
                        //游戏得分
                        chi.GameScore.ToString(),
                        //游戏时长
                        Tool.TimeSpanToString(chi.GameTime),
                        //游戏开始日期
                        Tool.DateTimeToChinese(chi.GameDateTime)
                    ));
                }
                //调用验证方法
                GameBase.TestAndVerifyRefreshMax(chi);
                //调用添加信息方法
                Data.TakeNotes.AddInformation(mode);
                //保存信息方法
                Data.TakeNotes.SaveTakeNotes();
                //将游戏信息进行保存
                Data.GameHistoryInformationList.Add(chi);
                //调用保存排行榜信息方法
                Data.SaveRanking();
                //调用清除资源方法
                this.Close();
                //判断事件是否为空
                if (this.Over != null)
                {
                    //调用事件
                    this.Over();
                }
            }
        }
        /// <summary>暂停方法
        /// 
        /// </summary>
        public override void Stop()
        {
            //循环进行暂停处理
            for (int i = 0; i < this._modeList.Length; i++)
            {
                //调用暂停方法
                this._modeList[i].Stop();
            }
        }
        /// <summary>开始方法
        /// 
        /// </summary>
        public override void Start()
        {
            //循环进行开始处理
            for (int i = 0; i < this._modeList.Length; i++)
            {
                //调用开始方法
                this._modeList[i].Start();
            }
        }
        /// <summary>结束当前游戏方式和对应的游戏模式的方法
        /// 
        /// </summary>
        public override void Close()
        {
            //循环进行清除游戏模式方法
            for (int i = 0; i < this._modeList.Length; i++)
            {
                //调用模式结束方法
                this._modeList[i].Close();
            }
        }
        /// <summary>存储游戏是否已经结束变量
        /// 
        /// </summary>
        private bool _isGameOver;
        /// <summary>获取是否已经游戏结束
        /// 
        /// </summary>
        public override bool IsGameOver
        {
            get
            {
                //返回变量存储的值
                return this._isGameOver;
            }
        }
        /// <summary>重置方法
        /// 
        /// </summary>
        public override void Reset()
        {
            //设置游戏为没有结束
            this._isGameOver = false;
            //循环调用模式刷新方法
            for (int i = 0; i < this._modeList.Length; i++)
            {
                //调用刷新方法
                this._modeList[i].Reset();
            }
        }
        /// <summary>游戏结束触发的事件
        /// 
        /// </summary>
        public override event Action Over;
    }
}
