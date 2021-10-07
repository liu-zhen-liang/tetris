using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsTableControl
{
    /// <summary>设置控件显示的背景颜色、绘制背景的画笔、背景图片接口
    /// 
    /// </summary>
    public interface IDraw
    {
        /// <summary>开始设置当前对象的背景颜色、绘制背景的画笔、背景图片
        /// 
        /// </summary>
        /// <param name="isRefresh">是否重新刷新背景</param>
        void Draw(bool isRefresh);
        /// <summary>绘制背景颜色
        /// 
        /// </summary>
        /// <param name="color">绘制的背景颜色</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        void Draw(Color color, bool isRefresh);
        /// <summary>用画笔绘制背景
        /// 
        /// </summary>
        /// <param name="br">画笔对象</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        void Draw(Brush br, bool isRefresh);
        /// <summary>绘制背景图片
        /// 
        /// </summary>
        /// <param name="image">背景图片</param>
        /// <param name="isRefresh">是否重新刷新背景</param>
        void Draw(Image image, bool isRefresh);
    }
}
