using System;
using Scripting;

public static class MatchTime
{
    public static void Run(DateTime now, DateTime time, double offsetMinutes, out bool match, out DateTime triggerTime, out string about)
    {
        DateTime testTime = time.AddMinutes(offsetMinutes);
		match = (now.Hour == testTime.Hour) && (now.Minute == testTime.Minute);
		about = "Trigger Time: "  + testTime.ToString("h:mm tt");
		triggerTime = testTime;
    }
}
