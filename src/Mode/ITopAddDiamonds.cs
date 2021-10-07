using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Mode
{
    /// <summary>往顶部添加方块方法接口【适用于类似生死转换模式的模式】
    /// 
    /// </summary>
    public interface ITopAddDiamonds
    {
        /// <summary>向显示表格上方添加指定行数的方块
        /// 
        /// </summary>
        /// <param name="play">触发的玩家对象</param>
        /// <param name="addRowCount">要进行添加的行数量</param>
        void TopAddDiamonds(Player play, int addRowCount);
    }
}
