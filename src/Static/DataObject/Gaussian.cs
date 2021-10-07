using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LZLTetris.Static.DataObject
{
    #region 高斯模糊算法
    /// <summary>
    /// 高斯模糊算法
    /// </summary>
    public class Gaussian
    {
        public static double[,] Calculate1DSampleKernel(double deviation, int size)
        {
            double[,] ret = new double[size, 1];
            double sum = 0;
            int half = size / 2;
            for (int i = 0; i < size; i++)
            {
                ret[i, 0] = 1 / (Math.Sqrt(2 * Math.PI) * deviation) * Math.Exp(-(i - half) * (i - half) / (2 * deviation * deviation));
                sum += ret[i, 0];
            }
            return ret;
        }
        public static double[,] Calculate1DSampleKernel(double deviation)
        {
            int size = (int)Math.Ceiling(deviation * 3) * 2 + 1;
            return Calculate1DSampleKernel(deviation, size);
        }
        public static double[,] CalculateNormalized1DSampleKernel(double deviation)
        {
            return NormalizeMatrix(Calculate1DSampleKernel(deviation));
        }
        public static double[,] NormalizeMatrix(double[,] matrix)
        {
            double[,] ret = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double sum = 0;
            for (int i = 0; i < ret.GetLength(0); i++)
            {
                for (int j = 0; j < ret.GetLength(1); j++)
                    sum += matrix[i, j];
            }
            if (sum != 0)
            {
                for (int i = 0; i < ret.GetLength(0); i++)
                {
                    for (int j = 0; j < ret.GetLength(1); j++)
                        ret[i, j] = matrix[i, j] / sum;
                }
            }
            return ret;
        }
        public static double[,] GaussianConvolution(double[,] matrix, double deviation)
        {
            double[,] kernel = CalculateNormalized1DSampleKernel(deviation);
            double[,] res1 = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[,] res2 = new double[matrix.GetLength(0), matrix.GetLength(1)];
            //x-direction
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    res1[i, j] = processPoint(matrix, i, j, kernel, 0);
            }
            //y-direction
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    res2[i, j] = processPoint(res1, i, j, kernel, 1);
            }
            return res2;
        }
        private static double processPoint(double[,] matrix, int x, int y, double[,] kernel, int direction)
        {
            double res = 0;
            int half = kernel.GetLength(0) / 2;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                int cox = direction == 0 ? x + i - half : x;
                int coy = direction == 1 ? y + i - half : y;
                if (cox >= 0 && cox < matrix.GetLength(0) && coy >= 0 && coy < matrix.GetLength(1))
                {
                    res += matrix[cox, coy] * kernel[i, 0];
                }
            }
            return res;
        }
        /// <summary>
        /// 对颜色值进行灰色处理
        /// </summary>
        /// <param name="cr"></param>
        /// <returns></returns>
        private Color grayscale(Color cr)
        {
            return Color.FromArgb(cr.A, (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11),
               (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11),
              (int)(cr.R * .3 + cr.G * .59 + cr.B * 0.11));
        }
        /// <summary>
        /// 对图片进行高斯模糊
        /// </summary>
        /// <param name="d">模糊数值，数值越大模糊越很</param>
        /// <param name="image">一个需要处理的图片</param>
        /// <returns></returns>
        public static Bitmap FilterProcessImage(double d, Bitmap image)
        {
            Bitmap ret = new Bitmap(image.Width, image.Height);
            Double[,] matrixR = new Double[image.Width, image.Height];
            Double[,] matrixG = new Double[image.Width, image.Height];
            Double[,] matrixB = new Double[image.Width, image.Height];
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    //matrix[i, j] = grayscale(image.GetPixel(i, j)).R;
                    matrixR[i, j] = image.GetPixel(i, j).R;
                    matrixG[i, j] = image.GetPixel(i, j).G;
                    matrixB[i, j] = image.GetPixel(i, j).B;
                }
            }
            matrixR = Gaussian.GaussianConvolution(matrixR, d);
            matrixG = Gaussian.GaussianConvolution(matrixG, d);
            matrixB = Gaussian.GaussianConvolution(matrixB, d);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Int32 R = (int)Math.Min(255, matrixR[i, j]);
                    Int32 G = (int)Math.Min(255, matrixG[i, j]);
                    Int32 B = (int)Math.Min(255, matrixB[i, j]);
                    ret.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return ret;
        }

    }
    #endregion
}
