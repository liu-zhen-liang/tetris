using LZLTetris.ConventionShape;
using LZLTetris.Mode;
using LZLTetris.Static.DataObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using TdatAnalysis;
using WindowsTableControl;

namespace LZLTetris.Static
{
    /// <summary>数据存储类
    /// 用于保存设置读取设置等一系列方法。
    /// </summary>
    public static class Data
    {
        /*文档设置保存结构
         * 
         * 键位设置
         *     暂停游戏键位
         *     控制台键位
         *     打开菜单键位
         *     玩家操作键位集合
         *         玩家一
         *             旋转模型
         *             左移一格
         *             右移一格
         *             下移一格
         *             下移到底
         *         玩家二
         *             旋转模型
         *             左移一格
         *             右移一格
         *             下移一格
         *             下移到底
         * 声音设置
         *     是否开启音效
         * 显示设置
         *     是否显示解密边框
         *     是否显示下一个边框
         *     是否使用默认背景图片
         *     是否显示格子边框颜色
         *     格子边框颜色
         *     背景图片名称
         *     高斯模糊程度
         *     下落形状颜色
         *         形状I
         *         形状J
         *         形状L
         *         形状O
         *         形状S
         *         形状T
         *         形状Z
         */

        //默认开启声音
        private static bool _isMusic = true;
        /// <summary>是否开启音效
        /// 
        /// </summary>
        public static bool IsMusic
        {
            get { return _isMusic; }
            set { _isMusic = value; }
        }
        //设置两个玩家的默认键位
        private static PlayerSet[] _playerSetList = new PlayerSet[]{
            //玩家一：W键旋转，A键左移，D键右移，S键下移，空格键下移到底
            new PlayerSet(Keys.W, Keys.A, Keys.D, Keys.S, Keys.Space),
            //玩家二：向上箭头键旋转，向左箭头键左移，向右箭头键右移动，向下箭头键下移，回车键下移到底
            new PlayerSet(Keys.Up, Keys.Left, Keys.Right, Keys.Down, Keys.Return)
        };
        /// <summary>存储各个玩家的设置对象的数组】
        /// 
        /// </summary>
        public static PlayerSet[] PlayerSetList
        {
            get { return _playerSetList; }
            set { _playerSetList = value; }
        }
        //默认Back键暂停
        private static Keys _stopGame = Keys.Back;
        /// <summary>暂停游戏的键位
        /// 
        /// </summary>
        public static Keys StopGame
        {
            get { return _stopGame; }
            set { _stopGame = value; }
        }
        //默认Oemtilde键打开与关闭Dos命令
        private static Keys _openDosKey = Keys.Oemtilde;
        /// <summary>打开控制台的键位
        /// 
        /// </summary>
        public static Keys OpenDosKey
        {
            get { return _openDosKey; }
            set { _openDosKey = value; }
        }
        //默认为Esc键打开与关闭菜单
        private static Keys _openMenuKey = Keys.Escape;
        /// <summary>打开菜单的键位
        /// 
        /// </summary>
        public static Keys OpenMenuKey
        {
            get { return _openMenuKey; }
            set { _openMenuKey = value; }
        }
        private static List<GameHistoryInformation> _gameHistoryInformationList;
        /// <summary>游戏的历史信息集合【只保存前300条记录】
        /// 
        /// </summary>
        public static List<GameHistoryInformation> GameHistoryInformationList
        {
            get { return _gameHistoryInformationList; }
            set { _gameHistoryInformationList = value; }
        }
        /// <summary>存储键位所对应的命令
        /// 
        /// </summary>
        public static Dictionary<Keys, OrderValue> KeyAndOreder = new Dictionary<Keys, OrderValue>();
        private static Color _showCellColor = Color.Black;
        /// <summary>显示格子的线条颜色
        /// 
        /// </summary>
        public static Color ShowCellColor
        {
            get { return Data._showCellColor; }
            set
            {
                //赋值
                Data._showCellColor = value;
                //判断是否有显示当前显示的空间集合
                if (Tetris.ShowUesInformation != null)
                {
                    //循环更改当前显示的表格显示的边框颜色
                    for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
                    {
                        //更改线条颜色
                        (Tetris.ShowUesInformation[i][0] as Table).BorderColor = value;
                    }
                }
            }
        }
        private static bool _isShowCellColor;
        /// <summary>是否显示格子颜色
        /// 
        /// </summary>
        public static bool IsShowCellColor
        {
            get { return Data._isShowCellColor; }
            set
            {
                //更改颜色
                Data._isShowCellColor = value;
                //判断是否有显示当前显示的空间集合
                if (Tetris.ShowUesInformation != null)
                {
                    //循环更改当前显示的表格显示的边框颜色
                    for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
                    {
                        //更改线条颜色
                        (Tetris.ShowUesInformation[i][0] as Table).BorderColor = Color.Transparent;
                    }
                }
            }
        }
        /// <summary>是否使用默认的图片做背景
        /// 
        /// </summary>
        public static bool UseTheDefaultBackgroundImage = true;
        /// <summary>背景图片名称
        /// 
        /// </summary>
        public static string TheBackgroundImageName = "默认背景";
        /// <summary>高斯模糊程度
        /// 
        /// </summary>
        public static float GaussianBlurDegree = 2f;
        //默认不显示下一个形状的边框
        private static bool _whetherShowTheNextFrame;
        /// <summary>是否显示下一个的边框
        /// 
        /// </summary>
        public static bool WhetherShowTheNextFrame
        {
            get { return Data._whetherShowTheNextFrame; }
            set
            {
                Data._whetherShowTheNextFrame = value;
                //判断是否为空如果为空就不设置
                if (Tetris.ShowUesInformation != null)
                {
                    //循环设置下一个的边框
                    for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
                    {
                        //设置边框
                        (Tetris.ShowUesInformation[i][1] as Table).BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
                    }
                }
            }
        }
        //默认显示界面边框
        private static bool _whetherTheDisplayFrame = true;
        /// <summary>是否显示界面边框
        /// 
        /// </summary>
        public static bool WhetherTheDisplayFrame
        {
            get { return Data._whetherTheDisplayFrame; }
            set
            {
                Data._whetherTheDisplayFrame = value;
                //判断是否为空如果为空就不设置
                if (Tetris.ShowUesInformation != null)
                {
                    //循环设置边框
                    for (int i = 0; i < Tetris.ShowUesInformation.Length; i++)
                    {
                        //设置边框
                        (Tetris.ShowUesInformation[i][0] as Table).BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
                    }
                }
            }
        }
        /// <summary>保存设置信息的方法
        /// 
        /// </summary>
        public static void SaveSet()
        {
            //创建Tdat文档对象
            TdatDocument tdatDoc = new TdatDocument();

            //创建文档根包
            TdatItme root = new TdatItme();
            //将此根包作为文档对象的根节点
            tdatDoc.RootItme = root;
            //设置根包的名称
            tdatDoc.RootName = "LZ俄罗斯方块设置文件";

            #region 存入键位设置
            //创建包节点【键位设置】
            TdatItme keyTI = new TdatItme();
            //将此键位设置存入根节点
            root.Add("键位设置", keyTI);

            //创建字段存储【暂停游戏键位】
            keyTI.Add("暂停游戏键位", new TdatText(Data.StopGame.ToString()));
            //创建字段存储【控制台键位】
            keyTI.Add("控制台键位", new TdatText(Data.OpenDosKey.ToString()));
            //创建字段存储【打开菜单键位】
            keyTI.Add("打开菜单键位", new TdatText(Data.OpenMenuKey.ToString()));

            #region 玩家设置键位集合
            //创建存储玩家操作键位集合【TdatItmeList】
            TdItmeList playKeyList = new TdItmeList();
            //将玩家操作键位集合存入键位设置包对象
            keyTI.Add("玩家操作键位集合", playKeyList);
            //循环存入玩家设置信息
            for (int i = 0; i < Data.PlayerSetList.Length; i++)
            {
                //将调用玩家设置键位保存方法，将保存的Tdat文档包对象存入玩家操作键位集合
                playKeyList.Add(Data.PlayerSetList[i].Save());
                //存入是第几个玩家【没有实际用途】
                playKeyList[i].Attributes.Add("玩家编号", Tool.FigureToChinses(i + 1));
            }
            #endregion
            #endregion

            #region 存入声音设置
            //创建存储声音设置的Tdat文档包对象
            TdatItme voiceItme = new TdatItme();
            //将声音对象存入根包对象
            root.Add("声音设置", voiceItme);

            //将是否开启音效存入声音包对象
            voiceItme.Add("是否开启音效", new TdatText(Data.IsMusic ? "是" : "否"));
            #endregion

            #region 存入显示设置
            //创建存储显示设置的包对象
            TdatItme showItme = new TdatItme();
            //将当前包对象存入根对象
            root.Add("显示设置", showItme);

            //存入字段【是否显示下一个的边框】
            showItme.Add("是否显示下一个的边框", new TdatText(Data.WhetherShowTheNextFrame ? "是" : "否"));
            //存入字段【是否显示界面边框】
            showItme.Add("是否显示界面边框", new TdatText(Data.WhetherTheDisplayFrame ? "是" : "否"));
            //存入字段【是否使用默认背景图片】
            showItme.Add("是否使用默认背景图片", new TdatText(Data.UseTheDefaultBackgroundImage ? "是" : "否"));
            //存入字段【是否显示边框颜色】
            showItme.Add("是否显示格子边框颜色", new TdatText(Data.IsShowCellColor ? "是" : "否"));
            //存入字段【显示边框的颜色】
            showItme.Add("格子边框颜色", new TdatText(Tool.ColorToString(Data.ShowCellColor)));
            //存入字段【背景图片名称】
            showItme.Add("背景图片名称", new TdatText(Data.TheBackgroundImageName));
            //存入字段【高斯模糊程度】
            showItme.Add("高斯模糊程度", new TdatText(Data.GaussianBlurDegree.ToString()));

            #region 下落形状颜色
            //存入下落形状的颜色的包对象
            TdatItme shapeItme = new TdatItme();
            //将下落形状颜色对象存入显示设置包对象中
            showItme.Add("下落形状颜色", shapeItme);

            //存储字段【形状I】
            shapeItme.Add("形状I", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_I)));
            //存储字段【形状J】
            shapeItme.Add("形状J", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_J)));
            //存储字段【形状L】
            shapeItme.Add("形状L", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_L)));
            //存储字段【形状O】
            shapeItme.Add("形状O", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_O)));
            //存储字段【形状S】
            shapeItme.Add("形状S", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_S)));
            //存储字段【形状T】
            shapeItme.Add("形状T", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_T)));
            //存储字段【形状Z】
            shapeItme.Add("形状Z", new TdatText(Tool.ColorToString(Data.ShapeColor.Shape_Z)));
            #endregion
            #endregion

            //将设置文档保存【保存位置为当前程序的根目录】
            tdatDoc.Save(Path.Combine(Data.DataSavePath, "LZ俄罗斯方块设置文件.set"));
        }
        /// <summary>读取保存设置信息的方法
        /// 
        /// </summary>
        public static void ReadSet()
        {
            //创建文档对象
            TdatDocument tdatDoc = new TdatDocument();
            //读取文档
            tdatDoc.ReadTdat(Path.Combine(Data.DataSavePath, "LZ俄罗斯方块设置文件.set"));

            #region 加载键位设置
            //得到键位设置包对象
            TdatItme keyItme = tdatDoc.RootItme["键位设置"] as TdatItme;

            //得到“暂停游戏键位”并设置
            Data.StopGame = PlayerSet.StrToKeys[(keyItme["暂停游戏键位"] as TdatText).Text];
            //得到“控制台键位”并设置
            Data.OpenDosKey = PlayerSet.StrToKeys[(keyItme["控制台键位"] as TdatText).Text];
            //得到“打开菜单键位”并设置
            Data.OpenMenuKey = PlayerSet.StrToKeys[(keyItme["打开菜单键位"] as TdatText).Text];

            #region 玩家操作键位集合
            //玩家操作键位集合，并设置
            TdItmeList tdKetList = (keyItme["玩家操作键位集合"] as TdItmeList);
            //设置数组大小
            PlayerSet[] psList = new PlayerSet[tdKetList.Count];
            //循环开始设置
            for (int i = 0; i < tdKetList.Count; i++)
            {
                //创建PlayerSet对象
                psList[i] = new PlayerSet(tdKetList[i]);
            }
            //设置玩家设置
            Data.PlayerSetList = psList;
            #endregion
            #endregion

            #region 加载声音设置
            //得到声音设置包对象
            TdatItme voItme = tdatDoc.RootItme["声音设置"] as TdatItme;
            //将是否开启音效保存设置
            Data.IsMusic = (voItme["是否开启音效"] as TdatText).Text == "是";
            #endregion

            #region 加载显示设置
            //得到显示设置包对象
            TdatItme showItme = tdatDoc.RootItme["显示设置"] as TdatItme;

            //加载并设置【是否显示下一个的边框】
            Data.WhetherShowTheNextFrame = (showItme["是否显示下一个的边框"] as TdatText).Text == "是";
            //加载并设置【是否显示界面边框】
            Data.WhetherTheDisplayFrame = (showItme["是否显示界面边框"] as TdatText).Text == "是";
            //加载并设置【是否使用默认背景图片】
            Data.UseTheDefaultBackgroundImage = (showItme["是否使用默认背景图片"] as TdatText).Text == "是";
            //加载并设置【是否显示格子边框颜色】
            Data.IsShowCellColor = (showItme["是否显示格子边框颜色"] as TdatText).Text == "是";
            //加载并设置【格子边框颜色】
            Data.ShowCellColor = Tool.StringToColor((showItme["格子边框颜色"] as TdatText).Text);
            //加载并设置【背景图片名称】
            Data.TheBackgroundImageName = (showItme["背景图片名称"] as TdatText).Text;
            //加载并设置【高斯模糊程度】
            Data.GaussianBlurDegree = Convert.ToSingle((showItme["高斯模糊程度"] as TdatText).Text);

            #region 加载下落形状颜色
            //得到下落形状颜色包对象
            TdatItme tdColorItme = showItme["下落形状颜色"] as TdatItme;
            //加载形状I颜色
            Data.ShapeColor.Shape_I = Tool.StringToColor((tdColorItme["形状I"] as TdatText).Text);
            //加载形状J颜色
            Data.ShapeColor.Shape_J = Tool.StringToColor((tdColorItme["形状J"] as TdatText).Text);
            //加载形状L颜色
            Data.ShapeColor.Shape_L = Tool.StringToColor((tdColorItme["形状L"] as TdatText).Text);
            //加载形状O颜色
            Data.ShapeColor.Shape_O = Tool.StringToColor((tdColorItme["形状O"] as TdatText).Text);
            //加载形状S颜色
            Data.ShapeColor.Shape_S = Tool.StringToColor((tdColorItme["形状S"] as TdatText).Text);
            //加载形状T颜色
            Data.ShapeColor.Shape_T = Tool.StringToColor((tdColorItme["形状T"] as TdatText).Text);
            //加载形状Z颜色
            Data.ShapeColor.Shape_Z = Tool.StringToColor((tdColorItme["形状Z"] as TdatText).Text);
            #endregion
            #endregion

            //加载数据完成触发刷新设置键位的方法
            Data.RefreshKeySet();
        }
        /// <summary>保存排行榜信息的方法
        /// 
        /// </summary>
        public static void SaveRanking()
        {
            //判断存储数据的文件夹是否存在如果不存在就创建
            if (Directory.Exists(Data.DataSavePath))
            {
                //创建此目录
                Directory.CreateDirectory(Data.DataSavePath);
            }
            //判断数据是否超过300条
            if (Data.GameHistoryInformationList.Count > 300)
            {
                //进行排序
                Data.GameHistoryInformationList.Sort();
                //进行反转
                Data.GameHistoryInformationList.Reverse();
                //创建存储数据的数组
                GameHistoryInformation[] ghi = new GameHistoryInformation[300];
                //截取前300条
                Data.GameHistoryInformationList.CopyTo(ghi);
                //将原集合清空
                Data.GameHistoryInformationList.Clear();
                //将新结果存储到数组中
                Data.GameHistoryInformationList.AddRange(ghi);
            }

            //把这个对象进行保存
            using (FileStream flie = new FileStream(Path.Combine(Data.DataSavePath, "LZ排行榜数据.dat"), FileMode.OpenOrCreate, FileAccess.Write))
            {
                //创建可以序列化类的对象
                BinaryFormatter bf = new BinaryFormatter();
                //把对象转换成2进制并放入选择的文件中
                bf.Serialize(flie, Data.GameHistoryInformationList);
            }
        }
        /// <summary>读取排行榜信息的方法
        /// 
        /// </summary>
        public static void ReadRanking()
        {
            //得到文件路径
            string file = Path.Combine(Data.DataSavePath, "LZ排行榜数据.dat");
            //判断当前文件是否存在，不存在就退出方法
            if (!File.Exists(file)) return;
            //读取文件并进行反序列化处理
            using (FileStream fsRead = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                //把代码强制转换为这个对象并返回
                Data.GameHistoryInformationList = (List<GameHistoryInformation>)bf.Deserialize(fsRead);
            }
        }
        /// <summary>刷新键位触发的事件
        /// 
        /// </summary>
        public static event Action RefreshKey;
        /// <summary>刷新键位的设置方法
        /// 
        /// </summary>
        public static void RefreshKeySet()
        {
            //清除键位命令键值对集合
            Data.KeyAndOreder.Clear();
            //添加暂停游戏的键位
            Data.KeyAndOreder.Add(Data._stopGame, new OrderValue(Enum.PlayerInformation.System, Enum.Order.Stop, Data._stopGame));
            //添加打开控制台的键位
            Data.KeyAndOreder.Add(Data._openDosKey, new OrderValue(Enum.PlayerInformation.System, Enum.Order.OpenDosOrder, Data._openDosKey));
            //添加打开菜单的键位
            Data.KeyAndOreder.Add(Data._openMenuKey, new OrderValue(Enum.PlayerInformation.System, Enum.Order.OpenMenu, Data._openMenuKey));
            //循环添加玩家的键位
            for (int i = 0; i < Data._playerSetList.Length; i++)
            {
                //得到玩家对象
                PlayerSet player = Data._playerSetList[i];
                //得到是第几个玩家
                Enum.PlayerInformation playID = (Enum.PlayerInformation)(i + 2);
                //添加旋转键位
                Data.KeyAndOreder.Add(player.Spin, new OrderValue(playID, Enum.Order.Spin, player.Spin));
                //添加左移动键位
                Data.KeyAndOreder.Add(player.LeftMove, new OrderValue(playID, Enum.Order.LeftMove, player.LeftMove));
                //添加向右移动的键位
                Data.KeyAndOreder.Add(player.RighMove, new OrderValue(playID, Enum.Order.RightMove, player.RighMove));
                //添加向下移动的键位
                Data.KeyAndOreder.Add(player.BelowMove, new OrderValue(playID, Enum.Order.BelowMove, player.BelowMove));
                //添加向下移动到底的键位
                Data.KeyAndOreder.Add(player.MoveToTheEnd, new OrderValue(playID, Enum.Order.MoveToTheEnd, player.MoveToTheEnd));
            }
            //判断刷新事件是否为空
            if (Data.RefreshKey != null)
            {
                //调用刷新方法
                Data.RefreshKey();
            }
        }

        /// <summary>形状对象所对应的颜色静态类
        /// 
        /// </summary>
        public static class ShapeColor
        {
            /// <summary>普通形状I颜色
            /// 
            /// </summary>
            public static Color Shape_I
            {
                get { return TetrisItme_I.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_I.FixedShowColor = value;
                }
            }
            /// <summary>普通形状J颜色
            /// 
            /// </summary>
            public static Color Shape_J
            {
                get { return TetrisItme_J.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_J.FixedShowColor = value;
                }
            }
            /// <summary>普通形状L颜色
            /// 
            /// </summary>
            public static Color Shape_L
            {
                get { return TetrisItme_L.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_L.FixedShowColor = value;
                }
            }
            /// <summary>普通形状O颜色
            /// 
            /// </summary>
            public static Color Shape_O
            {
                get { return TetrisItme_O.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_O.FixedShowColor = value;
                }
            }
            /// <summary>普通形状S颜色
            /// 
            /// </summary>
            public static Color Shape_S
            {
                get { return TetrisItme_S.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_S.FixedShowColor = value;
                }
            }
            /// <summary>普通形状T颜色
            /// 
            /// </summary>
            public static Color Shape_T
            {
                get { return TetrisItme_T.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_T.FixedShowColor = value;
                }
            }
            /// <summary>普通形状Z颜色
            /// 
            /// </summary>
            public static Color Shape_Z
            {
                get { return TetrisItme_Z.FixedShowColor; }
                set
                {
                    //赋值
                    TetrisItme_Z.FixedShowColor = value;
                }
            }
        }
        /// <summary>记录静态类用于成就
        /// 
        /// </summary>
        public static class TakeNotes
        {
            /*消除行数
             *  草房       100行
             *  三层小洋楼 1000行
             *  超市       10000行
             *  百货大超市 100000行
             *  埃菲尔铁塔 1000000行
             *  帝国大厦   10000000行
             *  三峡大坝   100000000行
             *  万里长城   1000000000行
             *下落形状
             *  方块收集者 100个
             *  方块狂热者 1000个
             *  方块噩梦   10000个
             *  方块吞噬者 100000个
             *  方块集中营 1000000个
             *  方块秒杀者 10000000个
             *  方块见光死 100000000个
             *  方块终结者 1000000000个
             *总分
             *  小白   100分
             *  菜鸟   1000分
             *  新手   10000分
             *  老鸟   1000000分
             *  高手   100000000分
             *  大神   10000000000分
             *  无敌   1000000000000分
             *赢的数量
             *  小试牛刀 10次
             *  略显身手 100次
             *  娴熟使用 1000次
             *  战无不胜 10000次
             *  俯视一切 1000000次
             *  无敌存在 100000000次
             *输的次数
             *  第一滴血 1次
             *玩的的次数
             *  大头兵 1次
             *  班长   10次
             *  排长   100次
             *  连长   1000次
             *  营长   10000次
             *  团长   100000次
             *  旅长   1000000次
             *  师长   10000000次
             *  军长   100000000次
             *  司令   1000000000次
             *游玩时间
             *  初来乍到       10分钟
             *  左碰右撞       100分钟
             *  找到诀窍       1000分钟
             *  有点牛逼       10000分钟
             *  老司机         100000分钟
             *  飞的起         1000000分钟
             *  秒天秒地秒空气 10000000分钟
             */
            /// <summary>消除行数
            /// 
            /// </summary>
            public static int RemoveRowCount;
            /// <summary>下落形状数量
            /// 
            /// </summary>
            public static int ShapeCount;
            /// <summary>得到的总分
            /// 
            /// </summary>
            public static long Fraction;
            /// <summary>赢的数量
            /// 
            /// </summary>
            public static int WinCount;
            /// <summary>输的次数
            /// 
            /// </summary>
            public static int LoseCount;
            /// <summary>玩的次数
            /// 
            /// </summary>
            public static int PlayCount;
            /// <summary>游玩游戏总时间
            /// 
            /// </summary>
            public static TimeSpan Time;
            /// <summary>保存记录方法
            /// 
            /// </summary>
            public static void SaveTakeNotes()
            {
                //判断存储数据的文件夹是否存在如果不存在就创建
                if (Directory.Exists(Data.DataSavePath))
                {
                    //创建此目录
                    Directory.CreateDirectory(Data.DataSavePath);
                }
                //创建一个值类型数组
                Dictionary<string, object> vts = new Dictionary<string, object>{
                    //存入总分
                    {"总分" ,TakeNotes.Fraction},
                    //存入消除行数
                    { "消除行数", TakeNotes.RemoveRowCount},
                     //存入下落形状数量
                    {"下落形状数量", TakeNotes.ShapeCount},
                    //存入游玩时间
                    { "玩耍时间", TakeNotes.Time},
                    //存入玩的次数
                    { "玩次数", TakeNotes.PlayCount},
                    //存入赢的次数
                    { "赢次数", TakeNotes.WinCount},
                    //存入输的次数
                    { "输次数", TakeNotes.LoseCount}
                };
                //得到指定文件位置
                string filePath = Path.Combine(Data.DataSavePath, "LZ俄罗斯方块游玩数据.dat");
                //判断文件是否存在存在就删除
                if (File.Exists(filePath)) File.Delete(filePath);
                //把这个对象进行保存
                using (FileStream flie = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    //创建可以序列化类的对象
                    BinaryFormatter bf = new BinaryFormatter();
                    //把对象转换成2进制并放入选择的文件中
                    bf.Serialize(flie, vts);
                }
            }
            /// <summary>读取记录方法
            /// 
            /// </summary>
            public static void ReadTakeNotes()
            {
                //得到指定文件位置
                string filePath = Path.Combine(Data.DataSavePath, "LZ俄罗斯方块游玩数据.dat");
                //判断文件是否存在
                if (File.Exists(filePath))
                {
                    //加载存档文件
                    using (FileStream fsRead = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        //创建序列化与反序列化对象
                        BinaryFormatter bf = new BinaryFormatter();
                        //进行强制转换
                        Dictionary<string, object> vts = (Dictionary<string, object>)bf.Deserialize(fsRead);
                        //得到总分
                        TakeNotes.Fraction = (long)vts["总分"];
                        //得到消除行
                        TakeNotes.RemoveRowCount = (int)vts["消除行数"];
                        //得到下落形状数量
                        TakeNotes.ShapeCount = (int)vts["下落形状数量"];
                        //得到游玩时间
                        TakeNotes.Time = (TimeSpan)vts["玩耍时间"];
                        //存入玩的次数
                        TakeNotes.PlayCount = (int)vts["玩次数"];
                        //存入赢的次数
                        TakeNotes.WinCount = (int)vts["赢次数"];
                        //存入输的次数
                        TakeNotes.LoseCount = (int)vts["输次数"];
                    }
                }
            }
            /// <summary>刷新成就方法
            /// 
            /// </summary>
            public static void RefreshAchievement()
            {
                //得到排行榜
                ListView lv = Program.GameForm.OF.lvAchievement;
                //清除所有项
                lv.Items.Clear();

                #region 消除行数
                // 草房       100行
                TakeNotes.AddShowAchievement(lv, 100, "草房", "消除100行", TakeNotes.RemoveRowCount);
                // 三层小洋楼 1000行
                TakeNotes.AddShowAchievement(lv, 1000, "三层小洋楼", "消除1000行", TakeNotes.RemoveRowCount);
                // 超市       10000行
                TakeNotes.AddShowAchievement(lv, 10000, "超市", "消除10000行", TakeNotes.RemoveRowCount);
                // 百货大超市 100000行
                TakeNotes.AddShowAchievement(lv, 100000, "百货大超市", "消除100000行", TakeNotes.RemoveRowCount);
                // 埃菲尔铁塔 1000000行
                TakeNotes.AddShowAchievement(lv, 1000000, "埃菲尔铁塔", "消除1000000行", TakeNotes.RemoveRowCount);
                // 帝国大厦   10000000行
                TakeNotes.AddShowAchievement(lv, 10000000, "帝国大厦", "消除10000000行", TakeNotes.RemoveRowCount);
                // 三峡大坝   100000000行
                TakeNotes.AddShowAchievement(lv, 100000000, "三峡大坝", "消除100000000行", TakeNotes.RemoveRowCount);
                // 万里长城   1000000000行
                TakeNotes.AddShowAchievement(lv, 1000000000, "万里长城", "消除1000000000行", TakeNotes.RemoveRowCount);
                #endregion

                #region 下落形状
                // 方块收集者 100个
                TakeNotes.AddShowAchievement(lv, 100, "方块收集者", "下落100个方块", TakeNotes.ShapeCount);
                // 方块狂热者 1000个
                TakeNotes.AddShowAchievement(lv, 1000, "方块狂热者", "下落1000个方块", TakeNotes.ShapeCount);
                // 方块噩梦   10000个
                TakeNotes.AddShowAchievement(lv, 10000, "方块噩梦", "下落10000个方块", TakeNotes.ShapeCount);
                // 方块吞噬者 100000个
                TakeNotes.AddShowAchievement(lv, 100000, "方块吞噬者", "下落100000个方块", TakeNotes.ShapeCount);
                // 方块集中营 1000000个
                TakeNotes.AddShowAchievement(lv, 1000000, "方块集中营", "下落1000000个方块", TakeNotes.ShapeCount);
                // 方块秒杀者 10000000个
                TakeNotes.AddShowAchievement(lv, 10000000, "方块秒杀者", "下落10000000个方块", TakeNotes.ShapeCount);
                // 方块见光死 100000000个
                TakeNotes.AddShowAchievement(lv, 100000000, "方块见光死", "下落100000000个方块", TakeNotes.ShapeCount);
                // 方块终结者 1000000000个
                TakeNotes.AddShowAchievement(lv, 1000000000, "方块终结者", "下落1000000000个方块", TakeNotes.ShapeCount);
                #endregion

                #region 总分
                // 小白   100分
                TakeNotes.AddShowAchievement(lv, 100, "小白", "获得100分", TakeNotes.Fraction);
                // 菜鸟   1000分
                TakeNotes.AddShowAchievement(lv, 1000, "菜鸟", "获得1000分", TakeNotes.Fraction);
                // 新手   10000分
                TakeNotes.AddShowAchievement(lv, 10000, "新手", "获得10000分", TakeNotes.Fraction);
                // 老鸟   1000000分
                TakeNotes.AddShowAchievement(lv, 1000000, "老鸟", "获得1000000分", TakeNotes.Fraction);
                // 高手   100000000分
                TakeNotes.AddShowAchievement(lv, 100000000, "高手", "获得100000000分", TakeNotes.Fraction);
                // 大神   10000000000分
                TakeNotes.AddShowAchievement(lv, 10000000000L, "大神", "获得10000000000分", TakeNotes.Fraction);
                // 无敌   1000000000000分
                TakeNotes.AddShowAchievement(lv, 1000000000000L, "无敌", "获得1000000000000分", TakeNotes.Fraction);
                #endregion

                #region 赢的数量
                // 小试牛刀 10次
                TakeNotes.AddShowAchievement(lv, 10, "小试牛刀", "赢10局", TakeNotes.WinCount);
                // 略显身手 100次
                TakeNotes.AddShowAchievement(lv, 100, "略显身手", "赢100局", TakeNotes.WinCount);
                // 娴熟使用 1000次
                TakeNotes.AddShowAchievement(lv, 1000, "娴熟使用", "赢1000局", TakeNotes.WinCount);
                // 战无不胜 10000次
                TakeNotes.AddShowAchievement(lv, 10000, "战无不胜", "赢10000局", TakeNotes.WinCount);
                // 俯视一切 1000000次
                TakeNotes.AddShowAchievement(lv, 1000000, "俯视一切", "赢1000000局", TakeNotes.WinCount);
                // 无敌存在 100000000次
                TakeNotes.AddShowAchievement(lv, 100000000, "无敌存在", "赢100000000局", TakeNotes.WinCount);
                #endregion

                // 第一滴血 1次
                TakeNotes.AddShowAchievement(lv, 1, "第一滴血", "输1局", TakeNotes.LoseCount);

                #region 玩的的次数
                // 大头兵 1次
                TakeNotes.AddShowAchievement(lv, 1, "大头兵", "玩1局", TakeNotes.PlayCount);
                // 班长   10次
                TakeNotes.AddShowAchievement(lv, 10, "班长", "玩10局", TakeNotes.PlayCount);
                // 排长   100次
                TakeNotes.AddShowAchievement(lv, 100, "排长", "玩100局", TakeNotes.PlayCount);
                // 连长   1000次
                TakeNotes.AddShowAchievement(lv, 1000, "连长", "玩1000局", TakeNotes.PlayCount);
                // 营长   10000次
                TakeNotes.AddShowAchievement(lv, 10000, "营长", "玩10000局", TakeNotes.PlayCount);
                // 团长   100000次
                TakeNotes.AddShowAchievement(lv, 100000, "团长", "玩100000局", TakeNotes.PlayCount);
                // 旅长   1000000次
                TakeNotes.AddShowAchievement(lv, 1000000, "旅长", "玩1000000局", TakeNotes.PlayCount);
                // 师长   10000000次
                TakeNotes.AddShowAchievement(lv, 10000000, "师长", "玩10000000局", TakeNotes.PlayCount);
                // 军长   100000000次
                TakeNotes.AddShowAchievement(lv, 100000000, "军长", "玩100000000局", TakeNotes.PlayCount);
                // 司令   1000000000次
                TakeNotes.AddShowAchievement(lv, 1000000000, "司令", "玩1000000000局", TakeNotes.PlayCount);
                #endregion

                #region 游玩时间
                //得到时间
                long time = (long)TakeNotes.Time.TotalMinutes;
                // 初来乍到       10分钟
                TakeNotes.AddShowAchievement(lv, 10, "初来乍到", "玩10分钟", time);
                // 左碰右撞       100分钟
                TakeNotes.AddShowAchievement(lv, 100, "左碰右撞", "玩100分钟", time);
                // 找到诀窍       1000分钟
                TakeNotes.AddShowAchievement(lv, 1000, "找到诀窍", "玩1000分钟", time);
                // 有点牛逼       10000分钟
                TakeNotes.AddShowAchievement(lv, 10000, "有点牛逼", "玩10000分钟", time);
                // 老司机         100000分钟
                TakeNotes.AddShowAchievement(lv, 100000, "老司机", "玩100000分钟", time);
                // 飞的起         1000000分钟
                TakeNotes.AddShowAchievement(lv, 1000000, "飞的起", "玩1000000分钟", time);
                // 秒天秒地秒空气 10000000分钟
                TakeNotes.AddShowAchievement(lv, 10000000, "秒天秒地秒空气", "玩10000000分钟", time);
                #endregion
            }
            /// <summary>添加信息
            /// 
            /// </summary>
            /// <param name="lv">显示数据的表格</param>
            /// <param name="Count">指定消除行数</param>
            /// <param name="name">成就名称</param>
            /// <param name="accomplishCondition">完成条件</param>
            /// <param name="DB">对比的数据</param>
            private static void AddShowAchievement(ListView lv, long Count, string name, string accomplishCondition, long DB)
            {
                //添加行
                lv.Items.Add(new ListViewItem(new string[]{
                        //成就名称
                        name,
                        //完成条件
                        accomplishCondition,
                        //完成进度
                        (Count.ToString() + "/" + DB.ToString()),
                        //完成状态
                       (DB > Count) ? "已完成" : Tool.Proportion(Count,DB)
                    }));
            }
            /// <summary>添加信息方法
            /// 
            /// </summary>
            /// <param name="mb">添加信息得模式对象</param>
            public static void AddInformation(ModeBase mb)
            {
                //得到游玩信息
                GameHistoryInformation chi = mb.Save();
                //将玩的次数+1
                TakeNotes.PlayCount++;
                //判断是数还是赢
                if (mb.State == Enum.GameState.WinEnd)
                {
                    //将赢的数量+1
                    TakeNotes.WinCount++;
                }
                else
                {
                    //将输的数量+1
                    TakeNotes.LoseCount++;
                }
                //判断时间
                if (chi.GameTime >= new TimeSpan(0, 0, 0))
                    //加上游戏游玩时间
                    TakeNotes.Time += chi.GameTime;
                //加上总分
                TakeNotes.Fraction += chi.GameScore;
                //加上消除行数
                TakeNotes.RemoveRowCount += chi.PerishRowCount;
                //循环加上下落形状数量
                for (int i = 0; i < mb.PlayerList.Length; i++)
                {
                    //加上下落方块数量
                    TakeNotes.ShapeCount += mb.PlayerList[i].DiamondsCount;
                }
                //调用刷新成就方法
                TakeNotes.RefreshAchievement();
            }
        }
        /// <summary>保存数据的文件夹目录
        /// 
        /// </summary>
        public readonly static string DataSavePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LZ俄罗斯方块数据文件夹");
    }
}
