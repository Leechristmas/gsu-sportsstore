using SportsStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Models
{
    /// <summary>
    /// Product category
    /// </summary>
    public class Category: Entity
    {
        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; set; }
    }
}
