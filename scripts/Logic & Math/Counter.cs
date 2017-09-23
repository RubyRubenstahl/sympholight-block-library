using System;
using Scripting;
using System.Collections.Generic;
/**
* A counter that increments each time the script is run
**/
public static class Counter
{
	private static Dictionary<string,int> _valueLookUp = new Dictionary<string, int>();
    public static void Run(out int value, string key="uniqueKey")
    {		
			int currentValue;
			_valueLookUp.TryGetValue(key, out currentValue);
			currentValue++;
			_valueLookUp[key] = currentValue++;
			value = currentValue;
    }
}
