using System;
using Scripting;

public static class MatchMonth
{
	
	public enum Month
	{
	    January = 1,
	    February = 2,
	    March = 3,
	    April = 4,
	    May = 5,
	    June = 6,
	    July = 7,
	    August = 8,
	    September = 9,
	    October = 10,
	    November = 11,
	    December = 12
	}
	
    public static void Run(
		DateTime now, 
		bool January, 
		bool February, 
		bool March, 
		bool April, 
		bool May, 
		bool June, 
		bool July, 
		bool August, 
		bool September, 
		bool October, 
		bool November, 
		bool December, 
		out bool match, 
		out string about)
    {        
		match = (
			January   && now.Month == (int)Month.January   ||
			February  && now.Month == (int)Month.February  ||
			March     && now.Month == (int)Month.March     ||
			April     && now.Month == (int)Month.April     ||
			May       && now.Month == (int)Month.May       ||
			June      && now.Month == (int)Month.June      ||
			July      && now.Month == (int)Month.July      ||
			August    && now.Month == (int)Month.August    ||
			September && now.Month == (int)Month.September ||
			October   && now.Month == (int)Month.October   ||
			November  && now.Month == (int)Month.November  ||
			December  && now.Month == (int)Month.December 
		);
		
		
		about=now.ToString("Now: MM/dd/yy");
		about += "\n" + "Current Month: " + now.ToString("MMMM");
		about += "\n" + "Match: " + match.ToString();
		about += "\n\n" + "--- Selected Months ---";
		if(!(January || February || March || April || May || June || July || August || September || October || November || December )){
			about += "\n" + "None";
		}
		else{
			if(January)   about += "\n" + "January";
			if(February)  about += "\n" + "February";
			if(March)     about += "\n" + "March";
			if(April)     about += "\n" + "April";
			if(May)       about += "\n" + "May";
			if(June)      about += "\n" + "June";
			if(August)    about += "\n" + "August";
			if(September) about += "\n" + "September";
			if(October)   about += "\n" + "October";
			if(November)  about += "\n" + "November";
			if(December)  about += "\n" + "December";
			if(July)      about += "\n" + "July";
			if(July)      about += "\n" + "July";
			
		}
    }
}
