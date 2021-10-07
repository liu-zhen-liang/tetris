using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TdatAnalysis;

namespace LZLTetris.Static.DataObject
{
    /// <summary>玩家设置对象
    /// 储玩家的键位设置的对象。
    /// </summary>
    public class PlayerSet
    {
        /// <summary>创建对象并赋值
        /// 
        /// </summary>
        /// <param name="spin">旋转键</param>
        /// <param name="leftMove">左移一步键</param>
        /// <param name="rightMove">右移一步键</param>
        /// <param name="belovMove">下移一步键</param>
        /// <param name="moveToTheEnd">下移到底键</param>
        public PlayerSet(Keys spin, Keys leftMove, Keys rightMove, Keys belovMove, Keys moveToTheEnd)
        {
            //赋值
            this._spin = spin;
            this._leftMove = leftMove;
            this._righMove = rightMove;
            this._belowMove = belovMove;
            this._moveToTheEnd = moveToTheEnd;
        }
        /// <summary>创建当前对象并使用Tdat包对象进行赋值
        /// 
        /// </summary>
        /// <param name="ti">Tdta包对象</param>
        public PlayerSet(TdatItme ti)
        {
            //赋值
            this._spin = PlayerSet.StrToKeys[(ti["旋转模型"] as TdatText).Text];
            this._leftMove = PlayerSet.StrToKeys[(ti["左移一格"] as TdatText).Text];
            this._righMove = PlayerSet.StrToKeys[(ti["右移一格"] as TdatText).Text];
            this._belowMove = PlayerSet.StrToKeys[(ti["下移一格"] as TdatText).Text];
            this._moveToTheEnd = PlayerSet.StrToKeys[(ti["下移到底"] as TdatText).Text];
        }
        private Keys _spin;
        /// <summary>旋转键位
        /// 
        /// </summary>
        public Keys Spin
        {
            get { return _spin; }
            set { _spin = value; }
        }
        private Keys _leftMove;
        /// <summary>向左移动一步键位
        /// 
        /// </summary>
        public Keys LeftMove
        {
            get { return _leftMove; }
            set { _leftMove = value; }
        }
        private Keys _righMove;
        /// <summary>向右移动一步键
        /// 
        /// </summary>
        public Keys RighMove
        {
            get { return _righMove; }
            set { _righMove = value; }
        }
        private Keys _belowMove;
        /// <summary>向下移动一步键
        /// 
        /// </summary>
        public Keys BelowMove
        {
            get { return _belowMove; }
            set { _belowMove = value; }
        }
        private Keys _moveToTheEnd;
        /// <summary>向下移动到底键位
        /// 
        /// </summary>
        public Keys MoveToTheEnd
        {
            get { return _moveToTheEnd; }
            set { _moveToTheEnd = value; }
        }
        /// <summary>将当前对象保存成Tdat包对象
        /// 
        /// </summary>
        /// <returns>当前对象存储成的Tdta包对象</returns>
        public TdatItme Save()
        {
            //创建保存当前对象的Tdta文档对象
            TdatItme ti = new TdatItme()
            {
                {"旋转模型" , new TdatText(this._spin.ToString())},
                {"左移一格" , new TdatText(this._leftMove.ToString())},
                {"右移一格" , new TdatText(this._righMove.ToString())},
                {"下移一格" , new TdatText(this._belowMove.ToString())},
                {"下移到底" , new TdatText(this._moveToTheEnd.ToString())}
            };
            //返回对象
            return ti;
        }
        /// <summary>将字符串形式的键转换成Keys枚举
        /// 
        /// </summary>
        public readonly static Dictionary<string, Keys> StrToKeys = new Dictionary<string, Keys>() {
            {"Return",Keys.Return},{"Oemtilde",Keys.Oemtilde},
            {"A",Keys.A},{"Add",Keys.Add},{"Alt",Keys.Alt},{"Apps",Keys.Apps},{"Attn",Keys.Attn},{"B",Keys.B},{"Back",Keys.Back},{"BrowserBack",Keys.BrowserBack},{"BrowserFavorites",Keys.BrowserFavorites},{"BrowserForward",Keys.BrowserForward},{"BrowserHome",Keys.BrowserHome},{"BrowserRefresh",Keys.BrowserRefresh},{"BrowserSearch",Keys.BrowserSearch},{"BrowserStop",Keys.BrowserStop},{"C",Keys.C},{"Cancel",Keys.Cancel},{"Capital",Keys.Capital},{"Clear",Keys.Clear},{"Control",Keys.Control},{"ControlKey",Keys.ControlKey},{"Crsel",Keys.Crsel},{"D",Keys.D},{"D0",Keys.D0},{"D1",Keys.D1},{"D2",Keys.D2},{"D3",Keys.D3},{"D4",Keys.D4},{"D5",Keys.D5},{"D6",Keys.D6},{"D7",Keys.D7},{"D8",Keys.D8},{"D9",Keys.D9},{"Decimal",Keys.Decimal},{"Delete",Keys.Delete},{"Divide",Keys.Divide},{"Down",Keys.Down},{"E",Keys.E},{"End",Keys.End},{"Enter",Keys.Enter},{"EraseEof",Keys.EraseEof},{"Escape",Keys.Escape},{"Execute",Keys.Execute},{"Exsel",Keys.Exsel},{"F",Keys.F},{"F1",Keys.F1},{"F10",Keys.F10},{"F11",Keys.F11},{"F12",Keys.F12},{"F13",Keys.F13},{"F14",Keys.F14},{"F15",Keys.F15},{"F16",Keys.F16},{"F17",Keys.F17},{"F18",Keys.F18},{"F19",Keys.F19},{"F2",Keys.F2},{"F20",Keys.F20},{"F21",Keys.F21},{"F22",Keys.F22},{"F23",Keys.F23},{"F24",Keys.F24},{"F3",Keys.F3},{"F4",Keys.F4},{"F5",Keys.F5},{"F6",Keys.F6},{"F7",Keys.F7},{"F8",Keys.F8},{"F9",Keys.F9},{"FinalMode",Keys.FinalMode},{"G",Keys.G},{"H",Keys.H},{"HanguelMode",Keys.HanguelMode},{"HanjaMode",Keys.HanjaMode},{"Help",Keys.Help},{"Home",Keys.Home},{"I",Keys.I},{"IMEAccept",Keys.IMEAccept},{"IMEConvert",Keys.IMEConvert},{"IMEModeChange",Keys.IMEModeChange},{"IMENonconvert",Keys.IMENonconvert},{"Insert",Keys.Insert},{"J",Keys.J},{"JunjaMode",Keys.JunjaMode},{"K",Keys.K},{"KeyCode",Keys.KeyCode},{"L",Keys.L},{"LButton",Keys.LButton},{"LControlKey",Keys.LControlKey},{"LMenu",Keys.LMenu},{"LShiftKey",Keys.LShiftKey},{"LWin",Keys.LWin},{"LaunchApplication1",Keys.LaunchApplication1},{"LaunchApplication2",Keys.LaunchApplication2},{"LaunchMail",Keys.LaunchMail},{"Left",Keys.Left},{"LineFeed",Keys.LineFeed},{"M",Keys.M},{"MButton",Keys.MButton},{"MediaNextTrack",Keys.MediaNextTrack},{"MediaPlayPause",Keys.MediaPlayPause},{"MediaPreviousTrack",Keys.MediaPreviousTrack},{"MediaStop",Keys.MediaStop},{"Menu",Keys.Menu},{"Modifiers",Keys.Modifiers},{"Multiply",Keys.Multiply},{"N",Keys.N},{"Next",Keys.Next},{"NoName",Keys.NoName},{"None",Keys.None},{"NumLock",Keys.NumLock},{"NumPad0",Keys.NumPad0},{"NumPad1",Keys.NumPad1},{"NumPad2",Keys.NumPad2},{"NumPad3",Keys.NumPad3},{"NumPad4",Keys.NumPad4},{"NumPad5",Keys.NumPad5},{"NumPad6",Keys.NumPad6},{"NumPad7",Keys.NumPad7},{"NumPad8",Keys.NumPad8},{"NumPad9",Keys.NumPad9},{"O",Keys.O},{"Oem1",Keys.Oem1},{"Oem102",Keys.Oem102},{"Oem2",Keys.Oem2},{"Oem3",Keys.Oem3},{"Oem4",Keys.Oem4},{"Oem5",Keys.Oem5},{"Oem6",Keys.Oem6},{"Oem7",Keys.Oem7},{"Oem8",Keys.Oem8},{"OemClear",Keys.OemClear},{"OemMinus",Keys.OemMinus},{"OemPeriod",Keys.OemPeriod},{"Oemcomma",Keys.Oemcomma},{"Oemplus",Keys.Oemplus},{"P",Keys
.P},{"Pa1",Keys.Pa1},{"Packet",Keys.Packet},{"PageUp",Keys.PageUp},{"Pause",Keys.Pause},{"Play",Keys.Play},{"Print",Keys.Print},{"PrintScreen",Keys.PrintScreen},{"ProcessKey",Keys.ProcessKey},{"Q",Keys.Q},{"R",Keys.R},{"RButton",Keys.RButton},{"RControlKey",Keys.RControlKey},{"RMenu",Keys.RMenu},{"RShiftKey",Keys.RShiftKey},{"RWin",Keys.RWin},{"Right",Keys.Right},{"S",Keys.S},{"Scroll",Keys.Scroll},{"Select",Keys.Select},{"SelectMedia",Keys.SelectMedia},{"Separator",Keys.Separator},{"Shift",Keys.Shift},{"ShiftKey",Keys.ShiftKey},{"Sleep",Keys.Sleep},{"Space",Keys.Space},{"Subtract",Keys.Subtract},{"T",Keys.T},{"Tab",Keys.Tab},{"U",Keys.U},{"Up",Keys.Up},{"V",Keys.V},{"VolumeDown",Keys.VolumeDown},{"VolumeMute",Keys.VolumeMute},{"VolumeUp",Keys.VolumeUp},{"W",Keys.W},{"X",Keys.X},{"XButton1",Keys.XButton1},{"XButton2",Keys.XButton2},{"Y",Keys.Y},{"Z",Keys.Z},{"Zoom",Keys.Zoom},};
    }
}
