//-------------------------------------------------------------------------------------
//	SkyLaunch.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//Subclasses
public class SkyLaunch : SuperPower
{
    //Has to have its own version of Activate()（子类实现自己版本的Activate()方法）
    public override void Activate()
    {
        Debug.Log("--------------------------SkyLaunch SuperPower Activate!--------------------");
        //make own unique features.（组合子类自己独特的功能）
        Move(10f);
        PlaySound("SkyLaunch");
        SpawnParticles("SkyLaunch Particles");
    }
}
