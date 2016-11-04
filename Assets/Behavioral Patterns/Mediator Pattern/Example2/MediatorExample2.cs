//-------------------------------------------------------------------------------------
//	MediatorExample2.cs
//-------------------------------------------------------------------------------------

/*
 * It is used to handle communication between related objects(Colleagues)
 *
 * All communication is handled by the mediator
 * the colleagues don't need to know anything about each other
 *
 * GOF: Allows loose coupling by encapsulating the way disparate sets of objects
 * interact and communicate with each other.Allows for the actions
 * of each object set to vary independently of one another
 *
 *
 **/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MediatorExample2
{

    public class MediatorExample2 : MonoBehaviour
    {
	    void Start ( )
	    {
            StockMediator nyse = new StockMediator();

            // important here is:
            // in this example they both might be doing nothing different, but
            // they could be totally different objects and calculate stuff different or so
            // but still be able to talk to the mediator the same easy way
            // that's why we have different objects here:
            GormanSlacks broker = new GormanSlacks(nyse);
            JTPoorman broker2 = new JTPoorman(nyse);

            nyse.AddColleague(broker);
            nyse.AddColleague(broker2);

            // because they call methods on the same mediator object they talk to the same mediator
            // who handles all the stock exanche and keeps track of that. so the brokers by themselves
            // don't know anything about each other. which is a good thing :-)
            broker.SaleOffer(Stock.MSFT, 100);
            broker.SaleOffer(Stock.GOOG, 50);

            broker2.BuyOffer(Stock.MSFT, 100);
            broker2.SaleOffer(Stock.NRG, 10);

            broker.BuyOffer(Stock.NRG, 10);
            broker.BuyOffer(Stock.NRG, 50);

            nyse.PrintStockOfferings();
        }


    }

    // I like using enums more than using strings
    // because it prevents typos and I don't need to remember strings ;)
    public enum Stock
    {
        MSFT,
        GOOG,
        NRG
    };


    public class StockOffer
    {
        public int stockShares { get; private set; }
        public Stock stock { get; private set; }
        public int colleagueCode { get; private set; }

        public StockOffer(int numOfShares, Stock stock, int collCode)
        {
            this.stockShares = numOfShares;
            this.stock = stock;
            this.colleagueCode = collCode;
        }
    }


    public abstract class Colleague
    {
        private Mediator mediator;
        private int colleagueCode;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void SetCode(int code)
        {
            colleagueCode = code;
        }

        public void SaleOffer(Stock stock, int shares)
        {
            mediator.SaleOffer(stock, shares, this.colleagueCode);
        }

        public void BuyOffer(Stock stock, int shares)
        {
            mediator.BuyOffer(stock, shares, this.colleagueCode);
        }
    }


    public class GormanSlacks : Colleague
    {
        // using : base() like here calls the constructor of the base class with the arguments passed in
        // here it calls "Colleague(Mediator mediator)"
        public GormanSlacks(Mediator mediator) : base(mediator)
        {
            Debug.Log("Gorman Slacks signed up with the stockexange");
        }
    }

    public class JTPoorman : Colleague
    {
        public JTPoorman(Mediator mediator) : base(mediator)
        {
            Debug.Log("JT Poorman signed up with the stockexange");
        }
    }






    public interface Mediator
    {
        void AddColleague(Colleague colleague);
        void SaleOffer(Stock stock, int shares, int code);
        void BuyOffer(Stock stock, int shares, int code);
    }


    public class StockMediator : Mediator
    {
        private List<Colleague> colleagues;
        private List<StockOffer> buyOffers;
        private List<StockOffer> sellOffers;

        private int colleagueCodes = 0;

        public StockMediator()
        {
            colleagues = new List<Colleague>();
            buyOffers = new List<StockOffer>();
            sellOffers = new List<StockOffer>();
        }

        #region Mediator implementation
        public void AddColleague(Colleague colleague)
        {
            this.colleagues.Add(colleague);
            colleagueCodes += 1;
            colleague.SetCode(colleagueCodes);
        }

        public void SaleOffer(Stock stock, int shares, int code)
        {
            bool stockSold = false;

            // see if someone is willing to buy:
            for (int i = 0; i < buyOffers.Count; i++)
            {
                StockOffer offer = buyOffers[i];
                // check if the stock is the same:
                if (offer.stock == stock && offer.stockShares == shares)
                {
                    Debug.Log(shares + " shares of " + stock + " stocks sold to colleague with code " + code);

                    buyOffers.Remove(offer);
                    stockSold = true;
                }

                if (stockSold) break;
            }

            if (!stockSold)
            {
                Debug.Log(shares + " shares of " + stock + " stocks added to inventory");
                StockOffer offer = new StockOffer(shares, stock, code);
                sellOffers.Add(offer);
            }
        }

        public void BuyOffer(Stock stock, int shares, int code)
        {
            bool stockBought = false;

            // see if someone is willing to buy:
            for (int i = 0; i < sellOffers.Count; i++)
            {
                StockOffer offer = sellOffers[i];
                // check if the stock is the same:
                if (offer.stock == stock && offer.stockShares == shares)
                {
                    Debug.Log(shares + " shares of " + stock + " stocks bought by colleague with code " + code);

                    sellOffers.Remove(offer);
                    stockBought = true;
                }

                if (stockBought) break;
            }

            if (!stockBought)
            {
                Debug.Log(shares + " shares of " + stock + " stocks added to inventory");
                StockOffer offer = new StockOffer(shares, stock, code);
                buyOffers.Add(offer);
            }
        }
        #endregion


        public void PrintStockOfferings()
        {
            Debug.Log("For Sale: " + sellOffers.Count);
            foreach (StockOffer offer in sellOffers)
            {
                Debug.Log(offer.stock + " - " + offer.stockShares + " - " + offer.colleagueCode);
            }


            Debug.Log("For Buy: " + buyOffers.Count);
            foreach (StockOffer offer in buyOffers)
            {
                Debug.Log(offer.stock + " - " + offer.stockShares + " - " + offer.colleagueCode);
            }
        }
    }

}