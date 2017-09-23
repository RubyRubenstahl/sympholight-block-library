using System;
using Scripting;

/**
* If a value is outside of its range, wrap it around to start
**/
public static class WrapInt
{
    public static int Run(int value, int min=0, int max=10)
    {
       	int rangeSize = max - min + 1;
		if(value < min){
			value = rangeSize * ((min - value) / rangeSize + 1);
		}
		
		return min + (value - min) % rangeSize;
    }
}