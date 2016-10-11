//-------------------------------------------------------------------------------------
//	TestSubclassSandbox.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSubclassSandbox : MonoBehaviour
{
    //A list that will store all superpowers（一个存储所有超能力的List）
    List<SuperPower> _superPowers = new List<SuperPower>();

    private float _elapsedTime = 0.0f;

    void Start()
    {
        _superPowers.Add(new SkyLaunch());
        _superPowers.Add(new GroundDive());
        _superPowers.Add(new FlashSpeed());
        _elapsedTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        //Trigger once per second（每一秒触发一次）
        if (Time.realtimeSinceStartup - _elapsedTime > 1f)
        {
            for (int i = 0; i < _superPowers.Count; i++)
            {
                _superPowers[i].Activate();
            }
            _elapsedTime = Time.realtimeSinceStartup;
        }

    }
}
