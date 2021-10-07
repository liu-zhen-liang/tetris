using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace LZLTetris.Static
{
    /// <summary>执行各种音效的静态对象
    /// 执行各种背景音乐，比如消除音效【如果设置中取消可以直接在方法中取消，方便】等各种音效！
    /// </summary>
    public static class Music
    {
        /// <summary>播放声音的对象
        /// 
        /// </summary>
        private static SoundPlayer _soundPlayer = new SoundPlayer();
        /// <summary>触发开始的音效
        /// 
        /// </summary>
        public static void BeginMusic()
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                //设置播放的音效流
                Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.BeginMusic;
                //开启新线程播放音效
                Music._soundPlayer.Play();
            }
        }
        /// <summary>触发暂停的音效
        /// 
        /// </summary>
        public static void StopMusic()
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                //设置播放的音效流
                Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.StopMusic;
                //开启新线程播放音效
                Music._soundPlayer.Play();
            }
        }
        /// <summary>触发旋转的音效
        /// 
        /// </summary>
        public static void SpinMusic()
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                
            }
        }
        /// <summary>触发落地的音效
        /// 
        /// </summary>
        public static void BeBornMusic()
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                //设置播放的音效流
                Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.BeBornMusic;
                //开启新线程播放音效
                Music._soundPlayer.Play();
            }
        }
        /// <summary>触发消除音效
        /// 
        /// </summary>
        public static void EliminateMusic()
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                //设置播放的音效流
                Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.EliminateMusic;
                //开启新线程播放音效
                Music._soundPlayer.Play();
            }
        }
        /// <summary>触发结束音效
        /// 
        /// </summary>
        /// <param name="musicName">播放的结束音效名称</param>
        public static void EndMusic(string musicName)
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {
                //判断是触发什么音效
                switch (musicName)
                {
                    case "胜利音效":
                        //设置播放的音效流
                        Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.WinMusic;
                        //开启新线程播放音效
                        Music._soundPlayer.Play();
                        break;
                    case "输的音效":
                        //设置播放的音效流
                        Music._soundPlayer.Stream = global::LZLTetris.Properties.Resources.LoseMusic;
                        //开启新线程播放音效
                        Music._soundPlayer.Play();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>触发过关音效
        /// 
        /// </summary>
        /// <param name="musicName">触发的过关音效名称</param>
        public static void PassABarrierMusic(string musicName)
        {
            //判断是否开启音效
            if (Data.IsMusic)
            {

            }
        }
    }
}
