//-------------------------------------------------------------------------------------
//	NoCard.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class NoCard : ATMState
{

    ATMMachine atmMachine;


    public NoCard(ATMMachine newATMMachine)
{

    atmMachine = newATMMachine;

}

public void insertCard()
{

   Debug.Log("Please enter your pin");
        //改变状态了
        atmMachine.setATMState(new HasCard(atmMachine));
        atmMachine.setATMState(atmMachine.getYesCardState());

}

public void ejectCard()
{

    Debug.Log("You didn't enter a card");

}

public void requestCash(int cashToWithdraw)
{

    Debug.Log("You have not entered your card");

}

public void insertPin(int pinEntered)
{

    Debug.Log("You have not entered your card");

}
}