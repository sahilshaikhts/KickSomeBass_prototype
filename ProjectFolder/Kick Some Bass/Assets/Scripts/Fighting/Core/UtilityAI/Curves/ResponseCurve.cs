using UnityEngine;

namespace UtilityAIHelpers
{
    public enum CurveTypes
    {
        Linear,         // y = mx + b;
        Quadratic,
        Logistic,
        InverseLogistic
    }

    public struct Consideration
    {
        public Consideration(CurveTypes curveType, float slope, float exponent, float YIntercept, float XIntercept)
        {
            //name   =   parameterName;
            curve = curveType;
            m = slope;
            k = exponent;
            b = YIntercept;
            c = XIntercept;
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

            switch (consideration.curve)
            {
                case CurveTypes.Linear:

                    consideration.k = 1;
                    consideration.c = 0;
                    output = GetQuadraticOutput(consideration, input);
                    break;

                case CurveTypes.Quadratic:
                    output = GetQuadraticOutput(consideration, input);
                    break;

                case CurveTypes.Logistic:
                    output = GetLogisticOutput(consideration, input);
                    break;
                case CurveTypes.InverseLogistic:
                    output = GetInverseLogisticOutput(consideration, input);
                    break;
            }

            return output;
        }

        private static float GetQuadraticOutput(Consideration consideration, float input)
        {
            float output = consideration.m * Mathf.Pow((input - consideration.c), consideration.k) + consideration.b;

            output = Mathf.Clamp01(output);

            return output;
        }

        private static float GetLogisticOutput(Consideration consideration, float input)
        {
            float output = consideration.k * (1.0f / (1.0f + Mathf.Pow((1000.0f * consideration.m * Mathf.Exp(1)), input - consideration.c))) + consideration.b;

            output = Mathf.Clamp01(output);

            return output;
        }

        public static float GetLogisticOutputRaw(Consideration consideration, float input)
        {
            float output = consideration.k * (1.0f / (1.0f + Mathf.Pow((1000.0f * consideration.m * Mathf.Exp(1)), input - consideration.c))) + consideration.b;

            return output;
        }

        private static float GetInverseLogisticOutput(Consideration consideration, float input)
        {
            float output = consideration.k * (1.0f / (1.0f + Mathf.Pow((1000.0f * consideration.m * Mathf.Exp(1)), input - consideration.c))) + consideration.b;

            //output =  2.0f - output;

            output = Mathf.Abs(output);

            return output;
            //return Mathf.Clamp01(output);
        }
    }
}