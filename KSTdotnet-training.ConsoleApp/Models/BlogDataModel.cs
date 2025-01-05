using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int BlogID { get; set;}
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public bool DeleteFlag { get; set; }
        
    }

    [Table("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        [Column("BlogID")]
        public int BlogID { get; set; }

        [Column("BlogTitle")]
        public string BlogTitle { get; set; }

        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; }

        [Column("BlogContent")]
        public string BlogContent { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }

    }
}
