using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace radarsystem
{
    public class FeatureModel
    {
        /**
         * 特性分析处理类，这里面添加特性处理的代码
         * param: list 是运行轨迹的一些点； count 是特性的个数
         * */
        public Dictionary<String, double> getTimeAndSpaceFeature(List<PointD> list,int count)
        {
            Dictionary<String, double> featDic = new Dictionary<String, double>();
            //计算时域空域特征分析
            double[] features = new double[count];

            PointD[] p1 = new PointD[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                p1[i] = list[i];
            }


            double[] pX = new double[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                pX[i] = p1[i].X;
            }
            //算术平均值,arithmetic mean value
            for (int i = 0; i < list.Count; i++)
            {
                features[0] += p1[i].X;
            }
            features[0] /= list.Count;
            featDic.Add("算术平均值", features[0]);

            //几何平均值,geometric mean
            features[1] = 1.0;
            for (int i = 0; i < list.Count; i++)
            {
                if (p1[i].X != 0)
                    features[1] *= p1[i].X;

            }
            features[1] = Math.Pow(features[1], 1 / list.Count);
            featDic.Add("几何平均值", features[1]);


            //均方根值,root mean square value
            for (int i = 0; i < list.Count; i++)
            {
                features[2] += Math.Pow(p1[i].X, 2);
            }
            features[2] /= list.Count;
            features[2] = Math.Pow(features[2], 1 / 2);
            featDic.Add("均方根值", features[2]);

            //方差, variance
            for (int i = 0; i < list.Count; i++)
            {
                features[3] += Math.Pow(p1[i].X - features[0], 2);
            }
            features[3] /= list.Count - 1;
            featDic.Add("方差", features[3]);

            //标准差,standard deviation
            for (int i = 0; i < list.Count; i++)
            {
                features[4] += Math.Pow(p1[i].X - features[0], 2);
            }
            features[4] /= list.Count;
            features[4] = Math.Pow(features[4], 1 / 2);
            featDic.Add("标准差", features[4]);

            //波形指标,waveform indicators
            features[5] = featDic["均方根值"] / Math.Abs(featDic["算术平均值"]);
            featDic.Add("波形指标", features[5]);

            //峰值指标,peak index
            features[6] = pX.Max() / featDic["均方根值"];
            featDic["峰值指标"] = features[6];

            //脉冲指标,pulse factor
            features[7] = pX.Max() / Math.Abs(featDic["算术平均值"]);
            featDic["脉冲指标"] = features[7];

            //方根幅值,root amplitude
            for (int i = 0; i < list.Count; i++)
            {
                features[8] += Math.Pow(Math.Abs(p1[i].X), 1 / 2);
            }
            features[8] = Math.Pow(features[8] / list.Count, 2);
            featDic["方根幅值"] = features[8];

            //裕度指标,margin indicator
            features[9] = pX.Max() / featDic["方根幅值"];
            featDic["裕度指标"] = features[9];

            //峭度指标,Kurosis amplitude
            for (int i = 0; i < list.Count; i++)
            {
                features[10] += Math.Pow(p1[i].X, 4);
            }
            features[10] /= list.Count;
            features[10] = features[10] / Math.Pow(featDic["均方根值"], 4);
            featDic["峭度指标"] = features[10];

            //自相关函数,m=2,autocorrelation
            for (int i = 0; i < (list.Count - 2); i++)
            {
                features[11] += p1[i].X * p1[i + 2].X;
            }
            featDic["自相关函数"] = features[11];

            //互相关函数,cross-correlation
            for (int i = 0; i < (list.Count - 2); i++)
            {
                features[12] += p1[i].X * p1[i + 2].Y;
            }
            featDic["互相关函数"] = features[12];

            return featDic;
        }


        /**
         * 计算频域特性
         **/
        public Dictionary<String, Double> getFrequentFeature(List<PointD> list)
        {
            Dictionary<String, Double> frequencyFeature = new Dictionary<string, double>();

            return frequencyFeature;
        }
       
    }
}
