using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LZLTetris.Static.DataObject;
using LZLTetris.Mode;

namespace LZLTetris.Static
{
    /// <summary>执行Dos命令的静态对象
    /// 
    /// </summary>
    public static class Dos
    {
        /// <summary>Dos命令控制台窗体对象
        /// 
        /// </summary>
        public static DosForm DosForm;
        private static bool _isClickRemoveTR;
        /// <summary>获取和设置是否点击消除行命令
        /// 
        /// </summary>
        public static bool IsClickRemoveTR
        {
            get { return Dos._isClickRemoveTR; }
            set
            {
                //判断是否选择了点击消除行，如果选择了就是value=true，就将点击消除单元格设置为false，否则就不设置【并且也开启了点击消除单元格在进行设置】
                if (value && Dos._isClickRemoveTD)
                {
                    //设置不点击消除单元格
                    Dos._isClickRemoveTD = false;
                    //显示设置成功
                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击消除单元格成功！");
                }
                //赋值
                Dos._isClickRemoveTR = value;
            }
        }
        private static bool _isClickRemoveTD;
        /// <summary>获取和设置是否点击消除单元格命令
        /// 
        /// </summary>
        public static bool IsClickRemoveTD
        {
            get { return Dos._isClickRemoveTD; }
            set
            {
                //判断是否选择了点击消除单元格，如果选择了就将点击消除行设置为false【并且也设置了点击消除行在进行设置】
                if (value && Dos._isClickRemoveTR)
                {
                    //设置点击消除行为false
                    Dos._isClickRemoveTR = false;
                    //显示设置成功
                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击消除行成功！");
                }
                //赋值
                Dos._isClickRemoveTD = value;
            }
        }
        private static bool _isClickCloseCell;
        /// <summary>获取和设置是否点击清除全屏命令
        /// 
        /// </summary>
        public static bool IsClickCloseCell
        {
            get { return Dos._isClickCloseCell; }
            set { Dos._isClickCloseCell = value; }
        }
        private static Keys? _clickCloseCellKey;
        /// <summary>获取与设置按键清除全屏的键，如果为null，就不按键清除全屏
        /// 不为null，就按照设置的键位清除全屏
        /// </summary>
        public static Keys? ClickCloseCellKey
        {
            get { return Dos._clickCloseCellKey; }
            set { Dos._clickCloseCellKey = value; }
        }
        private static bool _isShowCell;
        /// <summary>获取与设置是否显示单元格
        /// true为显示单元格【隐形模式】false为隐藏单元格【隐形模式】
        /// </summary>
        public static bool IsShowCell
        {
            get { return Dos._isShowCell; }
            set
            {
                //判断值是否发生改变
                if (Dos._isShowCell != value)
                {
                    //赋值
                    Dos._isShowCell = value;
                    //判断玩法对象是否为空
                    if (Program.GameForm.GB != null)
                    {
                        //判断当前模式对象中的模式对象是否为空
                        if (Program.GameForm.GB.ModeList != null)
                        {
                            //循环得到模式对象
                            foreach (ModeBase mb in Program.GameForm.GB.ModeList)
                            {
                                //将当前对象转换成隐形接口
                                IHideMode ihm = mb as IHideMode;
                                //判断是否转换成功，如果转换成就设置其属性
                                if (ihm != null)
                                {
                                    //调用设置属性方法，取反值，因为模式对象是是否隐藏，而这个是是否显示
                                    ihm.IsHide = !value;
                                }
                            }
                        }
                    }
                }
            }
        }
        //默认不限速
        private static int _whereaboutsVelocity = -1;
        /// <summary>获取与设置是否限制下落速度【如果为-1就代表不限速，否则限速】
        /// 
        /// </summary>
        public static int WhereaboutsVelocity
        {
            get { return Dos._whereaboutsVelocity; }
            set { Dos._whereaboutsVelocity = value; }
        }

