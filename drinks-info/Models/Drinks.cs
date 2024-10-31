using Newtonsoft.Json;

namespace drinks_info.Models
{
    public class Drinks
    {
        [JsonProperty("Drinks")]
        
        public List<Drink> DrinksList {get; set;}

    }
    
    public class Drink
    {
        public string IdDrink {get; set; }

        public string strDrink {get; set; }
    }
}