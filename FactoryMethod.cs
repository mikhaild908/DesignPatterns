/*******************************************************************************
 * Factory Method Pattern
 * defines an interface for creating an object, but lets subclasses decide
 * which class to instantiate. Factory Method lets a class defer instantiation
 * to subclasses.
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Lib.FactoryMethod
{
    #region Pizzas
    public abstract class Pizza
    {
        public string Name { get; protected set; }
        public string Dough { get; protected set; }
        public string Sauce { get; protected set; }
        public List<string> Toppings { get; protected set; } = new List<string>();

        public virtual void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Console.WriteLine("Tossing dough...");
            Console.WriteLine("Adding sauce...");
            Console.WriteLine("Adding toppings: ");
            foreach (var topping in Toppings)
            {
                Console.WriteLine("   " + topping);
            }
        }

        public virtual void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public virtual void Box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("---- " + Name + " ----");
            result.AppendLine(Dough);
            result.AppendLine(Sauce);
            foreach (var topping in Toppings)
            {
                result.AppendLine(topping);
            }

            return result.ToString();
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Shredded Mozzarella Cheese";

            Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
    #endregion

    #region Pizza Stores
    public abstract class PizzaStore
    {
        protected abstract Pizza CreatePizza(string item);

        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            Console.WriteLine("--- Making a " + pizza.Name + " ---");
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string item)
        {
            Pizza pizza = null;

            switch (item)
            {
                case "cheese":
                    pizza = new ChicagoStyleCheesePizza();
                    break;
                //case "veggie":
                //    pizza = new ChicagoStyleVeggiePizza();
                //    break;
                //case "clam":
                //    pizza = new ChicagoStyleClamPizza();
                //    break;
                //case "pepperoni":
                //    pizza = new ChicagoStylePepperoniPizza();
                //    break;
            }

            return pizza;
        }
    }

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            switch (item)
            {
                case "cheese":
                    pizza = new NYStyleCheesePizza();
                    break;
                //case "veggie":
                //    pizza = new NYStyleVeggiePizza();
                //    break;
                //case "clam":
                //    pizza = new NYStyleClamPizza();
                //    break;
                //case "pepperoni":
                //    pizza = new NYStylePepperoniPizza();
                //    break;
            }

            return pizza;
        }
    }
    #endregion

    #region Client
    public class Program
    {
        public static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("clam");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("clam");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("pepperoni");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("pepperoni");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("veggie");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("veggie");
            Console.WriteLine("Joel ordered a " + pizza + "\n");
        }
    }
    #endregion
}
