using System;
using Scripting;

public static class MatchDayOfWeek
{
    public static void Run(DateTime now, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, bool Sunday, out bool match, out string about)
    {
        DayOfWeek today = now.DayOfWeek;
		match = (
			Sunday    && today == DayOfWeek.Sunday    ||
			Monday    && today == DayOfWeek.Monday    ||
			Tuesday   && today == DayOfWeek.Tuesday   ||
			Wednesday && today == DayOfWeek.Wednesday ||
			Thursday  && today == DayOfWeek.Thursday  ||
			Friday    && today == DayOfWeek.Friday    ||
			Saturday  && today == DayOfWeek.Saturday
		);
		
		about=now.ToString("Now: MM/dd/yy");
		about += "\n" + "Current Day: " + now.ToString("dddd");
		about += "\n" + "Match: " + match.ToString();
		about += "\n\n" + "--- Selected Days ---";
		if(!(Sunday || Monday || Tuesday || Wednesday || Thursday || Friday || Saturday)){
			about += "\n" + "None";
		}
		else{
			if(Monday)    about += "\n" + "Monday";
			if(Tuesday)   about += "\n" + "Tuesday";
			if(Wednesday) about += "\n" + "Wednesday";
			if(Thursday)  about += "\n" + "Thursday";
			if(Friday)    about += "\n" + "Friday";
			if(Saturday)  about += "\n" + "Saturday";
			if(Sunday)    about += "\n" + "Sunday";
		}
    }
}
