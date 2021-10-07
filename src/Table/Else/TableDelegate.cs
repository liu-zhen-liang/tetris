using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>表格事件委托
    /// 
    /// </summary>
    /// <typeparam name="S">触发事件的对象类型</typeparam>
    /// <typeparam name="E">事件信息对象类型</typeparam>
    /// <param name="sender">触发事件的对象</param>
    /// <param name="e">事件信息对象</param>
    public delegate void TableDelegate<in S, in E>(S sender, E e);
}
