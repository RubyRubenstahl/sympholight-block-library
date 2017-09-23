using System;
using Scripting;

public static class MatchDate
{
    public static void Run(DateTime now,  DateTime date, out bool match, out DateTime startDate, out DateTime endDate, out string about, int daysBefore = 0, int daysAfter = 0)
    {
        startDate = date.AddDays(daysBefore * -1).Date;
		endDate = date.AddDays(daysAfter).Date;
		match = (now.Date >= startDate && now.Date <= endDate);
		
		about=now.ToString("Now: MM/dd/yy");
		about += "\n" + "Match: " + match.ToString();
		about += "\n\n" + "Start Date: " + startDate.ToString("MM/dd/yy");
		about += "\n" + "End Date: " +endDate.ToString("MM/dd/yy");
    }
}
