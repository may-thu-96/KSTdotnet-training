using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblGeoFencing
{
    public string GeoFencingId { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double Radius { get; set; }
}
