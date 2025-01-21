namespace KSTdotnet_training.ChartWebApp.Models
{
    public class ApexChartBarChartModel
    {
        public List<SeriesDataForBarChart> Series { get; set; }
        public string[] Categories { get; set; }
    }

    public class SeriesDataForBarChart
    {
        public string Name { get; set; }
        public int[] Data { get; set; }
    }
 
}
