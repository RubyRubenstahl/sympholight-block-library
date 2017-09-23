using System;
using Scripting;

/**
* Map an input value from one range to another
**/ 
public static class RangeMap
{
    public static void Run(
		double value, 
		out double mappedValue,
		double inputMin=0, double inputMax = 100, 
		double outputMin = 0, double outputMax = 100
		
		)
    {
        mappedValue = (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin) + outputMin;
    }
}
