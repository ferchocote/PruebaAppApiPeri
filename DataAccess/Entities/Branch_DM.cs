using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Branch_DM
{
    public Guid ID { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public Guid Currency { get; set; }

    public bool State { get; set; }

    public virtual Currency_DM CurrencyNavigation { get; set; } = null!;
}
