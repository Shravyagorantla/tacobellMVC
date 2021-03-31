using System;
using System.Collections.Generic;

#nullable disable

namespace tacobellMVC.Models
{
    public partial class FoodDetail
    {
        public FoodDetail()
        {
            Nutritions = new HashSet<Nutrition>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int? Quantity { get; set; }
        public string Imageurl { get; set; }
        public int? Price { get; set; }
        public int? TotalPrice { get; set; }

        public virtual ICollection<Nutrition> Nutritions { get; set; }
    }
}
