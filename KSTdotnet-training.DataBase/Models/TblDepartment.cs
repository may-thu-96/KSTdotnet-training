using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblDepartment
{
    public string DepartmentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Floor { get; set; } = null!;
}
