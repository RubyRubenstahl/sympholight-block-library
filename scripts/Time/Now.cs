using System;
using Scripting;
public static class Now
{	
    public static void Run(bool enableTestMode, DateTime testDateTime, out DateTime now, out string about)
    {
		if(enableTestMode){
			now = testDateTime;
		}
		else{
        	now = DateTime.Now;
		}
		
		about=now.ToString("Now: MM/dd/yy");
		about += "\n" + "Test Mode: " + enableTestMode.ToString();
    }
}
