using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10361554_PROG6221_POE
{
	// Enumeration for different food groups
	public enum FoodGroups
	{
		Fruits,
		Vegetables,
		Grains,
		Proteins,
		Dairy,
		Fats_and_Oils,
		Sugars_and_Sweets
	}

	public class FoodGroup
	{
		// Property to hold the food group category
		public FoodGroups Groups { get; set; }

		// Property to hold a description of the food group
		public string Description { get; set; }

		// Property to hold examples of foods in this food group
		public List<string> examples { get; set; }

		// Method to display the food group description and examples
		public void DisplayFoodGroupDescription(int i)
		{
			// Print the food group, its description, and a list of examples
			Console.WriteLine($"({i}) {Groups} \n{Description} \nExamples: ");

			// If examples list is not null, iterate through and print each example
			if (examples != null)
			{
				foreach (string example in examples)
				{
					Console.WriteLine($"- {example}");
				}
			}
		}

		// Method to display only the food group enum value
		public void DisplayFoodGroupEnum(int i)
		{
			// Print the food group enum value
			Console.WriteLine($"({i}) {Groups}");
		}

		// Code Attribution
		// Method written using code from: 
		// Matt Parkins
		// Stack Overflow
		// Total number of items defined in an enum
		// https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
		// Method to get the total number of items defined in an enum
		public static int GetEnumCount<T>() where T : Enum
		{
			// Return the total number of enum values
			return Enum.GetValues(typeof(T)).Length;
		}
	}
}
