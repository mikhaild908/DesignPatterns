/*******************************************************************************
 * Abstract Factory Pattern
 * provides an interface for creating families of related or dependent objects
 * without specifying their concrete classes.
 ******************************************************************************/

using System;
using System.Text;

namespace DesignPatterns.Lib.AbstractFactory
{
    #region Ingredients
    public interface ICheese
    {
        string ToString();
    }

    public interface IClams
    {
        string ToString();
    }

    public interface IDough
    {
        string ToString();
    }

    public interface IPepperoni
    {
        string ToString();
    }

    public interface ISauce
    {
        string ToString();
    }

    public interface IVeggies
    {
        string ToString();
    }

    public class BlackOlives : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Black Olives";
        }
    }

    public class Eggplant : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Eggplant";
        }
    }

    public class FreshClams : IClams
    {
        string IClams.ToString()
        {
            return "Fresh Clams from Long Island Sound";
        }
    }

    public class FrozenClams : IClams
    {
        string IClams.ToString()
        {
            return "Frozen Clams from Chesapeake Bay";
        }
    }

    public class Garlic : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Garlic";
        }
    }

    public class MarinaraSauce : ISauce
    {
        string ISauce.ToString()
        {
            return "Marinara Sauce";
        }
    }

    public class MozzarellaCheese : ICheese
    {
        string ICheese.ToString()
        {
            return "MozzarellaCheese";
        }
    }

    public class Mushroom : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Mushrooms";
        }
    }

    public class Onion : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Onion";
        }
    }

    public class ParmesanCheese : ICheese
    {
        string ICheese.ToString()
        {
            return "Shredded Parmesan";
        }
    }

    public class PlumTomatoSauce : ISauce
    {
        string ISauce.ToString()
        {
            return "Tomato sauce with plum tomatoes";
        }
    }

    public class RedPepper : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Red Pepper";
        }
    }

    public class ReggianoCheese : ICheese
    {
        string ICheese.ToString()
        {
            return "Reggiano Cheese";
        }
    }

    public class SlicedPepperoni : IPepperoni
    {
        string IPepperoni.ToString()
        {
            return "Sliced Pepperoni";
        }
    }

    public class Spinach : IVeggies
    {
        string IVeggies.ToString()
        {
            return "Spinach";
        }
    }

    public class ThickCrustDough : IDough
    {
        string IDough.ToString()
        {
            return "ThickCrust style extra thick crust dough";
        }
    }

    public class ThinCrustDough : IDough
    {
        string IDough.ToString()
        {
            return "Thin Crust Dough";
        }
    }
    #endregion

    #region Pizzas
    public abstract class Pizza
    {
        public string Name { get; set; }

        public IDough Dough { get; protected set; }
        public ISauce Sauce { get; protected set; }
        public IVeggies[] Veggies { get; protected set; }
        public ICheese Cheese { get; protected set; }
        public IPepperoni Pepperoni { get; protected set; }
        public IClams Clam { get; protected set; }

        public abstract void Prepare();

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
            if (Dough != null)
            {
                result.AppendLine(Dough.ToString());
            }
            if (Sauce != null)
            {
                result.AppendLine(Sauce.ToString());
            }
            if (Cheese != null)
            {
                result.AppendLine(Cheese.ToString());
            }
            if (Veggies != null)
            {
                for (int i = 0; i < Veggies.Length; i++)
                {
                    result.Append(Veggies[i].ToString());
                    if (i < Veggies.Length - 1)
                    {
                        result.Append(", ");
                    }
                }
                result.Append("\n");
            }
            if (Clam != null)
            {
                result.AppendLine(Clam.ToString());
            }
            if (Pepperoni != null)
            {
                result.AppendLine(Pepperoni.ToString());
            }

            return result.ToString();
        }
    }

    public class CheesePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
        }
    }

    public class ClamPizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public ClamPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Clam = _ingredientFactory.CreateClam();
        }
    }

    public class PepperoniPizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Veggies = _ingredientFactory.CreateVeggies();
            Pepperoni = _ingredientFactory.CreatePepperoni();
        }
    }

    public class VeggiePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Veggies = _ingredientFactory.CreateVeggies();
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
            IPizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientFactory();

            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientFactory) { Name = "Chicago Style Cheese Pizza" };
                    break;
                case "veggie":
                    pizza = new VeggiePizza(ingredientFactory) { Name = "Chicago Style Veggie Pizza" };
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientFactory) { Name = "Chicago Style Clam Pizza" };
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza(ingredientFactory) { Name = "Chicago Style Pepperoni Pizza" };
                    break;
            }

            return pizza;
        }
    }

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string item)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NYPizzaIngredientFactory();

            switch (item)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientFactory) { Name = "New York Style Cheese Pizza" };
                    break;
                case "veggie":
                    pizza = new VeggiePizza(ingredientFactory) { Name = "New York Style Veggie Pizza" };
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientFactory) { Name = "New York Style Clam Pizza" };
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza(ingredientFactory) { Name = "New York Style Pepperoni Pizza" };
                    break;
            }

            return pizza;
        }
    }
    #endregion

    public interface IPizzaIngredientFactory
    {
        IDough CreateDough();
        ISauce CreateSauce();
        ICheese CreateCheese();
        IVeggies[] CreateVeggies();
        IPepperoni CreatePepperoni();
        IClams CreateClam();
    }

    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public ICheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public IClams CreateClam()
        {
            return new FrozenClams();
        }

        public IDough CreateDough()
        {
            return new ThickCrustDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] veggies = { new BlackOlives(), new Spinach(), new Eggplant() };
            return veggies;
        }
    }

    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public ICheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public IClams CreateClam()
        {
            return new FreshClams();
        }

        public IDough CreateDough()
        {
            return new ThinCrustDough();
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public ISauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] veggies = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
            return veggies;
        }
    }

    #region Client
    public class Program
    {
        public static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese");
            //Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("cheese");
            //Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("clam");
            //Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("clam");
            //Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("pepperoni");
            //Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("pepperoni");
            //Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.OrderPizza("veggie");
            //Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.OrderPizza("veggie");
            //Console.WriteLine("Joel ordered a " + pizza + "\n");
        }
    }
    #endregion
}
