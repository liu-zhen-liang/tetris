using LZLTetris.Mode;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Game
{
    /// <summary>作为游戏对象的父对象：单人游戏、本地双人游戏、联机双人游戏都是他的子类
    /// 
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>游戏方式名称
        /// 
        /// </summary>
        public abstract string GameWayName { get; }
        /// <summary>存储当前游戏方式的所有子游戏模式对象
        /// 
        /// </summary>
        public abstract ModeBase[] ModeList { get; set; }
        /// <summary>获取是否已经游戏结束
        /// 
        /// </summary>
        public abstract bool IsGameOver { get; }
        /// <summary>游戏结束事件
        /// 
        /// </summary>
        public abstract event Action Over;
        /// <summary>按照指定命令和触发命令的对象来执行命令
        /// 
        /// </summary>
        /// <param name="order">执行命令的玩家、执行的命令、键</param>
        public abstract void Exec(OrderValue order);
        /// <summary>用于结束游戏方法
        /// 
        /// </summary>
        /// <param name="mode">输了或者赢了的模式对象</param>
        public abstract void GameOver(ModeBase mode);
        /// <summary>暂停方法
        /// 
        /// </summary>
        public abstract void Stop();
        /// <summary>开始方法
        /// 
        /// </summary>
        public abstract void Start();
        /// <summary>结束当前游戏方式和对应的游戏模式的方法
        /// 
        /// </summary>
        public abstract void Close();
        /// <summary>重置方法
        /// 
        /// </summary>
        public abstract void Reset();
        /// <summary>判断是否刷新纪录方法
        /// 
        /// </summary>
        /// <param name="ghInf">新记录</param>
        public static void TestAndVerifyRefreshMax(GameHistoryInformation ghInf)
        {
            //创建最大值对象，默认存储第一个
            GameHistoryInformation max = null;
            //循环进行得到最大值
            foreach (GameHistoryInformation item in Data.GameHistoryInformationList)
            {
                //判断玩法和模式是否一致
                if (ghInf.GameWay == item.GameWay && ghInf.GameMode == item.GameMode)
                {
                    //判断最大值是否为null
                    if (max == null)
                    {
                        //将值存入最大值
                        max = item;
                    }
                    else
                    {
                        //判断是否大于最大值
                        if (max.CompareTo(item) < 0) max = item;
                    }
                }
            }
            //判断最大值是否为null
            if (max == null)
            {
                //输出为新纪录
                Tool.ShowRemindBox(string.Format("恭喜您在“{0}”->“{1}”创建了新记录！O(∩_∩)O~~", ghInf.GameWay, ghInf.GameMode));
            }
            else if (max.CompareTo(ghInf) < 0)
            {
                //输出刷新新记录
                Tool.ShowRemindBox(string.Format("恭喜您在“{0}”->“{1}”刷新了新记录！O(∩_∩)O~~", ghInf.GameWay, ghInf.GameMode));
            }
        }
    }
}
