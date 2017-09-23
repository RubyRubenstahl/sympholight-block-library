using System;
using Scripting;

public static class Clock
{
    public static void Run(
			DateTime now,
			out int hour_24h, out int hour_12h, out int minute, out int second, 
			out double hourAngle, out double minuteAngle, out double secondAngle, 
			out string formattedDateTime,
			out string about,
			string dateTimeFormat = "h:m"
		)
    {
		
        hour_24h = now.Hour;
		hour_12h = Convert.ToInt32( now.ToString("hh"));
		
		minute = now.Minute;
		second = now.Second;
		hourAngle =  (double)(hour_12h) / 12.0 * 360.0;
		minuteAngle = (double)(minute) / 60.0 * 360.0;
		secondAngle = (double)(second) / 60.0 * 360.0;
		
		formattedDateTime = now.ToString(dateTimeFormat);
		
		about = now.ToString("Now: MM/dd/yy");
		about += "\n" + "Formmated Date/Time: " + formattedDateTime;
		
		about += "\n\n --- Time Componentns ---";
		about += "\n" + "Hour (24h): " + hour_24h.ToString();
		about += "\n" + "Hour (12h): " + hour_12h.ToString();
		about += "\n" + "Minute: " + minute.ToString();
		about += "\n" + "Second: " + second.ToString();
		
		about += "\n\n --- Clock Angles ---";
		about += "\n" + "Hour: " + hourAngle.ToString() + "°";
		about += "\n" + "Minute: " + minuteAngle.ToString() + "°";
		about += "\n" + "Second: " + secondAngle.ToString() + "°";
		
		
    }
}
