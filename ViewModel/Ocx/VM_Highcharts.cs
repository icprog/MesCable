using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Ocx {
    public class VM_Highcharts {
        private List<SeriesData> _seriesData = new List<SeriesData>();
        public List<SeriesData> seriesData {
            get {
                return _seriesData;
            }
            set {
                _seriesData = value;
            }
        }
        public string title { get; set; }
        public string subTitle { get; set; }
        public string yAxisUnitName { get; set; }
        public string xAxisUnitName { get; set; }
        public string yAxisUnitSymbol { get; set; }
        public string xAxisUnitSymbol { get; set; }
        public double maxValue { get; set; }
        public double minValue { get; set; }
        private string _maxThresholdLabel = "最大值";



        public string maxLabel {
            get { return _maxThresholdLabel; }
            set { _maxThresholdLabel = value; }
        }

        private string _minThresholdLabel = "最小值";

        public string minLabel {
            get { return _minThresholdLabel; }
            set { _minThresholdLabel = value; }
        }

    }

    /// <exclude />
    public class SeriesData {
        public double x { get; set; }
        public double y { get; set; }
    }

    /// <summary>
    /// Highcharts基本属性
    /// </summary>
    public class VM_Highcharts_Property {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Symbol { get; set; }
        public int ParamCodeId { get; set; }
        public bool IsCPK { get; set; }
        public bool CanDrawChart { get; set; }
        public int? drawType { get; set; }
    }

  
}
