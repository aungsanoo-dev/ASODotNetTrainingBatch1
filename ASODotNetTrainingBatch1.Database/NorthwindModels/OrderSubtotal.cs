using System;
using System.Collections.Generic;

namespace ASODotNetTrainingBatch1.Database.NorthwindModels;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
