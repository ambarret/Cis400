using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaParlor.Data;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<IMenuItem> Pizza {  get; set; }

        public IEnumerable<IMenuItem> Drinks { get; set; }

        public IEnumerable<IMenuItem> Sides { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        public void OnGet()
        {
            Pizza = Menu.PizzaSearch(SearchTerms);
            Drinks = Menu.DrinkSearch(SearchTerms);
            Sides = Menu.SideSearch(SearchTerms);
            Pizza = Menu.Calories(Pizza, CaloriesMin, CaloriesMax);
            Drinks = Menu.Calories(Drinks, CaloriesMin, CaloriesMax);
            Sides = Menu.Calories(Sides, CaloriesMin, CaloriesMax);
            Pizza = Menu.Price(Pizza, PriceMin, PriceMax);
            Drinks = Menu.Price(Drinks, PriceMin, PriceMax);
            Sides = Menu.Price(Sides, PriceMin, PriceMax);
        }
    }
}