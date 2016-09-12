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
    /// Mapping for products
    /// </summary>
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(t => t.Id);

            this.Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ProductName).IsRequired().HasColumnName("ProductName");
            Property(t => t.Price).IsOptional().HasColumnName("Price");
            Property(t => t.Details).IsOptional().HasColumnName("ProductDetails");
            Property(t => t.ImageMimeType).IsOptional().HasColumnName("ImageMimeType");
            Property(t => t.ImageData).IsOptional().HasColumnName("ProductImageData");

            Property(t => t.CategoryId).IsOptional().HasColumnName("ProductCategoryId");
            HasOptional(t => t.Category).WithMany().HasForeignKey(t => t.CategoryId);


            //TODO: properties



        }
    }
}
