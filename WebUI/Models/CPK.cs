using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    public class CPK {
        /// <summary>
        /// 规格上限
        /// </summary>
        /// <value>The usl.</value>
        public float USL { get; set; }

        /// <summary>
        ///规格下限
        /// </summary>
        /// <value>The LSL.</value>
        public float LSL { get; set; }

        /// <summary>
        /// 平均值
        /// </summary>
        /// <value>The average.</value>
        public float Average { get; set; }

        /// <summary>
        /// 标准差
        /// </summary>
        /// <value>The sigma.</value>
        public float Sigma { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        /// <value>The spec value.</value>
        public float SpecValue { get; set; }

        /// <summary>
        ///数据个数
        /// </summary>
        /// <value>The times.</value>
        public float Times {
            get {
                return Math.Abs(USL - LSL);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CPK"/> class.
        /// </summary>
        /// <param name="specValue">当前值</param>
        /// <param name="usl">设定最大值</param>
        /// <param name="lsl">设定最小值</param>
        /// <param name="average">平均值</param>
        /// <param name="sigma">标准差</param>
        public CPK(float specValue,float usl,float lsl,float average,float sigma) {
            USL = usl;
            LSL = lsl;
            Average = average;
            Sigma = sigma;
            SpecValue = specValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CPK"/> class.
        /// </summary>
        /// <param name="usl">设定最大值</param>
        /// <param name="lsl">设定最小值</param>
        /// <param name="specIndex">待计算的值得序号，默认最后一个值</param>
        /// <param name="arr">待对比的数组</param>
        public CPK(float usl,float lsl,int specIndex = -1,params float[] arr) {
            Sigma = MathExt.CalcSigma(arr);
            USL = usl;
            LSL = lsl;
            Average = MathExt.CalcAvg(arr);
            if(specIndex >= 0 && specIndex < arr.Length) {
                SpecValue = arr[specIndex];
            } else {
                SpecValue = arr.LastOrDefault();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CPK"/> class.
        /// </summary>
        /// <param name="usl">设定最大值</param>
        /// <param name="lsl">设定最小值</param>
        /// <param name="list">待对比的列表</param>
        /// <param name="specIndex">待计算的值得序号，默认最后一个值</param>
        public CPK(float usl,float lsl,List<float> list,int specIndex = -1) {
            Sigma = MathExt.CalcSigma(list);
            Debug.WriteLine("-------------------Sigma-----------------------");
            Debug.WriteLine(Sigma);
            // USL = usl;
            // LSL = lsl;
            USL = MathExt.CalcMax(list);
            lsl = MathExt.CalcMin(list);
            Average = MathExt.CalcAvg(list);
            if(specIndex > 0 && specIndex < list.Count) {
                SpecValue = list[specIndex];
            } else {
                SpecValue = list.LastOrDefault();
            }
        }

        public float getCPK() {
            float cpk = 0.0f;
            var cp = getCP();
            cpk = cp - Math.Abs(SpecValue - Average) / (3 * Sigma);
            return Math.Abs(cpk);
        }

        public float getCP() {
            float cp = 0.0f;
            cp = Times / (6 * Sigma);
            return cp;
        }


    }

    public static class MathExt {
        public static float CalcSigma(params float[] arr) {
            float sigma = 0f;
            float arrSum = 0f;
            float squareSum = 0f;
            float avg = 0f;
            foreach(var item in arr) {
                arrSum += item;
            }
            avg = arrSum / arr.Length;
            foreach(var item in arr) {
                squareSum += (float)Math.Pow((item - avg),2);
            }
            sigma = Convert.ToSingle(Math.Sqrt((squareSum) / (arr.Length)).ToString());
            return sigma;
        }

        public static float CalcSigma(List<float> arr) {
            return CalcSigma(arr.ToArray());
        }

        public static float CalcAvg(params float[] arr) {
            float avg = 0f;
            float sum = 0f;
            foreach(var item in arr) {
                sum += item;
            }
            avg = sum / arr.Length;
            return avg;
        }
        public static float CalcAvg(List<float> arr) {
            return CalcAvg(arr.ToArray());
        }

        public static float CalcMax(params float[] arr) {
            float max = float.MinValue;
            foreach(var item in arr) {
                if(item > max) {
                    max = item;
                }
            }
            return max;
        }

        public static float CalcMax(List<float> list) {
            return CalcMax(list.ToArray());
        }

        public static float CalcMin(params float[] arr) {
            float min = float.MaxValue;
            foreach(var item in arr) {
                if(item < min) {
                    min = item;
                }
            }
            return min;
        }

        public static float CalcMin(List<float> list) {
            return CalcMin(list.ToArray());
        }

    }
}