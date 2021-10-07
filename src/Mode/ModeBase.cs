using LZLTetris.ConventionShape;
using LZLTetris.Enum;
using LZLTetris.Game;
using LZLTetris.Static;
using LZLTetris.Static.DataObject;
using LZLTetris.TetrisShape.BossShape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsTableControl;

namespace LZLTetris.Mode
{
    /// <summary>所有模式的直接父对象
    /// 
    /// </summary>
    public class ModeBase : IDisposable
    {
        /// <summary>创建模式对象并赋值
        /// 
        /// </summary>
        /// <param name="game">游戏父对象【游戏方式：单人游戏、本地双人等】</param>
        /// <param name="table">显示数据的表格</param>
        /// <param name="seed">随机种子【填写值：-1代表按照系统开机时间创建随机对象】</param>
        /// <param name="id">存储当前模式对象的ID属性【就是在游戏方式对象中存储的索引位置】</param>
        protected ModeBase(GameBase game, Table table, int seed, int id)
        {
            //赋值
            this._game = game;
            this._table = table;
            this._seed = seed;
            //判断种子值是否为-1
            if (seed == -1)
            {
                //随机种子
                this._random = new Random();
            }
            else
            {
                //按照种子产生新随机对象
                this._random = new Random(seed);
            }
            //赋值id
            this._id = id;
            //创建计时器对象
            this._timer = new Timer();
        }
        /// <summary>随机对象
        /// 
        /// </summary>
        protected Random _random;
        private GameBase _game;
        /// <summary>游戏父对象，使用它可以调用游戏结束方法
        /// 
        /// </summary>
        public GameBase Game
        {
            get { return _game; }
        }
        private Table _table;
        /// <summary>用于显示执行数据的表格对象
        /// 
        /// </summary>
        public Table Table
        {
            get { return _table; }
        }
        protected int _customsPass;
        /// <summary>存储所在关卡的变量【有些模式将他当做速度】
        /// 
        /// </summary>
        public int CustomsPass
        {
            get { return _customsPass; }
            set
            {
                //赋值
                this._customsPass = value;
                //设置计时器的间隔秒数
                this._timer.Interval = Static.Tetris.GetCustomsPassCorrespondingTime(value);
            }
        }
        protected int _fraction;
        /// <summary>存储总分数的变量
        /// 
        /// </summary>
        public int Fraction
        {
            get { return _fraction; }
            set { _fraction = value; }
        }
        protected int _perishRowCount;
        /// <summary>存储总消灭的行数量
        /// 
        /// </summary>
        public int PerishRowCount
        {
            get { return _perishRowCount; }
            set { _perishRowCount = value; }
        }
        protected Player[] _playerList;
        /// <summary>玩家集合【存储下落方块形状对象】
        /// 存储下落的方块模型对象集合，平常都是只有第一个，但是在合作模式中有两，或以上，就代表为两个或者多个玩家，每次执行输入命令都进行查找看有几个玩家，生成块也按照这个来生成
        /// </summary>
        public Player[] PlayerList
        {
            get { return _playerList; }
            set
            {
                //赋值
                this._playerList = value;
                //判断传入的值数量是否等于一，如果等于一就代表只有一个玩家，反之亦然
                this._isOnePlayer = value.Length == 1;
            }
        }
        private bool _isOnePlayer;
        /// <summary>判断是否当前只有一个玩家？【单人游戏，或者对抗游戏等】
        /// 
        /// </summary>
        public bool IsOnePlayer
        {
            get { return _isOnePlayer; }
        }
        private int _id;
        /// <summary>存储当前模式对象的ID属性【就是在游戏方式对象中存储的索引位置】
        /// 
        /// </summary>
        public int ID
        {
            get { return _id; }
        }
        /// <summary>游戏开始时间
        /// 
        /// </summary>
        protected DateTime _beginDateTime;
        /// <summary>游戏结束时间
        /// 
        /// </summary>
        protected DateTime _endDateTime;
        private int _seed;
        /// <summary>关卡的随机种子
        /// 
        /// </summary>
        public int Seed
        {
            get { return _seed; }
        }
        protected Timer _timer;
        /// <summary>计时器
        /// 
        /// </summary>
        public Timer Timer
        {
            get { return _timer; }
        }
        /// <summary>获取模式的名称
        /// 
        /// </summary>
        public virtual string ModeName { get { return "模式父类"; } }
        /// <summary>存储当前模式的状态
        /// 
        /// </summary>
        private GameState _state = GameState.NotBegin;
        /// <summary>存储当前模式的状态【未开始、正在运行、暂停、输了、赢了】
        /// 
        /// </summary>
        public GameState State
        {
            get { return _state; }
            set { this._state = value; }
        }

