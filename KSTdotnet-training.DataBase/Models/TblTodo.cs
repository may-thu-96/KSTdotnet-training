using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblTodo
{
    public string TodoId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Status { get; set; } = null!;
}
