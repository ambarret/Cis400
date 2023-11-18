using PizzaParlor.Data.Enums;
using PizzaParlor.Data.Pizzas;
using PizzaParlor.Data.Breadsticks;
using PizzaParlor.Data.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    public static class Menu
    {
        public static IEnumerable<IMenuItem> Pizzas
        {
            get
            {
                List<IMenuItem> p = new List<IMenuItem>();

                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    foreach (Crust crust in Enum.GetValues(typeof(Crust)))
                    {
                        Pizza pizza = new Pizza();
                        pizza.PizzaSize = size;
                        pizza.PizzaCrust = crust;
                        p.Add(pizza);

                        HawaiianPizza hawaiianPizza = new HawaiianPizza();
                        hawaiianPizza.PizzaSize = size;
                        hawaiianPizza.PizzaCrust = crust;
                        p.Add(hawaiianPizza);

                        MeatsPizza meatsPizza = new MeatsPizza();
                        meatsPizza.PizzaSize = size;
                        meatsPizza.PizzaCrust = crust;
                        p.Add(meatsPizza);

                        SupremePizza supremePizza = new SupremePizza();
                        supremePizza.PizzaSize = size;
                        supremePizza.PizzaCrust = crust;
                        p.Add(supremePizza);

                        VeggiePizza veggiePizza = new VeggiePizza();
                        veggiePizza.PizzaSize = size;
                        veggiePizza.PizzaCrust = crust;
                        p.Add(veggiePizza);
                    }
                }

                return p;
            }
        }

        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> s = new List<IMenuItem>();
                BreadSticks bread = new BreadSticks();
                CinnamonSticks cinnamon = new CinnamonSticks();
                GarlicKnots garlic = new GarlicKnots();
                Wings wings = new Wings();

                s.Add(bread);
                s.Add(cinnamon);
                s.Add(garlic);

                bread.Cheese = true;
                cinnamon.Frosting = false;

                // Create new instances for each iteration
                foreach (WingSauce sauce in Enum.GetValues(typeof(WingSauce)))
                {
                    Wings wingInstance = new Wings();
                    wingInstance.Sauce = sauce;
                    s.Add(wingInstance);
                }

                return s;
            }
        }

        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> drinks = new List<IMenuItem>();
                IcedTea tea = new IcedTea();
                Soda soda = new Soda();

                // Create new instances for each iteration
                foreach (Size size in Enum.GetValues(typeof(Size)))
                {
                    IcedTea teaInstance = new IcedTea();
                    teaInstance.DrinkSize = size;
                    drinks.Add(teaInstance);

                    foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
                    {
                        Soda sodaInstance = new Soda();
                        sodaInstance.DrinkSize = size;
                        sodaInstance.DrinkType = flavor;
                        drinks.Add(sodaInstance);
                    }
                }

                return drinks;
            }
        }

        public static IEnumerable<IMenuItem> FullMenu 
        {
            get 
            {
                List<IMenuItem> full = new List<IMenuItem>();
                List<IMenuItem> p = (List<IMenuItem>)Pizzas;
                List<IMenuItem> s = (List<IMenuItem>)Sides;
                List<IMenuItem> d = (List<IMenuItem>)Drinks;
                foreach( IMenuItem item in p )
                {
                    full.Add(item);
                }
                foreach( IMenuItem item in s )
                {
                    full.Add(item);
                }
                foreach( IMenuItem item in d )
                {
                    full.Add(item);
                }
                return full;
            }
        }

        public static IEnumerable<IMenuItem> PizzaSearch (string terms)
        {
            if (terms == null || terms.Length == 0) return Pizzas;
            List<IMenuItem> results = new List<IMenuItem>();
            List<IMenuItem> temp = (List<IMenuItem>)Pizzas;
            string[] splitterms = terms.Split(" ");
            foreach(string term in splitterms)
            {
                results = new List<IMenuItem>();
                foreach(IMenuItem item in temp)
                {
                    if (item.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase)) results.Add(item);
                }
                temp = results;         
            }

            return results;
        }

        public static IEnumerable<IMenuItem> SideSearch(string terms)
        {
            if (terms == null || terms.Length == 0) return Sides;
            List<IMenuItem> results = new List<IMenuItem>();
            List<IMenuItem> temp = (List<IMenuItem>)Sides;
            string[] splitterms = terms.Split(" ");
            foreach (string term in splitterms)
            {
                results = new List<IMenuItem>();
                foreach (IMenuItem item in temp)
                {
                    if (item.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase)) results.Add(item);
                }
                temp = results;
            }

            return results;
        }

        public static IEnumerable<IMenuItem> DrinkSearch(string terms)
        {
            if (terms == null || terms.Length == 0) return Drinks;
            List<IMenuItem> results = new List<IMenuItem>();
            List<IMenuItem> temp = (List<IMenuItem>)Drinks;
            string[] splitterms = terms.Split(" ");
            foreach (string term in splitterms)
            {
                results = new List<IMenuItem>();
                foreach (IMenuItem item in temp)
                {
                    if (item.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase)) results.Add(item);
                }
                temp = results;
            }

            return results;
        }

        public static IEnumerable<IMenuItem> Calories(IEnumerable<IMenuItem> items, uint? min, uint? max)
        {
            if (min == null && max == null) return items;
            List<IMenuItem> results = new List<IMenuItem> ();
            if(min == null)
            {
                foreach(IMenuItem item in items)
                {
                    if(item.CaloriesPerEach <= max) results.Add(item);
                }
            }
            else if(max == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.CaloriesPerEach >= min) results.Add(item);
                }
            }
            else
            {
                foreach (IMenuItem item in items)
                {
                    if(item.CaloriesPerEach <= max && item.CaloriesPerEach >= min) results.Add(item);
                }
            }
            return results;
        }

        public static IEnumerable<IMenuItem> Price(IEnumerable<IMenuItem> items, decimal? min, decimal? max)
        {
            if (min == null && max == null) return items;
            List<IMenuItem> results = new List<IMenuItem>();
            if (min == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Price <= max) results.Add(item);
                }
            }
            else if (max == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Price >= min) results.Add(item);
                }
            }
            else
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Price <= max && item.Price >= min) results.Add(item);
                }
            }
            return results;
        }
    }
}
