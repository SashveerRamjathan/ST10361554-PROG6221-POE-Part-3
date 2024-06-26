using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class RecipeMethods
	{

		// List collection to store more than one recipe
		public List<Recipe> recipes = new List<Recipe>();

		// Instance of FoodGroupInformation to access food group information
		FoodGroupInformation FoodGroupInformation = new FoodGroupInformation();

		// Instance of CalorieCounter to perform calorie-related operations
		CalorieCounter counter = new CalorieCounter();
	}
}
