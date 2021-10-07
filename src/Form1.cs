using LZLTetris.ConventionShape;
using LZLTetris.Game;
using LZLTetris.Game.GameObject;
using LZLTetris.Mode;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsTableControl;
using System.IO;
using System.Diagnostics;

namespace LZLTetris
{
    public partial class Form1 : Form
    {
        /// <summary>关于LZ俄罗斯方块窗体对象
        /// 
        /// </summary>
        private About ab = new About();
        /// <summary>帮助窗体对象
        /// 
        /// </summary>
        public Help help = new Help();
        /// <summary>默认背景图像
        /// 
        /// </summary>
        public static Image AcquiesceInImage;
        /// <summary>存储菜单控件的键值对集合
        /// 
        /// </summary>
        public Dictionary<string, ControlGroup> MenuControlList = new Dictionary<string, ControlGroup>();
        /// <summary>存储菜单窗体的控件
        /// 
        /// </summary>
        public optionFrom OF;
        private GameBase _gb;
        /// <summary>玩法对象
        /// 
        /// </summary>
        public GameBase GB
        {
            get { return this._gb; }
            set
            {
                this._gb = value;
                //设置游戏结束事件
                value.Over += () =>
                {
                    //设置暂停按钮为重新开始游戏
                    this.tsmStop1.Text = "重新开始";
                };
            }
        }
        /// <summary>模式对象数组
        /// 
        /// </summary>
        public ModeBase[] MBList;
        /// <summary>加载菜单控件方法
        /// 
        /// </summary>
        private void LoadMenuControl()
        {
            //创建存储控件的窗体
            optionFrom of = new optionFrom(this.MenuControlList);
            //赋值
            this.OF = of;
            //创建存储控件组的集合
            List<ControlGroup> CGList = new List<ControlGroup>();

            #region 得到所有菜单控件
            foreach (TabPage item in of.tabOption.TabPages)
            {
                //创建控件组对象
                ControlGroup cg = new ControlGroup(item.Text);
                //将对象存入集合
                CGList.Add(cg);
                //循环将元素存入对象
                foreach (Control con in item.Controls)
                {
                    //将元素存入控件绑定项集合中
                    cg.Add(con);
                }
            }
            #endregion

            #region 将所有控件都添加到集合容器中
            foreach (ControlGroup cgList in CGList)
            {
                //开始遍历元素并设置每个元素为隐藏
                for (int i = 0; i < cgList.Count; i++)
                {
                    //一开始就记录矩形位置及大小【防止出现BUG】
                    Rectangle rect = cgList[i].Bounds;
                    //将元素添加到控件中
                    this.PanelMenu.Controls.Add(cgList[i]);
                    //设置老位置及大小【防止出现BUG】
                    cgList[i].Bounds = rect;
                    //设置为隐藏
                    cgList[i].Visible = false;
                }
            }
            #endregion

            #region 设置同级对象集合
            for (int i = 0; i < CGList.Count; i++)
            {
                //设置内层循环【并且不将当前对象存入】
                for (int j = 0; j < CGList.Count; j++)
                {
                    //判断是否到当对象的位置了
                    if (i == j) continue;
                    //将元素存入
                    CGList[i].BrothersControlGroups.Add(CGList[j]);
                }
            }
            #endregion

            //将元素存入键值对集合
            for (int i = 0; i < CGList.Count; i++)
            {
                //存入元素
                this.MenuControlList.Add(CGList[i].Name, CGList[i]);
            }
        }
        /// <summary>创建菜单容器控件
        /// 
        /// </summary>
        public Panel PanelMenu;
        /// <summary>构造函数
        /// 
        /// </summary>
        public Form1()
        {
            //创建容器控件
            Panel P = new Panel();
            //赋值
            this.PanelMenu = P;
            //设置背景图片更改事件
            P.BackgroundImageChanged += (a, c) =>
            {
                //调用更改背景图片方法
                this.OF.SetBackgroundImage(new Bitmap(this.PanelMenu.BackgroundImage));
            };
            //设置位置
            P.Location = new Point(0, 0);
            //填充到当前窗体中
            this.Controls.Add(P);
            //设置容器控件大小
            P.Size = new System.Drawing.Size(950, 535);
            //隐藏控件
            P.Visible = false;



            //加载控件
            InitializeComponent();

            //设置默认背景图像
            Form1.AcquiesceInImage = this.panelGame.BackgroundImage;


            #region 遮罩层
            //设置位置【x为0，y为菜单控件的高度【因为不用遮住菜单控件】】
            this.Mask.Location = new Point(0, this.menuStrip.Height);
            //设置大小【宽度为父容器控件的宽度，高度因为不需要遮罩菜单控件，所以减去菜单控件高度】
            this.Mask.Size = new System.Drawing.Size(this.PanelMenu.Width, this.panelGame.Height - this.menuStrip.Height);
            //将控件隐藏
            this.Mask.Visible = false;
            #endregion



            //调用加载菜单控件的方法
            this.LoadMenuControl();

        }
        /// <summary>窗体加载事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置允许不同线程访问同一资源
            Control.CheckForIllegalCrossThreadCalls = false;

