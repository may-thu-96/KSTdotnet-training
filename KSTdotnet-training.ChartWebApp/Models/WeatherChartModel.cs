namespace KSTdotnet_training.ChartWebApp.Models
{
    public class WeatherChartModel
    {
        public List<string> Categories { get; set; }
        public List<double> Rainfall { get; set; }
        public List<double> SeaLevelPressure { get; set; }
        public List<double> Temperature { get; set; }
    }
}
