using KSTdotnet_training.ChartWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KSTdotnet_training.ChartWebApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartModel model = new ApexChartPieChartModel();

            model.Series = new int[] { 44, 55, 13, 43, 22 };

            model.Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };
            return View(model);
        }

        public IActionResult MixedChart()
        {
            ApexChartMixedChartModel model = new ApexChartMixedChartModel
            {
                Series = new List<SeriesData>
                    {
                        new SeriesData
                        {
                            Name = "Website Blog",
                            Type = "column",
                            Data = new int[] { 440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160 }
                        },
                        new SeriesData
                        {
                            Name = "Social Media",
                            Type = "line",
                            Data = new int[] { 23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16 }
                        }
                    },
                Labels = new string[]
                {
                        "01 Jan 2001", "02 Jan 2001", "03 Jan 2001", "04 Jan 2001", "05 Jan 2001",
                        "06 Jan 2001", "07 Jan 2001", "08 Jan 2001", "09 Jan 2001", "10 Jan 2001",
                        "11 Jan 2001", "12 Jan 2001"
                }
            };

            return View(model);
        }

        public IActionResult BarChart()
        {
            var model = new ApexChartBarChartModel
            {
                Series = new List<SeriesDataForBarChart>
            {
                new SeriesDataForBarChart { Name = "Net Profit", Data = new int[] { 44, 55, 57, 56, 61, 58, 63, 60, 66 } },
                new SeriesDataForBarChart { Name = "Revenue", Data = new int[] { 76, 85, 101, 98, 87, 105, 91, 114, 94 } },
                new SeriesDataForBarChart { Name = "Free Cash Flow", Data = new int[] { 35, 41, 36, 26, 45, 48, 52, 53, 41 } }
            },
                Categories = new string[] { "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct" }
            };

            return View(model);
        }
        public IActionResult LineChart()
        {
            ApexChartLineChartModel model = new ApexChartLineChartModel
            {
                SeriesData = new int[] { 10, 41, 35, 51, 49, 62, 69, 91, 148 },
                Categories = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep" }
            };

            return View(model);
        }
    }
}

