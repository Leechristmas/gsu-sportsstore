using SportsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Mapping
{
    /// <summary>
    /// Mapping for category
    /// </summary>
    public class CategoryMap: EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            //Key
            this.HasKey(t => t.Id);

            //Properties
            this.Property(t => t.Name).IsRequired().HasMaxLength(64);

            //Table & Column Mappings
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("CategoryName");
        }
    }
}
