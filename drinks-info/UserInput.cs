
namespace drinks_info
{
    public class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput()
        {
            drinksService.getCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine(); 

            while(!Validator.isStringValid(category))
            {
                Console.WriteLine("\n Invalid Category");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            drinksService.getDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0: ");

            string drink = Console.ReadLine();

            if(drink=="0") GetCategoriesInput();

            while(!Validator.isIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            drinksService.GetDrink(drink);
        }
    }
}