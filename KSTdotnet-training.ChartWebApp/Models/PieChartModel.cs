namespace KSTdotnet_training.ChartWebApp.Models
{
    public class PieChartModel
    {
        //public string name { get; set; }
        //public Boolean colorByPoint { get; set; }
        public List<SeriesDataForPieChart> data { get; set; }
    }
    public class SeriesDataForPieChart
    {
        public string name { get; set; }
        public double y { get; set; }
    }
}
