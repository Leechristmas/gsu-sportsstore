using SportsStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Models
{
    /// <summary>
    /// user's order
    /// </summary>
    public class Purchase: Entity
    {
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        /// <summary>
        /// the common id for all purchases in an one group
        /// </summary>
        public int PurchaseGroupId { get; set; }

        /// <summary>
        /// information about not registered user's order
        /// </summary>
        //public string CustomerContact { get; set; }

        /// <summary>
        /// id of the registered user's order
        /// </summary>
        //public int? CustomerId { get; set; }

        //public StoreUser Customer { get; set; }

        /// <summary>
        /// Id of the bought product
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// The bought product
        /// </summary>
        public Product Product { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int PurchaseProductCount { get; set; }
    }
}