        /// <summary>向Dos命令中输入命令
        /// 
        /// </summary>
        /// <param name="order">命令字符串</param>
        public static void Wrile(string order)
        {
            //验证输入命令是否为空
            if (order == null)
            {
                //向Dos命令窗口中输入不能输入空命令
                Dos.DosForm.ConsoleAddInformationLine("不能输入空命令！");
                //退出方法
                return;
            }
            //除去前端空格、排版符，换行符
            string OrderStr = order.TrimStart(' ', '\t', '\r', '\n');
            //判断除去无效字符的字符串长度是否为0
            if (OrderStr.Length == 0)
            {
                //向Dos命令中输入无效命令【order】
                Dos.DosForm.ConsoleAddInformationLine("无效命令：“" + order + "”");
                //退出方法
                return;
            }
            //得到命令开始索引位置
            int index = OrderStr.IndexOfAny(new char[] { ' ', '：', ':' });
            //如果查找结果为-1就代表不是当前命令
            if (index != -1)
            {
                //开始截取命令符得到第一个由‘：’符号或‘:’或者空格符号的字符
                string ord = OrderStr.Substring(0, index);
                //得到命令值
                string ordValue = OrderStr.Substring(index + 1);
                //判断是什么命令，将命令转换成小写的形式【因为有英文】
                switch (ord.ToLower())
                {
                    case "开启":
                    case "开始":
                    case "打开":
                    case "open":
                        {
                            //去除命令中的所有空格【命令中没有空格，换行，排版等字符】
                            ordValue = ordValue.Trim(' ', '\t', '\r', '\n');
                            //判断是哪个命令
                            switch (ordValue)
                            {
                                case "点击消除行":
                                    //设置为点击消除行
                                    Dos.IsClickRemoveTR = true;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("开启：点击消除行成功！");
                                    break;
                                case "点击消除单元格":
                                    //设置为点击消除单元格
                                    Dos.IsClickRemoveTD = true;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("开启：点击消除单元格成功！");
                                    break;
                                case "点击清屏":
                                    //设置点击清屏
                                    Dos.IsClickCloseCell = true;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("开启：点击清屏成功！");
                                    break;
                                case "显示单元格":
                                case "显示方块":
                                    //设置显示单元格
                                    Dos.IsShowCell = true;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("开启：显示单元格成功！");
                                    break;
                                default:
                                    {
                                        //判断是否点击键位清屏
                                        //使用正则表达式
                                        //匹配点击键位
                                        Match Mat = Regex.Match(ordValue, @"^点击[\[【](.*)[\]】]键清屏$");
                                        //判断是否得到结果
                                        if (Mat != Match.Empty)
                                        {
                                            //得到键位
                                            string key = Mat.Groups[1].Value;
                                            //判断是否有此键位
                                            if (PlayerSet.StrToKeys.ContainsKey(key))
                                            {
                                                //设置键位
                                                Dos.ClickCloseCellKey = PlayerSet.StrToKeys[key];
                                                //显示设置成功
                                                Dos.DosForm.ConsoleAddInformationLine("设置：点击：" + key + "键清屏成功！");
                                            }
                                            else
                                            {
                                                //弹出信息没有此键位【请确定键位单词首是否字母大写！例如确定键为Enter，而普通字母键位：W，A等...】
                                                Dos.DosForm.ConsoleAddInformationLine("没有“" + key + "”此键位【请确定键位单词首字母是否大写！例如确定键为:Enter，而普通字母键位：W、A等。】");
                                            }
                                        }
                                        //设置判断是否是限制速度的那个命令
                                        else if ((Mat = Regex.Match(ordValue, @"^(限制速度为|限制速度|速度为|速度)[\[【]([0-9]*)[\]】](毫秒|ms|MS|mS|Ms)?$")) != Match.Empty)
                                        {
                                            //得到限制的速度,设置指定的毫秒数
                                            Dos.WhereaboutsVelocity = Convert.ToInt32(Mat.Groups[2].Value);
                                            //显示设置成功
                                            Dos.DosForm.ConsoleAddInformationLine("设置：限制速度为：" + Dos.WhereaboutsVelocity.ToString() + "毫秒成功！");
                                        }
                                        else
                                        {
                                            //弹出错误信息
                                            Dos.DosForm.ConsoleAddInformationLine("“" + ordValue + "”不是可开启的命令！");
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "关闭":
                    case "停止":
                    case "关上":
                    case "close":
                        {
                            //去除命令中的所有空格【命令中没有空格，换行，排版等字符】
                            ordValue = ordValue.Trim(' ', '\t', '\r', '\n');
                            //判断是什么命令
                            switch (ordValue)
                            {
                                case "点击消除行":
                                    //设置关闭消除行
                                    Dos.IsClickRemoveTR = false;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击消除行成功！");
                                    break;
                                case "点击消除单元格":
                                    //关闭点击消除单元格方法
                                    Dos.IsClickRemoveTD = false;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击消除单元格成功！");
                                    break;
                                case "点击清屏":
                                    //设置关闭点击清屏
                                    Dos.IsClickCloseCell = false;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击清屏成功！");
                                    break;
                                case "点击键位清屏":
                                    //设置关闭点击键位清屏
                                    Dos.ClickCloseCellKey = null;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭点击键位清屏成功！");
                                    break;
                                case "限制速度":
                                    //设置关闭限速【-1代表不限速】
                                    Dos.WhereaboutsVelocity = -1;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭限速成功！");
                                    break;
                                case "显示单元格":
                                    //设置隐藏单元格
                                    Dos.IsShowCell = false;
                                    //显示设置成功
                                    Dos.DosForm.ConsoleAddInformationLine("设置：关闭显示单元格成功！");
                                    break;
                                default:
                                    //弹出错误“【命令】”不是可关闭的命令！
                                    Dos.DosForm.ConsoleAddInformationLine("“" + ordValue + "”不是可关闭的命令！");
                                    break;
                            }
                        }
                        break;
                    case "发送聊天信息":
                    case "发送聊天消息":
                    case "发送信息":
                    case "发送消息":
                    case "发信息":
                    case "发消息":
                    case "sendinformation":
                    case "sendmessage":
                        {
                            //调用发送方法
                            Tetris.SendInformation(ordValue);
                            //弹出发送信息成功由Tetris.SendInformation来显示！
                        }
                        break;
                    default:
                        //向Dos命令中输入无效命令【order】
                        Dos.DosForm.ConsoleAddInformationLine("无效命令：“" + order + "”");
                        break;
                }
            }
            else
            {
                //向Dos命令中输入无效命令【order】
                Dos.DosForm.ConsoleAddInformationLine("无效命令：“" + order + "”");
            }
        }
        /// <summary>向Dos命令中输入纯文本信息，不执行任何命令
        /// 
        /// </summary>
        /// <param name="text">输入的文本信息</param>
        public static void WrileText(string text)
        {
            //显示文本信息【并换行】
            Dos.DosForm.ConsoleAddInformationLine(text);
        }
        /// <summary>清除所有单元格信息
        /// 
        /// </summary>
        public static void ClearAllCell()
        {
            throw new Exception("未实现！");
        }
    }
}
