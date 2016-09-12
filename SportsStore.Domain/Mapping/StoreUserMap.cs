using SportsStore.Domain.Common;
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
    /// Mapping for store user
    /// </summary>
    public class StoreUserMap: EntityTypeConfiguration<StoreUser>
    {
        public StoreUserMap()
        {
            ToTable("StoreUser");

            HasKey(t => t.Id);

            Property(t => t.FirstName).IsRequired().HasColumnName("UserFirstName");
            Property(t => t.LastName).IsRequired().HasColumnName("UserLastName");
            Property(t => t.EmailAddress).IsRequired().HasColumnName("UserEmailAddress");
            Property(t => t.MobileNumber).IsRequired().HasColumnName("UserMobileNumber");
            Property(t => t.UserRegisterDate).IsRequired().HasColumnName("UserRegisterDate");
        }


    }
}
