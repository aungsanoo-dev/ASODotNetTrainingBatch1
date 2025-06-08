using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.ConsoleApp4
{
    [Table("tbl_productcategory")]
    public class ProductCategory
    {
        [Key]
        [Column("Id")]
        public int ProductCategoryId { get; set; }

        [Column("Code")]
        public string Code { get; set; }

        [Column("Name")]
        public string Name { get; set; }

    }

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQL2022Express;Database=DotNetTrainingBatch1;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");
            }
        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }

}
