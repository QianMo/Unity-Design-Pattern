//-------------------------------------------------------------------------------------
//	TVRemove.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TVRemove
{
    public static IElectronicDevice GetDevice()
    {
        return new Television();
    }
}
