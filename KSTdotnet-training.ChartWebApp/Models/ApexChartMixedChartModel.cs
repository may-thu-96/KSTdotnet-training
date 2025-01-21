﻿namespace KSTdotnet_training.ChartWebApp.Models
{
    public class ApexChartMixedChartModel
    {
        public List<SeriesData> Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class SeriesData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int[] Data { get; set; }
    }
}
