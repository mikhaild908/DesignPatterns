/*******************************************************************************
 * Simple Factory
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Lib.SimpleFactory
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

    public class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            Name = "Cheese Pizza";
            Dough = "Regular Crust";
            Sauce = "Marinara Pizza Sauce";

            Toppings.Add("Fresh Mozzarella");
            Toppings.Add("Parmesan");
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza()
        {
            Name = "Pepperoni Pizza";
            Dough = "Crust";
            Sauce = "Marinara sauce";

            Toppings.Add("Sliced Pepperoni");
            Toppings.Add("Sliced Onion");
            Toppings.Add("Grated parmesan cheese");
        }
    }
    #endregion

    #region SimpleFactory
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza();
                    break;
                //case "veggie":
                //    pizza = new VeggiePizza();
                //    break;
                //case "clam":
                //    pizza = new ClamPizza();
                //    break;
                case "pepperoni":
                    pizza = new PepperoniPizza();
                    break;
            }

            return pizza;
        }
    }
    #endregion

    #region Pizza Store
    public class PizzaStore
    {
        private readonly SimplePizzaFactory _factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public Pizza OrderPizza(string type)
        {
            Pizza pizza = _factory.CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }
    #endregion

    #region Client
    public class Program2
    {
        public static void Main(string[] args)
        {
            SimplePizzaFactory factory = new SimplePizzaFactory();
            PizzaStore store = new PizzaStore(factory);

            Pizza pizza = store.OrderPizza("cheese");
            //Console.WriteLine("We ordered a " + pizza.Name);

            pizza = store.OrderPizza("veggie");
            //Console.WriteLine("We ordered a " + pizza.Name);
        }
    }
    #endregion
}
