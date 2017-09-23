using System;
using Scripting;

/**
* Clamp a value between min and max
**/
public static class ClampDouble
{
    public static double Run(double value, double min, double max)
    {
        if(value<min) return min;
		if(value>max) return max;
		return value;
    }
}
