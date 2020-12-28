/*******************************************************************************
 * Decorator Pattern
 * Attaches additional responsibilities to an object dynamically.  Decorations
 * provide a flexible alternative to subclassing for extending functionality.
 ******************************************************************************/

using System;
namespace DesignPatterns.Lib
{
    #region Components
    public abstract class Beverage
    {
        public virtual string Description { get; protected set; } = "Unknown Beverage";

        public abstract double Cost();
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast Coffee";
        }

        public override double Cost()
        {
            return .99;
        }
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            return .89;
        }
    }
    #endregion

    #region Decorators
    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string Description { get; }
    }

    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string Description => _beverage.Description + ", Mocha";

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }

    public class Soy : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .15 + _beverage.Cost();
        }

        public override string Description => _beverage.Description + ", Soy";
    }

    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .10 + _beverage.Cost();
        }

        public override string Description => _beverage.Description + ", Whip";
    }
    #endregion

    #region Client
    public class Program
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new Espresso();

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);

            Beverage beverage3 = new HouseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
        }
    }
    #endregion
}
