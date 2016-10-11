//-------------------------------------------------------------------------------------
//	HasPin.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HasPin : ATMState
{

    ATMMachine atmMachine;


    public HasPin(ATMMachine newATMMachine)
{

    atmMachine = newATMMachine;

}

public void insertCard()
{

    Debug.Log("You already entered a card");

}

public void ejectCard()
{

    Debug.Log("Your card is ejected");
    atmMachine.setATMState(atmMachine.getNoCardState());

}

public void requestCash(int cashToWithdraw)
{

    if (cashToWithdraw > atmMachine.cashInMachine)
    {

        Debug.Log("You don't have that much cash available");
        Debug.Log("Your card is ejected");
        atmMachine.setATMState(atmMachine.getNoCardState());

    }
    else {

        Debug.Log(cashToWithdraw + " is provided by the machine");
        atmMachine.setCashInMachine(atmMachine.cashInMachine - cashToWithdraw);

        Debug.Log("Your card is ejected");
        atmMachine.setATMState(atmMachine.getNoCardState());

        if (atmMachine.cashInMachine <= 0)
        {

            atmMachine.setATMState(atmMachine.getNoCashState());

        }
    }
}

public void insertPin(int pinEntered)
{

    Debug.Log("You already entered a PIN");

}	
}