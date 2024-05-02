using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Model.Models;

namespace Delivery.Model
{
    public class FoodTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity{ get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public static FoodTable ConvertFoodOnFoodTable(Food food)
        {
            FoodTable foodTable= new FoodTable();
            foodTable.Id = food.IdFood;
            foodTable.Name = food.Name;
            foodTable.Description= food.Description;
            foodTable.Price = food.Price;
            foodTable.Quantity = food.Quantity;
            foodTable.CategoryId = food.CategoryId;

            using (ApplicationContext db = new ApplicationContext())
            {
                foodTable.CategoryName= db.Categories.FirstOrDefault(g => g.IdCategory == food.CategoryId).Name;
            }

            return foodTable;
        }

    }
}
