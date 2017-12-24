//-------------------------------------------------------------------------------------
//	SuperPower.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This is the base class（基类）
public abstract class SuperPower
{
    //Abstract interface for sub class（给子类提供的抽象接口）
    public abstract void Activate();

    //Some of the tool methods given to the child class（给子类提供的一些工具方法类）
    protected void Move(float speed)
    {
        Debug.Log("Moving with speed " + speed + "!(速度)");
    }

    protected void PlaySound(string coolSound)
    {
        Debug.Log("Playing sound " + coolSound+"!(音效)");
    }

    protected void SpawnParticles(string particles)
    {
        Debug.Log("Spawn Particles "+ particles+"!(粒子特效)");
    }
}
