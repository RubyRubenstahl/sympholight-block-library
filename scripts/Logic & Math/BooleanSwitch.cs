using System;
using Scripting;
using System.Collections.Generic;
/**
* Switch between true & false
**/
public static class BooleanSwitch
{
	
	private static Dictionary<string,int> offset = new Dictionary<string, int>();
    public static void Run(out bool value, string key="uniqueKey")
    {
		int currentOffset;
		offset.TryGetValue(key, out currentOffset);
		currentOffset++;
		offset[key] = currentOffset;

		value = ((currentOffset % 2)==0) ; 
		Logger.Info(value.ToString());
    }
}
