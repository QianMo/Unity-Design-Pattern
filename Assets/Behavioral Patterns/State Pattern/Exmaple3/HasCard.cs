//-------------------------------------------------------------------------------------
//	HasCard.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HasCard : ATMState
{

    ATMMachine atmMachine;


    public HasCard(ATMMachine newATMMachine)
{

    atmMachine = newATMMachine;

}

public void insertCard()
{

    Debug.Log("You can only insert one card at a time");

}

public void ejectCard()
{

    Debug.Log("Your card is ejected");
    atmMachine.setATMState(atmMachine.getNoCardState());

}

public void requestCash(int cashToWithdraw)
{

    Debug.Log("You have not entered your PIN");


}

public void insertPin(int pinEntered)
{

    if (pinEntered == 1234)
    {

        Debug.Log("You entered the correct PIN");
        atmMachine.correctPinEntered = true;
        atmMachine.setATMState(atmMachine.getHasPin());

    }
    else {

        Debug.Log("You entered the wrong PIN");
        atmMachine.correctPinEntered = false;
        Debug.Log("Your card is ejected");
        atmMachine.setATMState(atmMachine.getNoCardState());

    }
}	
}