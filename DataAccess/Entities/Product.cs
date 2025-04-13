using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Product
{
    public Guid ID { get; set; }

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Estado { get; set; }
}
