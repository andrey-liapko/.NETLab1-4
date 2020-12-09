using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueMVC.Models
{
    public class CategoryTitleSearch
    {
        public List<Item> Names { get; set; }
        public SelectList Producer { get; set; }
        public SelectList Categori { get; set; }
        public string categoryFurniture { get; set; }
        public string SearchString { get; set; }
        public string PriceSortParm { get; set; }
        public string CategorySortParm { get; set; }
        public string TitleSortParm { get; set; }
        
    }
}