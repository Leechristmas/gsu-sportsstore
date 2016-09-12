using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.Domain.Models;

namespace SportsStore.WebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<SelectListItem> Categories { get; set; }  
    }
}