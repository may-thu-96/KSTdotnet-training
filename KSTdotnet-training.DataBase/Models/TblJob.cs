using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblJob
{
    public string JobId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;
}