            #region 加载设置文件
            //判断是否有设置文件
            if (File.Exists(Path.Combine(Data.DataSavePath, "LZ俄罗斯方块设置文件.set")))
            {
                //判断是否出错
                try
                {
                    //加载设置文件
                    Data.ReadSet();
                }
                catch
                {
                    //保存当前设置【下次就有设置可以读取了】
                    Data.SaveSet();
                    //刷新设置键位的方法
                    Data.RefreshKeySet();
                }
            }
            else
            {
                //保存当前设置【下次就有设置可以读取了】
                Data.SaveSet();
                //刷新设置键位的方法
                Data.RefreshKeySet();
            }
            #endregion


            #region 加载背景信息【背景图片】
            //得到指定名称的设置文件是否存在
            if (Tetris.IfShowImage(Data.TheBackgroundImageName))
            {
                //加载此背景图片并进行设置
                Tetris.ShowImage = Tetris.ReadShowImage(Data.TheBackgroundImageName);
            }
            else
            {
                //创建图片对象
                Img img = null;
                //判断默认背景是否存在
                if (!Tetris.IfShowImage("默认背景"))//进入代表不存在
                {
                    //弹出提示框
                    Tool.ShowRemindBox("正在生成背景请稍等片刻[下次就不需要等待了！]...\r\n请点击确定按钮关闭此对话框O(∩_∩)O~~");
                    //更改模糊度为2
                    Data.GaussianBlurDegree = 2f;
                    //创建背景对象
                    img = new Img(this.panelGame.BackgroundImage, Data.GaussianBlurDegree, "默认背景");
                    //保存当前背景
                    Tetris.SaveShowImage(img);
                }
                else//进入代表存在
                {
                    //加载默认背景
                    img = Tetris.ReadShowImage("默认背景");
                }
                //将图片背景保存
                Tetris.ShowImage = img;
                //存储设置名称
                Data.TheBackgroundImageName = "默认背景";
                //设置为选择默认背景
                Data.UseTheDefaultBackgroundImage = true;
                //调用设置保存方法
                Data.SaveSet();
            }
            #endregion

            #region 加载排行榜信息
            //判断排行榜信息文件是否存在
            if (File.Exists(Path.Combine(Data.DataSavePath, "LZ排行榜数据.dat")))
            {
                //调用加载排行榜数据方法
                Data.ReadRanking();
            }
            else
            {
                //创建一个空存储排行榜信息的集合
                Data.GameHistoryInformationList = new List<GameHistoryInformation>();
                //调用保存方法
                Data.SaveRanking();
            }
            #endregion

            //读取成就记录信息
            Data.TakeNotes.ReadTakeNotes();
            //刷新成就
            Data.TakeNotes.RefreshAchievement();

