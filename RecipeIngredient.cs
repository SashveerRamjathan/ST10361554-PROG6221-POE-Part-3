using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class RecipeIngredient
	{
		// Property to store the ingredient's name
		public string IngredientName { get; set; }

		// Property to store the quantity of the ingredient added
		public double IngredientQuantity { get; set; }

		// Property to store the unit of measurement of the ingredient (e.g., cup, gram)
		public string UnitOfMeasurement { get; set; }

		// Property to store the food group to which the ingredient belongs
		public FoodGroups Group { get; set; }

		// Property to store the calories of the ingredient
		public double Calories { get; set; }
	}
}
