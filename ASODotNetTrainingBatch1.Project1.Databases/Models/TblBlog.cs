﻿using System;
using System.Collections.Generic;

namespace ASODotNetTrainingBatch1.Project1.Databases.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;
}
