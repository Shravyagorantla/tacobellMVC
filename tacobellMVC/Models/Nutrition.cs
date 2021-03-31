using System;
using System.Collections.Generic;

#nullable disable

namespace tacobellMVC.Models
{
    public partial class Nutrition
    {
        public int NutritionId { get; set; }
        public int? FoodId { get; set; }
        public int? WeightInGrams { get; set; }
        public double? Protein { get; set; }
        public int? Calories { get; set; }
        public double? Totalsugar { get; set; }
        public double? Sodium { get; set; }
        public string Grain { get; set; }
        public string FruitorVegetable { get; set; }
        public string Dairy { get; set; }
        public string ProteinClassification { get; set; }

        public virtual FoodDetail Food { get; set; }
    }
}
