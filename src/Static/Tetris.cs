using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using WindowsTableControl;

namespace LZLTetris.Static
{
    /// <summary>俄罗斯方块命令处理类
    /// 
    /// </summary>
    public static class Tetris
    {

        private static Img _showImage;
        /// <summary>存储用于显示的背景图片对象【菜单背景等】
        /// 
        /// </summary>
        public static Img ShowImage
        {
            get { return Tetris._showImage; }
            set
            {
                //判断两个对象是否为同一个对象【同一个就不更改】
                if (Tetris._showImage == null || (!Tetris._showImage.Equals(value)))
                {
                    //开始更改主背景【游玩背景】
                    Program.GameForm.panelGame.BackgroundImage = value.CommonImage;
                    //更改菜单背景
                    Program.GameForm.PanelMenu.BackgroundImage = value.MenuImage;
                    //进行赋值
                    Tetris._showImage = value;
                }
            }
        }
        /// <summary>存储效果【单人模式、双人合作、双人对抗】的空间集
        /// 
        /// </summary>
        private static Dictionary<string, ControlGroup> ControlGroupList = new Dictionary<string, ControlGroup>();
        /// <summary>构造函数
        /// 
        /// </summary>
        static Tetris()
        {
            //创建显示游戏内容的窗体
            GameInteractiveForm gif = new GameInteractiveForm();
            //创建集合
            List<ControlGroup> cgList = new List<ControlGroup>();

            #region 得到每个页面的数据
            foreach (TabPage item in gif.tabControl1.TabPages)
            {
                //创建组对象
                ControlGroup cg = new ControlGroup(item.Text, item.Tag);
                //将组对象存入集合
                cgList.Add(cg);
                //开始遍历每个页面的元素
                foreach (Control con in item.Controls)
                {
                    //将元素存入组对象
                    cg.Add(con);
                }
            }
            #endregion

            #region 得到兄弟集合
            for (int i = 0; i < cgList.Count; i++)
            {
                //内存赋值循环
                for (int j = 0; j < cgList.Count; j++)
                {
                    //判断i索引是否等于j索引，如果等于就表示是自己，就不进行赋值
                    if (i == j) continue;
                    //将当前对象存入兄弟集合中
                    cgList[i].BrothersControlGroups.Add(cgList[j]);
                }
            }
            #endregion

            #region 将控件集对象存入键值对集合并且将控件存入容器
            //循环进行添加
            for (int i = 0; i < cgList.Count; i++)
            {
                //将当前控件组对象存入键值对集合中
                Tetris.ControlGroupList.Add(cgList[i].Name, cgList[i]);
                //进行遍历并添加
                foreach (Control item in cgList[i])
                {
                    //设置当前控件为隐藏
                    item.Visible = false;
                    //将元素添加到容器中
                    Program.GameForm.panelGame.Controls.Add(item);
                }
            }
            #endregion
        }
        /// <summary>存储重置的用来显示的控件集合
        /// 存储重置的用来显示的控件集合【外部索引是确定玩家0等于玩家一】内部索引是确定那个控件：0=【显示数据的表格】1=【显示下一个的表格】2=【当前关卡】3=【消灭行数】4=【当前分数】5=【下落的方块数量】
        /// </summary>
        public static Control[][] ShowUesInformation;
        /// <summary>关卡大小所对应的时间间隔【1-32关】
        /// 
        /// </summary>
        private readonly static int[] _customsPassCorrespondingTime = new int[]{
            500,
            490,
            480,
            470,
            460,
            450,
            440,
            430,
            410,
            400,
            390,
            380,
            360,
            340,
            320,
            300,
            280,
            260,
            240,
            220,
            200,
            180,
            160,
            140,
            130,
            120,
            110,
            100,
            60,
            50,
            30
        };
        /// <summary>按照关卡来获取时间间隔方法【1-32】关【方便Dos命令操作】
        /// 
        /// </summary>
        /// <param name="customsPass">关卡大小</param>
        /// <returns>指定的时间间隔</returns>
        public static int GetCustomsPassCorrespondingTime(int customsPass)
        {
            //判断是否限速，如果为-1就不进行限速
            if (Static.Dos.WhereaboutsVelocity == -1)
            {
                //判断值是否小于等于0,的话就赋值为1
                if (customsPass <= 0)
                {
                    //赋值为1
                    customsPass = 1;
                }
                //判断是否有值大于32，如果有就赋值为32
                else if (customsPass > 32)
                {
                    //赋值为32
                    customsPass = 32;
                }
                //返回值【关卡-1等于相应的索引位置】
                return Tetris._customsPassCorrespondingTime[customsPass - 1];
            }
            else
            {
                //返回限制的速度
                return Static.Dos.WhereaboutsVelocity;
            }
        }
        /// <summary>按照指定的样式进行重置
        /// 将重置的结果显示出来，并将每个的效果存入ShowUesInformation中
        /// </summary>
        /// <param name="style">重置成什么？【单人模式、双人合作、双人对抗】</param>
        public static void Reset(string style)
        {
            //判断是否有此模式
            if (!Tetris.ControlGroupList.ContainsKey(style)) throw new Exception("无“" + style + "”样式！");
            //将以前显示的样式隐藏
            Tetris.ControlGroupList[style].BrothersControlGroups.Visible = false;
            //显示当前控件元素
            Tetris.ControlGroupList[style].Visible = true;
            //将控件绑定到变量中
            Tetris.ShowUesInformation = Tetris.ControlGroupList[style].Tag as Control[][];
            //循环清除原来残留的信息
            for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
            {
                //得到表格
                Table tb1 = (Tetris.ShowUesInformation[i][0] as Table);
                //判断是否显示边框颜色
                if (Data.IsShowCellColor)
                {
                    //更改表格显示的边框颜色
                    tb1.BorderColor = Data.ShowCellColor;
                }
                else
                {
                    //更改表格颜色为透明
                    tb1.BackColor = Color.Transparent;
                }
                //清除显示元素的表格
                tb1.RefreshTable();
                //设置边框
                tb1.BorderStyle = Data.WhetherTheDisplayFrame ? BorderStyle.FixedSingle : BorderStyle.None;
                //得到下一个表格
                Table tb2 = Tetris.ShowUesInformation[i][1] as Table;
                //清除下一个表格
                tb2.RefreshTable();
                //设置边框
                tb2.BorderStyle = Data.WhetherShowTheNextFrame ? BorderStyle.FixedSingle : BorderStyle.None;
            }
        }
        /// <summary>根据键位获取触发此键的玩家和触发的命令
        /// 根据当前俄罗斯方块游戏的键位设定，根据指定的键，得到触发此键的玩家，及键位功能【如果没有设置此键就玩家就返回None】
        /// </summary>
        /// <param name="key">判断的键位</param>
        /// <returns>触发键位的玩家、触发的命令、触发键位的键</returns>
        public static OrderValue GetInstallOrder(Keys key)
        {
            //判断存储数据的对象是否有此键位数据
            if (Data.KeyAndOreder.ContainsKey(key))
            {
                //得到指定键所对应的命令，并返回此命令
                return Data.KeyAndOreder[key];
            }
            else
            {
                //没有此键返回默认状态触发的玩家为None
                return new OrderValue();
            }
        }
        /// <summary>打开或者关闭Dos命令窗口
        /// 
        /// </summary>
        public static void OpenOrCloseDosOrder()
        {
            //判断是否已经打开
            if (Dos.DosForm.IsAccessible)
            {
                //隐藏Dos命令窗体
                Dos.DosForm.Hide();
            }
            else
            {
                //显示Dos命令窗体
                Dos.DosForm.Show();
            }
        }
        /// <summary>打开主菜单方法
        /// 
        /// </summary>
        public static void OpenOrCloseMenu()
        {
            //显示遮罩容器
            Program.GameForm.PanelMenu.Visible = true;
            //隐藏它的兄弟容器们
            Program.GameForm.MenuControlList["主菜单"].BrothersControlGroups.Visible = false;
            //显示“主菜单”的容器
            Program.GameForm.MenuControlList["主菜单"].Visible = true;
            //默认选择开始游戏
            Program.GameForm.OF.buttStartTheGame.Focus();
        }
        /// <summary>打开暂停菜单方法
        /// 
        /// </summary>
        public static void OpenOrCloseStopMenu()
        {
            //暂停游戏
            Program.GameForm.IsStop = true;
            //显示遮罩容器
            Program.GameForm.PanelMenu.Visible = true;
            //隐藏它的兄弟容器们
            Program.GameForm.MenuControlList["暂停菜单"].BrothersControlGroups.Visible = false;
            //显示“字体菜单”的容器
            Program.GameForm.MenuControlList["暂停菜单"].Visible = true;
            //默认选择继续游戏
            Program.GameForm.OF.buttToContinueTheGame.Focus();
        }
        /// <summary>打开聊天窗口
        /// 
        /// </summary>
        public static void OpenChatForm()
        {
            throw new Exception("未实现！");
        }
        /// <summary>发送聊天信息方法
        /// 
        /// </summary>
        /// <param name="text">发送的文本信息</param>
        public static void SendInformation(string text)
        {
            throw new Exception("未实现！");
        }
        /// <summary>保存背景图片对象方法
        /// 
        /// </summary>
        /// <param name="img">要进行保存的背景图片对象</param>
        public static void SaveShowImage(Img img)
        {
            //得到父文件夹位置
            string Dir = Path.Combine(Data.DataSavePath, @"背景图片");
            //判断指定文件夹是否存在如果不存在就创建
            if (!Directory.Exists(Dir))
            {
                //创建文件夹
                Directory.CreateDirectory(Dir);
            }
            //把这个对象进行保存
            using (FileStream flie = new FileStream(Path.Combine(Data.DataSavePath, @"背景图片\" + img.Name + ".img"), FileMode.OpenOrCreate, FileAccess.Write))
            {
                //创建可以序列化类的对象
                BinaryFormatter bf = new BinaryFormatter();
                //把对象转换成2进制并放入选择的文件中
                bf.Serialize(flie, img);
            }
        }
        /// <summary>加载背景图片对象方法
        /// 
        /// </summary>
        /// <param name="filePath">加载的对象</param>
        /// <returns>加载完成的对象</returns>
        public static Img ReadShowImage(string filePath)
        {
            //合成路径
            filePath = Path.Combine(Data.DataSavePath, @"背景图片", filePath + ".img");
            //判断指定文件是否存在
            if (!File.Exists(filePath)) throw new Exception("指定路径：“" + filePath + "”文件不存在！");
            //开始反序列化
            using (FileStream fsRead = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                //把代码强制转换为这个对象并返回
                return (Img)bf.Deserialize(fsRead);
            }

        }
        /// <summary>判断指定图片对象是否存在
        /// 
        /// </summary>
        /// <param name="name">图片对象名称</param>
        /// <returns>true代表有false代表没有</returns>
        public static bool IfShowImage(string name)
        {
            //判断是否有这个文件
            return File.Exists(
                Path.Combine(
                //存储数据的文件夹
                    Data.DataSavePath,
                //指定文件
                   "背景图片\\" + name + ".img"
                )
           );
        }
    }
}
