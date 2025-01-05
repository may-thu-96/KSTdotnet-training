using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp.Models
{
    public class BlogDataModel
    {
        public int BlogID { get; set;}
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public bool DeleteFlag { get; set; }
        
    }
}
