using System;
using System.Collections.Generic;

namespace BlazorCalendar.Blazor.Models
{
    public class CalendarDay
    {
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsEmpty { get; set; }

        public List<CalendarEvent> Events { get; set; }
    }
}