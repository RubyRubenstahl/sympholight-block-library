using System;
using Scripting;
using System.Collections.Generic;

// Uses modified code from https://github.com/martinjw/Holiday/
// https://github.com/martinjw/Holiday/blob/master/src/PublicHoliday/USAPublicHoliday.cs

public static class USHolidays
{
    public static void Run(
		DateTime now, 
		out DateTime ChristmasDate,
		out DateTime ChristmasEveDate,
		out DateTime EasterDate,
		out DateTime FourthOfJulyDate,
		out DateTime HalloweenDate,
		out DateTime LaborDayDate,
		out DateTime MemorialDayDate,
		out DateTime MLKdayDate,
		out DateTime MothersDayDate,
		out DateTime NewYearsDayDate,
		out DateTime NewYearsEveDate,
		out DateTime PresidentsDayDate,
		out DateTime ThanksgivingDate,
		out DateTime ValentinesDate,
		out DateTime VeteransDayDate,
		out bool isChristmas, 
		out bool isEaster, 
		out bool isChristmasEve, 
		out bool isFourthOfJuly,
		out bool isHalloween,
		out bool isLaborDay,
		out bool isMemorialDay, 
		out bool isMLKday,
		out bool isMothersDay,
		out bool isNewYearsDay,
		out bool isNewYearsEve,
		out bool isPresidentsDay,
		out bool isThanksgiving, 
		out bool isValentines,
		out bool isVeteransDay
	)	
    {
        int year = now.Year;
		ThanksgivingDate = getThanksgivingDate(year);
		isThanksgiving = datesMatch(now, ThanksgivingDate);
		
		EasterDate = HolidayCalculator.GetEaster(year);
		isEaster = datesMatch(now, EasterDate);
		
		MemorialDayDate = getMemorialDayDate(year);
		isMemorialDay = datesMatch(now, MemorialDayDate);
		
		ValentinesDate = new DateTime(year, 2, 14);
		isValentines = datesMatch(now, ValentinesDate);
		
		ChristmasDate = new DateTime(year, 12, 25);
		isChristmas = datesMatch(now, ChristmasDate);
		
		ChristmasEveDate = new DateTime(year, 12, 24);
		isChristmasEve = datesMatch(now, ChristmasEveDate);
		
		LaborDayDate = getLaborDayDate(year);
		isLaborDay = datesMatch(now, LaborDayDate);
		
		MLKdayDate = getMLKdate(year);
		isMLKday = datesMatch(now, MLKdayDate);
		
		PresidentsDayDate = getPresidentsDayDate(year);
		isPresidentsDay = datesMatch(now, PresidentsDayDate);
		
		FourthOfJulyDate = new DateTime(year, 7, 4);
		isFourthOfJuly = datesMatch(now, FourthOfJulyDate);
		
		NewYearsDayDate = new DateTime(year, 1, 1);
		isNewYearsDay = datesMatch(now, NewYearsDayDate);
		
		NewYearsEveDate = new DateTime(year, 12, 31);
		isNewYearsEve = datesMatch(now, NewYearsEveDate);
		
		VeteransDayDate = new DateTime(year, 11, 11);
		isVeteransDay = datesMatch(now, VeteransDayDate);
		
		HalloweenDate = new DateTime(year, 10, 31);
		isHalloween = datesMatch(now, HalloweenDate);
		
		MothersDayDate = getMothersDayDate(year);
		isMothersDay = datesMatch(now, MothersDayDate);
    }
	
	public static bool datesMatch(DateTime date1, DateTime date2){
		return DateTime.Compare(date1.Date, date2.Date) == 0;
	}
	
    public static DateTime getThanksgivingDate(int year)
    {
        var hol = new DateTime(year, 11, 22);
        while (hol.DayOfWeek != DayOfWeek.Thursday)
        {
            hol = hol.AddDays(1);
        }
        return hol;
    }
	
	
	public static DateTime getMemorialDayDate(int year){
           var hol = new DateTime(year, 5, 25);
           return HolidayCalculator.FindFirstMonday(hol);
	}
	
	public static DateTime getLaborDayDate(int year){
	        var hol = new DateTime(year, 9, 1);
	        return HolidayCalculator.FindFirstMonday(hol);
	}
	
	
	public static DateTime getMLKdate(int year){
		    var hol = new DateTime(year, 1, 15);
            return HolidayCalculator.FindFirstMonday(hol);
	}
	
	public static DateTime getPresidentsDayDate(int year){
			var hol = new DateTime(year, 2, 15);
            return HolidayCalculator.FindFirstMonday(hol);
	}
	
	public static DateTime getMothersDayDate(int year){
		var hol = new DateTime(year, 5, 1);
		return HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Sunday, 2);
	}

}




static class HolidayCalculator
{
    /// <summary>
    /// Work out the date for Easter Sunday for specified year
    /// </summary>
    /// <param name="year">The year as an integer</param>
    /// <returns>Returns a datetime of Easter Sunday.</returns>
    public static DateTime GetEaster(int year)
    {
        //should be
        //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

        //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html
        var g = year % 19;
        var c = year / 100;
        var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
        var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
        var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
        var p = i - j;
        var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
        var easterMonth = 3 + (p + 26) / 30;

        return new DateTime(year, easterMonth, easterDay);
    }

    public static DateTime FixWeekend(DateTime hol)
    {
        if (hol.DayOfWeek == DayOfWeek.Sunday)
            hol = hol.AddDays(1);
        else if (hol.DayOfWeek == DayOfWeek.Saturday)
            hol = hol.AddDays(2);
        return hol;
    }

    public static DateTime FindOccurrenceOfDayOfWeek(DateTime hol, DayOfWeek day, short occurance)
    {
        while (hol.DayOfWeek != day)
            hol = hol.AddDays(1);

        hol = hol.AddDays(7 * (occurance - 1));

        return hol;
    }

    public static DateTime FindNearestDayOfWeek(DateTime hol, DayOfWeek day)
    {
        int advance = 0;
        while (((int)hol.DayOfWeek + advance) % 7 != (int)day)
            advance++;

        if (advance > 3)
            return hol.AddDays(advance - 7);
        else return hol.AddDays(advance);
    }

    public static DateTime FindFirstMonday(DateTime hol)
    {
        return FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 1);
    }

    public static DateTime FindPrevious(DateTime hol, DayOfWeek day)
    {
        while (hol.DayOfWeek != day)
            hol = hol.AddDays(-1);

        return hol;
    }

    public static DateTime FindNext(DateTime hol, DayOfWeek day)
    {
        while (hol.DayOfWeek != day)
            hol = hol.AddDays(1);

        return hol;
    }
}
