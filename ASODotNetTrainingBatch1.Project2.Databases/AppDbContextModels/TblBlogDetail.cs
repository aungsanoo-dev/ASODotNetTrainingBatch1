using System;
using System.Collections.Generic;

namespace ASODotNetTrainingBatch1.Project2.Databases.AppDbContextModels;

public partial class TblBlogDetail
{
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;

    // Optional: Navigation property
    public virtual TblBlogHeader? BlogHeader { get; set; }
}
