using System;
using System.Collections.Generic;
using Scripting;
 
public  class LimitedIncrement {
	private static Dictionary<string,double> _valueLookUp = new Dictionary<string, double>();
	 
	public static void Run(out double value, double increment, string key="uniqueKey", double sensitivity=1, double max=100, bool wrapValue=false){
			double currentValue = 0;
			_valueLookUp.TryGetValue(key, out currentValue);

			currentValue = currentValue + (increment * sensitivity);
			if(wrapValue){
				currentValue = wrap(currentValue, max);
			}
			else{
				currentValue = clamp(currentValue, max);
			}
			_valueLookUp[key] = currentValue;
			value = currentValue;
		}
           
		public static double wrap(double value, double max){
			if(value<0) return value + max;
			if(value>max) return value - max;
			return value;
		}

		public static double clamp(double value, double max){
			if(value<0) return 0;
			if(value>max) return max;
			return value;              
		}
}