            //调用刷新设置方法
            this.OF.LoadSet();

            //显示菜单容器
            this.PanelMenu.Visible = true;
            //显示菜单上的控件
            this.MenuControlList["主菜单"].Visible = true;
        }
        private bool _isStop;
        /// <summary>获取与设置是否暂停【true为暂停，false为继续】
        /// 
        /// </summary>
        public bool IsStop
        {
            get { return this._isStop; }
            set
            {
                //设置值
                this._isStop = value;
                //判断输入的是暂停还是继续
                if (value)
                {
                    #region 暂停方法
                    //调用玩法对象的停止方法
                    this.GB.Stop();
                    //拍一张照片
                    Bitmap Bp = new Bitmap(this.panelGame.Width, this.panelGame.Height);
                    //开始拍摄
                    this.panelGame.DrawToBitmap(Bp, this.panelGame.ClientRectangle);
                    //开始截取
                    Bp = Bp.Clone(new Rectangle(0, this.menuStrip.Height, this.panelGame.Width, (this.panelGame.Height - this.menuStrip.Height))
                    , Bp.PixelFormat);
                    //将图片显示到遮罩容器的背景
                    this.Mask.BackgroundImage = Bp;
                    //填充颜色
                    Tool.CoverColor(Bp, Color.FromArgb(200, 200, 200, 200));
                    //显示遮罩容器
                    this.Mask.Visible = true;
                    //更改菜单栏显示的文字
                    this.tsmStop1.Text = "继续";
                    this.tsmStop.Text = "继续";
                    #endregion
                    //开启计时器
                    this.timer1.Enabled = true;
                    //播放暂停音效音效
                    Music.StopMusic();
                }
                else
                {
                    //调用玩法对象的开始方法
                    this.GB.Start();
                    //隐藏遮罩层
                    this.Mask.Visible = false;
                    //更改菜单栏显示的文字
                    this.tsmStop1.Text = "暂停";
                    this.tsmStop.Text = "暂停";
                    //关闭计时器
                    this.timer1.Enabled = false;
                }
            }
        }
        /// <summary>菜单栏->暂停/继续按钮
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmStop_Click(object sender, EventArgs e)
        {
            //转换成控件
            ToolStripMenuItem tmStop = sender as ToolStripMenuItem;
            //判断是暂停还是重新开始
            if (tmStop.Text == "重新开始")
            {
                //调用重置方法
                this.GB.Reset();
                //调用开始方法
                this.GB.Start();
                //设置为暂停
                tmStop.Text = "暂停";
            }
            else
            {
                //设置暂停还是继续，得到值的取反
                this.IsStop = !this._isStop;
            }
        }
        /// <summary>菜单栏->主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTheMainMenu_Click(object sender, EventArgs e)
        {
            //停止
            this.IsStop = true;
            //弹出要用户选择是否退出
            if (Tool.ShowSelectBox(this.GB.IsGameOver ? "是否返回主菜单？" : "游戏尚未结束！现在返回主菜单数据将不会保存！是否返回？") == DialogResult.Yes)
            {
                //调用停止方法
                this.GB.Close();
                //调用打开主菜单方法
                Tetris.OpenOrCloseMenu();
            }
        }
        /// <summary>菜单->暂停菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTheStopMenu_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //调用打开主菜单方法
            Tetris.OpenOrCloseStopMenu();
        }
        /// <summary>菜单->排行榜
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmList_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示菜单层
            this.PanelMenu.Visible = true;
            //显示排行榜
            this.MenuControlList["排行榜"].Visible = true;
            //设置排行榜的返回按钮为：返回游戏
            this.OF.buttReturnToTheMainMenu2.Text = "返回游戏";
            //设置焦点为排行榜表
            this.OF.listVRanking.Focus();
        }
        /// <summary>菜单->游戏设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGameSet_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示菜单层
            this.PanelMenu.Visible = true;
            //显示游戏设置
            this.MenuControlList["游戏设置"].Visible = true;
            //设置游戏设置的返回按钮为：返回游戏
            this.OF.buttReturnToTheMainMenu3.Text = "返回游戏";
        }
        /// <summary>容器背景图片发送改变触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelGame_BackgroundImageChanged(object sender, EventArgs e)
        {
            //判断是否为空，如果为空就退出
            if (Tetris.ShowUesInformation == null) return;
            //得到背景图片
            Bitmap Bp = new Bitmap(panelGame.BackgroundImage);
            //开始循环更改背景
            foreach (Control[] item in Tetris.ShowUesInformation)
            {
                //开始更改背景【主表格】
                item[0].BackgroundImage = Bp.Clone(item[0].Bounds, Bp.PixelFormat);
                //开更改显示下一个的表格
                item[1].BackgroundImage = Bp.Clone(item[1].Bounds, Bp.PixelFormat);
            }
        }
        /// <summary>点击退出游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExitTheGame_Click(object sender, EventArgs e)
        {
            //调用退出游戏方法
            this.ExitGame();
        }
        /// <summary>退出游戏方法
        /// 
        /// </summary>
        private void ExitGame()
        {
            //判断GameBase是否为空
            if (this.GB != null && !this.GB.IsGameOver && !this.IsStop)
            {
                //调用暂停
                this.IsStop = true;
            }
            //弹出选择框
            if (Tool.ShowSelectBox("是否退出LZ俄罗斯方块？") == DialogResult.Yes)
            {
                //关闭程序
                Application.Exit();
            }
        }
        /// <summary>点击退出游戏方法
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            //调用退出游戏方法
            this.ExitGame();
        }
        /// <summary>点击菜单的成就触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chAchievement_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示菜单层
            this.PanelMenu.Visible = true;
            //显示成就
            this.MenuControlList["成就"].Visible = true;
            //设置排行榜的返回按钮为：返回游戏
            this.OF.buttReturnToTheMainMenu4.Text = "返回游戏";
            //设置焦点为成就表
            this.OF.lvAchievement.Focus();
        }
        /// <summary>点击关闭LZ俄罗斯方块
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMAboutTheLZTetris_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示窗体
            this.ab.Show();
        }
        //存储时间
        int zt = 0;
        /// <summary>计时器事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //判断状态
            if (zt == 0)
            {
                //设置显示值
                this.labelShowStop.Text = "暂停中.  ";
                zt = 1;
            }
            else if (zt == 1)
            {
                //设置显示值
                this.labelShowStop.Text = "暂停中.. ";
                zt = 2;
            }
            else
            {
                //设置显示值
                this.labelShowStop.Text = "暂停中...";
                zt = 0;
            }
        }
        /// <summary>点击帮助按钮
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSeeTheHelp_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示帮助
            this.help.Show();
        }
        /// <summary>点击重新开始游戏按钮
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsResf_Click(object sender, EventArgs e)
        {
            //调用重置方法
            this.GB.Reset();
            //调用开始方法
            this.GB.Start();
        }
        /// <summary>点击查看帮助人员信息
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsHelpInformation_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示信息
            Tool.ShowRemindBox("帮助人员：↓\r\n殷振海、易峥颖、周鑫、罗承志、陈丽");
        }
        /// <summary>介绍当前版本新增的内容
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmVer_Click(object sender, EventArgs e)
        {
            //判断是否没有暂停就进行暂停
            if (!this.IsStop)
            {
                //暂停游戏
                this.IsStop = true;
            }
            //显示内容
            Tool.ShowRemindBox("当前版本新增内容：↓\r\n1.新增计时模式\r\n2.显示有帮助的人\r\n3.显示超过上一名\r\n4.可以显示格子线条\r\n5.解决键位重复BUG\r\n6.添加合作默契度比例\r\n7.单人模式玩家键位通用\r\n8.BOSS模式模型360度转动");
        }
    }
}
