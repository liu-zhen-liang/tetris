using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TdatAnalysis;

namespace LZLTetris.Static.DataObject
{
    /// <summary>游戏的历史信息对象
    /// 存储游戏的历史信息，得分，游戏方式，游戏关卡等。
    /// </summary>
    [Serializable]
    public class GameHistoryInformation : IComparable<GameHistoryInformation>
    {
        /// <summary>创建对象并赋值
        /// 
        /// </summary>
        /// <param name="gameWay">游戏方式</param>
        /// <param name="gameMode">游戏模式</param>
        /// <param name="gameCustomsPass">游戏关卡</param>
        /// <param name="perishRowCount">消灭行数</param>
        /// <param name="gameTime">游戏时长</param>
        /// <param name="gameScore">游戏得分</param>
        /// <param name="gameDateTime">游戏日期</param>
        /// <param name="gameRemark">备注信息</param>
        /// <param name="isSucceed">是否成功</param>
        public GameHistoryInformation(string gameWay, string gameMode, int gameCustomsPass, int perishRowCount, TimeSpan gameTime, int gameScore, DateTime gameDateTime, string gameRemark,bool isSucceed)
        {
            //赋值
            this._gameWay = gameWay;
            this._gameMode = gameMode;
            this._gameCustomsPass = gameCustomsPass;
            this._perishRowCount = perishRowCount;
            this._gameTime = gameTime;
            this._gameScore = gameScore;
            this._gameDateTime = gameDateTime;
            this._gameRemark = gameRemark;
            this._isSucceed = isSucceed;
        }
        private string _gameWay;
        /// <summary>游戏方式
        /// 
        /// </summary>
        public string GameWay
        {
            get { return _gameWay; }
            set { _gameWay = value; }
        }
        private string _gameMode;
        /// <summary>游戏模式
        /// 
        /// </summary>
        public string GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; }
        }
        private int _gameCustomsPass;
        /// <summary>游戏关卡
        /// 
        /// </summary>
        public int GameCustomsPass
        {
            get { return _gameCustomsPass; }
            set { _gameCustomsPass = value; }
        }
        private int _perishRowCount;
        /// <summary>消灭行数
        /// 
        /// </summary>
        public int PerishRowCount
        {
            get { return _perishRowCount; }
            set { _perishRowCount = value; }
        }
        private TimeSpan _gameTime;
        /// <summary>游戏时长【存储秒数】
        /// 
        /// </summary>
        public TimeSpan GameTime
        {
            get { return _gameTime; }
            set { _gameTime = value; }
        }
        private int _gameScore;
        /// <summary>游戏得分
        /// 
        /// </summary>
        public int GameScore
        {
            get { return _gameScore; }
            set { _gameScore = value; }
        }
        private DateTime _gameDateTime;
        /// <summary>游戏的开始日期
        /// 
        /// </summary>
        public DateTime GameDateTime
        {
            get { return _gameDateTime; }
            set { _gameDateTime = value; }
        }
        private string _gameRemark;
        /// <summary>备注信息
        /// 
        /// </summary>
        public string GameRemark
        {
            get { return _gameRemark; }
            set { _gameRemark = value; }
        }
        private bool _isSucceed;
        /// <summary>是否成功
        /// 
        /// </summary>
        public bool IsSucceed
        {
            get { return _isSucceed; }
            set { _isSucceed = value; }
        }
        /// <summary>将当前对象转换成表格显示元素
        /// 
        /// </summary>
        /// <returns>转换完成的ListViewItem对象</returns>
        public ListViewItem ShowItme()
        {
            //返回对象
            return new ListViewItem(new string[]{
                //名次填空字符串
                "",
                //游戏方式
                this.GameWay,
                //游戏模式
                this.GameMode,
                //成功与否
                (this.IsSucceed?"胜利":"虽败犹荣"),
                //游戏关卡
                this.GameCustomsPass.ToString(),
                //消灭行数
                this.PerishRowCount.ToString(),
                //游戏时长
                Tool.TimeSpanToString(this.GameTime),
                //游戏得分
                this.GameScore.ToString(),
                //游戏日期
                Tool.DateTimeToChinese(this.GameDateTime),
                //备注
                this.GameRemark
            });
        }
        /// <summary>比较方法【用于排序】
        /// 
        /// </summary>
        /// <param name="other">用于排序的对象</param>
        /// <returns>一个值，指示要比较的对象的相对顺序。返回值的含义如下：值含义小于零此对象小于 other 参数。零此对象等于 other。大于零此对象大于 other。</returns>
        public int CompareTo(GameHistoryInformation other)
        {
            //判断传入参数是否为null，如果等于null就返回1【表示当前对象大于此参数】
            if (other == null) return 1;
            //创建一个存储匹配参数的对象
            int it;
            //匹配总分
            it = this.GameScore - other.GameScore;
            //判断是否不等于零，如果不等于零就直接返回结果
            if (it != 0) return it;
            //匹配游戏关卡
            it = this.GameCustomsPass - other.GameCustomsPass;
            //判断是否不等于零，如果不等于零就直接返回结果
            if (it != 0) return it;
            //匹配消灭行数
            it = this.PerishRowCount - other.PerishRowCount;
            //判断是否不等于零，如果不等于零就直接返回结果
            if (it != 0) return it;
            //匹配游戏时长
            it = this.GameTime.CompareTo(other.GameTime);
            //判断是否不等于零，如果不等于零就直接返回结果【并将结果进行反转】
            if (it != 0) return it > 0 ? -1 : 1;
            //匹配开始日期
            it = this.GameDateTime.CompareTo(other.GameDateTime);
            //返回比较结果
            return it;
        }
    }
}
