using System;
using Scripting;

/**
* Clamp a value between min and max
**/
public static class ClampInt
{
    public static int Run(int value, int min, int max)
    {
        if(value<min) return min;
		if(value>max) return max;
		return value;
    }
}