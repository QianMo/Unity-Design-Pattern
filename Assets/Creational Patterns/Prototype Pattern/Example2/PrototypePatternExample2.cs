//-------------------------------------------------------------------------------------
//	PrototypePatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace PrototypePatternExample2
{
    public class PrototypePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            CloneFactory factory = new CloneFactory();
            
            Sheep sally = new Sheep();

            Sheep clonedSheep = (Sheep)factory.GetClone(sally);

            Debug.Log("Sally: " + sally.ToStringEX());
            Debug.Log("Clone of Sally: " + clonedSheep.ToStringEX());
            Debug.Log("Sally Hash: " + sally.GetHashCode() + " - Cloned Sheep Hash: " + clonedSheep.GetHashCode());
        }

    }

    public class CloneFactory
    {
        public IAnimal GetClone(IAnimal animalSample)
        {
            return (IAnimal)animalSample.Clone();
        }
    }

    public interface IAnimal : ICloneable
    {
        object Clone();
    }

    public class Sheep : IAnimal
    {
        public Sheep()
        {
            Debug.Log("Made Sheep");
        }

        public object Clone()
        {
            Sheep sheep = null;

            try
            {
                sheep = (Sheep)base.MemberwiseClone();
            }
            catch (Exception e)
            {
                Debug.LogError("Error cloning Sheep");
            }

            return sheep;
        }

        public string ToStringEX()
        {
            return "Hello I'm a Sheep";
        }
    }

}

