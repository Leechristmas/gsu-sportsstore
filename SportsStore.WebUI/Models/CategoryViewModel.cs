using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Models
{
    public class CategoryViewModel
    {
        public int SelectedCategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } 
    }
}