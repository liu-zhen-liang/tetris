using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris.TetrisShape.BossShape
{
    /// <summary>Boss的H形状。
    /// 
    /// </summary>
    public class TetrisItme_BossH : TetrisItmeBossBase
    {
        /// <summary>存储的是当前形状对象的各个形态的数组
        /// 
        /// </summary>
        private readonly static TableIndex[][] ModelList = new TableIndex[][]{
            new TableIndex[]{
				new TableIndex(0,0),
				new TableIndex(1,0),
				new TableIndex(2,0),
				new TableIndex(1,1),//中心点
				new TableIndex(0,2),
				new TableIndex(1,2),
				new TableIndex(2,2)
            },
            new TableIndex[]{
				new TableIndex(0,2),
				new TableIndex(0,1),
				new TableIndex(0,0),
				new TableIndex(1,1),//中心点
				new TableIndex(2,2),
				new TableIndex(2,1),
				new TableIndex(2,0)
            }
        };
        /// <summary>缩略图集合
        /// 【专门用于解决缩略图显示问题【如果要进行添加请用ModelList属性】因为这个属性考虑美观，ModelList考虑实用】
        /// </summary>
        public readonly static TableIndex[][] BreviaryList = new TableIndex[][]{
            new TableIndex[]{
				new TableIndex(0,0),
				new TableIndex(1,0),
				new TableIndex(2,0),
				new TableIndex(1,1),//中心点
				new TableIndex(0,2),
				new TableIndex(1,2),
				new TableIndex(2,2)
            },
            new TableIndex[]{
				new TableIndex(0,2),
				new TableIndex(0,1),
				new TableIndex(0,0),
				new TableIndex(1,1),//中心点
				new TableIndex(2,2),
				new TableIndex(2,1),
				new TableIndex(2,0)
            }
        };
        /// <summary>可供设置的当前形状显示的颜色
        /// 
        /// </summary>
        public static Color FixedShowColor = Color.Blue;
        /// <summary>可供设置的固定不动的块颜色
        /// 
        /// </summary>
        public static Color FastenColor = Color.Red;
        /// <summary>固定颜色集合【判断指定位置是固定颜色还是活动颜色】
        /// 
        /// </summary>
        public readonly static bool[] IsFixedColours = new bool[]{
            false,
            false,
            false,
            true,
            false,
            false,
            false
        };
        /// <summary>私有构造函数【用于赋值】
        /// 
        /// </summary>
        private TetrisItme_BossH()
        {
            //设置当前俄罗斯方块的形态数量
            base._formCount = TetrisItme_BossH.ModelList.Length;
            //设置当前形状显示的颜色
            base._showColor = TetrisItme_BossH.FixedShowColor;
            //固定颜色
            base._fixedColor = TetrisItme_BossH.FastenColor;
            //方块颜色是否为固定集合
            base._isFixedColorList = TetrisItme_BossH.IsFixedColours;
        }
        /// <summary>创建该形状对象并赋值
        /// 
        /// </summary>
        /// <param name="form">创建的当前形状的形态</param>
        /// <param name="containerTable">容器表格控件</param>
        /// <param name="upIndex">将该对象创建的最第一行的中心点位置【合作模式的话，就是当前玩家所分配的范围中的中心点】</param>
        public TetrisItme_BossH(int form, Table containerTable, int upIndex)
            : this()
        {
            //设置输入的形态值
            base._form = form;
            //设置显示的表格容器
            base._containerTable = containerTable;
            //将索引--【因为他要和这个4*4表格中的列索引相加，0，1的位置就代表那个容器表的中心位置，所以要减一】
            upIndex-=2;
            //得到选择的形态的所对应的形状数组位置，并创建副本
            TableIndex[] ti = TetrisItme_BossH.ModelList[form].ToArray();
            //循环更改值设置显示在容器中的位置【计算相对坐标】【将索引位置加入列行】并存储到对象中
            for (int i = 0; i < ti.Length; i++)
            {
                //更改值
                ti[i].CellIndex += upIndex;
            }
            //并设置在容器的位置
            base._tetrisItmeTable = ti;
            //设置缩略图的位置
            base._breviary = TetrisItme_BossH.BreviaryList[form];
        }
        /// <summary>旋转方法
        /// 
        /// </summary>
        /// <returns>返回true，代表旋转成功，返回false代表旋转失败</returns>
        public override bool Spin()
        {
            //创建一个当前对象的索引位置副本
            TableIndex[] ti = base._tetrisItmeTable.ToArray();
            //得到下一个形态
            //判断当前形态+1是否大于等于形态数量【索引从0开始】就赋值当前形态为0，否则就+1
            int form = base._form + 1 >= base._formCount ? 0 : base._form + 1;
            //开始更改形态【得到上一个形态与这个形态的差并加上】
            for (int i = 0; i < ti.Length; i++)
            {
                //得到形态差
                TableIndex difference = TetrisItme_BossH.ModelList[form][i] - TetrisItme_BossH.ModelList[base._form][i];
                //加上形态差
                ti[i] += difference;
            }
            //判断旋转完毕是否合法
            if (base.IsEffective(ti))
            {
                //显示设置值
                base.SetShapeNewIndex(ti);
                //设置当前形状形态为+1,如果超过形状形态维度就变为0
                base._form = base._form + 1 >= base._formCount ? 0 : base._form + 1;
                //返回true代表旋转成功
                return true;
            }
            else
            {
                //返回false代表旋转失败
                return false;
            }
        }
    }
}
