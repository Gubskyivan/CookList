using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookList.Views
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
    }
    public class DishModel
    {
        private List<Dish> dishs = new List<Dish>();
        public List<Dish> GetDishs()
        {
            return dishs;
        }
        public void AddDish(Dish dish)
        {
            dishs.Add(dish);
        }
        public void RemoveDish(int id)
        {
            dishs.RemoveAll(dishs => dishs.Id == id);
        }
    }
}
