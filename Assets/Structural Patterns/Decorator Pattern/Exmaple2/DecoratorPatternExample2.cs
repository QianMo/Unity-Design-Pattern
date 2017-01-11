//-------------------------------------------------------------------------------------
//	DecoratorPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace DecoratorPatternExample2
{
    public class DecoratorPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // Make Pizzas:
            IPizza basicPizza = new TomatoSauce(new Mozzarella(new PlainPizza()));
            Debug.Log("Ingredients of Pizza: " + basicPizza.GetDescription());
            Debug.Log("Total Cost: " + basicPizza.GetCost());
        }
    }



    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }


    public class PlainPizza : IPizza
    {
        public string GetDescription()
        {
            return "Thin Dough";
        }

        public double GetCost()
        {
            return 4.00;
        }
    }



    public abstract class ToppingDecorator : IPizza
    {
        protected IPizza tempPizza;

        public ToppingDecorator(IPizza newPizza)
        {
            this.tempPizza = newPizza;
        }


        public virtual string GetDescription()
        {
            return tempPizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return tempPizza.GetCost();
        }
    }



    public class Mozzarella : ToppingDecorator
    {
        public Mozzarella(IPizza newPizza) : base(newPizza)
        {
            Debug.Log("Adding Dough");
            Debug.Log("Adding Morarella");
        }

        public override string GetDescription()
        {
            return tempPizza.GetDescription() + ", Mozzarella";
        }

        public override double GetCost()
        {
            return tempPizza.GetCost() + 0.50;
        }
    }


    public class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(IPizza newPizza) : base(newPizza)
        {
            Debug.Log("Adding Sauce");
        }

        public override string GetDescription()
        {
            return tempPizza.GetDescription() + ", Tomato Sauce";
        }

        public override double GetCost()
        {
            return tempPizza.GetCost() + 0.35;
        }
    }




    namespace BadStyleExample
    {
        public abstract class Pizza
        {
            public abstract void SetDescription(string newDescription);
            public abstract string GetDescription();
            public abstract double GetCost();
            //public abstract bool HasFontina();
        }

        // this way would force to create an infinite amount of subclasses for each type of pizza
        // and if cost if calculated off of individual topings you would have to change cost for all pizzas
        // if cost for one topping chages
        public class ThreeCheesePizza : Pizza
        {
            public override void SetDescription(string newDescription)
            {
            }

            public override string GetDescription()
            {
                return "Mozarella, Fontina, Parmesan, Cheese Pizza";
            }

            public override double GetCost()
            {
                return 10.00;
            }

        }
    }

}