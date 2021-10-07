using LZLTetris.ConventionShape;
using LZLTetris.Game;
using LZLTetris.Game.GameObject;
using LZLTetris.Mode;
using LZLTetris.Mode.ModeObject;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsTableControl;

namespace LZLTetris
{
    public partial class optionFrom : Form
    {
        /// <summary>背景图片
        /// 
        /// </summary>
        public Bitmap Background;
        /// <summary>当前页面的控件组
        /// 
        /// </summary>
        private Dictionary<string, ControlGroup> MenuControlList;
        /// <summary>创建当前对象并传入初始值
        /// 
        /// </summary>
        /// <param name="dictionary">初始值</param>
        public optionFrom(Dictionary<string, ControlGroup> menuControlList)
        {
            InitializeComponent();
            //将控件集合存入当前对象
            this.MenuControlList = menuControlList;
            //调用加载设置方法
            this.LoadSet();
        }
        /// <summary>返回游戏窗体方法
        /// 
        /// </summary>
        private void ReturnGame()
        {
            //隐藏菜单层
            Program.GameForm.PanelMenu.Visible = false;
        }
        /// <summary>更改背景图片【更改各个控件的背景图片方法】
        /// 
        /// </summary>
        /// <param name="img">背景图片</param>
        public void SetBackgroundImage(Bitmap img)
        {
            #region 多人游戏
            //更改：多人游戏->本地多人 的背景
            this.gbThisLocality.BackgroundImage = img.Clone(new Rectangle(this.gbThisLocality.Location, this.gbThisLocality.Size), img.PixelFormat);
            //更改：多人游戏->联机多人 的背景
            this.gbOnline.BackgroundImage = img.Clone(new Rectangle(this.gbOnline.Location, this.gbOnline.Size), img.PixelFormat);
            #endregion

            #region 游戏设置
            //更改：游戏设置->键位设置的背景
            this.groupBox3.BackgroundImage = img.Clone(new Rectangle(this.groupBox3.Location, this.groupBox3.Size), img.PixelFormat);
            //更改：游戏设置->声音设置的背景
            this.groupBox4.BackgroundImage = img.Clone(new Rectangle(this.groupBox4.Location, this.groupBox4.Size), img.PixelFormat);
            //更改：游戏设置->显示设置的背景
            this.groupBox5.BackgroundImage = img.Clone(new Rectangle(this.groupBox5.Location, this.groupBox5.Size), img.PixelFormat);

            #region 键位设置Label背景

            //得到键位设置背景图片
            Bitmap keyImage = new Bitmap(this.groupBox3.BackgroundImage);
            //设置 暂停游戏 背景
            this.label12.Image = keyImage.Clone(new Rectangle(this.label12.Location, this.label12.Size), keyImage.PixelFormat);
            //设置 控制台 背景
            this.label13.Image = keyImage.Clone(new Rectangle(this.label13.Location, this.label13.Size), keyImage.PixelFormat);
            //设置 打开菜单 背景
            this.label14.Image = keyImage.Clone(new Rectangle(this.label14.Location, this.label14.Size), keyImage.PixelFormat);

            #endregion

            #region 声音设置Label背景

            //得到声音设置背景
            Bitmap voiceImage = new Bitmap(this.groupBox4.BackgroundImage);
            //设置是否开启背景音乐复选框背景
            this.cbIfOpenTheBackgroundMusic.BackgroundImage = voiceImage.Clone(new Rectangle(this.cbIfOpenTheBackgroundMusic.Location, this.cbIfOpenTheBackgroundMusic.Size), voiceImage.PixelFormat);

            #endregion

            #region 显示设置Label背景

            //得到显示设置背景
            Bitmap showImage = new Bitmap(this.groupBox5.BackgroundImage);
            //设置“是否显示下一个的边框”的Label的背景图片
            this.cbWhetherShowTheNextFrame.BackgroundImage = showImage.Clone(this.cbWhetherShowTheNextFrame.Bounds, showImage.PixelFormat);
            //设置“是否显示界面边框”的Label的背景图片
            this.cbWhetherTheDisplayFrame.BackgroundImage = showImage.Clone(this.cbWhetherTheDisplayFrame.Bounds, showImage.PixelFormat);
            //设置是否显示背景图片的背景图片
            this.cbWhetherToShowTheBackgroundImage.BackgroundImage = showImage.Clone(new Rectangle(this.cbWhetherToShowTheBackgroundImage.Location, this.cbWhetherToShowTheBackgroundImage.Size), showImage.PixelFormat);
            //设置背景图片Label背景
            this.label15.Image = showImage.Clone(new Rectangle(this.label15.Location, this.label15.Size), showImage.PixelFormat);
            //设置高斯模糊程度Label背景
            this.label11.Image = showImage.Clone(new Rectangle(this.label11.Location, this.label11.Size), showImage.PixelFormat);
            //设置是否显示显示线条颜色复选框背景
            this.cbShowCellColor.BackgroundImage = showImage.Clone(this.cbShowCellColor.Bounds, showImage.PixelFormat);
            //设置格子线条颜色背景
            this.labeShowColor.Image = showImage.Clone(this.labeShowColor.Bounds, showImage.PixelFormat);
            #endregion

            #endregion

            #region 排行榜
            //更改：排行榜->显示数据的背景图片
            this.listVRanking.BackgroundImage = img.Clone(
                new Rectangle(
                    this.listVRanking.Location,
                    this.listVRanking.Size
                ),
                img.PixelFormat
            );
            #endregion

            #region 设置下落方块颜色
            //设置形状I表格背景
            this.tbI.BackgroundImage = img.Clone(this.tbI.Bounds, img.PixelFormat);
            //设置形状J表格背景
            this.tbJ.BackgroundImage = img.Clone(this.tbJ.Bounds, img.PixelFormat);
            //设置形状L表格背景
            this.tbL.BackgroundImage = img.Clone(this.tbL.Bounds, img.PixelFormat);
            //设置形状O表格背景
            this.tbO.BackgroundImage = img.Clone(this.tbO.Bounds, img.PixelFormat);
            //设置形状S表格背景
            this.tbS.BackgroundImage = img.Clone(this.tbS.Bounds, img.PixelFormat);
            //设置形状T表格背景
            this.tbT.BackgroundImage = img.Clone(this.tbT.Bounds, img.PixelFormat);
            //设置形状Z表格背景
            this.tbZ.BackgroundImage = img.Clone(this.tbZ.Bounds, img.PixelFormat);
            #endregion

            #region 成就
            //更改：成就->显示数据的背景图片
            this.lvAchievement.BackgroundImage = img.Clone(
                this.lvAchievement.Bounds,
                img.PixelFormat
            );
            #endregion
        }
        /// <summary>加载设置方法
        /// 
        /// </summary>
        public void LoadSet()
        {
            #region 设置键位设置
            //加载暂停游戏键位
            this.txtPauseTheGame.Text = Data.StopGame.ToString();
            //加载控制台键位
            this.txtTheConsole.Text = Data.OpenDosKey.ToString();
            //加载打开菜单键位
            this.txtOpenTheMenu.Text = Data.OpenMenuKey.ToString();

            #region 加载玩家一键位设置
            //加载玩家一信息
            PlayerSet ps1 = Data.PlayerSetList[0];
            //加载旋转模型键位
            this.txtRotaryModel1.Text = ps1.Spin.ToString();
            //加载左移一格键位
            this.txtOneStepLeft1.Text = ps1.LeftMove.ToString();
            //加载右移一格键位
            this.txtMovesToTheRightStep1.Text = ps1.RighMove.ToString();
            //加载下移一格键位
            this.txtAStepDown1.Text = ps1.BelowMove.ToString();
            //加载下移到底键位
            this.txtDownToTheEnd1.Text = ps1.MoveToTheEnd.ToString();
            #endregion

            #region 加载玩家二键位设置
            //加载玩家一信息
            PlayerSet ps2 = Data.PlayerSetList[1];
            //加载旋转模型键位
            this.txtRotaryModel2.Text = ps2.Spin.ToString();
            //加载左移一格键位
            this.txtOneStepLeft2.Text = ps2.LeftMove.ToString();
            //加载右移一格键位
            this.txtMovesToTheRightStep2.Text = ps2.RighMove.ToString();
            //加载下移一格键位
            this.txtAStepDown2.Text = ps2.BelowMove.ToString();
            //加载下移到底键位
            this.txtDownToTheEnd2.Text = ps2.MoveToTheEnd.ToString();
            #endregion

            #endregion

            #region 声音设置
            //是否开启音效
            this.cbIfOpenTheBackgroundMusic.Checked = Data.IsMusic;
            #endregion

            #region 显示设置
            //设置是否显示下一个的边框
            this.cbWhetherShowTheNextFrame.Checked = Data.WhetherShowTheNextFrame;
            //设置是否显示界面边框
            this.cbWhetherTheDisplayFrame.Checked = Data.WhetherTheDisplayFrame;
            //设置是否使用默认背景图片
            this.cbWhetherToShowTheBackgroundImage.Checked = Data.UseTheDefaultBackgroundImage;
            //背景图片名称
            this.txtTheBackgroundImage.Text = Data.TheBackgroundImageName;
            //设置高斯模糊程度
            this.nudGaussianBlurDegree.Value = (decimal)Data.GaussianBlurDegree;
            //设置是否显示边框颜色
            this.cbShowCellColor.Checked = Data.IsShowCellColor;
            //显示颜色
            this.scShowColor.SelectColor = Data.ShowCellColor;

            #region 设置下落颜色显示的方块的绑定项
            //绑定形状I
            this.SetWhereaboutsShapeColor(TetrisItme_I.BreviaryList[0], this.tbI, this.scI);
            //更改显示颜色
            this.scI.SelectColor = Data.ShapeColor.Shape_I;
            //绑定形状J
            this.SetWhereaboutsShapeColor(TetrisItme_J.BreviaryList[0], this.tbJ, this.scJ);
            //更改显示颜色
            this.scJ.SelectColor = Data.ShapeColor.Shape_J;
            //绑定形状L
            this.SetWhereaboutsShapeColor(TetrisItme_L.BreviaryList[0], this.tbL, this.scL);
            //更改显示颜色
            this.scL.SelectColor = Data.ShapeColor.Shape_L;
            //绑定形状O
            this.SetWhereaboutsShapeColor(TetrisItme_O.BreviaryList, this.tbO, this.scO);
            //更改显示颜色
            this.scO.SelectColor = Data.ShapeColor.Shape_O;
            //绑定形状S
            this.SetWhereaboutsShapeColor(TetrisItme_S.BreviaryList[0], this.tbS, this.scS);
            //更改显示颜色
            this.scS.SelectColor = Data.ShapeColor.Shape_S;
            //绑定形状T
            this.SetWhereaboutsShapeColor(TetrisItme_T.BreviaryList[2], this.tbT, this.scT);
            //更改显示颜色
            this.scT.SelectColor = Data.ShapeColor.Shape_T;
            //绑定形状Z
            this.SetWhereaboutsShapeColor(TetrisItme_Z.BreviaryList[0], this.tbZ, this.scZ);
            //更改显示颜色
            this.scZ.SelectColor = Data.ShapeColor.Shape_Z;
            #endregion
            #endregion
        }
        /// <summary>将表格和显示模型绑定方法
        /// 
        /// </summary>
        /// <param name="breviary">显示的模型坐标</param>
        /// <param name="table">显示的表格</param>
        /// <param name="selectColour">选择颜色的控件对象</param>
        private void SetWhereaboutsShapeColor(TableIndex[] breviary, Table table, SelectColour selectColour)
        {
            //绑定颜色更改事件
            selectColour.SelectNewColor += (color) =>
            {
                //将指定位置的方块颜色清空
                table.ShowIndexList(breviary, color);
            };
        }
        /// <summary>判断是否有键位冲突
        /// 
        /// </summary>
        /// <param name="key">键位的字符串形式</param>
        /// <returns>如果不为null就代表有重复，而返回的文本框就是重复的文本框</returns>
        private TextBox IfThereIsAFewConflicts(string key)
        {
            //开始循环遍历键位设置判断是否有键位冲突
            foreach (Control item in this.groupBox3.Controls)
            {
                //试着转换成文本框
                TextBox tb = item as TextBox;
                //判断是否转换成功
                if (tb != null)
                {
                    //判断值是否重复，如果一致就返回重复的文本框
                    if (key == tb.Text) return tb;
                }
            }
            //开始循环遍历玩家键位
            foreach (TabPage cont in this.tabControl1.TabPages)
            {
                //遍历页面内部元素
                foreach (Control item in cont.Controls)
                {
                    //试着转换成文本框
                    TextBox tb = item as TextBox;
                    //判断是否转换成功
                    if (tb != null)
                    {
                        //判断值是否重复，如果一致就返回重复的文本框
                        if (key == tb.Text) return tb;
                    }
                }
            }
            //返回不重复
            return null;
        }
        #region 主菜单按钮事件设置
        /// <summary>主菜单->开始游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttStartTheGame_Click(object sender, EventArgs e)
        {
            //设置主菜单为隐藏
            this.MenuControlList["主菜单"].Visible = false;
            //调用显示“合作或单人模式”页面组
            this.MenuControlList["合作或单人模式"].Visible = true;
            //设置返回按钮文本 返回主菜单
            this.buttReturnToTheMainMenu.Text = "返回主菜单";
            //设置合作或单人模式的Tag内容 单人模式
            this.MenuControlList["合作或单人模式"].Tag = "单人模式";
            //设置默认选择第一个按钮【普通模式】
            this.buttNormalMode.Focus();
        }
        /// <summary>主菜单->排行榜
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttList_Click(object sender, EventArgs e)
        {
            //设置主菜单为隐藏
            this.MenuControlList["主菜单"].Visible = false;
            //调用显示“排行榜”页面组
            this.MenuControlList["排行榜"].Visible = true;
            //设置设置的返回按钮文本为：返回到主菜单
            this.buttReturnToTheMainMenu2.Text = "返回到主菜单";
            //设置默认选择第一个按钮【表格】
            this.listVRanking.Focus();
        }
        /// <summary>主菜单->成就
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAchievement_Click(object sender, EventArgs e)
        {
            //设置主菜单为隐藏
            this.MenuControlList["主菜单"].Visible = false;
            //调用显示“成就”页面组
            this.MenuControlList["成就"].Visible = true;
            //设置设置的返回按钮文本为：返回到主菜单
            this.buttReturnToTheMainMenu4.Text = "返回到主菜单";
            //设置焦点为表格
            this.lvAchievement.Focus();
        }
        /// <summary>主菜单->多人游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttMultiplayerGames_Click(object sender, EventArgs e)
        {
            //设置主菜单为隐藏
            this.MenuControlList["主菜单"].Visible = false;
            //调用显示“多人游戏”页面组
            this.MenuControlList["多人游戏"].Visible = true;
            //设置默认选择第一个按钮【双人合作模式】
            this.buttLocalCoOperativeMode.Focus();
        }
        /// <summary>主菜单游戏设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttTheGameIsSet_Click(object sender, EventArgs e)
        {
            //设置主菜单为隐藏
            this.MenuControlList["主菜单"].Visible = false;
            //调用显示“游戏设置”页面组
            this.MenuControlList["游戏设置"].Visible = true;
            //设置设置的返回按钮文本为：返回到主菜单
            this.buttReturnToTheMainMenu3.Text = "返回主菜单";
            //设置默认选择第一个按钮【保存设置】
            this.buttSaveSet.Focus();
        }
        /// <summary>主菜单->退出游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttQuitTheGame_Click(object sender, EventArgs e)
        {
            //关闭当前程序
            Application.Exit();
        }
        #endregion

