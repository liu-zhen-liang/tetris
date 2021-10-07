using LZLTetris.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZLTetris
{
    /// <summary>所输入的键所对应的玩家，及命令结果
    /// 
    /// </summary>
    public struct OrderValue
    {
        /// <summary>创建该对象并赋值
        /// 
        /// </summary>
        /// <param name="player">当前命令是谁触发的</param>
        /// <param name="order">要执行的命令</param>
        /// <param name="key">触发命令的是哪个键</param>
        public OrderValue(PlayerInformation player, Order order, Keys key)
        {
            //赋值
            this._player = player;
            this._order = order;
            this._key = key;
        }
        private PlayerInformation _player;
        /// <summary>当前命令是谁触发的
        /// 例如：None就是代表空命令，如果为System代表为系统的，如果为P1就是玩家一，P2及玩家二
        /// </summary>
        public PlayerInformation Player
        {
            get { return _player; }
            set { _player = value; }
        }
        private Order _order;
        /// <summary>当前要执行的命令
        /// 
        /// </summary>
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
        private Keys _key;
        /// <summary>触发命令的键
        /// 
        /// </summary>
        public Keys Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }
}
