using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using YAXLib;

namespace YAXLibTests.SampleClasses
{
    public class LargeDoc
    {
        #region Public Properties

        [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement, EachElementName = "ChartData")]
        public ObservableCollection<LargeDocChart> Charts { get; set; } = new ObservableCollection<LargeDocChart>();

        #endregion Public Properties

        #region Public Methods

        public void InitialiseDummyData()
        {
            Random random = new Random();
            for (int i = 0; i < 500; i++)
            {
                var chart = new LargeDocChart() { Name = string.Format("Chart{0}", i) };

                foreach (var series in chart.AllSeries)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        series.Values.Add(random.Next(-500, 500));
                        series.ComparisonValues.Add(random.Next(0, 10000));
                    }
                }
                Charts.Add(chart);
            }
        }

        #endregion Public Methods

    }

    public class LargeDocChart
    {
        #region Public Properties

        [YAXDontSerialize]
        public IEnumerable<LargeDocChartSeries> AllSeries
        {
            get
            {
                return new[] { Series1, Series2, Series3, Series4 };
            }
        }


        public string Name { get; set; }

        public LargeDocChartSeries Series1 { get; set; } = new LargeDocChartSeries();

        public LargeDocChartSeries Series2 { get; set; } = new LargeDocChartSeries();

        public LargeDocChartSeries Series3 { get; set; } = new LargeDocChartSeries();

        public LargeDocChartSeries Series4 { get; set; } = new LargeDocChartSeries();

        #endregion Public Properties

    }

    public class LargeDocChartSeries
    {
        #region Public Properties

        [YAXCollection(YAXCollectionSerializationTypes.Serially, SeparateBy = ",")]
        public ObservableCollection<int> ComparisonValues { get; set; } = new ObservableCollection<int>();


        [YAXCollection(YAXCollectionSerializationTypes.Serially, SeparateBy = ",")]
        public ObservableCollection<int> Values { get; set; } = new ObservableCollection<int>();

        #endregion Public Properties
    }
}