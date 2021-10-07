using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Mode
{
    /// <summary>如果有模式要进行隐藏处理的隐藏属性接口
    ///  简介：如果需要隐藏属性的模式要继承的接口，里面有隐藏属性【用于方便设置模式的方块的隐藏与显示】
    ///  方便介绍：到时候要设置某个模式【有隐藏方块的地方】的隐藏与显示只需要将那个模式转换成此接口然后设置这个属性即可！
    /// </summary>
    public interface IHideMode
    {
        /// <summary>获取与设置是否隐藏固定方块
        /// 
        /// </summary>
        bool IsHide { get; set; }
    }
}
