namespace CsharpUtilsLib.External.Meal;

public sealed class MealData : BaseExternalData<SearchMeals>
{
    protected override string Url => "https://www.themealdb.com/api/json/v1/1/search.php?s={0}";

    public MealData() : base() { }

    public MealData(HttpWrapper http) : base(http) { }

    public async Task<SearchMeals> GetMealByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return null!;
        }

        return await Request(parameters: Uri.EscapeDataString(name.ToLower()));
    }
}