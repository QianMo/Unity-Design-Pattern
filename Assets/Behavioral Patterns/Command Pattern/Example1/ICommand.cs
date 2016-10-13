//-------------------------------------------------------------------------------------
//	ICommand.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;


// commands:
// command interface:
public interface ICommand
{
    void Execute();
    void Undo();
}
