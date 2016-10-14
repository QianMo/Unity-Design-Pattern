//-------------------------------------------------------------------------------------
//	TemplateMethodPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/* 
 Used to create a group of sublcasses that have to execute a similar group of methods
 You create an abstract class that contains a method called the Template Method
 The Template method contains a series of method calls that every sublcass object will call
 The subclass objects can override some of the method calls
*/

namespace TemplateMethodPatternExample1
{

    public class TemplateMethodPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            Hoagie cust12Hoagie = new ItalienHoagie();
            cust12Hoagie.MakeSandwich();

            Hoagie cust13Hoagie = new VeggieHoagie();
            cust13Hoagie.MakeSandwich();
        }
    }

    public abstract class Hoagie
    {
        public void MakeSandwich()
        {
            Debug.Log("Making new Sandwich");

            CutBun();

            if (CustomerWantsMeat())
            {
                AddMeat();
            }

            if (CustomerWantsCheese())
            {
                AddCheese();
            }

            if (CustomerWantsVegetables())
            {
                AddVegetables();
            }

            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }

            WrapTheHoagie();
        }
        protected abstract void AddMeat();
        protected abstract void AddCheese();
        protected abstract void AddVegetables();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsMeat() { return true; } // << called Hook
        protected virtual bool CustomerWantsCheese() { return true; }
        protected virtual bool CustomerWantsVegetables() { return true; }
        protected virtual bool CustomerWantsCondiments() { return true; }

        protected void CutBun()
        {
            Debug.Log("Bun is Cut");
        }

        protected void WrapTheHoagie()
        {
            Debug.Log("Hoagie is wrapped.");
        }
    }


    public class ItalienHoagie : Hoagie
    {
        protected override void AddMeat()
        {
            Debug.Log("Adding the Meat: Salami");
        }

        protected override void AddCheese()
        {
            Debug.Log("Adding the Cheese: Provolone");
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }
    }



    public class VeggieHoagie : Hoagie
    {
        protected override void AddMeat()
        {
        }

        protected override void AddCheese()
        {
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }

        protected override bool CustomerWantsMeat() { return false; }
        protected override bool CustomerWantsCheese() { return false; }

    }


    namespace BadExample
    {
        // this way you would have to rewrite a lot of code
        // especially if something changes or another class differs and does e.g. not AddMeat()
        public class ItalienHoagie
        {
            public void MakeSandwich()
            {
                CutBun();
                AddMeat();
                AddCheese();
                AddVegtables();
                AddCondiments();
                WrapHoagie();
            }

            public void CutBun()
            {
                Debug.Log("Hoagie is Cut");
            }

            public void AddMeat()
            {
                Debug.Log("Added Meat");
            }

            public void AddCheese()
            {
                Debug.Log("Added Cheese");
            }

            public void AddVegtables()
            {
                Debug.Log("Added Vegies");
            }

            public void AddCondiments()
            {
                Debug.Log("Added Condiments");
            }

            public void WrapHoagie()
            {
                Debug.Log("Wrapped Hoagie");
            }
        }
    }
}