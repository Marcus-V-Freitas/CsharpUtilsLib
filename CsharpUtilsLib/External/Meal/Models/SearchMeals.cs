namespace CsharpUtilsLib.External.Meal.Models;

public sealed class SearchMeals
{
    [Display(Name = "Meals"), JsonPropertyName("meals")]
    public List<Meal> Meals { get; set; }
}