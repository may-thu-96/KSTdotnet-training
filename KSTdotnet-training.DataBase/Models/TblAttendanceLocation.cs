using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblAttendanceLocation
{
    public string AttendanceLocationId { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime UserTime { get; set; }
}
