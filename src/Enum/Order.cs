using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZLTetris.Enum
{
    /// <summary>是用户设置的键位，所点击触发的命令枚举。
    /// 
    /// </summary>
    public enum Order
    {
        /// <summary>
        /// 代表没有命令
        /// </summary>
        None = 0,
        /// <summary>
        /// 旋转命令【俄罗斯方块形状对象命令】
        /// </summary>
        Spin = 1,
        /// <summary>
        /// 左移一步【俄罗斯方块形状对象命令】
        /// </summary>
        LeftMove = 2,
        /// <summary>
        /// 右移一步【俄罗斯方块形状对象命令】
        /// </summary>
        RightMove = 3,
        /// <summary>
        /// 下移一步【俄罗斯方块形状对象命令】
        /// </summary>
        BelowMove = 4,
        /// <summary>
        /// 下移到底【俄罗斯方块形状对象命令】
        /// </summary>
        MoveToTheEnd = 5,
        /// <summary>
        /// 暂停游戏【系统命令】
        /// </summary>
        Stop = 6,
        /// <summary>
        /// 打开聊天对话框【系统命令】
        /// </summary>
        Chat = 7,
        /// <summary>
        /// 打开Dos命令窗口【系统命令】
        /// </summary>
        OpenDosOrder = 8,
        /// <summary>
        /// 打开菜单【系统命令】
        /// </summary>
        OpenMenu = 9,
        /// <summary>关闭Dos命令窗口
        /// 
        /// </summary>
        CloseDosOredr = 10,
        /// <summary>关闭菜单
        /// 
        /// </summary>
        CloseMenu = 11
    }
}
