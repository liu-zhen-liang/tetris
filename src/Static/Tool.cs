using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LZLTetris.Static
{
    /// <summary>工具类
    /// 
    /// </summary>
    public static class Tool
    {
        /// <summary>将TimeSpan转换成字符串形式
        /// 
        /// </summary>
        /// <param name="ts">TimeSpan对象</param>
        /// <returns>字符串形式</returns>
        public static string TimeSpanToString(TimeSpan ts)
        {
            //存储上面是否有的变量【如果上面一级有大于零后面不管是零还是其他数都要显示】
            bool Is = false;
            //创建连接字符串
            StringBuilder conn = new StringBuilder();
            //判断是否有天数
            if (ts.Days > 0)
            {
                //存入连接字符串
                conn.Append(ts.Days.ToString() + "天");
                //设置上面已经有执行了
                Is = true;
            }
            //判断是否有小时数，或者上面执行与否
            if (ts.Hours > 0 || Is)
            {
                //存入连接字符串
                conn.Append(ts.Hours.ToString() + "小时");
                //设置上面已经有执行了
                Is = true;
            }
            //判断是否有分钟数，或者上面执行与否
            if (ts.Minutes > 0 || Is)
            {
                //存入连接字符串
                conn.Append(ts.Minutes.ToString() + "分钟");
                //设置上面已经有执行了
                Is = true;
            }
            //判断是否有秒数，或者上面执行与否
            if (ts.Seconds > 0 || Is)
            {
                //存入连接字符串
                conn.Append(ts.Seconds.ToString() + "秒");
                //设置上面已经有执行了
                Is = true;
            }
            //判断是否有毫秒数，或者上面执行与否
            if (ts.TotalMilliseconds > 0 || Is)
            {
                //存入连接字符串
                conn.Append(ts.TotalMilliseconds.ToString() + "毫秒");
                //设置上面已经有执行了
                Is = true;
            }
            //返回字符串
            return conn.ToString();
        }
        /// <summary>将DateTime转换成中文的显示，例如：2017年1月25日 23点41分56秒
        /// 
        /// </summary>
        /// <param name="dt">要进行转换的日期时间对象</param>
        /// <returns>转换完成的日期</returns>
        public static string DateTimeToChinese(DateTime dt)
        {
            //返回拼接完成的字符串值
            return dt.Year.ToString()
                + "年" +
                dt.Month.ToString()
                + "月" +
                dt.Day.ToString()
                + "日 " +
                dt.Hour.ToString()
                + "点" +
                dt.Minute.ToString()
                + "分" +
                dt.Second.ToString()
                + "秒";
        }
        /// <summary>临时转换，所用到的字符串数组
        /// 
        /// </summary>
        private readonly static string[] _ftc = new string[]{
            "零",
            "一",
            "二",
            "三",
            "四",
            "五",
            "六",
            "七",
            "八",
            "九",
            "十"
        };
        /// <summary>将整型数转换成中文形式：17 -> 十七
        /// 
        /// </summary>
        /// <param name="value">要被转换的值</param>
        /// <returns>转换完成的值</returns>
        public static string FigureToChinses(int value)
        {
            //判断如果大小小于零或者大于10就报错
            if (value < 0 || value > 10) throw new Exception("当前转换只能转换范围：0-10，还未扩展其他功能，有需要在进行扩展");
            //返回转换结果
            return Tool._ftc[value];
        }
        /// <summary>将制定图片上方覆盖一种指定颜色
        /// 
        /// </summary>
        /// <param name="bit">要进行转换的图片对象</param>
        /// <param name="color">覆盖的颜色</param>
        public static void CoverColor(Bitmap bit, Color color)
        {
            //从当前图片上方创建GDI对象
            Graphics g = Graphics.FromImage(bit);
            //开始绘制一个矩形并按照指定颜色进行填充
            g.FillRectangle(new SolidBrush(color), new Rectangle(new Point(), bit.Size));
        }
        /// <summary>将颜色转换成字符串形式
        /// 
        /// </summary>
        /// <param name="color">要进行转换的颜色对象</param>
        /// <returns>颜色的字符串形式</returns>
        public static string ColorToString(Color color)
        {
            //返回转换完成的结果【[A-25,R-85,G-45,B-236]】
            return "[A-" +
                color.A.ToString() +
                ",R-" +
                color.R.ToString() +
                ",G-" +
                color.G.ToString() +
                ",B-" +
                color.B.ToString() +
                "]";
        }
        /// <summary>将字符串转换成颜色对象
        /// 
        /// </summary>
        /// <param name="strColor">颜色的字符串形式</param>
        /// <returns>转换完成的颜色对象</returns>
        public static Color StringToColor(string strColor)
        {
            //判断字符串是否为空或者长度为零
            if (strColor == null || strColor.Length == 0) throw new Exception("要进行转换的颜色字符串不能为空或者长度为零！");
            //创建一个存储颜色值的对象
            byte A = 255, R = 255, G = 255, B = 255;
            //使用正则进行匹配结果
            MatchCollection mcList = Regex.Matches(strColor, "([argbARGB]){1}-([0-9]*)");
            //循环进行设置结果
            foreach (Match item in mcList)
            {
                //判断匹配的是哪个字母
                switch (item.Groups[1].Value)
                {
                    case "a":
                    case "A":
                        //设置颜色值
                        A = Convert.ToByte(item.Groups[2].Value);
                        break;
                    case "r":
                    case "R":
                        //设置颜色值
                        R = Convert.ToByte(item.Groups[2].Value);
                        break;
                    case "g":
                    case "G":
                        //设置颜色值
                        G = Convert.ToByte(item.Groups[2].Value);
                        break;
                    case "b":
                    case "B":
                        //设置颜色值
                        B = Convert.ToByte(item.Groups[2].Value);
                        break;
                }
            }
            //返回颜色结果
            return Color.FromArgb(A, R, G, B);
        }
        /// <summary>显示提醒信息方法
        /// 
        /// </summary>
        /// <param name="showText">要显示的提醒信息</param>
        public static void ShowRemindBox(string showText)
        {
            //创建提醒框
            MessageBox.Show(showText, "提醒信息 - LZ俄罗斯方块", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        /// <summary>显示警告信息
        /// 
        /// </summary>
        /// <param name="showText">要显示的警告信息</param>
        public static void ShowWarningBox(string showText)
        {
            //弹出警告框
            MessageBox.Show(showText, "警告信息 - LZ俄罗斯方块", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>显示错误信息
        /// 
        /// </summary>
        /// <param name="showText">要进行显示的错误信息</param>
        public static void ShowMistakeBox(string showText)
        {
            //显示错误信息框
            MessageBox.Show(showText, "错误信息 - LZ俄罗斯方块", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>判断两个颜色是否一致
        /// 
        /// </summary>
        /// <param name="color1">颜色一</param>
        /// <param name="color2">颜色二</param>
        /// <returns>true代表一致false代表不一致</returns>
        public static bool ColorEqual(Color color1, Color color2)
        {
            //判断A是否一致
            if (color1.A != color2.A) return false;
            //判断R是否一致
            if (color1.R != color2.R) return false;
            //判断G是否一致
            if (color1.G != color2.G) return false;
            //判断B是否一致
            if (color1.B != color2.B) return false;
            //返回一致
            return true;
        }
        /// <summary>将当前对象历史速度都转换成字符串
        /// 
        /// </summary>
        /// <param name="thisVelocityList">要进行转换的速度集合</param>
        /// <returns>合成的字符串</returns>
        public static string ShowVelocityList(List<int> thisVelocityList)
        {
            //创建存储数据的StringBuilder对象
            StringBuilder sb = new StringBuilder("[");
            //循环进行遍历
            foreach (int item in thisVelocityList)
            {
                //存入数据
                sb.Append(item.ToString() + ",");
            }
            //移除最后一个逗号
            sb.Remove(sb.Length - 1, 1);
            //加上“]”
            sb.Append(']');
            //返回值
            return sb.ToString();
        }
        /// <summary>弹出选择框
        /// 
        /// </summary>
        /// <param name="showText">要显示的文本</param>
        /// <returns>返回选择的值Yes和No</returns>
        public static DialogResult ShowSelectBox(string showText)
        {
            //弹出选择框
            return MessageBox.Show(showText, "选择信息 - LZ俄罗斯方块", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }
        /// <summary>得到比例
        /// 
        /// </summary>
        /// <param name="l1">比较值</param>
        /// <param name="l2">相对于值</param>
        /// <returns>比例字符串</returns>
        public static string Proportion(long l1, long l2)
        {
            //得到结果并返回
            return (((double)l2 / (double)l1) * 100).ToString("0.00") + " %";
        }
        /// <summary>将1080分辨率下的大小转换成768分辨率下的大小
        /// 
        /// </summary>
        /// <param name="size">要转换的大小</param>
        /// <returns>转换完成的效果</returns>
        public static Size _1080To768(Size size)
        {
            //返回转换完成的效果
            return new Size((size.Width * 140) / 100, (size.Height * 138) / 100);
        }
    }
}
