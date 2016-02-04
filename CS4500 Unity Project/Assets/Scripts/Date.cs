using UnityEngine;
using System.Collections;

/**
 * Class representing a three-part date. Used mostly for sorting Opportunity s.
 */
public class Date
{
	public int year;
	public int month;
	public int day;
	
	// Empty constructor.
	public Date() {
		this.year = 0;
		this.month = 0;
		this.day = 0;
	}
	
	// Constructor.
	public Date (int year, int month, int day)
	{
		this.year = year;
		this.month = month;
		this.day = day;
	}
	
	// Returns the current Date.
	public static Date get_today() {
		System.DateTime now = System.DateTime.Now;
		return new Date(now.Year, now.Month, now.Day);
	}
	
	/************* OPERATORS AND OVERRIDES *****************/
	public static Date operator - (Date d1, Date d2)
	{
		return new Date (d1.year - d2.year, d1.month - d2.month, d1.day - d2.day);
	}
	
	public static bool operator > (Date d1, Date d2) {
		if (d1.year > d2.year) return true;
		else if (d1.year < d2.year) return false;
		else if (d1.month > d2.month) return true;
		else if (d1.month < d2.month) return false;
		else if (d1.day > d2.day) return true;
		else return false;
	}
	
	public static bool operator < (Date d1, Date d2) {
		if (d1 == null) return true;
		if (d2 == null) return false;
		if (d1.year < d2.year) return true;
		else if (d1.year > d2.year) return false;
		else if (d1.month < d2.month) return true;
		else if (d1.month > d2.month) return false;
		else if (d1.day < d2.day) return true;
		else return false;
	}
	
	public override string ToString() {
		return year.ToString() + "/" + month + "/" + day;
	}
}
