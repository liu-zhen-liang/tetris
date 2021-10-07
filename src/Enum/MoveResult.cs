using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Enum
{
    /// <summary>移动结果枚举
    /// 
    /// </summary>
    public enum MoveResult
    {
        /// <summary>移动成功
        /// 
        /// </summary>
        MoveSucceed = 0,
        /// <summary>移动未成功但是也没有失败【遇到合作伙伴的模型不移动也不停止】
        /// 
        /// </summary>
        MoveNotSucceed = 1,
        /// <summary>移动失败
        /// 
        /// </summary>
        MoveFail = 2
    }
}
