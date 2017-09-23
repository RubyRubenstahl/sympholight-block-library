using System;
using Scripting;

public static class DateRange
{
	public struct DateComponents{
		public Nullable<int> month;
		public Nullable<int> day;
		public Nullable<int> year;
	}
	
	public static void Run(out bool match, out string about, DateTime now, string startDate="1/1", string endDate = "12/31")
    {

		int currentYear = now.Year;
		
		try{
			DateComponents startDateComponents = parseDate(startDate);
			DateComponents endDateComponents = parseDate(endDate);
			
			if(startDateComponents.year == null ^ endDateComponents.year == null){
				throw new Exception("Start & end date styles must match (MM/DD or MM/DD/YY)");
			}
			
			// If only the month & day are defined, set the start year to the current year
			if(startDateComponents.year == null){
				startDateComponents.year = currentYear;
				
				if(endDateComponents.month < startDateComponents.month && now.Month < startDateComponents.month){
					startDateComponents.year = currentYear -1;
				}
			}
			
			// If only the month & day are defined and the end date is before the start date
			if(endDateComponents.year == null){
				endDateComponents.year = currentYear;
				if(endDateComponents.month < startDateComponents.month){
					endDateComponents.year = startDateComponents.year + 1;
				}
				
				if(endDateComponents.month == startDateComponents.month &&
					endDateComponents.day < startDateComponents.day){
					endDateComponents.year = startDateComponents.year + 1;
				}
			}
			
			match = isBetween(now, startDateComponents, endDateComponents);
			
			about=now.ToString("Now: MM/dd/yy");
			about += "\nMatch: " + match.ToString();
			about += "\n\n--- Caluclated Range ---";
			about += "\n  Start: " + formatDateComponents(startDateComponents);
			about += "\n  End: " + formatDateComponents(endDateComponents);

			
		}
		catch(Exception e){
			about = "INVALID CONFIGURATION: \n\n" + e.Message;
			about += "\n\n" + "Valid date formats are MM/DD or MM/DD/YY";
			match = false;
		}
    }
	
	
	private static bool isBetween(DateTime now, DateComponents startDateComponents, DateComponents endDateComponents){
		
		DateTime startDate = toDateTime(startDateComponents).Date;
		DateTime endDate = toDateTime(endDateComponents).Date;
		
		return now.Date >= startDate && now.Date <= endDate;
	}

	private static DateTime toDateTime(DateComponents date){
		return new DateTime((int)date.year, (int)date.month, (int)date.day);
	}
	
	private static string formatDateComponents(DateComponents date){
		return string.Format("{0}/{1}/{2}", date.month.ToString(), date.day.ToString(), date.year==null ? "**" : date.year.ToString());
	}
	
	private static DateComponents parseDate(string date){
		string[] components = date.Split('/');
		if(components.Length<2 || components.Length > 3){
			throw new Exception(string.Format("Date string {0} is invalid", date));
		}
		
		DateComponents result;
		result.month = (Nullable<int>)Convert.ToInt16(components[0]);
		result.day = (Nullable<int>)Convert.ToInt16(components[1]);
		result.year = (components.Length == 3) ? (Nullable<int>)Convert.ToInt16(components[2]) : null;
		
		if(result.month<1 || result.month > 12){
			throw new Exception(string.Format("Month value is invalid: {0}", date));
		};
		
		if(result.day<1 || result.day > 31){
			throw new Exception(string.Format("Day value is invalid: {0}", date));
		};
		
		if(result.year !=null && result.year < 0){
			throw new Exception(string.Format("Year value is invalid: {0}", date));
		}
		
		if(result.year !=null && result.year < 100){
			result.year += 2000;
		}
		
		return result;
	}
}
