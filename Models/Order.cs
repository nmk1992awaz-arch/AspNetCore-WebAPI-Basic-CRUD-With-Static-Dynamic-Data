using System;
using System.Collections.Generic;

namespace Basic_CURD_Operation.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public DateTime OrderDate { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public string? OrderStatus { get; set; }
}
