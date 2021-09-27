using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAIHelpers
{
public enum CurveTypes
{
    Linear,         // y = mx + b;
    Exponential,    
    Logistic,
    Logit
}

public struct Consideration
{
    public Consideration(CurveTypes curveType, float slope, float exponent, float YIntercept, float XIntercept)
    {
       //name   =   parameterName;
       curve  =   curveType;
       m      =   slope;
       k      =   exponent;
       b      =   YIntercept;
       c      =   XIntercept;
    }

    //public string name;
    public CurveTypes curve;

    public float m;
    public float k;
    public float b;
    public float c;

}

static public class ResponseCurve
{
    public static float GetOutputValue(Consideration consideration, float input)
    {
        float output = 0.0f;

        switch(consideration.curve)
        {
            case CurveTypes.Linear:

                consideration.k = 1;
                consideration.c = 0;
                output = GetQuadraticOutput(consideration, input);
                break;

            case CurveTypes.Exponential:

                output = GetQuadraticOutput(consideration, input);
                break;

            case CurveTypes.Logistic:
                output = GetLogisticOutput(consideration, input);
                break;

            case CurveTypes.Logit:
                break;
        }

        return output;
    }

    private static float GetQuadraticOutput(Consideration consideration, float input)
    {
        float output = consideration.m * Mathf.Pow((input - consideration.c), consideration.k) + consideration.b;

        output = Clamp(output);

        return output;
    }

    private static float GetLogisticOutput(Consideration consideration, float input)
    {
        float e = 2.718f;

        float output = 1 + (1000 * e * (Mathf.Pow(consideration.m, -input + consideration.c)));

        output = consideration.k * ( 1 / output) + consideration.b;

        output = Clamp(output);

        return output;
    }

    private static float Clamp(float input, float minRange = 0.0f, float maxRange = 1.0f)
    {
        if(input >= maxRange)
        {
            input = maxRange;
        }

        if(input <= minRange)
        {
            input = minRange;
        }

         return input;
    }
}
}