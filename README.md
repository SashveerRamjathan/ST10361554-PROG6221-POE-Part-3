# Recipe App

Welcome to the Recipe App repository, a console-based application designed to manage recipes efficiently. This repository hosts the code for my Recipe App, which allows users to create, scale, and manage recipes with ease.

<div align="center">
	<img src = "https://st3.depositphotos.com/13324256/17303/i/450/depositphotos_173034766-stock-photo-woman-writing-down-recipe.jpg" width =650 height = 400 />
</div>

## Table of Contents
- #### [Description](#description)
- #### [Features](#features)
- #### [Implementation of Feedback](#ImplementationofFeedback)
- #### [How To Compile and Run Software](#HowToCompileandRunSoftware)
	- [Prerequisites](#Prerequisites)
	- [Steps to Clone this GitHub Repository](#StepstoClonethisGitHubRepository)
	- [Steps to Compile and Run the Software](#StepstoCompileandRuntheSoftware)
- #### [Author](#author)
- #### [App Demonstration Video](#AppDemonstrationVideo)

## Description

The Recipe App is a user-friendly console-based application designed to simplify the process of creating, managing, and scaling recipes. 
With the Recipe App, users can effortlessly create new recipes by adding ingredients and steps, scale ingredient quantities based on chosen factors, and view detailed recipe information.

## Features

- ### Recipe Creation:
	 Users can easily create new recipes by providing the recipe name, number of ingredients, and steps needed to prepare the dish.

- ### Ingredient Management:
	#### Add Ingredients: 
	Users can add ingredients to a recipe, including the ingredient name, quantity, unit of measurement, and food group.
	#### Validate Measurements: 
	The app validates unit measurements to ensure accuracy and consistency in recipes.

- ### Calorie Tracking:
	#### Calorie Counter: 
	Users can input calorie counts for ingredients, allowing the app to calculate total calories for the recipe.
	#### Total Calories: 
	The app displays the total calorie count for each recipe, helping users make informed dietary choices.

- ### Scaling Quantities:
	#### Scale Ingredients: 
	Users can scale ingredient quantities by factors such as halving, doubling, or tripling, making it easy to adjust recipes for different serving sizes.
	#### Revert Scaling: 
	The app allows users to revert scaled quantities back to their original values, ensuring flexibility in recipe management.

- ### Recipe Display and Management:
	#### Display Recipes: 
	Users can view a list of all saved recipes, including ingredients, steps, and total calories.
	#### Sort Recipes: 
	The app provides options to sort recipes alphabetically, enhancing organization and accessibility.

- ### Interactive Console Interface:
	#### User-Friendly Interface: 
	The app features a console-based interface with clear prompts and messages, making it intuitive and easy to navigate.
	#### Colour-Coded Messages: 
	System messages are colour-coded for clarity, with green indicating success, red for errors, cyan for special notifications and yellow to display recipes.

- ### Event Handling:
	#### Calorie Exceeded Alert: 
	The app triggers a yellow warning message when the total calorie count exceeds 300, helping users monitor nutritional values.

- ### Data Persistence:
	#### List Storage: 
	The app uses generic collections (lists) to store recipes, ingredients, and steps, ensuring data persistence and efficient retrieval.

## Implementation of Feedback

- #### "Error handling was implemented but could be better"
	The app now uses more robust and effective error handling in the form of custom exceptions being thrown at certain points if execution fails.
	Stricter validation was implemented, checks for user inputs, such as ingredient names, quantities, and unit measurements, to prevent erroneous data entry.
	Try-catch blocks was implemented in critical sections of the code to catch and handle exceptions gracefully, preventing application crashes and providing meaningful feedback to users.

- #### "Required to use advanced features such as colours"
	The app now makes use of colour-coded system messages which have specific functions e.g. Red to display errors or green to indicate successful operations.
	Recipes when displayed using the menu option are displayed in yellow to improve the readability against the console background and other text on the screen.
	Critical alerts, such as exceeding calorie limits, are displayed in yellow, drawing immediate attention to important information.
	The use of different colours meaningfully serves a specific purpose, creating a visual hierarchy that guides users through different stages of interaction within the app.

- #### "Recipe should be displayed after being scaled" 
	The app has implemented a feature that displays the recipe immediately after it has been scaled. 
	This feature provides users with a clear view of the adjusted quantities and allows them to review and verify the changes made.
	Additionally, the display is colour-coded, with scaled quantities and relevant information highlighted in cyan, making it visually distinct and easy to identify.

- #### "Recipe is not displayed after being scaled recipe not scaled back to original"
						
	The app has implemented a stack data structure within each recipe object to store scaling factors.
	This stack efficiently keeps track of the factors used to scale ingredient quantities, maintaining a record of each modification made to the recipe.
	The app allows users to revert scaled quantities back to their original values with ease. 
	By popping factors from the stack in reverse order, the app recalculates ingredient quantities and recalibrates calorie counts, ensuring accuracy and consistency.
	After scaling, the app displays the recipe, showcasing the modified quantities and total calories. 
	The app incorporates clear indicators in the recipe display, highlighting whether a recipe has been scaled and displaying the factor it has been scaled by.

- #### "ReadMe needs to include more information on using the app"
	The updated readMe now includes a short description of the app, a table of contents, a list of features presented in the app and also steps to download and run the apps source code.
	This provides the user with more than information and background to use the app knowledgably.

## How To Compile and Run Software

### Prerequisites

Before you begin, ensure you have the following installed on your system:

- .Net 8 SDK or higher
- Microsoft Visual Studio 2022 or higher

### Steps to Clone this GitHub Repository

1. Open Visual Studio
2. Under "Get Started" on the right click clone repository.
3. In the repository location bar, paste the link you used to open the repository on your browser (https://github.com/SashveerRamjathan/ST10361554-PROG6221-POE-Part2.git).
4. In the path bar add the file path to the location you want to save the code to.
5. Click clone in the bottom right corner of the same window.

### Steps to Compile and Run the Software

1. Clone the repository following the steps above.
2. Click the hollow green play button on the navigation bar on the top of your screen or click "Ctrl + F5".
3. The command window should display after the project builds and you will be able to interact with the program following the prompts that appear on screen.
	
## Author
**Name:** [Sashveer Lakhan Ramjathan](https://github.com/SashveerRamjathan)

**Student Number:** ST10361554

**Group:** 2

## App Demonstration Video
#### Link to Video:
https://advtechonline-my.sharepoint.com/:v:/g/personal/st10361554_vcconnect_edu_za/EfXUo21EmTJKg6vyAiMRg_QBhnWTIi_HsKtqqpDNBhF4og?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=qkv66F
