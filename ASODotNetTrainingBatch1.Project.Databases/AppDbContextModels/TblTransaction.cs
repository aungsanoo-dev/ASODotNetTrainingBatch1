﻿using System;
using System.Collections.Generic;

namespace ASODotNetTrainingBatch1.Project.Databases.AppDbContextModels;

public partial class TblTransaction
{
    public string TransactionId { get; set; } = null!;

    public string TransactionNo { get; set; } = null!;

    public string FromMobileNo { get; set; } = null!;

    public string ToMobileNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }
}
