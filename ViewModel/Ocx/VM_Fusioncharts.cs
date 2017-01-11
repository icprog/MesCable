using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Ocx {
    public class VM_Fusioncharts_Line {
        private FusionChart _chart;

        public FusionChart chart {
            get { return _chart; }
            set { _chart = value; }
        }

        private List<FusionData> _data = new List<FusionData>();

        public List<FusionData> data {
            get { return _data; }
            set { _data = value; }
        }
        private List<FusionTrendLine> _trendlines = new List<FusionTrendLine>();

        public List<FusionTrendLine> trendlines {
            get { return _trendlines; }
            set { _trendlines = value; }
        }

        public int paramCodeId { get; set; }

    }
    public class FusionChart {
        public string xAxisSymbol { get; set; }
        public string xAxisName { get; set; }
        public string yAxisName { get; set; }
        public string numberSuffix { get; set; }

        public string caption { get; set; }
        public string subcaption { get; set; }
        private string _plottooltext = "$seriesname,$label,$value";

        public string plottooltext {
            get { return _plottooltext; }
            set { _plottooltext = value; }
        }
        //private string _theme = "fint";

        //public string theme {
        //    get { return _theme = "fint"; }
        //    set { _theme = "fint" = value; }
        //}


    }

    public class FusionData {
        public string value { get; set; }
        public string label { get; set; }
    }

    public class FusionTrendLine {
        private List<FusionLine> _line = new List<FusionLine>();

        public List<FusionLine> line {
            get { return _line; }
            set { _line = value; }
        }

    }

    public class FusionLine {
        public string startvalue { get; set; }
        public string displayvalue { get; set; }

        public int _valueOnRight = 1;
        /// <summary>
        /// 设置显示值位置，0：左边,1：右边，默认右边，
        /// </summary>
        /// <value>The value on right.</value>
        public int valueOnRight { get { return _valueOnRight; } set { _valueOnRight = value; } }
        private string _color = "#ff0000";

        public string color {
            get { return _color; }
            set { _color = value; }
        }


    }

    public class VM_Fusioncharts_MSLine {
        private FusionChart _chart = new FusionChart();

        public FusionChart chart {
            get { return _chart; }
            set { _chart = value; }
        }

        private List<FusionMSCategories> _categories = new List<FusionMSCategories>();

        public List<FusionMSCategories> categories {
            get { return _categories; }
            set { _categories = value; }
        }

        private List<FusionMSDataset> _dataset = new List<FusionMSDataset>();

        public List<FusionMSDataset> dataset {
            get { return _dataset; }
            set { _dataset = value; }
        }

        private List<FusionTrendLine> _trendlines = new List<FusionTrendLine>();

        public List<FusionTrendLine> trendlines {
            get { return _trendlines; }
            set { _trendlines = value; }
        }

        //private FusionColorrange _colorrange;

        //public FusionColorrange colorrange {
        //    get { return _colorrange; }
        //    set { _colorrange = value; }
        //}


    }


    public class FusionColorrange {
        private List<FusionColor> _color = new List<FusionColor>();

        public List<FusionColor> color {
            get { return _color; }
            set { _color = value; }
        }
    }

    public class FusionColor {
        public string maxvalue { get; set; }
        public string minValue { get; set; }
    }

    public class FusionMSCategories {
        private List<FusionMSCategorie> _category = new List<FusionMSCategorie>();

        public List<FusionMSCategorie> category {
            get { return _category; }
            set { _category = value; }
        }

    }

    public class FusionMSCategorie {
        public string label { get; set; }
    }

    public class FusionMSDataset {
        public string seriesname { get; set; }
        private List<MSlineValue> _data = new List<MSlineValue>();

        public List<MSlineValue> data {
            get { return _data; }
            set { _data = value; }
        }


    }

    public class MSlineValue {
        public string value { get; set; }
    }

}

