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
    /// Mapping for purchase
    /// </summary>
    public class PurchaseMap: EntityTypeConfiguration<Purchase>
    {
        public PurchaseMap()
        {
            ToTable("Purchase");

            HasKey(t => t.Id);

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.PurchaseGroupId).IsRequired().HasColumnName("PurchaseGroupId");            
            Property(t => t.PurchaseDate).IsRequired().HasColumnName("PurchaseDate");
            Property(t => t.PurchaseProductCount).IsRequired().HasColumnName("PurchaseProductCount");
            Property(t => t.CustomerFirstName).IsRequired().HasColumnName("CustomerFirstName");
            Property(t => t.CustomerLastName).IsRequired().HasColumnName("CustomerLastName");
            Property(t => t.CustomerEmail).IsRequired().HasColumnName("CustomerEmail");
            Property(t => t.CustomerPhone).IsRequired().HasColumnName("CustomerPhone");
            Property(t => t.ProductId).IsRequired().HasColumnName("PurchaseProductId");
            HasRequired(t => t.Product).WithMany().HasForeignKey(t => t.ProductId);

            //
            //Property(t => t.CustomerContact).IsOptional().HasColumnName("CustomerContact");
            //Property(t => t.CustomerId).IsOptional().HasColumnName("CustomerId");
        }
    }
}