        /// <summary>方块到底部触发的事件
        /// 
        /// </summary>
        public event Action<Player> ToTheEnd;
        /// <summary>消除行触发的事件第一个参数是消除方块的玩家对象，第二个参数是消除的行数量
        /// 
        /// </summary>
        public event Action<Player, int> EliminateRow;

        /// <summary>验证是否有行可以被消除
        /// 如果有行被消除，就进行消除行并返回消除的行的数量【并更改显示的效果：迅速消除行并且下移填补空行】
        /// </summary>
        /// <returns>如果返回的是0,就代表没有消除任何行，如果返回大于0就是消除的行数。</returns>
        public virtual int EliminateRowCount()
        {
            //得到可以被消除的行索引数组
            int[] indexList = this._table.EliminateRow();
            //判断是否元素数量为零，如果为零就代表没有行可以被消除，就退出方法并返回零
            if (indexList.Length == 0) return 0;
            //开始循环消除行
            for (int i = 0; i < indexList.Length; i++)
            {
                //消除指定行
                this._table[indexList[i]].ResetTD();
            }
            //创建存储当前垫底的行索引消除的行索引最后一个的索引
            int index = indexList[indexList.Length - 1];
            //判断最后一个索引是否为0如果为0就代表是第一行，所以就没必要再下移了，直接返回清除数量
            if (index == 0) return indexList.Length;
            //循环开始移动单元格【倒序，因为表格的单元格索引是最高那一行为0，所以要想将索引低的移动到索引高的就使用倒序循环】
            for (int i = index - 1; i >= 0; i--)
            {
                //移动当前行的数据到指定行并清除当前固定行【不移动和清除活动单元格【移动的俄罗斯方块形状】】
                //调用表格的移动行并判断是否移动成功，如果成功就索引--，否则不更改
                if (this._table.MoveTR(index, i))
                {
                    //进入代表更改成功，将索引--
                    index--;
                }
            }
            //返回消除的行数量
            return indexList.Length;
        }
        /// <summary>根据输入的命令来执行相应的操作
        /// 
        /// </summary>
        /// <param name="order">执行命令的玩家、执行的命令、键</param>
        public virtual void Exec(OrderValue order)
        {
            //判断如果不是正在运行就不执行任何命令
            if (this.State != GameState.BeInMotion) return;
            //创建存储是第几个玩家触发的命令
            int playIndex;
            //得到是哪个玩家触发的
            switch (order.Player)
            {
                case LZLTetris.Enum.PlayerInformation.P1:
                    //设置为0
                    playIndex = 0;
                    break;
                case LZLTetris.Enum.PlayerInformation.P2:
                    //设置为1
                    playIndex = 1;
                    break;
                case LZLTetris.Enum.PlayerInformation.None:
                case LZLTetris.Enum.PlayerInformation.System:
                    //如果是这两个命令就不予以执行
                    return;
                default:
                    //如果是到这里代表扩展了枚举，但是没有设置所以抛出异常
                    throw new Exception("扩展了但是没有设置！");
            }
            //得到玩家对象
            Player pl;
            //判断有几个玩家，如果为一个就不管索引是几都执行，如果是多个就执行指定索引位置的玩家对象
            if (this._playerList.Length == 1)
            {
                //直接赋值第一个玩家对象
                pl = this._playerList[0];
            }
            else
            {
                //赋值指定索引位置的玩家对象
                pl = this._playerList[playIndex];
            }

            //开始调用指定玩家对象的俄罗斯方块模型对象的指定操作命令
            switch (order.Order)
            {
                case LZLTetris.Enum.Order.Spin:
                    //调用玩家的正在操作的模型对象的旋转方法
                    pl.Model.Spin();
                    //触发旋转声音效果
                    Static.Music.SpinMusic();
                    break;
                case LZLTetris.Enum.Order.LeftMove:
                    //调用玩家的正在操作的模型对象的左移动方法
                    pl.Model.Move(true);
                    break;
                case LZLTetris.Enum.Order.RightMove:
                    //调用玩家的正在操作的模型对象的右移动方法
                    pl.Model.Move(false);
                    break;
                case LZLTetris.Enum.Order.BelowMove:
                    //调用玩家的正在操作的模型对象的下移动方法并判断是否移动到低，判断是否已经到底了如果到底了就触发移动到底方法
                    if (pl.Model.BelowMove(true) == MoveResult.MoveFail)
                    {
                        //调用移动到底的验证方法
                        this.MoveToTheEnd(pl);
                    }
                    break;
                case LZLTetris.Enum.Order.MoveToTheEnd:
                    //调用玩家的正在操作的模型对象的下移动到底方法
                    MoveResult mr = pl.Model.BelowMove(false);
                    //判断是否移动失败
                    if (mr == MoveResult.MoveFail)
                    {
                        //调用移动到底的验证方法
                        this.MoveToTheEnd(pl);
                    }
                    break;
                case LZLTetris.Enum.Order.None:
                case LZLTetris.Enum.Order.Stop:
                case LZLTetris.Enum.Order.Chat:
                case LZLTetris.Enum.Order.OpenDosOrder:
                case LZLTetris.Enum.Order.OpenMenu:
                    //系统命令不执行，退出
                    return;
                default:
                    //扩展了新命令，但是代码还没设置对此命令的相关操作，所以抛出异常，来用于告诉，这个地方还没有指定的操作
                    throw new Exception("枚举更新了，但是这里还没有指定的操作！");
            }
        }
        /// <summary>显示获得的分数、当前关卡等信息
        /// 
        /// </summary>
        public virtual void Show()
        {
            //判断存储玩家对象是否为空，如果为空就退出方法
            if (this._playerList == null) return;
            //循环调用玩家对象集合显示数据
            for (int i = 0; i < this._playerList.Length; i++)
            {
                //得到玩家信息对象
                Player play = this._playerList[i];
                //显示关卡信息
                play.CustomsPassLabel.Text = "当前关卡：" + this._customsPass.ToString();
                //判断是多个玩家还是一个玩家
                if (this.IsOnePlayer)
                {
                    //显示得分信息
                    play.FractionLabel.Text = "当前得分：" + play.Fraction.ToString();
                    //显示消除行的数量
                    play.PerishRowCountLabel.Text = "消除行数：" + play.PerishRowCount.ToString();
                }
                else
                {
                    //显示得分信息【总得分/自得分】
                    play.FractionLabel.Text = "当前得分：" + this._fraction.ToString() + "/" + play.Fraction.ToString();
                    //显示消除行的数量【总消灭行/自消灭行】
                    play.PerishRowCountLabel.Text = "消除行数：" + this._perishRowCount.ToString() + "/" + play.PerishRowCount.ToString();
                }
                //显示下落方块的数量
                play.DiamondsCountLabel.Text = "下落方块数量：" + this._playerList[i].DiamondsCount.ToString();
            }
        }
        //普通形状
        /// <summary>普通形状选择次数集合
        /// 【0 = TetrisItme_O】【1 = TetrisItme_S】【2 = TetrisItme_I】【3 = TetrisItme_Z】【4 = TetrisItme_J】【5 = TetrisItme_L】【6 = TetrisItme_T】
        /// </summary>
        private int[] __shapeCounts = new int[7];
        /// <summary>普通形状选择的目前最大数量
        /// 【只要小于这个最大数量的形状都可以被选择否则就不可以被选择直到全部选择了一遍就将最大数量 + 2】
        /// </summary>
        private int __shapeMaxCount = 2;
        //Boss形状
        /// <summary>Boss选择选择此数集合
        /// 【0 = TetrisItme_BossBigTen】【1 = TetrisItme_BossBomb】
        /// 【2 = TetrisItme_BossBy】【3 = TetrisItme_BossC】【4 = TetrisItme_BossE】
        /// 【5 = TetrisItme_BossH】【6 = TetrisItme_BossHalfTen】
        /// 【7 = TetrisItme_BossO】【8 = TetrisItme_BossQ】【9 = TetrisItme_BossRadiation】
        /// 【10 = TetrisItme_BossT】【11 = TetrisItme_BossTen】
        /// 【12 = TetrisItme_BossV】【13 = TetrisItme_BossY】【14 = TetrisItme_BossZ】
        /// </summary>
        private int[] __BossShapeCounts = new int[15];
        /// <summary>Boss选择的目前最大数量
        /// 
        /// </summary>
        private int __BossShapeMaxCount = 2;
        /// <summary>得到一个随机形状对象【如果为true就生成Boss形状false生成普通形状】
        /// 
        /// </summary>
        /// <param name="upIndex">将该对象创建的最第一行的中心点位置【合作模式的话，就是当前玩家所分配的范围中的中心点】</param>
        /// <param name="isBoss">如果为true就生成Boss形状false生成普通形状</param>
        /// <returns>随机的形状对象</returns>
        public virtual TetrisItmeBase NextShape(int upIndex, bool isBoss)
        {
            //存储可以被使用的形状集合
            List<int> selectIndexList = new List<int>();
            //判断是选择生成普通形状还是Boss形状
            if (isBoss)//生成Boss形状
            {
            //创建跳转标签
            label:
                #region 得到可以被选择的形状的索引
                //得到可以被选择的形状的索引
                for (int i = 0; i < this.__BossShapeCounts.Length; i++)
                {
                    //判断当前形状是否可以被选择
                    if (this.__BossShapeCounts[i] < this.__BossShapeMaxCount)
                    {
                        //将当前形状索引存入数组
                        selectIndexList.Add(i);
                    }
                }
                #endregion
                //判断是否有可以被选择的索引没有
                if (selectIndexList.Count > 0)//右可以被选择的形状
                {
                    //随机选择指定索引形状
                    int sapIndex = selectIndexList[this._random.Next(selectIndexList.Count)];
                    //将指定形状数量++
                    this.__BossShapeCounts[sapIndex]++;
                    //得到并返回指定形状
                    return this.GetShape(upIndex, sapIndex, true);
                }
                else//没有可以被选择的形状
                {
                    //将Boss模型最大数量 + 2
                    this.__BossShapeMaxCount += 2;
                    //跳转到跳转标签
                    goto label;
                }
            }
            else//生成普通形状
            {
                #region 生成普通形状
            //得到跳转标签
            label:
                #region 得到可以被使用的形状索引位置
                //得到可以被使用的形状
                for (int i = 0; i < this.__shapeCounts.Length; i++)
                {
                    //判断当前形状是否可以被使用
                    if (this.__shapeCounts[i] < this.__shapeMaxCount)
                    {
                        //将当前索引存入集合
                        selectIndexList.Add(i);
                    }
                }
                #endregion
                //判断是否有可以被选择的选择
                if (selectIndexList.Count > 0)
                {
                    //随机选择指定索引中的索引然后按照此形状索引
                    int sapIndex = selectIndexList[this._random.Next(selectIndexList.Count)];
                    //将指定形状数量++
                    this.__shapeCounts[sapIndex]++;
                    //得到指定形状并返回此形状
                    return this.GetShape(upIndex, sapIndex, false);
                }
                else
                {
                    //将最大数量+2
                    this.__shapeMaxCount += 2;
                    //跳转到反倒标签
                    goto label;
                }
                #endregion
            }
        }
        /// <summary>得到指定索引位置的形状，并将普通模型进行随机得到选择的生成形状
        /// 
        /// </summary>
        /// <param name="upIndex">形状生成所在索引位置</param>
        /// <param name="index">指定索引位置的形状</param>
        /// <param name="isBoss">true代表Boss形状false代表普通形状</param>
        /// <returns>指定形状</returns>
        private TetrisItmeBase GetShape(int upIndex, int index, bool isBoss)
        {
            //判断获取Boss模型还是普通模型
            if (isBoss)//Boss形状
            {
                #region 得到指定位置的图形对象并返回
                //得到指定位置的图形对象并返回
                switch (index)
                {
                    case 0:
                        //得到指定图形
                        return new TetrisItme_BossBigTen(0, this._table, upIndex);
                    case 1:
                        //得到指定图形
                        return new TetrisItme_BossBomb(0, this._table, upIndex);
                    case 2:
                        //得到指定图形
                        return new TetrisItme_BossBy(0, this._table, upIndex);
                    case 3:
                        //得到指定图形
                        return new TetrisItme_BossC(0, this._table, upIndex);
                    case 4:
                        //得到指定图形
                        return new TetrisItme_BossE(0, this._table, upIndex);
                    case 5:
                        //得到指定图形
                        return new TetrisItme_BossH(0, this._table, upIndex);
                    case 6:
                        //得到指定图形
                        return new TetrisItme_BossHalfTen(0, this._table, upIndex);
                    case 7:
                        //得到指定图形
                        return new TetrisItme_BossO(0, this._table, upIndex);
                    case 8:
                        //得到指定图形
                        return new TetrisItme_BossQ(0, this._table, upIndex);
                    case 9:
                        //得到指定图形
                        return new TetrisItme_BossRadiation(0, this._table, upIndex);
                    case 10:
                        //得到指定图形
                        return new TetrisItme_BossT(0, this._table, upIndex);
                    case 11:
                        //得到指定图形
                        return new TetrisItme_BossTen(0, this._table, upIndex);
                    case 12:
                        //得到指定图形
                        return new TetrisItme_BossV(0, this._table, upIndex);
                    case 13:
                        //得到指定图形
                        return new TetrisItme_BossY(0, this._table, upIndex);
                    case 14:
                        //得到指定图形
                        return new TetrisItme_BossZ(0, this._table, upIndex);
                    default:
                        //抛出异常
                        throw new Exception("木有此形状！");
                }
                #endregion
            }
            else//普通形状
            {
                #region 得到普通形状
                //得到指定索引位置的模型
                switch (index)
                {
                    case 0:
                        //返回模型
                        return new TetrisItme_O(this._table, upIndex);
                    case 1:
                        //返回模型
                        return new TetrisItme_S(this._random.Next(2), this._table, upIndex);
                    case 2:
                        //返回模型
                        return new TetrisItme_I(this._random.Next(2), this._table, upIndex);
                    case 3:
                        //返回模型
                        return new TetrisItme_Z(this._random.Next(2), this._table, upIndex);
                    case 4:
                        //返回模型
                        return new TetrisItme_J(this._random.Next(4), this._table, upIndex);
                    case 5:
                        //返回模型
                        return new TetrisItme_L(this._random.Next(4), this._table, upIndex);
                    case 6:
                        //返回模型
                        return new TetrisItme_T(this._random.Next(4), this._table, upIndex);
                    default:
                        //抛出异常
                        throw new Exception("未此模型！");
                }
                #endregion
            }
        }
        /// <summary>开始方法
        /// 
        /// </summary>
        public virtual void Start()
        {
            //显示关卡模式玩法
            Program.GameForm.Text = string.Format("LZ俄罗斯方块 - [{0} -> {1}]", this.Game.GameWayName, this.ModeName);
        }
        /// <summary>暂停方法
        /// 
        /// </summary>
        public virtual void Stop()
        {
            throw new Exception("不实现！给子类重写的方法！");
        }
        /// <summary>移动到底触发的方法【播放音效、检索是否有块可以被消除】
        /// 
        /// </summary>
        /// <param name="play">移动到底的玩家对象</param>
        public virtual void MoveToTheEnd(Player play)
        {
            //播放落地音效
            Music.BeBornMusic();
            //判断“触底”事件是否为空，如果不为空就触发此事件
            if (this.ToTheEnd != null) { this.ToTheEnd(play); }
            //设置当前玩家的所在形状为固定形状【如果不设置这个就将会不消除任何行】
            play.Model.SetFixedCell();
            //验证并消除完成行返回完成数量
            int count = this.EliminateRowCount();
            //判断消除的行数是否等于0，如果等于0就直接退出
            if (count == 0) return;
            //计算出消除分【普通模式】【分数计算：每消除一行底分150，连着消除两行第一行：150，第二行分数：150+100分，连着消除三行：第一行：150，第二行150+100，第三行150+200】
            int fraction = (count * 150) + ((((count - 1) * count) / 2) * 100);
            //将消除行数量存入，当前对象的消除行数中
            this._perishRowCount += count;
            //将消灭的行数加入消除的对象中
            play.PerishRowCount += count;
            //将分数加入当前对象存储的总分中
            this._fraction += fraction;
            //将分数加入玩家变量的分数中
            play.Fraction += fraction;
            //播放消除音效
            Music.EliminateMusic();
            //判断“消除行”事件是否为空，如果不为空就触发事件
            if (this.EliminateRow != null) { this.EliminateRow(play, count); }
        }
        /// <summary>保存当前游戏记录方法
        /// 
        /// </summary>
        public virtual GameHistoryInformation Save()
        {
            throw new Exception("不实现！给子类重写的方法！");
        }
        /// <summary>释放占用资源的方法
        /// 
        /// </summary>
        public void Dispose()
        {
            //释放计时器资源
            this._timer.Dispose();
        }
        /// <summary>清除掉当前模式的方法【完全停止当前模式对象并清除资源】
        /// 
        /// </summary>
        public virtual void Close()
        {
            //更改标题
            Program.GameForm.Text = "LZ俄罗斯方块";
            //调用停止方法
            this.Stop();
            //调用释放资源方法
            this.Dispose();
        }
        /// <summary>游戏结束时更改表格的方块的方法
        /// 
        /// </summary>
        public virtual void OverUpdateTable()
        {
            //循环显示固定方块
            for (int row = 0; row < this.Table.RowCount; row++)
            {
                for (int line = 0; line < this.Table.CellCount; line++)
                {
                    //得到指定单元格
                    TD td = this.Table[row, line];
                    //得到单元格附加数据对象
                    CellInformation cf = td.Tag;
                    //判断颜色透明通道不等于0就设置为灰色，或者被选择
                    if (td.BackgroundColor.A != 0 || cf.IsSelect)
                    {
                        //更改颜色为灰色
                        td.BackgroundColor = Color.FromArgb(160, 160, 160);
                    }
                }
            }
        }
        /// <summary>重置方法
        /// 
        /// </summary>
        public virtual void Reset()
        {
            //将关卡速度设置为零
            this.CustomsPass = 0;
            //重置总分
            this._fraction = 0;
            //重置总消灭行数
            this._perishRowCount = 0;
            //重置游戏开始时间
            this._beginDateTime = new DateTime();
            //重置游戏结束时间
            this._endDateTime = new DateTime();
            //设置状态为【还未开始】
            this.State = GameState.NotBegin;
            //重置表格
            this._table.RefreshTable();
            //循环调用玩家对象重置方法
            for (int i = 0; i < this._playerList.Length; i++)
            {
                //调用重置方法
                this._playerList[i].Reset();
            }
        }
    }
}
