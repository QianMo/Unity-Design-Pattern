//-------------------------------------------------------------------------------------
//	NoCash.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class NoCash : ATMState
{

    ATMMachine atmMachine;

    public NoCash(ATMMachine newATMMachine)
    {
        atmMachine = newATMMachine;
    }

    public void insertCard()
    {
        Debug.Log("We don't have any money");
        Debug.Log("Your card is ejected");
    }

    public void ejectCard()
    {
        Debug.Log("We don't have any money");
        Debug.Log("There is no card to eject");

    }

    public void requestCash(int cashToWithdraw)
    {
        Debug.Log("We don't have any money");
    }

    public void insertPin(int pinEntered)
    {
        Debug.Log("We don't have any money");
    }

    //to fix the private field `NoCash.atmMachine' is assigned but its value is never used warning
    ATMMachine GetATMMachine()
    {
        return atmMachine;
    }
}