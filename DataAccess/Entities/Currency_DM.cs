using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Currency_DM
{
    public Guid ID { get; set; }

    public string Description { get; set; } = null!;

    public string code { get; set; } = null!;

    public bool State { get; set; }

    public virtual ICollection<Branch_DM> Branch_DM { get; } = new List<Branch_DM>();
}
