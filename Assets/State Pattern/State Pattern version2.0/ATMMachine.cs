//-------------------------------------------------------------------------------------
//	ATMMachine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ATMMachine
{

    ATMState atmState;

    public int cashInMachine = 2000;
    public bool correctPinEntered = false;

    public ATMMachine()
    {

        atmState = new NoCard(this); ;

        if (cashInMachine < 0)
        {

            atmState = new NoCash(this);

        }

    }

   public void setATMState(ATMState newATMState)
    {

        atmState = newATMState;

    }

    public void setCashInMachine(int newCashInMachine)
    {

        cashInMachine = newCashInMachine;

    }

    public void insertCard()
    {

        atmState.insertCard();

    }

    public void ejectCard()
    {

        atmState.ejectCard();

    }

    public void requestCash(int cashToWithdraw)
    {

        atmState.requestCash(cashToWithdraw);

    }

    public void insertPin(int pinEntered)
    {

        atmState.insertPin(pinEntered);

    }

    public ATMState getYesCardState() { return new HasCard(this); }
    public ATMState getNoCardState() { return new NoCard(this); }
    public ATMState getHasPin() { return new HasPin(this); }
    public ATMState getNoCashState() { return new NoCash(this); }

}