        #region 设置按钮选择的显示的样式
        /// <summary>按钮得到焦点触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonToGetFocus(object sender, EventArgs e)
        {
            //将当前对象转换成按钮
            Button but = sender as Button;
            //设置按钮的字体为粗体
            but.Font = new Font(but.Font.FontFamily, but.Font.Size, FontStyle.Bold);
        }
        /// <summary>按钮失去焦点触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLosesFocus(object sender, EventArgs e)
        {
            //将当前对象转换成按钮
            Button but = sender as Button;
            //设置按钮的字体为默认
            but.Font = new Font(but.Font.FontFamily, but.Font.Size, FontStyle.Regular);
        }
        #endregion

        #region 合作或单人模式
        /// <summary>表格刷新方法
        /// 
        /// </summary>
        private void TableRefresh()
        {
            #region 如果不写这个就会出现，形状走过的区域不恢复为背景
            //得到当前显示的图片
            Bitmap BP = new Bitmap(Program.GameForm.panelGame.BackgroundImage);
            //循环进行刷新截取背景
            for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
            {
                //得到显示数据的表格
                Table tab1 = Tetris.ShowUesInformation[i][0] as Table;
                //得到背景图片
                tab1.BackgroundImage = BP.Clone(new Rectangle(tab1.Location, tab1.Size), BP.PixelFormat);
                //得到显示下一个的表格
                Table nextTable = Tetris.ShowUesInformation[i][1] as Table;
                //得到背景图片
                nextTable.BackgroundImage = BP.Clone(new Rectangle(nextTable.Location, nextTable.Size), BP.PixelFormat);
            }
            #endregion
        }
        /// <summary>合作或单人模式->普通模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttNormalMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“普通模式”对象
                this.OnePersonMode("普通模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“普通模式”
                this.ThisTowPersonMode("普通模式");
            }
        }
        /// <summary>单人玩法根据指定模式来创建模式对象
        /// 
        /// </summary>
        /// <param name="mode">指定的模式对象</param>
        private void OnePersonMode(string mode)
        {
            //创建单人玩法对象
            GameBase gb = new OnePersonGame();
            //赋值玩法
            Program.GameForm.GB = gb;
            //创建模式对象
            ModeBase mb = null;
            switch (mode)
            {
                case "普通模式":
                    mb = new CommonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "马拉松模式":
                    mb = new MarathonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "无尽模式":
                    mb = new LookForDieMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "上气不接下气模式":
                    mb = new BeOutOfBreathMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "挑战模式":
                    mb = new ChallengeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "隐形模式":
                    mb = new InvisibleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    //设置是否隐藏固定单元格属性，取反值，因为模式对象是是否隐藏，而这个是是否显示
                    (mb as IHideMode).IsHide = !Dos.IsShowCell;
                    break;
                case "大杂烩模式":
                    mb = new MeddleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    //判断Dos命令里面是否输入了不隐藏单元格，如果设置了就设置为不隐藏单元格
                    if (Dos.IsShowCell)
                    {
                        //设置不隐藏单元格
                        (mb as IHideMode).IsHide = false;
                    }
                    break;
                case "大乱斗模式":
                    mb = new BigChaosFight(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "计时模式":
                    mb = new TimeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
            }
            //将模式存入玩法对象
            gb.ModeList = new ModeBase[] { mb };
            //创建一个玩家对象
            Player play = new Player(
                //玩家产生的方块模型起始位置
                6,
                //用于显示下一个要出来的方块形状的表格控件对象
                Tetris.ShowUesInformation[0][1] as Table,
                //存储显示关卡信息的标签对象【显示所在关卡】
                Tetris.ShowUesInformation[0][2] as Label,
                //存储显示得分的标签对象
                Tetris.ShowUesInformation[0][3] as Label,
                //储存显示消灭的行数的标签对象
                Tetris.ShowUesInformation[0][4] as Label,
                //当前俄罗斯方块模型对象
                mb.NextShape(6, false),
                //当前玩家对象所在的模式对象
                mb,
                //显示下落的方块【形状】数量的标签对象
                Tetris.ShowUesInformation[0][5] as Label
            );
            //将玩家对象存入模式数组
            mb.PlayerList = new Player[] { play };
            //隐藏当前界面
            this.MenuControlList["合作或单人模式"].Visible = false;
            //隐藏菜单容器
            Program.GameForm.PanelMenu.Visible = false;
            //调用表格刷新方法
            this.TableRefresh();
            //调用表格刷新方法
            this.TableRefresh();
            //调用模式对象的刷新方法
            mb.Show();
            //开始
            gb.Start();
            //停止暂停
            Program.GameForm.IsStop = false;
            //播放开始音效
            Music.BeginMusic();
        }
        /// <summary>本地双人玩法根据指定模式来创建模式对象
        /// 
        /// </summary>
        /// <param name="mode">指定的模式对象</param>
        private void ThisTowPersonMode(string mode)
        {
            //创建本地双人玩法对象
            GameBase gb = new ThisLocalityTwoPersonCooperationGame();
            //赋值玩法
            Program.GameForm.GB = gb;
            //创建模式对象
            ModeBase mb = null;
            switch (mode)
            {
                case "普通模式":
                    mb = new CommonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "马拉松模式":
                    mb = new MarathonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "无尽模式":
                    mb = new LookForDieMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "上气不接下气模式":
                    mb = new BeOutOfBreathMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "挑战模式":
                    mb = new ChallengeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "隐形模式":
                    mb = new InvisibleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    //设置是否隐藏固定单元格属性，取反值，因为模式对象是是否隐藏，而这个是是否显示
                    (mb as IHideMode).IsHide = !Dos.IsShowCell;
                    break;
                case "大杂烩模式":
                    mb = new MeddleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    //判断Dos命令里面是否输入了不隐藏单元格，如果设置了就设置为不隐藏单元格
                    if (Dos.IsShowCell)
                    {
                        //设置不隐藏单元格
                        (mb as IHideMode).IsHide = false;
                    }
                    break;
                case "大乱斗模式":
                    mb = new BigChaosFight(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
                case "计时模式":
                    mb = new TimeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    break;
            }
            //将模式存入玩法对象
            gb.ModeList = new ModeBase[] { mb };
            //创建一个玩家一对象
            Player play01 = new Player(
                //玩家一产生的方块模型起始位置
                6,
                //用于显示下一个要出来的方块形状的表格控件对象
                Tetris.ShowUesInformation[0][1] as Table,
                //存储显示关卡信息的标签对象【显示所在关卡】
                Tetris.ShowUesInformation[0][2] as Label,
                //存储显示得分的标签对象
                Tetris.ShowUesInformation[0][3] as Label,
                //储存显示消灭的行数的标签对象
                Tetris.ShowUesInformation[0][4] as Label,
                //当前俄罗斯方块模型对象
                mb.NextShape(6, false),
                //当前玩家一对象所在的模式对象
                mb,
                //显示下落的方块【形状】数量的标签对象
                Tetris.ShowUesInformation[0][5] as Label
            );
            //创建一个玩家二对象
            Player play02 = new Player(
                //玩家二产生的方块模型起始位置
                16,
                //用于显示下一个要出来的方块形状的表格控件对象
                Tetris.ShowUesInformation[1][1] as Table,
                //存储显示关卡信息的标签对象【显示所在关卡】
                Tetris.ShowUesInformation[1][2] as Label,
                //存储显示得分的标签对象
                Tetris.ShowUesInformation[1][3] as Label,
                //储存显示消灭的行数的标签对象
                Tetris.ShowUesInformation[1][4] as Label,
                //当前俄罗斯方块模型对象
                mb.NextShape(16, false),
                //当前玩家二对象所在的模式对象
                mb,
                //显示下落的方块【形状】数量的标签对象
                Tetris.ShowUesInformation[1][5] as Label
            );
            //将玩家对象存入模式数组
            mb.PlayerList = new Player[] { play01, play02 };
            //隐藏当前界面
            this.MenuControlList["合作或单人模式"].Visible = false;
            //隐藏菜单容器
            Program.GameForm.PanelMenu.Visible = false;
            //调用表格刷新方法
            this.TableRefresh();
            //调用表格刷新方法
            this.TableRefresh();
            //调用模式对象的刷新方法
            mb.Show();
            //开始
            gb.Start();
            //停止暂停
            Program.GameForm.IsStop = false;
            //播放开始音效
            Music.BeginMusic();
        }
        /// <summary>合作或者单人模式->马拉松模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttMarathonMode_Click_1(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“马拉松模式”对象
                this.OnePersonMode("马拉松模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“马拉松模式”
                this.ThisTowPersonMode("马拉松模式");
            }
        }
        /// <summary>合作或单人模式->挑战模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttChallengeMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“挑战模式”对象
                this.OnePersonMode("挑战模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“挑战模式”
                this.ThisTowPersonMode("挑战模式");
            }
        }
        /// <summary>合作或单人模式->无尽模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttFaultMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“无尽模式”对象
                this.OnePersonMode("无尽模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“无尽模式”
                this.ThisTowPersonMode("无尽模式");
            }
        }
        /// <summary>合作或单人模式->上气不接下气模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAllOutOfBreathMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“上气不接下气模式”对象
                this.OnePersonMode("上气不接下气模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“上气不接下气模式”
                this.ThisTowPersonMode("上气不接下气模式");
            }
        }
        /// <summary>合作或单人模式->大杂烩模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttHodgepodgeMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“大杂烩模式”对象
                this.OnePersonMode("大杂烩模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“大杂烩模式”
                this.ThisTowPersonMode("大杂烩模式");
            }
        }
        /// <summary>合作或单人模式->大乱斗
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttTimingMode_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“大乱斗模式”对象
                this.OnePersonMode("大乱斗模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“大乱斗模式”
                this.ThisTowPersonMode("大乱斗模式");
            }
        }
        /// <summary>合作或单人模式->隐形模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttInvisible_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“隐形模式”对象
                this.OnePersonMode("隐形模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“隐形模式”
                this.ThisTowPersonMode("隐形模式");
            }
        }
        /// <summary>合作或单人模式->偏移模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttExcursion_Click(object sender, EventArgs e)
        {
            //判断是单人模式不
            if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "单人模式")
            {
                //创建单人模式的“计时模式”对象
                this.OnePersonMode("计时模式");
            }
            //判断是否是本地双人合作模式不
            else if (this.MenuControlList["合作或单人模式"].Tag.ToString() == "本地双人合作模式")
            {
                //创建本地双人合作模式的“计时模式”
                this.ThisTowPersonMode("计时模式");
            }
        }
        /// <summary>合作或单人模式->返回到主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnToTheMainMenu_Click(object sender, EventArgs e)
        {
            //判断返回 主菜单还是多人游戏
            if (this.buttReturnToTheMainMenu.Text == "返回主菜单")
            {
                //隐藏“合作或单人模式”
                this.MenuControlList["合作或单人模式"].Visible = false;
                //显示主菜单
                this.MenuControlList["主菜单"].Visible = true;
                //设置焦点为开始游戏
                this.buttStartTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu.Text == "返回多人游戏")
            {
                //隐藏“合作或单人模式”
                this.MenuControlList["合作或单人模式"].Visible = false;
                //显示“多人游戏”
                this.MenuControlList["多人游戏"].Visible = true;
                //设置焦点为“双人合作模式”
                this.buttLocalCoOperativeMode.Focus();
            }
        }
        #endregion

        #region 多人游戏
        /// <summary>多人游戏->本地双人合作模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttLocalCoOperativeMode_Click(object sender, EventArgs e)
        {
            //隐藏 多人游戏 控件
            this.MenuControlList["多人游戏"].Visible = false;
            //显示 合作或单人模式 控件
            this.MenuControlList["合作或单人模式"].Visible = true;
            //设置返回按钮文本 返回多人游戏
            this.buttReturnToTheMainMenu.Text = "返回多人游戏";
            //设置合作或单人模式的Tag内容 本地双人合作模式
            this.MenuControlList["合作或单人模式"].Tag = "本地双人合作模式";
            //设置默认选择第一个按钮【普通模式】
            this.buttNormalMode.Focus();
        }
        /// <summary>多人游戏->本地双人对抗模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttDoubleAgainstLocalMode_Click(object sender, EventArgs e)
        {
            //隐藏多人游戏
            this.MenuControlList["多人游戏"].Visible = false;
            //显示对抗模式控件
            this.MenuControlList["对抗模式"].Visible = true;
            //设置Tag值为：本地双人对抗模式
            this.MenuControlList["对抗模式"].Tag = "本地双人对抗模式";
            //设置焦点为：普通模式
            this.buttAgainstTheNormalMode.Focus();
        }
        /// <summary>多人游戏->联机双人合作模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttOnlineDoubleCooperationMode_Click(object sender, EventArgs e)
        {
            //隐藏 多人游戏 控件
            this.MenuControlList["多人游戏"].Visible = false;
            //显示 合作或单人模式 控件
            this.MenuControlList["合作或单人模式"].Visible = true;
            //设置返回按钮文本 返回多人游戏
            this.buttReturnToTheMainMenu.Text = "返回多人游戏";
            //设置合作或单人模式的Tag内容 联机双人合作模式
            this.MenuControlList["合作或单人模式"].Tag = "联机双人合作模式";
            //设置默认选择第一个按钮【普通模式】
            this.buttNormalMode.Focus();
        }
        /// <summary>多人游戏->联机双人对抗模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttDoubleAgainstOnlineMode_Click(object sender, EventArgs e)
        {
            //隐藏多人游戏
            this.MenuControlList["多人游戏"].Visible = false;
            //显示对抗模式控件
            this.MenuControlList["对抗模式"].Visible = true;
            //设置Tag值为：联机双人对抗模式
            this.MenuControlList["对抗模式"].Tag = "联机双人对抗模式";
            //设置焦点为：普通模式
            this.buttAgainstTheNormalMode.Focus();
        }
        /// <summary>多人游戏->返回到主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturnToTheMainMenu_Click(object sender, EventArgs e)
        {
            //隐藏“多人游戏”
            this.MenuControlList["多人游戏"].Visible = false;
            //显示主菜单
            this.MenuControlList["主菜单"].Visible = true;
            //设置焦点为开始游戏
            this.buttStartTheGame.Focus();
        }
        #endregion

        #region 对抗模式
        /// <summary>双人对抗玩法根据指定模式来创建模式对象
        /// 
        /// </summary>
        /// <param name="mode">指定的模式对象</param>
        private void ConfrontMode(string mode)
        {
            //创建本地双人对抗对象
            GameBase gb = new ThisLocalityTwoPersonConfrontGame();
            //赋值玩法
            Program.GameForm.GB = gb;
            //创建模式对象【玩家一】
            ModeBase mb01 = null;
            //创建模式对象【玩家二】
            ModeBase mb02 = null;
            switch (mode)
            {
                case "普通模式":
                    mb01 = new CommonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new CommonMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "马拉松模式":
                    mb01 = new MarathonMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new MarathonMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "无尽模式":
                    mb01 = new LookForDieMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new LookForDieMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "上气不接下气模式":
                    mb01 = new BeOutOfBreathMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new BeOutOfBreathMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "挑战模式":
                    mb01 = new ChallengeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new ChallengeMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "隐形模式":
                    mb01 = new InvisibleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    //设置是否隐藏固定单元格属性，取反值，因为模式对象是是否隐藏，而这个是是否显示
                    (mb01 as IHideMode).IsHide = !Dos.IsShowCell;
                    mb02 = new InvisibleMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    //设置是否隐藏固定单元格属性，取反值，因为模式对象是是否隐藏，而这个是是否显示
                    (mb02 as IHideMode).IsHide = !Dos.IsShowCell;
                    break;
                case "大杂烩模式":
                    mb01 = new MeddleMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new MeddleMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    //判断Dos命令里面是否输入了不隐藏单元格，如果设置了就设置为不隐藏单元格
                    if (Dos.IsShowCell)
                    {
                        //设置不隐藏单元格
                        (mb01 as IHideMode).IsHide = false;
                        //设置不隐藏单元格
                        (mb02 as IHideMode).IsHide = false;
                    }
                    break;
                case "大乱斗模式":
                    mb01 = new BigChaosFight(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new BigChaosFight(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "生死转换模式":
                    mb01 = new TransitionMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new TransitionMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
                case "计时模式":
                    mb01 = new TimeMode(gb, Tetris.ShowUesInformation[0][0] as Table, -1, 0);
                    mb02 = new TimeMode(gb, Tetris.ShowUesInformation[1][0] as Table, -1, 1);
                    break;
            }
            //将模式存入玩法对象
            gb.ModeList = new ModeBase[] { mb01, mb02 };

            #region 玩家一
            //创建一个玩家对象
            Player play01 = new Player(
                //玩家产生的方块模型起始位置
                6,
                //用于显示下一个要出来的方块形状的表格控件对象
                Tetris.ShowUesInformation[0][1] as Table,
                //存储显示关卡信息的标签对象【显示所在关卡】
                Tetris.ShowUesInformation[0][2] as Label,
                //存储显示得分的标签对象
                Tetris.ShowUesInformation[0][3] as Label,
                //储存显示消灭的行数的标签对象
                Tetris.ShowUesInformation[0][4] as Label,
                //当前俄罗斯方块模型对象
                mb01.NextShape(6, false),
                //当前玩家对象所在的模式对象
                mb01,
                //显示下落的方块【形状】数量的标签对象
                Tetris.ShowUesInformation[0][5] as Label
            );
            //将玩家对象存入模式数组
            mb01.PlayerList = new Player[] { play01 };
            #endregion


            #region 玩家二
            //创建一个玩家对象
            Player play02 = new Player(
                //玩家产生的方块模型起始位置
                6,
                //用于显示下一个要出来的方块形状的表格控件对象
                Tetris.ShowUesInformation[1][1] as Table,
                //存储显示关卡信息的标签对象【显示所在关卡】
                Tetris.ShowUesInformation[1][2] as Label,
                //存储显示得分的标签对象
                Tetris.ShowUesInformation[1][3] as Label,
                //储存显示消灭的行数的标签对象
                Tetris.ShowUesInformation[1][4] as Label,
                //当前俄罗斯方块模型对象
                mb02.NextShape(6, false),
                //当前玩家对象所在的模式对象
                mb02,
                //显示下落的方块【形状】数量的标签对象
                Tetris.ShowUesInformation[1][5] as Label
            );
            //将玩家对象存入模式数组
            mb02.PlayerList = new Player[] { play02 };
            #endregion


            //隐藏当前界面
            this.MenuControlList["对抗模式"].Visible = false;
            //隐藏菜单容器
            Program.GameForm.PanelMenu.Visible = false;
            //调用表格刷新方法
            this.TableRefresh();
            //调用表格刷新方法
            this.TableRefresh();
            //调用模式对象的刷新方法
            mb01.Show();
            mb02.Show();
            //开始
            gb.Start();
            //停止暂停
            Program.GameForm.IsStop = false;
            //播放开始音效
            Music.BeginMusic();
        }
        /// <summary>对抗模式->计时模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttTime_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“计时模式”对象
                this.ConfrontMode("计时模式");
            }
        }
        /// <summary>对抗模式->普通模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstTheNormalMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“普通模式”对象
                this.ConfrontMode("普通模式");
            }
        }
        /// <summary>对抗模式->马拉松模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstTheMarathonMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“马拉松模式”对象
                this.ConfrontMode("马拉松模式");
            }
        }
        /// <summary>对抗模式->挑战模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstChallengeMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“挑战模式”对象
                this.ConfrontMode("挑战模式");
            }
        }
        /// <summary>对抗模式->无尽模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstTheFaultMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“无尽模式”对象
                this.ConfrontMode("无尽模式");
            }
        }
        /// <summary>对抗模式->上气不接下气模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstTheBreathMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“上气不接下气模式”对象
                this.ConfrontMode("上气不接下气模式");
            }
        }
        /// <summary>对抗模式->大杂烩模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstAHodgepodgeMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“大杂烩模式”对象
                this.ConfrontMode("大杂烩模式");
            }
        }
        /// <summary>对抗模式->大乱斗
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstTheTimingMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“大乱斗模式”对象
                this.ConfrontMode("大乱斗模式");
            }
        }
        /// <summary>对抗模式->生死转换模式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAgainstDeathConversionMode_Click(object sender, EventArgs e)
        {
            //判断是本地双人对抗模式不
            if (this.MenuControlList["对抗模式"].Tag.ToString() == "本地双人对抗模式")
            {
                //创建本地双人对抗游戏模式的“生死转换模式”对象
                this.ConfrontMode("生死转换模式");
            }
        }
        /// <summary>对抗模式->返回到多人游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnToTheMultiplayerGames_Click(object sender, EventArgs e)
        {
            //隐藏“对抗模式”
            this.MenuControlList["对抗模式"].Visible = false;
            //显示多人游戏
            this.MenuControlList["多人游戏"].Visible = true;
            //设置焦点为双人合作模式
            this.buttLocalCoOperativeMode.Focus();
        }
        #endregion

        #region 排行榜
        /// <summary>排行榜->返回到主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnToTheMainMenu2_Click(object sender, EventArgs e)
        {
            //隐藏“排行榜”
            this.MenuControlList["排行榜"].Visible = false;
            //判断显示的文字为：返回到主菜单还是返回到菜单
            if (this.buttReturnToTheMainMenu2.Text == "返回到主菜单")
            {
                //显示主菜单
                this.MenuControlList["主菜单"].Visible = true;
                //设置焦点为开始游戏
                this.buttStartTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu2.Text == "返回到菜单")
            {
                //显示暂停菜单
                this.MenuControlList["暂停菜单"].Visible = true;
                //设置焦点为继续游戏
                this.buttToContinueTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu2.Text == "返回游戏")
            {
                //调用返回游戏方法
                this.ReturnGame();
            }
        }
        /// <summary>更改排行榜的显示控件的可见度触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listVRanking_VisibleChanged(object sender, EventArgs e)
        {
            //判断当前排行榜表格是否可见，并且存储记录的对象不能为空
            if (this.listVRanking.Visible == true && Data.GameHistoryInformationList != null)
            {
                //将结果进行排序
                Data.GameHistoryInformationList.Sort();
                //将元素进行反转 按照降序排列【从大到小】
                Data.GameHistoryInformationList.Reverse();
                //清除表格中的所有元素
                this.listVRanking.Items.Clear();
                //循环输入值
                for (int i = 0; i < Data.GameHistoryInformationList.Count; i++)
                {
                    //得到要显示的行对象
                    ListViewItem lvi = Data.GameHistoryInformationList[i].ShowItme();
                    //更改名次
                    lvi.Text = (i + 1).ToString();
                    //强行对象加入表格
                    this.listVRanking.Items.Add(lvi);
                }
            }
        }
        #endregion

        #region 暂停菜单
        /// <summary>点击继续游戏
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttToContinueTheGame_Click(object sender, EventArgs e)
        {
            //隐藏菜单遮罩层
            Program.GameForm.PanelMenu.Visible = false;
            //隐藏所有暂停菜单的元素
            this.MenuControlList["暂停菜单"].Visible = false;
            //判断是否为空
            if (Tetris.ShowUesInformation != null)
            {
                //设置焦点给显示数据的表格
                Tetris.ShowUesInformation[0][0].Focus();
            }
        }
        /// <summary>排行榜
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttStopList_Click(object sender, EventArgs e)
        {
            //设置“暂停菜单”为隐藏
            this.MenuControlList["暂停菜单"].Visible = false;
            //调用显示“排行榜”页面组
            this.MenuControlList["排行榜"].Visible = true;
            //设置游戏设置的退出按钮的文本为：返回到菜单
            this.buttReturnToTheMainMenu2.Text = "返回到菜单";
            //设置默认选择第一个按钮【显示的表】
            this.listVRanking.Focus();
        }
        /// <summary>游戏设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttStopTheGameIsSet_Click(object sender, EventArgs e)
        {
            //设置“暂停菜单”为隐藏
            this.MenuControlList["暂停菜单"].Visible = false;
            //调用显示“游戏设置”页面组
            this.MenuControlList["游戏设置"].Visible = true;
            //设置游戏设置的退出按钮的文本为：返回到菜单
            this.buttReturnToTheMainMenu3.Text = "返回到菜单";
            //设置默认选择第一个按钮【保存设置】
            this.buttSaveSet.Focus();
        }
        /// <summary>返回主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttStopReturnToTheMainMenu_Click(object sender, EventArgs e)
        {
            //弹出要用户选择是否退出
            if (Tool.ShowSelectBox(Program.GameForm.GB.IsGameOver ? "是否返回主菜单？" : "游戏尚未结束！现在返回主菜单数据将不会保存！是否返回？") == DialogResult.Yes)
            {
                //调用停止方法
                Program.GameForm.Close();
                //隐藏当前控件
                this.MenuControlList["暂停菜单"].Visible = false;
                //显示主菜单控件
                this.MenuControlList["主菜单"].Visible = true;
                //设置焦点
                this.buttStartTheGame.Focus();
            }
        }
        /// <summary>暂停菜单->成就
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAchievement02_Click(object sender, EventArgs e)
        {
            //设置暂停菜单为隐藏
            this.MenuControlList["暂停菜单"].Visible = false;
            //调用显示“成就”页面组
            this.MenuControlList["成就"].Visible = true;
            //设置设置的返回按钮文本为：返回到菜单
            this.buttReturnToTheMainMenu4.Text = "返回到菜单";
            //设置焦点为表格
            this.listVRanking.Focus();
        }
        #endregion

        #region 游戏设置
        /// <summary>判断键位是否发生更改的方法
        /// 
        /// </summary>
        /// <returns>true代表更改false代表没有更改</returns>
        private bool IsKeyModif()
        {
            //判断“暂停游戏键位”是否发生更改
            if (Data.StopGame.ToString() != this.txtPauseTheGame.Text) return true;
            //判断“控制台键位”是否发生更改
            if (Data.OpenDosKey.ToString() != this.txtTheConsole.Text) return true;
            //判断“打开菜单键位”是否发生更改
            if (Data.OpenMenuKey.ToString() != this.txtOpenTheMenu.Text) return true;

            #region 判断玩家一是否更改
            //旋转键位
            if (Data.PlayerSetList[0].Spin.ToString() != this.txtRotaryModel1.Text) return true;
            //左移键位
            if (Data.PlayerSetList[0].LeftMove.ToString() != this.txtOneStepLeft1.Text) return true;
            //右移键位
            if (Data.PlayerSetList[0].RighMove.ToString() != this.txtMovesToTheRightStep1.Text) return true;
            //下移动
            if (Data.PlayerSetList[0].BelowMove.ToString() != this.txtAStepDown1.Text) return true;
            //下移到底
            if (Data.PlayerSetList[0].MoveToTheEnd.ToString() != this.txtDownToTheEnd1.Text) return true;
            #endregion

            #region 判断玩家二是否更改
            //旋转键位
            if (Data.PlayerSetList[1].Spin.ToString() != this.txtRotaryModel2.Text) return true;
            //左移键位
            if (Data.PlayerSetList[1].LeftMove.ToString() != this.txtOneStepLeft2.Text) return true;
            //右移键位
            if (Data.PlayerSetList[1].RighMove.ToString() != this.txtMovesToTheRightStep2.Text) return true;
            //下移动
            if (Data.PlayerSetList[1].BelowMove.ToString() != this.txtAStepDown2.Text) return true;
            //下移到底
            if (Data.PlayerSetList[1].MoveToTheEnd.ToString() != this.txtDownToTheEnd2.Text) return true;
            #endregion

            //返回没有更改
            return false;
        }
        /// <summary>判断声音与显示设置是否发生更改
        /// 
        /// </summary>
        /// <returns>true表示发生更改，false代表没有发生更改</returns>
        private bool IsVoiceAndShowModify()
        {
            //判断是否显示边框复选框是否发生改变
            if (this.cbShowCellColor.Checked != Data.IsShowCellColor) return true;
            //判断是否选择了显示边框
            if (this.cbShowCellColor.Checked)
            {
                //判断颜色是否发生改变
                if (this.scShowColor.SelectColor != Data.ShowCellColor)
                {
                    //返回
                    return true;
                }
            }
            //判断声音是否发生更改
            if (Data.IsMusic != this.cbIfOpenTheBackgroundMusic.Checked) return true;

            //判断是否显示下一个的边框发生改变与否
            if (Data.WhetherShowTheNextFrame != this.cbWhetherShowTheNextFrame.Checked) return true;
            //判断是否显示界面边框发生改变与否
            if (Data.WhetherTheDisplayFrame != this.cbWhetherTheDisplayFrame.Checked) return true;
            //判断是否使用默认背景图片
            if (Data.UseTheDefaultBackgroundImage != this.cbWhetherToShowTheBackgroundImage.Checked) return true;
            //判断背景图片是否发生改变
            if (Data.TheBackgroundImageName != this.txtTheBackgroundImage.Text) return true;
            //判断高斯模糊程度
            if (Data.GaussianBlurDegree != (float)this.nudGaussianBlurDegree.Value) return true;

            #region 判断下落形状颜色是否发生改变
            //判断形状I是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_I, this.scI.SelectColor)) return true;
            //判断形状J是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_J, this.scJ.SelectColor)) return true;
            //判断形状L是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_L, this.scL.SelectColor)) return true;
            //判断形状O是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_O, this.scO.SelectColor)) return true;
            //判断形状S是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_S, this.scS.SelectColor)) return true;
            //判断形状T是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_T, this.scT.SelectColor)) return true;
            //判断形状Z是否发生改变
            if (!Tool.ColorEqual(Data.ShapeColor.Shape_Z, this.scZ.SelectColor)) return true;
            #endregion

            //返回没有更改false
            return false;
        }
        /// <summary>返回到菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnToTheMainMenu3_Click(object sender, EventArgs e)
        {
            //判断是否更改设置
            if (this.IsVoiceAndShowModify() || this.IsKeyModif())
            {
                //提示用户是否保存
                if (Tool.ShowSelectBox("设置已经更改是否保存？") == DialogResult.Yes)
                {
                    //调用保存设置方法
                    this.SaveSet();
                }
                else
                {
                    //调用重置设置方法
                    this.LoadSet();
                }
            }
            //隐藏当前设置控件
            this.MenuControlList["游戏设置"].Visible = false;
            //判断文本是：返回到主菜单还是菜单
            if (this.buttReturnToTheMainMenu3.Text == "返回主菜单")
            {
                //显示主菜单控件
                this.MenuControlList["主菜单"].Visible = true;
                //设置焦点
                this.buttStartTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu3.Text == "返回到菜单")
            {
                //设置显示的暂停菜单
                this.MenuControlList["暂停菜单"].Visible = true;
                //设置焦点
                this.buttToContinueTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu3.Text == "返回游戏")
            {
                //调用返回游戏方法
                this.ReturnGame();
            }
        }
        /// <summary>设置下落形状颜色
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSetWhereaboutsShapeColor_Click(object sender, EventArgs e)
        {
            //隐藏游戏设置控件
            this.MenuControlList["游戏设置"].Visible = false;
            //显示“设置下落方块颜色”控件
            this.MenuControlList["设置下落方块颜色"].Visible = true;
        }
        /// <summary>点击保存设置按钮触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSaveSet_Click(object sender, EventArgs e)
        {
            //调用保存设置方法
            this.SaveSet();
        }
        /// <summary>保存设置方法
        /// 
        /// </summary>
        private void SaveSet()
        {
            //判断键位是否需要进行保存
            if (this.IsKeyModif())
            {
                #region 更改新键位
                //更改“暂停游戏键位”
                Data.StopGame = PlayerSet.StrToKeys[this.txtPauseTheGame.Text];
                //更改“控制台键位”
                Data.OpenDosKey = PlayerSet.StrToKeys[this.txtTheConsole.Text];
                //更改“打开菜单键位”
                Data.OpenMenuKey = PlayerSet.StrToKeys[this.txtOpenTheMenu.Text];

                #region 更改玩家一键位
                //旋转键位
                Data.PlayerSetList[0].Spin = PlayerSet.StrToKeys[this.txtRotaryModel1.Text];
                //左移键位
                Data.PlayerSetList[0].LeftMove = PlayerSet.StrToKeys[this.txtOneStepLeft1.Text];
                //右移键位
                Data.PlayerSetList[0].RighMove = PlayerSet.StrToKeys[this.txtMovesToTheRightStep1.Text];
                //下移动
                Data.PlayerSetList[0].BelowMove = PlayerSet.StrToKeys[this.txtAStepDown1.Text];
                //下移到底
                Data.PlayerSetList[0].MoveToTheEnd = PlayerSet.StrToKeys[this.txtDownToTheEnd1.Text];
                #endregion

                #region 更改玩家二键位
                //旋转键位
                Data.PlayerSetList[1].Spin = PlayerSet.StrToKeys[this.txtRotaryModel2.Text];
                //左移键位
                Data.PlayerSetList[1].LeftMove = PlayerSet.StrToKeys[this.txtOneStepLeft2.Text];
                //右移键位
                Data.PlayerSetList[1].RighMove = PlayerSet.StrToKeys[this.txtMovesToTheRightStep2.Text];
                //下移动
                Data.PlayerSetList[1].BelowMove = PlayerSet.StrToKeys[this.txtAStepDown2.Text];
                //下移到底
                Data.PlayerSetList[1].MoveToTheEnd = PlayerSet.StrToKeys[this.txtDownToTheEnd2.Text];
                #endregion
                #endregion
            }
            //判断显示与声音设置是否需要保存
            if (this.IsVoiceAndShowModify())
            {
                //判断背景图片名称是否发生改变了，或者是否使用默认左背景图片发生改变
                if (Data.TheBackgroundImageName != this.txtTheBackgroundImage.Text || this.cbWhetherToShowTheBackgroundImage.Checked != Data.UseTheDefaultBackgroundImage)
                {
                    //判断选择的是使用默认背景还是不使用默认背景
                    if (this.cbWhetherToShowTheBackgroundImage.Checked)//进入代表使用默认背景
                    {
                        #region 设置默认背景
                        //更改背景图片文本框为“默认背景”
                        this.txtTheBackgroundImage.Text = "默认背景";

                        //判断是否有“默认背景”这个背景文件
                        if (Tetris.IfShowImage("默认背景"))
                        {
                            //加载并设置默认背景
                            Tetris.ShowImage = Tetris.ReadShowImage("默认背景");
                        }
                        else
                        {
                            //弹出提示框
                            Tool.ShowRemindBox("正在生成默认背景请稍等片刻...\r\n请点击确定按钮关闭此对话框O(∩_∩)O~~");
                            //得到默认背景并进行设置
                            Img img = new Img(Form1.AcquiesceInImage, (float)this.nudGaussianBlurDegree.Value, "默认背景");
                            //保存当前背景对象
                            Tetris.SaveShowImage(img);
                            //赋值
                            Tetris.ShowImage = img;
                            //弹出提示框
                            Tool.ShowRemindBox("默认背景生成成功！O(∩_∩)O~~");
                        }
                        #endregion
                    }
                    else
                    {
                        #region 设置指定文件或者图片
                        //判断背景图片文本框的Tag是否不为null【不为null就代表选择的是图片而不是img背景文件】
                        if (this.txtTheBackgroundImage.Tag != null)//选择了图片文件【Tag中存储的就是图片文件】
                        {
                            //弹出提示框
                            Tool.ShowRemindBox("正在生成背景请稍等片刻...\r\n请点击确定按钮关闭此对话框O(∩_∩)O~~");
                            //得到图片文件
                            Image image = this.txtTheBackgroundImage.Tag as Image;
                            //得到Img背景文件
                            Img img = new Img(image, (float)this.nudGaussianBlurDegree.Value, this.txtTheBackgroundImage.Text);
                            //保存当前背景
                            Tetris.SaveShowImage(img);
                            //设置背景
                            Tetris.ShowImage = img;
                            //弹出提示框
                            Tool.ShowRemindBox("背景图片生成成功！O(∩_∩)O~~");
                        }
                        //当前内部存储就是已经存在的Img背景文件了
                        //判断是否有指定背景文件
                        else if (Tetris.IfShowImage(this.txtTheBackgroundImage.Text))//进入代表存在
                        {
                            //加载指定的背景文件
                            Img img = Tetris.ReadShowImage(this.txtTheBackgroundImage.Text);
                            //将img显示
                            Tetris.ShowImage = img;
                            //并设置高斯模糊程度
                            this.nudGaussianBlurDegree.Value = (decimal)img.MenuValue;
                        }
                        else//进入代表不存在
                        {
                            //弹出错误框
                            Tool.ShowMistakeBox("加载背景文件“" + this.txtTheBackgroundImage.Text + "”时失败，此文件或许已经不存在了！请您重新选择新背景文件或者图片文件！");
                        }
                        #endregion
                    }
                }
                //判断高斯模糊是否发生改变了
                else if (Data.GaussianBlurDegree != (float)this.nudGaussianBlurDegree.Value)
                {
                    //弹出提示框
                    Tool.ShowRemindBox("正在更改背景模糊程度请稍等片刻...\r\n请点击确定按钮关闭此对话框O(∩_∩)O~~");
                    //得到新背景对象，并设置模糊度
                    Img img = new Img(Tetris.ShowImage.CommonImage, (float)this.nudGaussianBlurDegree.Value, Tetris.ShowImage.Name);
                    //保存当前背景
                    Tetris.SaveShowImage(img);
                    //重新设置背景
                    Tetris.ShowImage = img;
                    //弹出提示框
                    Tool.ShowRemindBox("更改背景模糊程度成功！O(∩_∩)O~~");
                }


                #region 更改声音音效设置
                //是否开启音效
                Data.IsMusic = this.cbIfOpenTheBackgroundMusic.Checked;
                #endregion

                #region 显示设置
                //更改是否显示下一个的边框
                Data.WhetherShowTheNextFrame = this.cbWhetherShowTheNextFrame.Checked;
                //更改是否显示界面边框
                Data.WhetherTheDisplayFrame = this.cbWhetherTheDisplayFrame.Checked;
                //是否使用默认图片
                Data.UseTheDefaultBackgroundImage = this.cbWhetherToShowTheBackgroundImage.Checked;
                //更改背景图片名称
                Data.TheBackgroundImageName = this.txtTheBackgroundImage.Text;
                //更改高斯模糊程度
                Data.GaussianBlurDegree = (float)this.nudGaussianBlurDegree.Value;
                //判断是否选择了显示边框
                if (this.cbShowCellColor.Checked)
                {
                    //更改颜色
                    Data.ShowCellColor = this.scShowColor.SelectColor;
                }
                else
                {
                    //更改颜色为透明
                    Data.ShowCellColor = Color.Transparent;
                }
                //设置是否显示边框颜色
                Data.IsShowCellColor = this.cbShowCellColor.Checked;

                #region 设置下落形状颜色
                //设置下落形状I颜色
                Data.ShapeColor.Shape_I = this.scI.SelectColor;
                //设置下落形状J颜色
                Data.ShapeColor.Shape_J = this.scJ.SelectColor;
                //设置下落形状L颜色
                Data.ShapeColor.Shape_L = this.scL.SelectColor;
                //设置下落形状O颜色
                Data.ShapeColor.Shape_O = this.scO.SelectColor;
                //设置下落形状S颜色
                Data.ShapeColor.Shape_S = this.scS.SelectColor;
                //设置下落形状T颜色
                Data.ShapeColor.Shape_T = this.scT.SelectColor;
                //设置下落形状Z颜色
                Data.ShapeColor.Shape_Z = this.scZ.SelectColor;
                #endregion

                #endregion
            }
            //保存设置
            Static.Data.SaveSet();
            //设置键位完成触发刷新设置键位的方法
            Data.RefreshKeySet();
        }
        /// <summary>是否使用默认背景图片作为背景是否选中更改触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbWhetherToShowTheBackgroundImage_CheckedChanged(object sender, EventArgs e)
        {
            //根据是否选中更改选择背景图片按钮是否启用
            this.buttSelectImage.Enabled = !this.cbWhetherToShowTheBackgroundImage.Checked;
        }
        /// <summary>更改键位触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyKeyUp(object sender, KeyEventArgs e)
        {
            //得到当前文本框
            TextBox tb = sender as TextBox;
            //得到当前键位的字符串副本
            string key = e.KeyCode.ToString();
            //判断是否与当前文本框重复，如果重复就不需要更改了
            if (tb.Text == key)
            {
                //退出方法
                return;
            }
            //判断是否有键位重复
            TextBox TB = this.IfThereIsAFewConflicts(key);//判断是否有键位重复
            if (TB != null)
            {
                //弹出警告框
                Tool.ShowWarningBox("当前键位与：“" + TB.Tag.ToString() + "键”重复了，无法进行更改！");
            }
            else
            {
                //进行更改键位
                tb.Text = key;
            }
        }
        /// <summary>点击选择背景图片方法
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSelectImage_Click(object sender, EventArgs e)
        {
            //创建选择文件的窗体对象
            OpenFileDialog ofd = new OpenFileDialog();
            //设置显示的标题
            ofd.Title = "请您选择合适的背景或者作为背景的图片O(∩_∩)O~~";
            //得到存储图片文件的文件夹路径
            string path = Path.Combine(Data.DataSavePath, "背景图片");
            //设置初始目录【判断指定存储背景图片的文件夹是否存在如果存在就选择这个文件夹否则就选择桌面】
            ofd.InitialDirectory = Directory.Exists(path) ? path : @"C:\Users\Administrator\Desktop";
            //设置打开文件类型
            ofd.Filter = "背景文件与常用图片格式|*.img;*.jpg;*.png;*.bmp|所有文件|*.*";
            //打开选择文件窗体
            ofd.ShowDialog();

            //判断是否选择了文件
            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                //得到路径的后缀如果为img就代表为背景文件
                if (Path.GetExtension(ofd.FileName).ToLower() == ".img")
                {
                    //设置Tag为null
                    this.txtTheBackgroundImage.Tag = null;
                    //设置背景图片显示为当前图片的名称
                    this.txtTheBackgroundImage.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                }
                else
                {
                    //加载指定图片
                    Bitmap bp = new Bitmap(Bitmap.FromFile(ofd.FileName));
                    //判断其图片大小是否符合规定950*535
                    if (bp.Width < 950 || bp.Height < 535)
                    {
                        //弹出警告框
                        Tool.ShowWarningBox("您选择的作为背景的图片：“" + Path.GetFileName(ofd.FileName) + "”\r\n高宽为：[" + bp.Width.ToString() + "*" + bp.Height.ToString() + "]小于[950*535]无法作为背景！请您重新选择图片！");
                    }
                    else
                    {
                        //开始剪切图片
                        bp = bp.Clone(new Rectangle(0, 0, 950, 535), bp.PixelFormat);
                        //设置Tag值为图片
                        this.txtTheBackgroundImage.Tag = (Image)bp;
                        //设置显示的图片名称为选择的图片名称
                        this.txtTheBackgroundImage.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                    }
                }
            }
        }
        #endregion

        #region 设置下落方块颜色
        /// <summary>设置下落方块颜色->返回游戏设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnGameSet_Click(object sender, EventArgs e)
        {
            //隐藏下落方块颜色
            this.MenuControlList["设置下落方块颜色"].Visible = false;
            //显示游戏设置
            this.MenuControlList["游戏设置"].Visible = true;
        }
        #endregion

        #region 成就
        /// <summary>成就->返回主菜单
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttReturnToTheMainMenu4_Click(object sender, EventArgs e)
        {
            //隐藏“成就”
            this.MenuControlList["成就"].Visible = false;
            //判断显示的文字为：返回到主菜单还是返回到菜单
            if (this.buttReturnToTheMainMenu4.Text == "返回到主菜单")
            {
                //显示主菜单
                this.MenuControlList["主菜单"].Visible = true;
                //设置焦点为开始游戏
                this.buttStartTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu4.Text == "返回到菜单")
            {
                //显示暂停菜单
                this.MenuControlList["暂停菜单"].Visible = true;
                //设置焦点为继续游戏
                this.buttToContinueTheGame.Focus();
            }
            else if (this.buttReturnToTheMainMenu4.Text == "返回游戏")
            {
                //调用返回游戏方法
                this.ReturnGame();
            }
        }
        #endregion
        /// <summary>更改显示格子线条颜色触发的事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbShowCellColor_CheckedChanged(object sender, EventArgs e)
        {
            //判断是否选择
            if (!this.cbShowCellColor.Checked)
            {
                //更改颜色为灰色
                this.labeShowColor.ForeColor = Color.DimGray;
                //设置选择颜色为不可用
                this.scShowColor.Enabled = false;
            }
            else
            {
                //更改颜色为黑色
                this.labeShowColor.ForeColor = Color.Black;
                //设置选择颜色为可用
                this.scShowColor.Enabled = true;
            }
        }
    }
}
