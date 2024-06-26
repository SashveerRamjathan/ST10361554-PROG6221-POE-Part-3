using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	public class FoodGroupInformation
	{
		// List to store instances of FoodGroup representing different food groups
		public List<FoodGroup> Groups = new List<FoodGroup>()
		{
            // Initialisation of FoodGroup instances with specific properties for each food group
            new FoodGroup
			{
				Groups = FoodGroups.Fruits,
				Description = "Fruits are rich in vitamins, minerals, and fibre, and often have a high water content. \nThey are naturally sweet and can be eaten fresh, dried, or juiced.",
				examples = new List<string>{ "Apples", "Bananas", "Oranges", "Berries" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Vegetables,
				Description = "Vegetables are essential sources of vitamins, minerals, and fibre. \nThey are often low in calories and can be consumed raw, cooked, or juiced.",
				examples = new List<string>{ "Spinach", "Kale", "Carrots", "Potatoes" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Grains,
				Description = "Grains are a staple in many diets and provide essential carbohydrates, fibre, and various nutrients. \nThey can be consumed as whole grains or refined products.",
				examples = new List<string>{ "Brown Rice", "Oat Meal", "Flour", "Pasta" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Proteins,
				Description = "Proteins are crucial for building and repairing tissues. \nThey can be obtained from both animal and plant sources, each providing different nutrients.",
				examples = new List<string>{ "Chicken", "Beef", "Eggs", "Lentils", "Tofu" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Dairy,
				Description = "Dairy products are important for bone health due to their high calcium content. \nThey include milk, cheese, yogurt, and fortified plant milks.",
				examples = new List<string>{ "Milk", "Cheese", "Yogurt", "fortified plant milks" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Fats_and_Oils,
				Description = "Fats and oils provide essential fatty acids and are important for various bodily functions. \nHealthy sources include avocados, olive oil, nuts, and seeds.",
				examples = new List<string>{ "Avocados", "Olive Oil", "Nuts", "Seeds (Chia, Flax)" }
			},
			new FoodGroup
			{
				Groups = FoodGroups.Sugars_and_Sweets,
				Description = "Sugars and sweets are high in calories and should be consumed in moderation. \nThey provide quick energy but often lack nutritional value.",
				examples = new List<string>{ "Candy", "Refined Sugar", "Cookies" }
			}
		};
	}
}
