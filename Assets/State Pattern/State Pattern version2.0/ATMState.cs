//-------------------------------------------------------------------------------------
//	ATMState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;


public interface ATMState
{

    // Different states expected
    // HasCard, NoCard, HasPin, NoCash

    void insertCard();

    void ejectCard();

    void insertPin(int pinEntered);

    void requestCash(int cashToWithdraw);

}