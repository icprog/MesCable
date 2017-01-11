$(function () {
    // Define tasks
    var tasks = [{
        name: '工单 1',
        intervals: [{ // From-To pairs
            from: Date.UTC(2010, 5, 21),
            to: Date.UTC(2013, 5, 21),
            label: '工单 1'
        }]
    }, {
        name: '工单 2',
        intervals: [{ // From-To pairs
            from: Date.UTC(2010, 5, 21),
            to: Date.UTC(2010, 5, 21),
            label: '工单 2'
        }]
    }, {
        name: '工单 3',
        intervals: [{ // From-To pairs
            from: Date.UTC(2011, 05, 16),
            to: Date.UTC(2012, 03, 21),
            label: '工单 3'
        }, {
            from: Date.UTC(2013, 07, 09),
            to: Date.UTC(2015, 05, 22),
            label: '工单 3'
        }]
    }, {
        name: '工单 4',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 07, 18),
            to: Date.UTC(2015, 05, 22),
            label: '工单 4'
        }]
    }, {
        name: '工单 5',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 06, 17),
            to: Date.UTC(2014, 04, 21),
            label: '工单 5'
        }, {
            from: Date.UTC(2015, 01, 22),
            to: Date.UTC(2015, 05, 22),
            label: '工单 5'
        }]
    }, {
        name: '工单 6',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 06, 17),
            to: Date.UTC(2014, 04, 21),
            label: '工单 6'
        }, {
            from: Date.UTC(2015, 01, 22),
            to: Date.UTC(2015, 05, 22),
            label: '工单 6'
        }]
    }, {
        name: '工单 7',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 06, 17),
            to: Date.UTC(2014, 04, 21),
            label: '工单 7'
        }, {
            from: Date.UTC(2015, 01, 22),
            to: Date.UTC(2015, 05, 22),
            label: '工单 7'
        }]
    }, {
        name: '工单 8',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 06, 17),
            to: Date.UTC(2014, 04, 21),
            label: '工单 8'
        }, {
            from: Date.UTC(2015, 01, 22),
            to: Date.UTC(2015, 05, 22),
            label: '工单 8'
        }]
    }, {
        name: '工单 9',
        intervals: [{ // From-To pairs
            from: Date.UTC(2013, 06, 17),
            to: Date.UTC(2014, 04, 21),
            label: '工单 9'
        }, {
            from: Date.UTC(2015, 01, 22),
            to: Date.UTC(2015, 05, 22),
            label: '工单 9'
        }]
    }];


    // re-structure the tasks into line seriesvar series = [];
    var series = [];
    $.each(tasks.reverse(), function (i, task) {
        var item = {
            name: task.name,
            data: []
        };
        $.each(task.intervals, function (j, interval) {
            item.data.push({
                x: interval.from,
                y: i,
                label: interval.label,
                from: interval.from,
                to: interval.to
            }, {
                x: interval.to,
                y: i,
                from: interval.from,
                to: interval.to
            });

            // add a null value between intervals
            if (task.intervals[j + 1]) {
                item.data.push(
                    [(interval.to + task.intervals[j + 1].from) / 2, null]
                );
            }

        });

        series.push(item);
    });

 
    // create the chart
    var chart = new Highcharts.Chart({
        chart: {
            renderTo: 'hcs-task-complete'
        },

        title: {
            text: ''
        },

        xAxis: {
            type: 'datetime',
            title: {
                text:"时间"
            }
        },

        yAxis: {

            categories: ['工单 9',
                         '工单 8',
                         '工单 7',
                         '工单 6',
                         '工单 5',
                         '工单 4',
                         '工单 3',
                         '工单 2',
                         '工单 1'],
            tickInterval: 1,
            tickPixelInterval: 200,
            labels: {
                style: {
                    color: '#525151',
                    font: '12px Helvetica',
                    fontWeight: 'bold'
                },
            },
            startOnTick: false,
            endOnTick: false,
            title: {
                text: '工单号'
            },
            minPadding: 0.2,
            maxPadding: 0.2,
            fontSize: '15px'

        },

        legend: {
            enabled: false
        },
        tooltip: {
            formatter: function () {
                return '<b>' + tasks[this.y].name + '</b><br/>' +
                    Highcharts.dateFormat('%m-%d-%Y', this.point.options.from) +
                    ' - ' + Highcharts.dateFormat('%m-%d-%Y', this.point.options.to);
            }
        },

        plotOptions: {
            line: {
                lineWidth: 10,
                marker: {
                    enabled: true
                },
                dataLabels: {
                    enabled: true,
                    align: 'left',
                    formatter: function () {
                        return this.point.options && this.point.options.label;
                    }
                }
            }
        },

        series: series,
        scrollbar: {
         //   enabled: true
        }
    });
});