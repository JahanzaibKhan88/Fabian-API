using System;
using System.Collections.Generic;

namespace Fabian.Infrastructure.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string? Name { get; set; }

    public int? Sku { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Uom { get; set; }

    public DateTime? Expiry { get; set; }

    public bool? Active { get; set; }
}
