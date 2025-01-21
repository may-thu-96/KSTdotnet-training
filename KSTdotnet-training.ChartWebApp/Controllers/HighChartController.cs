using KSTdotnet_training.ChartWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace KSTdotnet_training.ChartWebApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult PieChart()
        {
            var model = new PieChartModel
            {
                //name = "Percentage",
                //colorByPoint = true,
                data = new List<SeriesDataForPieChart>
                {
                new SeriesDataForPieChart { name= "Water",  y= 55.02 },
                  new SeriesDataForPieChart { name= "Fats",  y= 26.71 },
                     new SeriesDataForPieChart { name= "Carbohydrates",  y= 1.09 },
                        new SeriesDataForPieChart { name= "Protein",  y= 15.5 },
                         new SeriesDataForPieChart { name= "Ash",  y=1.68 },
            }
               
            };
            return View(model);
        }

        public IActionResult WeatherChart()
        {
            var model = new WeatherChartModel
            {
                Categories = new List<string>
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            },
                Rainfall = new List<double> { 49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 },
                SeaLevelPressure = new List<double> { 1016, 1016, 1015.9, 1015.5, 1012.3, 1009.5, 1009.6, 1010.2, 1013.1, 1016.9, 1018.2, 1016.7 },
                Temperature = new List<double> { 7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6 }
            };

            return View(model);
        }
    }
}
