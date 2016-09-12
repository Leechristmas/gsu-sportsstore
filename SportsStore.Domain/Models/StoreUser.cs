using SportsStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Models
{
    /// <summary>
    /// Registered user
    /// </summary>
    public class StoreUser: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string UserRegisterDate { get; set; }
    }
}
