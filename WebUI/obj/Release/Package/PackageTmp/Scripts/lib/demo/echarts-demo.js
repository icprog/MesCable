$(function () {
    try {
        var lineChart = echarts.init(document.getElementById("echarts-line-chart"));
        var lineoption = {
            title: {
                text: '规格 GG-1'
            },
            tooltip: {
                trigger: 'axis'
            },

            grid: {
                x: 40,
                x2: 40,
                y2: 24
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: false,
                    data: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月']
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    axisLabel: {
                        formatter: '￥{value}'
                    }
                }
            ],
            series: [

                {
                    name: "价格",
                    type: 'line',
                    data: [1959, 2015, 3598, 7456, 1025, 3359, 4567, 1234, 4567, 1244, 1456, 1645],
                }
            ]
        };
        lineChart.setOption(lineoption);
        $(window).resize(lineChart.resize);

        //var barChart = echarts.init(document.getElementById("echarts-bar-chart"));
        //var baroption = {
        //    title: {
        //        text: '任务达成量'
        //    },
        //    tooltip: {
        //        trigger: 'axis'
        //    },
        //    legend: {
        //        data: ['总任务量', '当前达成量']
        //    },
        //    grid: {
        //        x: 30,
        //        x2: 40,
        //        y2: 24
        //    },
        //    calculable: true,
        //    xAxis: [
        //        {
        //            type: 'category',
        //            data: ['工单1', '工单2', '工单3', '工单4']
        //        }
        //    ],
        //    yAxis: [
        //        {
        //            type: 'value',
        //            axisLabel: {
        //                formatter: '{value}个'
        //            }
        //        }
        //    ],
        //    series: [
        //        {
        //            name: '总任务量',
        //            type: 'bar',
        //            data: [7, 12, 8, 9],

        //        },
        //        {
        //            name: '当前达成量',
        //            type: 'bar',
        //            data: [7, 9, 6, 9],

        //        }
        //    ]
        //};
        //barChart.setOption(baroption);
        //window.onresize = barChart.resize;

        var effBar = echarts.init(document.getElementById("echart-eff-bar"));
        var effOPtion = {
            title: {
                text: '规格 GG-1'
            },
            tooltip: {
                trigger: 'axis'
            },

            grid: {
                x: 30,
                x2: 40,
                y2: 24
            },

            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    data: ['机台1', '机台2', '机台3', '机台4']
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    axisLabel: {
                        formatter: '{value}'
                    }
                }
            ],
            series: [

                {
                    name: '效率',
                    type: 'bar',
                    data: [7, 9, 6, 9],
                    itemStyle: {
                        normal: { color: '#4e72b8' }

                    },
                    barWidth: 60
                }
            ]
        };

        effBar.setOption(effOPtion);
        window.onresize = effBar.resize;

    } catch (e) {

    }



});

function echartsMahineDemo() {


    var tempChart = echarts.init(document.getElementById("echarts_line_temp"));
    var lineoption = {
        title: {
            text: '实时温度'
        },
        tooltip: {
            trigger: 'axis'
        },

        grid: {
            x: 40,
            x2: 40,
            y2: 24
        },
        toolbox: {
            show: true,
            feature: {
                mark: { show: true },
                dataView: { show: true, readOnly: false },
                magicType: { show: true, type: ['line', 'bar'] },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                boundaryGap: false,
                data: ['12:00:00', '12:00:02', '12:00:04', '12:00:06', '12:00:08', '12:00:10', '12:00:12', '12:00:14', '12:00:16', '12:00:18', '12:00:20', '12:00:22']
            }
        ],
        yAxis: [
            {
                type: 'value',
                axisLabel: {
                    formatter: '{value}℃'
                }
            }
        ],
        series: [

            {
                name: "温度",
                type: 'line',
                data: [120, 125, 127, 123, 115, 128, 125, 50, 119, 134, 138, 136],
                markLine: {
                    data: [
                       { type: 'max', name: '最大值' },
                       { type: 'min', name: '最小值' }
                    ]

                }
            }

        ]
    };
    tempChart.setOption(lineoption);
    $(window).resize(tempChart.resize);
}
