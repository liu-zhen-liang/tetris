using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Enum
{
    /// <summary>玩家的枚举对象，P1、P2等
    /// 
    /// </summary>
    public enum PlayerInformation
    {
        /// <summary>代表没有玩家和系统使用此键位
        /// 
        /// </summary>
        None = 0,
        /// <summary>代表系统使用此键位
        /// 
        /// </summary>
        System = 1,
        /// <summary>代表玩家一使用此键位
        /// 
        /// </summary>
        P1 = 2,
        /// <summary>代表玩家二使用此键位
        /// 
        /// </summary>
        P2 = 3
    }
}
