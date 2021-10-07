using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsTableControl;

namespace LZLTetris.ConventionShape
{
    /// <summary>O字型常规形状
    /// 
    /// </summary>
    public class TetrisItme_O : TetrisItmeBase
    {
        /// <summary>当前形状，因为当前对象只有一个形态所以只有一个模型【4*4】
        /// 
        /// </summary>
        private readonly static TableIndex[] Model = {
            new TableIndex(0,1),
            new TableIndex(0,2),
            new TableIndex(1,1),
            new TableIndex(1,2)
        };
        /// <summary>缩略图集合
        /// 【专门用于解决缩略图显示问题【如果要进行添加请用Model属性】因为这个属性考虑美观，Model考虑实用】
        /// </summary>
        public readonly static TableIndex[] BreviaryList = new TableIndex[]{
            new TableIndex(1,1),
            new TableIndex(1,2),
            new TableIndex(2,1),
            new TableIndex(2,2)
        };
        /// <summary>可供设置的当前形状显示的颜色
        /// 
        /// </summary>
        public static Color FixedShowColor = Color.FromArgb(255, 0, 128);
        /// <summary>私有构造函数【用于赋值】
        /// 
        /// </summary>
        private TetrisItme_O()
        {
            //设置当前俄罗斯方块的形态数量为1
            base._formCount = 1;
            ////设置当前形状的Guid值
            //base._id = new Guid("2CF03B09-DF24-4CAD-A52C-C44A6AE33E56");
            //设置当前形状显示的颜色【160, 190, 55】
            base._showColor = TetrisItme_O.FixedShowColor;
        }
        /// <summary>创建该形状并赋值
        /// 
        /// </summary>
        /// <param name="containerTable">容器表格控件</param>
        /// <param name="upIndex">将该对象创建的最第一行的中心点位置【合作模式的话，就是当前玩家所分配的范围中的中心点】</param>
        public TetrisItme_O(Table containerTable, int upIndex)
            : this()
        {
            //设置输入形态值，因为当前对象只有一个形态所以默认为0
            base._form = 0;
            //设置显示的表格容器
            base._containerTable = containerTable;
            //将索引--【因为他要和这个4*4表格中的列索引相加，0，1的位置就代表那个容器表的中心位置，所以要减一】
            upIndex--;
            //设置显示在容器中的位置【计算相对坐标】【将索引位置加入列行】并存储到对象中
            base._tetrisItmeTable = new TableIndex[]{
                new TableIndex(0,1 + upIndex),
                new TableIndex(0,2 + upIndex),
                new TableIndex(1,1 + upIndex),
                new TableIndex(1,2 + upIndex)
            };
            //设置缩略图的位置
            base._breviary = TetrisItme_O.BreviaryList;
        }
        /// <summary>旋转方法【但是当前形状没有旋转的概念，所以每次调用此方法都将返回false，代表旋转失败】
        /// 
        /// </summary>
        /// <returns>每次都会返回false，代表旋转失败</returns>
        public override bool Spin()
        {
            //表示旋转失败，因为当前形状无法旋转
            return false;
        }
    }
}
