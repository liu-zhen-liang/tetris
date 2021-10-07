using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Enum
{
    /// <summary>模式或玩法对象的状态枚举
    /// 
    /// </summary>
    public enum GameState
    {
        /// <summary>还未开始
        /// 
        /// </summary>
        NotBegin = 0,
        /// <summary>正在运行
        /// 
        /// </summary>
        BeInMotion = 1,
        /// <summary>暂停
        /// 
        /// </summary>
        Stop = 2,
        /// <summary>输了
        /// 
        /// </summary>
        LoseEnd = 3,
        /// <summary>赢了
        /// 
        /// </summary>
        WinEnd = 4
    }
}
