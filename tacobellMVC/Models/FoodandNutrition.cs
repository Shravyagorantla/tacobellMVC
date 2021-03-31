using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tacobellMVC.Models
{
    public class FoodandNutrition
    {
        public int NutritionId { get; set; }
        public string FoodName { get; set; }
        public int? WeightInGrams { get; set; }
        public double? Protein { get; set; }
        public int? Calories { get; set; }
        public double? Totalsugar { get; set; }
        public double? Sodium { get; set; }
        public string Grain { get; set; }
        public string FruitorVegetable { get; set; }
        public string Dairy { get; set; }
        public string ProteinClassification { get; set; }
    }
}
