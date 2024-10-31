using Newtonsoft.Json;
using RestSharp;
using drinks_info.Models;
using System.Web;
using System.Reflection;

namespace drinks_info
{
    public class DrinksService
    {
        public void getCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList;

                TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");
            }
        }


        internal void getDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> returnedList = serialize.DrinksList;

                TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");
            }
        }

        internal void GetDrink(string drink)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.drinkDetailList;

                DrinkDetail drinkDetail = returnedList[0];

                List<object> prepList = new();

                string formattedName = "";

                foreach ( PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if(prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }

                    if(!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }

                TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);

            }
        }
    }
}