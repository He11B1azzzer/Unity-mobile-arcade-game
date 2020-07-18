using System;
using UnityEngine;

public class GenerateRandom : MonoBehaviour{
    public static float genRandom(double minValue, double maxValue){
        System.Random rng = new System.Random(DateTime.Now.Millisecond);
        double rDouble = rng.NextDouble() * (maxValue - minValue) + minValue;
        float rFloat = Convert.ToSingle(rDouble);
        return rFloat;
    }
}