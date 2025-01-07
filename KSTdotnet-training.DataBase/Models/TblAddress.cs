using System;
using System.Collections.Generic;

namespace KSTdotnet_training.DataBase.Models;

public partial class TblAddress
{
    public string AddressId { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
