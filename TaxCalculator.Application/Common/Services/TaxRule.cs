using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Common.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaxCalculator.Application.Common.Services;

public class TaxRule : ITaxRule
{
    public int GetTollFee(DateTime dateTime)
    {
        if (IsTollFreeDate(dateTime)) return 0;

        int hour = dateTime.Hour;
        int minute = dateTime.Minute;

        if (hour == 6 && minute <= 29) return 8;
        if (hour == 6 && minute <= 59) return 13;
        if (hour == 7) return 18;
        if (hour == 8 && minute <= 29) return 13;
        if (hour >= 8 && hour <= 14 && minute <= 59) return 8;
        if (hour == 15 && minute <= 29) return 13;
        if (hour == 15 || hour == 16) return 18;
        if (hour == 17) return 13;
        if (hour == 18 && minute <= 29) return 8;

        return 0;
    }

    public bool IsTollFreeDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
        if (date.Month == 7) return true;
        if (IsPublicHoliday(date)) return true;

        return false;
    }
    private bool IsPublicHoliday(DateTime date)
    {
        // لیست تعطیلات رسمی
        var publicHolidays = new List<DateTime>
    {
        new DateTime(2013, 1, 1),  
        new DateTime(2013, 3, 28),  
        new DateTime(2013, 3, 29), 
        new DateTime(2013, 4, 1),   
        new DateTime(2013, 4, 30), 
        new DateTime(2013, 5, 1),  
        new DateTime(2013, 5, 9),  
        new DateTime(2013, 6, 6),  
        new DateTime(2013, 6, 21), 
        new DateTime(2013, 12, 24),
        new DateTime(2013, 12, 25), 
        new DateTime(2013, 12, 26), 
        new DateTime(2013, 12, 31) 
    };
        return publicHolidays.Contains(date.Date);
    }
}