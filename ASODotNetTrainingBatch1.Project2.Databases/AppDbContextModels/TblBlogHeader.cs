using System;
using System.Collections.Generic;

namespace ASODotNetTrainingBatch1.Project2.Databases.AppDbContextModels;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    // Optional: Navigation property
    public virtual ICollection<TblBlogDetail> TblBlogDetails { get; set; } = new List<TblBlogDetail>();
}
